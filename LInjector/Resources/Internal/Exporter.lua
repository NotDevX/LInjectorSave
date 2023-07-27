if d_exportedfunctions then
	script:Remove()
	return
end
getgenv()["d_exportedfunctions"] = true

repeat wait'' until (LInjector and LInjector.loaded) == true

if not writefile then
    return
end

local ToExport = {}

local function SendFunction(text)
    writefile("LINJECTOR/LINJECTOR.li", text)
end

function ToExport.messagebox(title,text)
    SendFunction(('showmsg|||%s|||%s'):format(text, title))
end

function ToExport.setDiscordRPC(status)
    SendFunction(('setrpc|||%s'):format(status))
end
function ToExport.rconsoleprint(...)
	local args = table.pack(...)
	local String = ""
	
	for i = 1, args.n do
		String = ("%s %s"):format(String, tostring(args[i]))
	end
	
	SendFunction('rprintconsole|||'.. String)
end
ToExport.rconsoleinfo = ToExport.rconsoleprint
ToExport.rconsolewarn = ToExport.rconsoleprint
ToExport.rconsoleerr = ToExport.rconsoleprint
ToExport.rprintconsole = ToExport.rconsoleprint
ToExport.rconsolename = function() end
ToExport.printconsole = ToExport.rconsoleprint

function ToExport.toclipboard(...)
	local args = table.pack(...)
	local String = ""
	
	for i = 1, args.n do
		String = ("%s %s"):format(String, tostring(args[i]))
	end
	
	SendFunction('toClipboard|||'.. String)
end
ToExport.setclipboard = ToExport.toclipboard
ToExport.set_clipboard = ToExport.toclipboard
ToExport.Clipboard = {}
ToExport.Clipboard.set = ToExport.toclipboard

function ToExport.rconsoleclose()
	SendFunction('closeconsole|||')
end
function ToExport.rconsoleshow()
	SendFunction('showconsole|||')
end


for n in pairs(ToExport) do 
    getgenv()[n] = ToExport[n] 
end

local MarketplaceService = game:GetService('MarketplaceService')
local localplayer = game:GetService'Players'.LocalPlayer

SendFunction(('welcome|||%s|||%s'):format(localplayer.Name, MarketplaceService:GetProductInfo(game.PlaceId).Name))

-- messagebox("hi", "hello from linjector!")
