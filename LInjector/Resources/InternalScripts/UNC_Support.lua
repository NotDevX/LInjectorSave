if d_cryptloaded then
	return 
end

function Export(NameCaller, SubRoutine)
	getgenv()[NameCaller] = SubRoutine
end

Export("d_cryptloaded", true)

depso_crypt = {}

--crypt = {}

local b = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/'

function isString(String)
	return type(String) == "string"
end
function isNumber(Number)
	return type(Number) == "number"
end
function checkVar(Var, Var2)
	if not Var then
		return Var2
	end
	return Var
end

depso_crypt.hexdecode = function(hex)
	return (hex:gsub("^0x",""):gsub("%x%x", function(digits) return string.char(tonumber(digits, 16)) end))
end
depso_crypt.hexencode = function(str)
	return "0x" .. string.gsub((string.gsub(str, ".", function(char) return string.format("%2x", char:byte()) end)):upper(), " ", 0)
end
trimleft = function(sString, iLeft)
	if (not iLeft) then
		return sString 
	end
	return string.sub(sString, (iLeft + 1))
end
depso_crypt.tobytes = function(sString)
	local aBytes = {}
	string.gsub(sString, ".", function(sChar) 
		table.insert(aBytes, string.byte(sChar)) 
	end)
	return aBytes
end
left = function(sString, iLeft)
	if (not iLeft) then
		return "" 
	end
	local sLeft = string.sub(sString, 1, iLeft)
	return sLeft
end
right = function(sString, iRight)
	if (not iRight) then
		return "" 
	end
	local iLen = string.len(sString)
	local sRight = string.sub(sString, (iLen - iRight) + 1, iLen)
	return sRight
end
loopindex = function(num, target)
	local f = num / target
	if (target > num or f < 1) then
		return { 0, num }
	end
	local fits = string.gsub(f, "%.(.*)", "")
	local rem = num - (fits * target)
	return { fits, rem }
end;

depso_crypt.base64encode = function(str)
	str = tostring(str)
	local floor = math.floor
	local char = string.char
	local nOut = 0
	local alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"
	local strLen = #str
	local out = table.create(math.ceil(strLen / 0.75))

	-- 3 octets become 4 hextets
	for i = 1, strLen - 2, 3 do
		local b1, b2, b3 = str:byte(i, i + 3)
		local word = b3 + b2 * 256 + b1 * 256 * 256

		local h4 = word % 64 + 1
		word = floor(word / 64)
		local h3 = word % 64 + 1
		word = floor(word / 64)
		local h2 = word % 64 + 1
		word = floor(word / 64)
		local h1 = word % 64 + 1

		out[nOut + 1] = alphabet:sub(h1, h1)
		out[nOut + 2] = alphabet:sub(h2, h2)
		out[nOut + 3] = alphabet:sub(h3, h3)
		out[nOut + 4] = alphabet:sub(h4, h4)
		nOut = nOut + 4
	end

	local remainder = strLen % 3

	if remainder == 2 then
		-- 16 input bits -> 3 hextets (2 full, 1 partial)
		local b1, b2 = str:byte(-2, -1)
		-- partial is 4 bits long, leaving 2 bits of zero padding ->
		-- offset = 4
		local word = b2 * 4 + b1 * 4 * 256

		local h3 = word % 64 + 1
		word = floor(word / 64)
		local h2 = word % 64 + 1
		word = floor(word / 64)
		local h1 = word % 64 + 1

		out[nOut + 1] = alphabet:sub(h1, h1)
		out[nOut + 2] = alphabet:sub(h2, h2)
		out[nOut + 3] = alphabet:sub(h3, h3)
		out[nOut + 4] = "="
	elseif remainder == 1 then
		-- 8 input bits -> 2 hextets (2 full, 1 partial)
		local b1 = str:byte(-1, -1)
		-- partial is 2 bits long, leaving 4 bits of zero padding ->
		-- offset = 16
		local word = b1 * 16

		local h2 = word % 64 + 1
		word = floor(word / 64)
		local h1 = word % 64 + 1

		out[nOut + 1] = alphabet:sub(h1, h1)
		out[nOut + 2] = alphabet:sub(h2, h2)
		out[nOut + 3] = "="
		out[nOut + 4] = "="
	end
	-- if the remainder is 0, then no work is needed

	return table.concat(out, "")
