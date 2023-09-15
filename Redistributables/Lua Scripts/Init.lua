 --[[
 *
 * ░▒█░░░░▀█▀░█▀▀▄░░░▀░█▀▀░█▀▄░▀█▀░▄▀▀▄░█▀▀▄░░░▒█▀▀▀░█░▒█░█▀▀▄░█▀▄░▀█▀░░▀░░▄▀▀▄░█▀▀▄░█▀▀░░
 * ░▒█░░░░▒█░░█░▒█░░░█░█▀▀░█░░░░█░░█░░█░█▄▄▀░░░▒█▀▀░░█░▒█░█░▒█░█░░░░█░░░█▀░█░░█░█░▒█░▀▀▄░░
 * ░▒█▄▄█░▄█▄░▀░░▀░█▄█░▀▀▀░▀▀▀░░▀░░░▀▀░░▀░▀▀░░░▒█░░░░░▀▀▀░▀░░▀░▀▀▀░░▀░░▀▀▀░░▀▀░░▀░░▀░▀▀▀░░
 *
 * Written By Depso
 *
 * ]]

local EXPLOIT_NAME = "LInjector"
local EXLPOIT_VERSION = "22.08.2023"

--[[if EXPLOIT_NAME then
	return script:Remove()
end]]--
getgenv()[EXPLOIT_NAME] = true

--- Libraries
local HashIngLibrary = loadstring(game:HttpGet("https://raw.githubusercontent.com/zzerexx/scripts/main/HashLib.lua"))()
local disassemble = loadstring(game:HttpGet("https://raw.githubusercontent.com/TheSeaweedMonster/Luau/main/decompile.lua"))()

local localplayer=game:GetService'Players'.LocalPlayer
-------------

local hashlibalgs = {
	"sha1", "sha224"
}
local hashalgs = {
	"md5", "sha1", "sha224", "sha256", "sha384", "sha512", "sha3-256", "sha3-384", "sha3-512",
	"md2", "haval", "ripemd128", "ripemd160", "ripemd256", "ripemd320"
}
local ciphers = {
	['aes-cbc'] = "CBC",
	['aes-cfb'] = "CFB",
	['aes-ctr'] = "CTR",
	['aes-ofb'] = "OFB",
	['aes-gcm'] = "GCM"
}

STDExport=function(text)
	writefile("LINJECTOR/LINJECTOR.li", text)
end
Export=function(name, value)
	getgenv()[name] = value
end

Export("identifyexecutor", function()
	return EXPLOIT_NAME, EXLPOIT_VERSION
end)
Export("getexecutorname", function()
	return EXPLOIT_NAME, EXLPOIT_VERSION
end)
Export("disassemble", disassemble)


local Oldcrypt = crypt
local NewCrypt = {}

NewCrypt.encrypt = function(cipher, data, key, nonce)
	cipher = cipher:lower()
	if cipher:find("eax") or cipher:find("bf") then
		return ""
	end
	return crypt.custom_encrypt(data, key, nonce, ciphers[cipher:gsub("_", "-")])
end
NewCrypt.decrypt = function(cipher, data, key, nonce)
	cipher = cipher:lower()
	if cipher:find("eax") or cipher:find("bf") then
		return ""
	end
	return crypt.custom_decrypt(data, key, nonce, ciphers[cipher:gsub("_", "-")])
end
NewCrypt.hash = function(alg, data)
	alg = alg:lower():gsub("_", "-")

	local HashLib = table.find(hashlibalgs, alg)
	local SwLib = table.find(hashalgs, alg)
	assert(HashLib or SwLib, "#1 Unknown hash algorithm")

	if HashLib then
		return hash[alg:gsub("-", "_")](data)
	end
	if SwLib then
		return Oldcrypt.hash(data, alg):lower()
	end
end
NewCrypt.derive = function(_, len)
	return Oldcrypt.generatebytes(len)
end
NewCrypt.random = Oldcrypt.generatebytes 
NewCrypt.generatebytes = Oldcrypt.generatebytes

local oldRequest
oldRequest = hookfunction(request, function(Arguments)
    local Headers = Arguments.Headers or {}
    Headers['User-Agent'] = EXPLOIT_NAME
    return oldRequest({
        Url = Arguments.Url,
        Method = Arguments.Method or "GET",
        Headers = Headers,
        Cookies = Arguments.Cookies or {},
        Body = Arguments.Body or ""
    })
end)

Export("custom", NewCrypt)
Export("crypt", NewCrypt)
Export("crypto", NewCrypt)

setreadonly(crypt, true)
setreadonly(crypto, true)
setreadonly(custom, true)

for Name, _ in next, crypt do
	print(Name)
end

