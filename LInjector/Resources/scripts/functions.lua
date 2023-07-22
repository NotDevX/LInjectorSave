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

if LInjector then
	return 
end

LILibs = {}

local upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
local lowerCase = "abcdefghijklmnopqrstuvwxyz"
local numbers = "0123456789"
local symbols = "!@#$%&()*+-,./ñ:;<=>?^[]{}"

local characterSet = upperCase .. lowerCase .. numbers .. symbols

function Export(NameCaller, SubRoutine)
    getgenv()[NameCaller] = SubRoutine
end

Export("RandomString", function(keyLength)
    local Randomized = ""

    for i = 1, keyLength do
        local rand = math.random(#characterSet)
        Randomized = Randomized .. string.sub(characterSet, rand, rand)
    end

    return Randomized
end)

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
	if tonumber(str) ~= nil or str == 'inf' then
		return true
	end
    return false
end

for FunctionName in pairs(LILibs) do 
    getgenv()["LI_"..FunctionName] = LILibs[FunctionName] 
end

loadstring(game:HttpGet("https://github.com/ItzzExcel/LInjectorRedistributables/raw/main/injectionscreen.lua", true))()