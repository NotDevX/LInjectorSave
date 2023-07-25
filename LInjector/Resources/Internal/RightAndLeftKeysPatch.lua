if depso_keypatcher then
	return 
end

getgenv()["depso_keypatcher"] = true

local convertFrom = "RightControl"
local convertTo = "LeftControl"

local old = getrawmetatable(Enum.KeyCode)
setrawmetatable(Enum.KeyCode, {
   __index = function(self, key)
       if key == convertFrom then
           return old.__index(self, convertTo)
       end
       return old.__index(self, key)
   end
})