local Functions={
	["messagebox"]="showmsg",
	["setDiscordRPC"]="setrpc",
	["rconsoleprint"]="rprintconsole",
	["rconsoleinfo"]="rconsoleinfo",
	["rconsolename"]="rconsolename",
	["rconsolewarn"]="rconsolewarn",
	["rconsoleerr"]="rconsoleerr",
	["toclipboard"]="toClipboard",
	["rconsoleclose"]="closeconsole",
	["rconsoleshow"]="showconsole",
	["rconsoleclear"]="consoleclear",
}

for name, func in pairs(Functions) do
	Export(name,function(...)
		local String, args="",table.pack(...)
		for i=1, args.n do
			String=("%s|||%s"):format(String, tostring(args[i]))
		end
		STDExport(('%s%s'):format(name, String))
	end)
end

Export("rprintconsole",rconsoleprint)
Export("setclipboard",toclipboard)
Export("set_clipboard",toclipboard)
Export("set_clipboard",toclipboard)
Export("Clipboard",{set=toclipboard})

SendFunction(('welcome|||%s|||%s'):format(localplayer.DisplayName, MarketplaceService:GetProductInfo(game.PlaceId).Name))

local LInjNotification=Instance.new("ScreenGui")
local holder_1=Instance.new("Frame")
local UIListLayout_1=Instance.new("UIListLayout")
local container_1=Instance.new("Frame")
local main_1=Instance.new("Frame")
local Top_1=Instance.new("TextLabel")
local UICorner_1=Instance.new("UICorner")
local LExIcon_1=Instance.new("ImageLabel")
local UIPadding_1=Instance.new("UIPadding")
local UICorner_2=Instance.new("UICorner")
local UIGradient_1=Instance.new("UIGradient")
local UIStroke_1=Instance.new("UIStroke")
local UIGradient_2=Instance.new("UIGradient")
local information_1=Instance.new("TextLabel")
local UIPadding_2=Instance.new("UIPadding")
local UIPadding_3=Instance.new("UIPadding")
LInjNotification.Name=crypt.random()
LInjNotification.Parent=game.CoreGui
LInjNotification.DisplayOrder=2147483647
holder_1.Parent=LInjNotification
holder_1.AnchorPoint=Vector2.new(0.5, 0.5)
holder_1.BackgroundColor3=Color3.fromRGB(255,255,255)
holder_1.BackgroundTransparency=1
holder_1.BorderColor3=Color3.fromRGB(0,0,0)
holder_1.BorderSizePixel=0
holder_1.Position=UDim2.new(0.5, 0,0.5, 0)
holder_1.Size=UDim2.new(1, 0,1, 0)
UIListLayout_1.Parent=holder_1
UIListLayout_1.HorizontalAlignment=Enum.HorizontalAlignment.Right
UIListLayout_1.SortOrder=Enum.SortOrder.LayoutOrder
UIListLayout_1.VerticalAlignment=Enum.VerticalAlignment.Bottom
container_1.Parent=holder_1
container_1.AnchorPoint=Vector2.new(0.5, 0.5)
container_1.BackgroundColor3=Color3.fromRGB(255,255,255)
container_1.BackgroundTransparency=1
container_1.BorderColor3=Color3.fromRGB(0,0,0)
container_1.BorderSizePixel=0
container_1.Position=UDim2.new(0.907002985, 0,0.891910732, 0)
container_1.Size=UDim2.new(0, 250,0, 155)
main_1.Parent=container_1
main_1.AnchorPoint=Vector2.new(0.5, 0.5)
main_1.AutomaticSize=Enum.AutomaticSize.XY
main_1.BackgroundColor3=Color3.fromRGB(255,255,255)
main_1.BorderColor3=Color3.fromRGB(0,0,0)
main_1.BorderSizePixel=0
main_1.Position=UDim2.new(2, -100,1, -70)
main_1.Size=UDim2.new(0, 215,0, 100)
Top_1.Parent=main_1
Top_1.AnchorPoint=Vector2.new(0.5, 0.5)
Top_1.BackgroundColor3=Color3.fromRGB(21,16,45)
Top_1.BorderColor3=Color3.fromRGB(27,42,53)
Top_1.Position=UDim2.new(0.5, 0,0.119999997, 0)
Top_1.Size=UDim2.new(0, 215,0, 25)
Top_1.Font=Enum.Font.Gotham
Top_1.Text="LInjector"
Top_1.TextColor3=Color3.fromRGB(255,255,255)
Top_1.TextSize=14
Top_1.TextXAlignment=Enum.TextXAlignment.Left
UICorner_1.Parent=Top_1
UICorner_1.CornerRadius=UDim.new(0,4)
LExIcon_1.Parent=Top_1
LExIcon_1.AnchorPoint=Vector2.new(0.5, 0.5)
LExIcon_1.BackgroundColor3=Color3.fromRGB(255,255,255)
LExIcon_1.BackgroundTransparency=1
LExIcon_1.BorderColor3=Color3.fromRGB(27,42,53)
LExIcon_1.Position=UDim2.new(-0.12110053, 0,0.5, 0)
LExIcon_1.Size=UDim2.new(0, 21,0, 21)
LExIcon_1.Image="rbxassetid://14149221913"
UIPadding_1.Parent=Top_1
UIPadding_1.PaddingLeft=UDim.new(0,40)
UICorner_2.Parent=main_1
UICorner_2.CornerRadius=UDim.new(0,4)
UIGradient_1.Parent=main_1
UIGradient_1.Color=ColorSequence.new{ColorSequenceKeypoint.new(0, Color3.fromRGB(20, 20, 46)), ColorSequenceKeypoint.new(1, Color3.fromRGB(38, 31, 54))}
UIGradient_1.Rotation=90
UIStroke_1.Parent=main_1
UIStroke_1.ApplyStrokeMode=Enum.ApplyStrokeMode.Border
UIStroke_1.Color=Color3.fromRGB(255,255,255)
UIStroke_1.Thickness=2
UIGradient_2.Parent=UIStroke_1
UIGradient_2.Color=ColorSequence.new{ColorSequenceKeypoint.new(0, Color3.fromRGB(107, 39, 122)), ColorSequenceKeypoint.new(1, Color3.fromRGB(84, 144, 213))}
information_1.Parent=main_1
information_1.AnchorPoint=Vector2.new(0.5, 0.5)
information_1.BackgroundColor3=Color3.fromRGB(255,255,255)
information_1.BackgroundTransparency=1
information_1.BorderColor3=Color3.fromRGB(0,0,0)
information_1.BorderSizePixel=0
information_1.Position=UDim2.new(0.49999997, 0,0.610000014, 0)
information_1.Size=UDim2.new(0, 214,0, 78)
information_1.Text=""
information_1.Font=Enum.Font.Montserrat
information_1.TextColor3=Color3.fromRGB(255,255,255)
information_1.TextSize=12
information_1.TextWrapped=true
information_1.TextXAlignment=Enum.TextXAlignment.Left
information_1.TextYAlignment=Enum.TextYAlignment.Top
UIPadding_2.Parent=information_1
UIPadding_2.PaddingLeft=UDim.new(0,10)
UIPadding_2.PaddingRight=UDim.new(0,2)
UIPadding_2.PaddingTop=UDim.new(0,10)
UIPadding_3.Parent=container_1
UIPadding_3.PaddingRight=UDim.new(0,20)