end;

depso_crypt.base64decode = function(str)
	local floor = math.floor
	local char = string.char
	local nOut = 0
	local alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"
	local strLen = #str
	local out = table.create(math.ceil(strLen * 0.75))
	local acc = 0
	local nAcc = 0

	local alphabetLut = {}
	for i = 1, #alphabet do
		alphabetLut[alphabet:sub(i, i)] = i - 1
	end

	-- 4 hextets become 3 octets
	for i = 1, strLen do
		local ch = str:sub(i, i)
		local byte = alphabetLut[ch]
		if byte then
			acc = acc * 64 + byte
			nAcc += 1
		end

		if nAcc == 4 then
			local b3 = acc % 256
			acc = floor(acc / 256)
			local b2 = acc % 256
			acc = floor(acc / 256)
			local b1 = acc % 256

			out[nOut + 1] = char(b1)
			out[nOut + 2] = char(b2)
			out[nOut + 3] = char(b3)
			nOut += 3
			nAcc = 0
			acc = 0
		end
	end

	if nAcc == 3 then
		-- 3 hextets -> 16 bit output
		acc *= 64
		acc = floor(acc / 256)
		local b2 = acc % 256
		acc = floor(acc / 256)
		local b1 = acc % 256

		out[nOut + 1] = char(b1)
		out[nOut + 2] = char(b2)
	elseif nAcc == 2 then
		-- 2 hextets -> 8 bit output
		acc *= 64
		acc = floor(acc / 256)
		acc *= 64
		acc = floor(acc / 256)
		local b1 = acc % 256

		out[nOut + 1] = char(b1)
	elseif nAcc == 1 then
		error("Base64 has invalid length")
	end

	return table.concat(out, "")
end;

depso_crypt.base64 = {}

depso_crypt.base64.encode = depso_crypt.base64encode 
depso_crypt.base64.decode = depso_crypt.base64decode
depso_crypt.base64_encode = depso_crypt.base64encode 
depso_crypt.base64_decode = depso_crypt.base64decode

depso_crypt.aBinaryCharacters = { 'A', 'B', 'C', 'D', 'E', 'F', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }
depso_crypt.aBinaryIndexes = { ["A"] = 1, ["B"] = 2, ["C"] = 3, ["D"] = 4, ["E"] = 5, ["F"] = 6, ["0"] = 7, ["1"] = 8, ["2"] = 9, ["3"] = 10, ["4"] = 11, ["5"] = 12, ["6"] = 13, ["7"] = 14, ["8"] = 15, ["9"] = 16 }

depso_crypt.aCharSets = {
	["set_255"] = {},
	["set_253"] = {},
	["set_alpha"] = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
	["set_alphanum"] = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T' },
	["set_binary"] = { 'A', 'B', 'C', 'D', 'E', 'F', 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
	["set_binarylow"] = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 'a', 'b', 'c', 'd', 'e', 'f' },
	["set_special"] = { '!', '"', '§', '$', '%', '&', '/', '(', ')', '=', '?', '[', ']', '{', '}', '²', '³', "'", '*', '+', '~', '#', ',', ';', '.', ':', '-', '_', '<', '>', '|', '´', '`', '^', '°', '@' },
	["set_control"] = {},
	["set_print"] = {},
	["set_extended"] = {},
}

