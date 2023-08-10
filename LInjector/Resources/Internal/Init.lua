 --[[
 *
 * ░▒█░░░░▀█▀░█▀▀▄░░░▀░█▀▀░█▀▄░▀█▀░▄▀▀▄░█▀▀▄░░░▒█▀▀▀░█░▒█░█▀▀▄░█▀▄░▀█▀░░▀░░▄▀▀▄░█▀▀▄░█▀▀░░
 * ░▒█░░░░▒█░░█░▒█░░░█░█▀▀░█░░░░█░░█░░█░█▄▄▀░░░▒█▀▀░░█░▒█░█░▒█░█░░░░█░░░█▀░█░░█░█░▒█░▀▀▄░░
 * ░▒█▄▄█░▄█▄░▀░░▀░█▄█░▀▀▀░▀▀▀░░▀░░░▀▀░░▀░▀▀░░░▒█░░░░░▀▀▀░▀░░▀░▀▀▀░░▀░░▀▀▀░░▀▀░░▀░░▀░▀▀▀░░
 *
 * Created by depso (https://github.com/depthso)
 *
 *
 * ]]

local LINJECTOR_VERSION = "10.08.2023"

if linjector then
	script:Remove()
	return 
end

loadstring(game:HttpGet("https://api.irisapp.ca/Scripts/IrisInstanceProtect.lua"))() -- credit to iris (this is for protect_gui and unprotect_gui)
local hash = loadstring(game:HttpGet("https://raw.githubusercontent.com/zzerexx/scripts/main/HashLib.lua"), "HashLib")()
local hashlibalgs = {"sha1", "sha224"}
local hashalgs = {
	"md5", "sha1", "sha224", "sha256", "sha384", "sha512", "sha3-256", "sha3-384", "sha3-512",
	"md2", "haval", "ripemd128", "ripemd160", "ripemd256", "ripemd320"
}
local consolecolor, colors = "white", {
	['black'] = "black",
	['blue'] = "blue",
	['green'] = "green",
	['cyan'] = "cyan",
	['red'] = "red",
	['magenta'] = "magenta",
	['brown'] = "white",
	['light_gray'] = "white",
	['dark_gray'] = "white",
	['light_blue'] = "blue",
	['light_green'] = "green",
	['light_cyan'] = "cyan",
	['light_red'] = "red",
	['light_magenta'] = "magenta",
	['yellow'] = "yellow",
}
local ciphers = {
	['aes-cbc'] = "CBC",
	['aes-cfb'] = "CFB",
	['aes-ctr'] = "CTR",
	['aes-ofb'] = "OFB",
	['aes-gcm'] = "GCM"
	-- no aes-eax, bf-cbc, bf-cfb, bf-ofb
}
local specialinfo = {
	MeshPart = {
		"PhysicsData",
		"InitialSize"
	},
	UnionOperation = {
		"AssetId",
		"ChildData",
		"FormFactor",
		"InitialSize",
		"MeshData",
		"PhysicsData"
	},
	Terrain = {
		"SmoothGrid",
		"MaterialColors"
	}
}
getgenv().Drawing.Fonts = {
	['UI'] = 0,
	['System'] = 0,
	['Plex'] = 1,
	['Monospace'] = 2
}
local oldmt = getrawmetatable(game)
local none = newcclosure(function() end, "none")

local function define(name, value, parent)
	local lol = (typeof(value) == "function" and islclosure(value) and newcclosure(value, name)) or value
	if parent ~= nil then
		parent[name] = lol
		return
	end
	getgenv()[name] = lol
end
local function connection(conn, enabled)
	for _,v in next, getconnections(conn) do
		if enabled then
			v:Enable()
		else
			v:Disable()
		end
	end
end

	--[[ -- unused since its useless, but its cool ig
	local oldd;oldd = hookfunction(Drawing.new, function(class) -- same drawing object functionality
		local obj = oldd(class)
		local t = {
			['__OBJECT'] = obj,
			['__OBJECT_EXISTS'] = true
		}
		local function remove()
			obj:Remove()
			t.__OBJECT_EXISTS = false
		end
		function t:Remove()
			remove()
		end
		function t:Destroy()
			remove()
		end

		setmetatable(t, {
			__index = function(_, i)
				if t.__OBJECT_EXISTS then
					if i == ("__OBJECT" or "__OBJECT_EXISTS") then
						return t
					else
						return obj[i]
					end
				end
			end,
			__newindex = function(_, i, v)
				if t.__OBJECT_EXISTS then
					obj[i] = v
				end
			end
		})
		return t
	end)
	]]

local disassemble = loadstring(game:HttpGet("https://raw.githubusercontent.com/TheSeaweedMonster/Luau/main/decompile.lua"), "Disassembler")()
define("disassemble", disassemble)

do -- secure_call things
	local oldt;oldt = hookfunction(getrenv().debug.traceback, function(lol) -- prevent debug.traceback detection
		local traceback = oldt(lol)
		if checkcaller() then
			local a = traceback:split("\n")
			return string.format("%s\n%s\n", a[1], a[3])
		end
		return traceback
	end)
	local oldi;oldi = hookfunction(getrenv().debug.info, function(lvl, a) -- prevent debug.info detection
		if checkcaller() then
			return oldi(3, a)
		end
		return oldi(lvl, a)
	end)
end

xpcall(function()
	hookfunction(getexecutorname, function()
		return "LInjector UWP", LINJECTOR_VERSION
	end)
	hookfunction(identifyexecutor, function()
		return "LInjector UWP", LINJECTOR_VERSION
	end)
end, function()
	define(identifyexecutor, function()
		return "LInjector UWP", LINJECTOR_VERSION
	end)
	define(getexecutorname, function()
		return "LInjector UWP", LINJECTOR_VERSION
	end)
end)

local oldg;oldg = hookfunction(getconnections, function(signal)
	local a = oldg(signal)
	for i,v in next, a do
		local thread = v.Thread
		if thread then
			a[i].State = thread -- scriptware uses .Thread instead of .State
		end

		local object = v.Object
		if object then
			a[i].__OBJECT = a[i] -- for 'isconnectionenabled' function
		end
	end
	return a
end)

define("linjector", true)

define("syn_io_read", readfile)
define("syn_io_write", writefile)
define("syn_io_append", appendfile)
define("syn_io_makefolder", makefolder)
define("syn_io_listdir", listfiles)
define("syn_io_isfile", isfile)
define("syn_io_isfolder", isfolder)
define("syn_io_delfile", delfile)
define("syn_io_delfolder", delfolder)


define("syn_mouse1click", mouse1click)
define("syn_mouse1press", mouse1press)
define("syn_mouse1release", mouse1release)

define("syn_mouse2click", mouse2click)
define("syn_mouse2press", mouse2press)
define("syn_mouse2release", mouse2release)

define("syn_mousescroll", mousescroll)
define("syn_mousemoverel", mousemoverel)
define("syn_mousemoveabs", mousemoveabs)

define("syn_keypress", keypress)
define("syn_keyrelease", keyrelease)


define("syn_crypt_encrypt", crypt.encrypt)
define("syn_crypt_decrypt", crypt.decrypt)
define("syn_crypt_b64_encode", crypt.base64encode)
define("syn_crypt_b64_decode", crypt.base64decode)
define("syn_crypt_random", crypt.generatekey)
define("syn_crypt_hash", function(data)
	return crypt.hash(data, "sha384")
end)
define("syn_crypt_derive", function(_, len)
	return crypt.generatebytes(len)
end)



define("syn_getgenv", getgenv)
define("syn_getrenv", getrenv)
define("syn_getsenv", getsenv)
define("syn_getmenv", getmenv)
define("syn_getreg", getreg)
define("syn_getgc", getgc)
define("syn_getinstances", getinstances)
define("syn_context_get", getidentity)
define("syn_context_set", setidentity)
define("syn_setfflag", setfflag)
define("syn_dumpstring", dumpstring)
define("syn_islclosure", islclosure)
define("syn_checkcaller", checkcaller)
define("syn_clipboard_set", setclipboard)
define("syn_newcclosure", newcclosure)
define("syn_decompile", decompile)
define("syn_getloadedmodules", getloadedmodules)
define("syn_getcallingscript", getcallingscript)
define("syn_isactive", isrbxactive)
define("syn_websocket_connect", function(a)
	assert(typeof(a) == "string", string.format("bad argument #1 to 'syn_websocket_connect' (string expected, got %s)", typeof(a)))
	return WebSocket.connect(a)
end)
define("syn_websocket_close", function(a)
	assert(a.OnMessage ~= nil, "ws connection expected")
	a:Close()
end)



define("is_synapse_function", isourclosure)
define("is_protosmasher_closure", isourclosure)
define("is_protosmasher_caller", checkcaller)
define("is_lclosure", islclosure)
define("iswindowactive", isrbxactive)
define("validfgwindow", isrbxactive)
define("getprops", getproperties)
define("gethiddenprop", gethiddenproperty)
define("gethiddenprops", gethiddenproperties)
define("sethiddenprop", sethiddenproperty)
define("getpcdprop", getpcd)
define("getsynasset", getcustomasset)
define("htgetf", function(url)
	assert(typeof(url) == "string", string.format("bad argument #1 to 'htgetf' (string expected, got %s)", typeof(url)))
	return game:HttpGetAsync(url)
end)
define("gbmt", function()
	return {
		__index = oldmt.__index,
		__namecall = oldmt.__namecall,
		__tostring = oldmt.__tostring
	}
end)
define("getpropvalue", function(obj, prop)
	assert(typeof(obj) == "Instance", string.format("bad argument #1 to 'getpropvalue' (Instance expected, got %s)", typeof(obj)))
	assert(typeof(prop) == "string", string.format("bad argument #2 to 'getpropvalue' (string expected, got %s)", typeof(prop)))
	return cloneref(obj)[prop]
end)
define("setpropvalue", function(obj, prop, value)
	assert(typeof(obj) == "Instance", string.format("bad argument #1 to 'setpropvalue' (Instance expected, got %s)", typeof(obj)))
	assert(typeof(prop) == "string", string.format("bad argument #2 to 'setpropvalue' (string expected, got %s)", typeof(prop)))
	obj = cloneref(obj)
	local conn1 = obj:GetPropertyChangedSignal(prop)
	local conn2 = obj.Changed
	connection(conn1, false)
	connection(conn2, false)
	obj[prop] = value
	connection(conn1, true)
	connection(conn2, true)
end)
define("getstates", getallthreads) -- scriptware uses the term 'thread' instead of 'state'
define("getstateenv", gettenv)
define("getinstancefromstate", getscriptfromthread)
define("is_redirection_enabled", function()
	return false
end)
define("getspecialinfo", function(obj)
	assert(typeof(obj) == "Instance", string.format("bad argument #1 to 'getspecialinfo' (Instance expected, got %s)", typeof(obj)))
	local info = specialinfo[obj.ClassName]
	local props = {}
	if info then
		for _,v in next, info do
			props[v] = gethiddenproperty(obj, v)
		end
	end
	return props
end)
define("getvirtualinputmanager", function()
	return cloneref(game:GetService("VirtualInputManager")) -- not exactly sure whats different about this 're-implementation'
end)
define("isconnectionenabled", function(object)
	assert(rawget(object, "__OBJECT") ~= nil, "bad argument #1 to 'isconnectionenabled' (synapse signal expected)")
	return rawget(object, "Enabled")
end)
define("isactor", function()
	return false
end)
define("checkparallel", function()
	local suc = pcall(task.synchronize)
	if suc then
		task.desynchronize()
		print("desynced")
		return true
	end
	return false
end)



define("get_calling_script", getcallingscript)
define("get_instances", getinstances)
define("get_nil_instances", getnilinstances)
define("get_scripts", getscripts)
define("get_loaded_modules", getloadedmodules)

-- they dont do anything
local funcs = {
	"getlocal",
	"getlocals",
	"setlocal",
	"getcallstack",
	"isuntouched",
	"setuntouched",
	"setupvaluename",
	"XPROTECT",
	"getpointerfromstate",
	"setnonreplicatedproperty",
	"readbinarystring"
}
for _,v in next, funcs do
	define(v, none)
end


local t = {}

define("cache_replace", cache.replace, t)
define("cache_invalidate", cache.invalidate, t)
define("is_cached", cache.iscached, t)

define("get_thread_identity", getidentity, t)
define("set_thread_identity", setidentity, t)

define("write_clipboard", setclipboard, t)
define("queue_on_teleport", queue_on_teleport, t)

define("protect_gui", ProtectInstance, t) -- credit to iris
define("unprotect_gui", UnProtectInstance, t)

	--[[local Protected = {}
	define("protect_gui", function(obj)
		assert(typeof(obj) == "Instance", "bad argument #1 to 'protect_gui' (Instance expected, got "..typeof(obj)..")")
		local p = obj.parent
		if p then
			Protected[obj] = p
		end

		obj.Parent = gethui()
		task.spawn(function()
			local conn;conn = obj.AncestryChanged:Connect(function(_, p)
				-- most scripts parent it to coregui right after protecting (cuz thats how ur supposed to use it)
				task.wait()
				obj.Parent = gethui()
				Protected[obj] = p -- save the original parent for unprotecting
			end)
			task.wait(2)
			conn:Disconnect()
		end)
	end, t)
	define("unprotect_gui", function(obj)
		assert(typeof(obj) == "Instance", "bad argument #1 to 'protect_gui' (Instance expected, got "..typeof(obj)..")")
		local p = Protected[obj]
		if p then
			obj.Parent = p
		end
	end, t)]]

define("is_beta", function()
	return false
end, t)

local c = crypt
local crypt = {}
define("encrypt", c.encrypt, crypt)
define("decrypt", c.decrypt, crypt)
define("hash", function(data)
	return c.hash(data, "sha384"):lower()
end, crypt)
define("derive", function(_, len)
	return c.generatebytes(len)
end, t)
define("random", c.generatebytes, crypt)

local base64 = {}
define("encode", c.base64encode, base64)
define("decode", c.base64decode, base64)
define("base64", base64, crypt)

local lz4 = {}
define("compress", lz4compress, lz4)
--define("decompress", lz4decompress, lz4)
define("lz4", lz4, crypt)

local custom = {}
define("encrypt", function(cipher, data, key, nonce)
	cipher = cipher:lower()
	if cipher:find("eax") or cipher:find("bf") then
		return ""
	end
	return crypt.custom_encrypt(data, key, nonce, ciphers[cipher:gsub("_", "-")])
end, custom)
define("decrypt", function(cipher, data, key, nonce)
	cipher = cipher:lower()
	if cipher:find("eax") or cipher:find("bf") then
		return ""
	end
	return crypt.custom_decrypt(data, key, nonce, ciphers[cipher:gsub("_", "-")])
end, custom)
define("hash", function(alg, data)
	alg = alg:lower():gsub("_", "-")

	local HashLib = table.find(hashlibalgs, alg)
	local SwLib = table.find(hashalgs, alg)
	assert(HashLib or SwLib, "bad argument #1 to 'hash' (non-existant hash algorithm)")
	if HashLib then -- using hash lib for 'sha1' and 'sha224' cuz they return the same thing when using the built-in hash function
		return hash[alg:gsub("-", "_")](data)
	end
	if SwLib then
		return c.hash(data, alg):lower()
	end
end, custom)
define("custom", custom, crypt)
define("crypt", crypt, t)
define("crypto", crypt, t)

define("websocket", WebSocket, t)

define("secure_call", function(func, env, ...)
	local functype = typeof(func) 
	local envtype = typeof(env)
	assert(functype == "function", string.format("bad argument #1 to 'secure_call' (function expected, got %s)", functype))
	assert(envtype == "Instance", string.format("bad argument #2 to 'secure_call' (Instance expected, got %s)", envtype))
	local envclass = env.ClassName
	assert(envclass == "LocalScript" or envclass == "ModuleScript", string.format("bad argument #2 to 'secure_call' (LocalScript or ModuleScript expected, got %s)", envclass))
	local _, fenv = xpcall(function()
		return getsenv(env)
	end, function()
		return getfenv(func)
	end)
	return coroutine.wrap(function(...)
		setidentity(2)
		setfenv(0, fenv)
		setfenv(1, fenv)
		return func(...)
	end)(...)
end, t)

local actors = {}
local on_actor_created = Instance.new("BindableEvent")
game.DescendantAdded:Connect(function(v)
	if v:IsA("Actor") then
		on_actor_created:Fire(v)
		table.insert(actors, v)
	end
end)
for _,v in next, game:GetDescendants() do
	if v:IsA("Actor") then
		table.insert(actors, v)
	end
end
define("on_actor_created", on_actor_created.Event, t)
define("getactors", function()
	return actors
end)
define("run_on_actor", function(actor, code) -- This does not actually run on the actor's state (waiting for valyse implementation)
	assert(typeof(actor) == "Instance", ("bad argument #1 to 'run_on_actor' (Instance expected, got %s)"):format(typeof(actor)))
	assert(actor.ClassName == "Actor", ("bad argument #1 to 'run_on_actor' (Actor expected, got %s)"):format(actor.ClassName))
	assert(typeof(code) == "string", ("bad argument #2 to 'run_on_actor' (string expected, got %s)"):format(typeof(code)))

	loadstring(code, "run_on_actor")()
end, t)

local comm_channels = {}
define("create_comm_channel", function()
	local id = game:GetService("HttpService"):GenerateGUID(false)
	local bindable = Instance.new("BindableEvent")
	local object = newproxy(true)
	getmetatable(object).__index = function(_, i)
		if i == "bro" then
			return bindable
		end
	end
	local event = setmetatable({
		__OBJECT = object
	}, {
		__type = "SynSignal",
		__index = function(self, i)
			if i == "Connect" then
				return function(_, callback)
					print(callback)
					return self.__OBJECT.bro.Event:Connect(callback)
				end
			elseif i == "Fire" then
				return function(_, ...)
					return self.__OBJECT.bro:Fire(...)
				end
			end
		end,
		__newindex = function()
			error("SynSignal table is readonly.")
		end
	})
	comm_channels[id] = event
	return id, event
end, t)
define("get_comm_channel", function(id)
	local channel = comm_channels[id]
	if not channel then
		error("bad argument #1 to 'get_comm_channel' (invalid communication channel)")
	end
	return channel
end, t)

local unavailable = {
	"create_secure_function",
	"run_secure_function",
	"run_secure_lua",
	"secrun"
}
for _,v in next, unavailable do
	define(v, none, t)
end

define("syn", t)

setreadonly(syn, true)

define("ror", bit.rrotate, bit)
define("rol", bit.lrotate, bit)
define("tohex", function(a)
	return tonumber(string.format("%08x", a % 4294967296))
end, bit)