local function SAOKCV_fake_script() -- LInjNotification.scriptz
	local scriptz=Instance.new('LocalScript', LInjNotification)
	scriptz.Name=crypt.random()
	
	local function TypeWrite (Obj, Text)
		for I=1, #Text, 1 do
			Obj.Text=string.sub (Text, 1, I)
			wait()
		end
	end
	
	local Frame=main_1
	local BorderGradient=UIGradient_2
	local InformationBox=information_1

	local TWEEN_LENGTH=0.5
	local function Hide()
		for _, Child in next, Frame.Parent:GetDescendants() do 
			if Child:IsA ("TextLabel") then
				TweenService:Create(Child, TweenInfo.new (TWEEN_LENGTH), {TextTransparency=1, TextStrokeTransparency=1}):Play()
			elseif Child:IsA ("Frame") then
				TweenService:Create (Child, TweenInfo.new (TWEEN_LENGTH), {BackgroundTransparency=1}):Play()
			elseif Child:IsA ("ImageLabel") then
				TweenService:Create (Child, TweenInfo.new(TWEEN_LENGTH), {ImageTransparency=1}):Play()
			elseif Child:IsA ("UIStroke") then
				TweenService:Create (Child, TweenInfo.new(TWEEN_LENGTH), {Transparency=1}):Play()
			end
		end
	end

	local TweenInf=TweenInfo.new (2.5, Enum.EasingStyle.Sine, Enum.EasingDirection.InOut, -1, true, 0)
	local TweenRt=TweenService:Create (BorderGradient, TweenInf, {Rotation=360})

	local TweenSwitchFrame=TweenInfo.new(0.7, Enum.EasingStyle.Sine, Enum.EasingDirection.InOut, 0, false, 0)
	local ShowFrame=TweenService:Create (Frame, TweenSwitchFrame, {Position=UDim2.new(1,  -100, 1, -70)})
	local HideFrame=TweenService:Create (Frame, TweenSwitchFrame, {Position=UDim2.new(2,  -100, 1, -70)})
	
	TweenRt:Play()
	ShowFrame:Play()
	ShowFrame.Completed:Wait()

	TypeWrite(InformationBox, "All functions were loaded successfully.\n\nEnjoy LInjector!")

	wait(3)

	HideFrame:Play()
	HideFrame.Completed:Wait()
	LInjNotification:Remove()
end
coroutine.wrap(SAOKCV_fake_script)()