CALG_SCA_255 = 0x001
CALG_SCA_253 = 0x002
CALG_SCA_ALPHA = 0x003
CALG_SCA_ALPHANUM = 0x004
CALG_SCA_BINARY = 0x005
CALG_SCA_BINARYLOW = 0x006
CALG_SCA_SPECIAL = 0x007
CALG_SCA_CONTROL = 0x008
CALG_SCA_PRINT = 0x009
CALG_SCA_EXTENDED = 0x00A
STR_NOCOUNT = 2

depso_crypt.DEFAULT_CRYPTING_ALGORITHM = CALG_SCA_255

local iIndex_1, iIndex_2, iIndex_3 = 1, 1, 1
for i = 1, 255 do
	local sChar = string.char(i)
	depso_crypt.aCharSets["set_255"][i] = sChar
	if (i <= 253) then
		depso_crypt.aCharSets["set_253"][i] = sChar 
	end
	if (i <= 31 or i == 127) then
		depso_crypt.aCharSets["set_control"][iIndex_1] = sChar
		iIndex_1 = iIndex_1 + 1
	end
	if (i > 31 and i < 127) then
		depso_crypt.aCharSets["set_print"][iIndex_2] = sChar
		iIndex_2 = iIndex_2 + 1
	end
	if (i > 127) then
		depso_crypt.aCharSets["set_extended"][iIndex_3] = sChar
		iIndex_3 = iIndex_3 + 1
	end
end

depso_crypt.GetCharSet = function(iSet)
	if (iSet == "CBC") then
		return depso_crypt.aCharSets["set_255"]
	elseif (iSet == CALG_SCA_255) then
		return depso_crypt.aCharSets["set_255"]
	elseif (iSet == CALG_SCA_253) then
		return depso_crypt.aCharSets["set_253"]

	elseif (iSet == CALG_SCA_ALPHA) then
		return depso_crypt.aCharSets["set_alpha"]

	elseif (iSet == CALG_SCA_ALPHANUM) then
		return depso_crypt.aCharSets["set_alphanum"]

	elseif (iSet == CALG_SCA_BINARY) then
		return depso_crypt.aCharSets["set_binary"]

	elseif (iSet == CALG_SCA_BINARYLOW) then
		return depso_crypt.aCharSets["set_binarylow"]

	elseif (iSet == CALG_SCA_CONTROL) then
		return depso_crypt.aCharSets["set_control"]

	elseif (iSet == CALG_SCA_PRINT) then
		return depso_crypt.aCharSets["set_print"]

	elseif (iSet == CALG_SCA_SPECIAL) then
		return depso_crypt.aCharSets["set_special"]
	end
end

depso_crypt.CharGetIndex = function(sChar)
	local iIndex = (depso_crypt.aCharacterSet[depso_crypt.hexencode(sChar)])
	if (iIndex == 0) then
		return -1 end
	if (not isNumber(iIndex)) then
		return -1 end

	return iIndex - 1
end

depso_crypt.AssignChars = function(aSet)
	depso_crypt.aCharacterSet = {}
	local iCounter = 0
	for i, v in pairs(aSet) do
		iCounter = iCounter + 1
		depso_crypt.aCharacterSet[depso_crypt.hexencode(v)] = iCounter
	end
end

depso_crypt.DestroyChars = function(aSet)
	depso_crypt.aCharacterSet = nil
end

depso_crypt.CalculateKeyValue = function(sKey)
	local iCryptKeyVal = 0
	if (isString(sKey) and not (sKey == "")) then

		---
		local aKeyArray = depso_crypt.tobytes(sKey)
		local aKeyArrayNum = #aKeyArray
		for i = 1, aKeyArrayNum do
			iCryptKeyVal = iCryptKeyVal + aKeyArray[i] + i end
	end
	return iCryptKeyVal + string.len(sKey)
end

depso_crypt.GetBinaryChar = function(iIndex)
	return depso_crypt.aBinaryCharacters[iIndex]
end
depso_crypt.GetBinaryIndex = function(sChar)
	return depso_crypt.aBinaryIndexes[sChar]
