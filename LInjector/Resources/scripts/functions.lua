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

LILibs = {}

function Export(NameCaller, SubRoutine)
    getgenv()[NameCaller] = SubRoutine
end
function DebugOut(String)
    warn(("%s: %s"):format("LInjector",String))
end

Export("identifyexecutor", function()
    return "LInjector UWP"
end)

Export("getexecutorname", function()
	return "LInjector"
end)

Export("LInjector", true)

function LILibs.Hello_World( ) -- LI_Hello_World
    return print("Hello world!")
end
function LILibs.copy(String)
    local SetClipBoard = setclipboard or toclipboard or set_clipboard or (Clipboard and Clipboard.set)
	if SetClipBoard then
        SetClipBoard(String)
        return true
    else
        DebugOut("Unable to set clipboard")
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
	if tonumber(str) ~= nil or str == 'inf' then
		return true
	end
    return false
end

for FunctionName in pairs(LILibs) do 
    getgenv()["LI_"..FunctionName] = LILibs[FunctionName] 
end

loadstring(game:HttpGet("https://github.com/ItzzExcel/LInjectorRedistributables/raw/main/injectionscreen.lua", true))