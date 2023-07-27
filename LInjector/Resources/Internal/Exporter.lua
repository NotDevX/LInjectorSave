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

for n in pairs(ToExport) do 
    getgenv()[n] = ToExport[n] 
end

local MarketplaceService = game:GetService('MarketplaceService')
local localplayer = game:GetService'Players'.LocalPlayer

SendFunction(('welcome|||%s|||%s'):format(localplayer.Name, MarketplaceService:GetProductInfo(game.PlaceId).Name))

-- messagebox("hi", "hello from linjector!")