end

depso_crypt.decrypt = function(sString, sKey, sKey2, iCharSet2)
	local sKey = checkVar(sKey2, sKey)
	local iCharSet = checkVar(iCharSet, depso_crypt.DEFAULT_CRYPTING_ALGORITHM)

	sString = depso_crypt.base64decode(sString)
	
	local sKey = checkVar(sKey, "")
	local sString = depso_crypt.hexdecode(sString)
	local aString = string.split(sString, "", STR_NOCOUNT)
	local iString = string.len(sString)
	local iCharSet = checkVar(iCharSet, depso_crypt.DEFAULT_CRYPTING_ALGORITHM)
	local aCharSet = depso_crypt.GetCharSet(iCharSet)
	local iCharSetLen = #aCharSet
	if (iCharSetLen < 16) then
		return "-1"
	end

	local iCharsPerLoop = string.len(aCharSet[1])
	local iCryptAdd = 1
	local iCryptAdd_Extra = 1
	iCryptAdd = iCryptAdd + depso_crypt.CalculateKeyValue(sKey)
	local sChar, iCharIndex, iBinaryIndex, ifits, iAdd
	local iMultisetSkip, iMultisetStep = 0, 0
	local sCrypt = ""
	depso_crypt.AssignChars(aCharSet)
	local bStop = false
	for i = 1, iString do
		bStop = false
		iAdd = i
		if (iCharsPerLoop > 1) then
			iAdd = iMultisetStep
			if (i < iMultisetSkip) then 
				bStop = true
			end

			if (not bStop) then
				iMultisetStep = iMultisetStep + 1
				sChar = aString[i]
				for i_add = 1, iCharsPerLoop - 1 do
					sChar = sChar .. aString[i + i_add]
				end
				iMultisetSkip = i + iCharsPerLoop 
			end
		else
			sChar = aString[i]
		end
		if (not bStop) then
			iCryptAdd_Extra = iCryptAdd_Extra + right(iAdd, 2) + right(iAdd, 1) + left(iAdd, 1)
			if (iCryptAdd_Extra > 255) then
				iCryptAdd_Extra = left(iAdd, 2)
			end
			iCharIndex = depso_crypt.CharGetIndex(sChar)
			if (iCharIndex == -1) then
				sCrypt = ""
				break
			end
			iBinaryIndex = (iCharIndex) - (iCryptAdd + iAdd + iCryptAdd_Extra)
			ifits = (iBinaryIndex / iCharSetLen) * -1
			if (string.find(ifits, ".")) then
				ifits = string.match(ifits, "(%d+)")
			end
			if (tonumber(ifits) > 0) then
				iBinaryIndex = iBinaryIndex + iCharSetLen * ifits
			end
			if (iBinaryIndex < 1) then
				iBinaryIndex = iBinaryIndex + iCharSetLen
			end
			if (iBinaryIndex > 16 or iBinaryIndex < 1) then
				depso_crypt.DestroyChars(aCharSet)
				return "-1"
			end

			sCrypt = sCrypt .. depso_crypt.GetBinaryChar(iBinaryIndex)
		end
	end

	depso_crypt.DestroyChars(aCharSet)
	if (string.len(sCrypt) == 0) then
		return "-1"
	end

	sCrypt = "0x" .. sCrypt
	sCrypt = depso_crypt.hexdecode(sCrypt)
	
	return sCrypt
end

