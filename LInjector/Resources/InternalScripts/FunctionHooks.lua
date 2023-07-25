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

if DepsoExploit then
	return 
end

LILibs = {}

function Export(NameCaller, SubRoutine)
	getgenv()[NameCaller] = SubRoutine
end

---------

Export("identifyexecutor", function()
	return "Depso's exploit UWP", "v20.07.2023"
end)

Export("getexecutorname", function()
	return "Depso's exploit", "v20.07.2023"
end)

Export("DepsoExploit", true)

function LILibs.Hello_World( ) -- LI_Hello_World
	return print("Hello world!")
end
function LILibs.copy(String)
	local SetClipBoard = setclipboard or toclipboard or set_clipboard or (Clipboard and Clipboard.set)
	if SetClipBoard then
		SetClipBoard(String)
		return true
	else
		return "Unable to set clipboard"
	end
end
function LILibs.getRoot(CharacterModel)
	local rootPart = CharacterModel:FindFirstChild('HumanoidRootPart') or CharacterModel:FindFirstChild('Torso') or CharacterModel:FindFirstChild('UpperTorso')
	return rootPart
end
function LILibs.Isr15(CharacterModel)
	if CharacterModel:FindFirstChildOfClass('Humanoid').RigType == Enum.HumanoidRigType.R15 then
		return true
	end
	return false
end
function LILibs.isNumber(str)
	return tonumber(str) ~= nil or str == 'inf'
end
function LILibs.isString(String)
	return type(String) == "string"
end
function LILibs.createThread(FunctionAddress)
	xpcall(function()
		coroutine.resume(coroutine.create(FunctionAddress))
	end, function(ErrorFallBack)
		warn(ErrorFallBack)
	end)
end
function LILibs.checkVar(Var, Var2)
	if not Var then
		return Var2
	end
	return Var
end

for FunctionName in pairs(LILibs) do 
	getgenv()["d_"..FunctionName] = LILibs[FunctionName] 
end

wait(5)

print(identifyexecutor(), "hooked!")

pcall(function()
	setfpscap(99999)
end)