depso_crypt.encrypt = function(sString, sKey, sKey2, iCharSet)
	local sKey = checkVar(sKey2, sKey)
	local iCharSet = checkVar(iCharSet, depso_crypt.DEFAULT_CRYPTING_ALGORITHM)

	local sString = depso_crypt.hexencode(sString)
	sString = trimleft(sString, 2)

	local aString = string.split(sString, "")
	local iString = string.len(sString)
	local aCharSet = depso_crypt.GetCharSet(iCharSet)
	local iCharSetLen = #aCharSet
	if (iCharSetLen < 16) then
		return "-1"
	end

	depso_crypt.AssignChars(aCharSet)

	local iCryptAdd = 1
	local iCryptAdd_Extra = 1

	iCryptAdd = iCryptAdd + depso_crypt.CalculateKeyValue(sKey)	local sChar, iBinary, iBinaryAdded, iCharIndex
	local sCrypt = ""

	for i = 1, iString do
		iCryptAdd_Extra = iCryptAdd_Extra + right(i, 2) + right(i, 1) + left(i, 1)
		if (iCryptAdd_Extra > 255) then
			iCryptAdd_Extra = left(i, 2)
		end
		sChar = aString[i]

		iBinary = depso_crypt.GetBinaryIndex(sChar) + 1
		iBinaryAdded = iBinary + (iCryptAdd + i + iCryptAdd_Extra)
		iCharIndex = tonumber(loopindex(iBinaryAdded, iCharSetLen)[2])
		if (iCharIndex == 0) then
			iCharIndex = 1 end		sCrypt = sCrypt .. aCharSet[iCharIndex]
	end	
	
	return depso_crypt.base64encode(depso_crypt.hexencode(sCrypt, 4)), sKey
end

depso_crypt.hash = function(String, algorithm)
	return "Please UNC Test"
end

depso_crypt.generatebytes = function(length)
	local key = ""
	if not length then
		length = 10
	end
	for i = 1, length do
		key = key .. string.char(math.random(33, 125))
	end
	--key = depso_crypt.hexencode(key)
	return depso_crypt.base64encode(key)
end

depso_crypt.generatekey = function(length)
	local final =  ""
	local min, max = ("a"):byte(), ("z"):byte()
	local Nmin, Nmax = ("1"):byte(), ("9"):byte()
	
	if not length or length < 1 then
		length = 32
	end
	
	while wait() do
		final = final .. string.char(math.random(min, max))
		if math.random(1,3) == 2 then
			final = final .. string.char(math.random(Nmin, Nmax))
		end
		
		if #final == length then
			break
		end
	end
	
	return depso_crypt.base64encode(final)
end

local hashalgs = {
	"md5", "sha1", "sha224", "sha256", "sha384", "sha3-224", "sha512", "sha3-256", "sha3-384", "sha3-512",
	"md2", "haval", "ripemd128", "ripemd160", "ripemd256", "ripemd320"
}


	local hash = loadstring(game:HttpGet("https://raw.githubusercontent.com/zzerexx/scripts/main/HashLib.lua"), "HashLib")()
	depso_crypt.hash = function(data, alg) 
		local alg = alg:gsub("_", "-")
		
		print(alg)

		local HashLib = table.find(hashalgs, alg)
		assert(HashLib, "bad argument #1 to 'hash' (non-existant hash algorithm)")
		if HashLib then -- using hash lib for 'sha1' and 'sha224' cuz they return the same thing when using the built-in hash function
			return hash[alg:gsub("-", "_")](data)
		end
		if SwLib then
			return c.hash(data, alg):lower()
		end
	end


wait(1)

Export("crypt", table.clone(depso_crypt))
Export("d_crypt", table.clone(depso_crypt))

Export("getcallbackvalue", function(Instance, Value)

end)

wait(1)

a = depso_crypt.encrypt("Hello", "bozo")
print(a)
b = depso_crypt.decrypt(a, "bozo")
print(b)

print("-----------------------------------")

key = depso_crypt.generatekey()
print(key, " DECODED:", depso_crypt.base64decode(key))


print("-----------------------------------")
local size = math.random(10, 100)
local bytes = depso_crypt.generatebytes(size)
local bytes = depso_crypt.base64decode(bytes)
print(size)
print(bytes)
print(#bytes == size)

key = depso_crypt.generatebytes()
print(key, " DECODED:", depso_crypt.base64decode(key))

