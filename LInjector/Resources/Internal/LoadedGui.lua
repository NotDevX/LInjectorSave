repeat wait() until game:IsLoaded() == true
repeat wait() until (LInjector and LInjector.loaded) == true

if LInjector.GuiLoaded == true then 
	script:Remove()
	return
end
LInjector.GuiLoaded = true

local LInjNotification = Instance.new("ScreenGui")
local holder_1 = Instance.new("Frame")
local UIListLayout_1 = Instance.new("UIListLayout")
local container_1 = Instance.new("Frame")
local main_1 = Instance.new("Frame")
local Top_1 = Instance.new("TextLabel")
local UICorner_1 = Instance.new("UICorner")
local LExIcon_1 = Instance.new("ImageLabel")
local UIPadding_1 = Instance.new("UIPadding")
local UICorner_2 = Instance.new("UICorner")
local UIGradient_1 = Instance.new("UIGradient")
local UIStroke_1 = Instance.new("UIStroke")
local UIGradient_2 = Instance.new("UIGradient")
local information_1 = Instance.new("TextLabel")
local UIPadding_2 = Instance.new("UIPadding")
local UIPadding_3 = Instance.new("UIPadding")

-- Properties:
LInjNotification.Name = "LInjNotification"
LInjNotification.Parent = game.CoreGui
LInjNotification.DisplayOrder = 2147483647

holder_1.Name = "holder"
holder_1.Parent = LInjNotification
holder_1.AnchorPoint = Vector2.new(0.5, 0.5)
holder_1.BackgroundColor3 = Color3.fromRGB(255,255,255)
holder_1.BackgroundTransparency = 1
holder_1.BorderColor3 = Color3.fromRGB(0,0,0)
holder_1.BorderSizePixel = 0
holder_1.Position = UDim2.new(0.5, 0,0.5, 0)
holder_1.Size = UDim2.new(1, 0,1, 0)

UIListLayout_1.Parent = holder_1
UIListLayout_1.HorizontalAlignment = Enum.HorizontalAlignment.Right
UIListLayout_1.SortOrder = Enum.SortOrder.LayoutOrder
UIListLayout_1.VerticalAlignment = Enum.VerticalAlignment.Bottom

container_1.Name = "container"
container_1.Parent = holder_1
container_1.AnchorPoint = Vector2.new(0.5, 0.5)
container_1.BackgroundColor3 = Color3.fromRGB(255,255,255)
container_1.BackgroundTransparency = 1
container_1.BorderColor3 = Color3.fromRGB(0,0,0)
container_1.BorderSizePixel = 0
container_1.Position = UDim2.new(0.907002985, 0,0.891910732, 0)
container_1.Size = UDim2.new(0, 250,0, 155)

main_1.Name = "main"
main_1.Parent = container_1
main_1.AnchorPoint = Vector2.new(0.5, 0.5)
main_1.AutomaticSize = Enum.AutomaticSize.XY
main_1.BackgroundColor3 = Color3.fromRGB(255,255,255)
main_1.BorderColor3 = Color3.fromRGB(0,0,0)
main_1.BorderSizePixel = 0
main_1.Position = UDim2.new(2, -100,1, -70)
main_1.Size = UDim2.new(0, 215,0, 100)

Top_1.Name = "Top"
Top_1.Parent = main_1
Top_1.AnchorPoint = Vector2.new(0.5, 0.5)
Top_1.BackgroundColor3 = Color3.fromRGB(21,16,45)
Top_1.BorderColor3 = Color3.fromRGB(27,42,53)
Top_1.Position = UDim2.new(0.5, 0,0.119999997, 0)
Top_1.Size = UDim2.new(0, 215,0, 25)
Top_1.Font = Enum.Font.Gotham
Top_1.Text = "LInjector"
Top_1.TextColor3 = Color3.fromRGB(255,255,255)
Top_1.TextSize = 14
Top_1.TextXAlignment = Enum.TextXAlignment.Left

UICorner_1.Parent = Top_1
UICorner_1.CornerRadius = UDim.new(0,4)

LExIcon_1.Name = "LExIcon"
LExIcon_1.Parent = Top_1
LExIcon_1.AnchorPoint = Vector2.new(0.5, 0.5)
LExIcon_1.BackgroundColor3 = Color3.fromRGB(255,255,255)
LExIcon_1.BackgroundTransparency = 1
LExIcon_1.BorderColor3 = Color3.fromRGB(27,42,53)
LExIcon_1.Position = UDim2.new(-0.12110053, 0,0.5, 0)
LExIcon_1.Size = UDim2.new(0, 21,0, 21)
LExIcon_1.Image = "rbxassetid://14149221913"

UIPadding_1.Parent = Top_1
UIPadding_1.PaddingLeft = UDim.new(0,40)

UICorner_2.Parent = main_1
UICorner_2.CornerRadius = UDim.new(0,4)

UIGradient_1.Parent = main_1
UIGradient_1.Color = ColorSequence.new{ColorSequenceKeypoint.new(0, Color3.fromRGB(20, 20, 46)), ColorSequenceKeypoint.new(1, Color3.fromRGB(38, 31, 54))}
UIGradient_1.Rotation = 90

UIStroke_1.Parent = main_1
UIStroke_1.ApplyStrokeMode = Enum.ApplyStrokeMode.Border
UIStroke_1.Color = Color3.fromRGB(255,255,255)
UIStroke_1.Thickness = 2

UIGradient_2.Parent = UIStroke_1
UIGradient_2.Color = ColorSequence.new{ColorSequenceKeypoint.new(0, Color3.fromRGB(107, 39, 122)), ColorSequenceKeypoint.new(1, Color3.fromRGB(84, 144, 213))}

information_1.Name = "information"
information_1.Parent = main_1
information_1.AnchorPoint = Vector2.new(0.5, 0.5)
information_1.BackgroundColor3 = Color3.fromRGB(255,255,255)
information_1.BackgroundTransparency = 1
information_1.BorderColor3 = Color3.fromRGB(0,0,0)
information_1.BorderSizePixel = 0
information_1.Position = UDim2.new(0.49999997, 0,0.610000014, 0)
information_1.Size = UDim2.new(0, 214,0, 78)
information_1.Font = Enum.Font.Unknown
information_1.Text = ""
information_1.TextColor3 = Color3.fromRGB(255,255,255)
information_1.TextSize = 14
information_1.TextWrapped = true
information_1.TextXAlignment = Enum.TextXAlignment.Left
information_1.TextYAlignment = Enum.TextYAlignment.Top

UIPadding_2.Parent = information_1
UIPadding_2.PaddingLeft = UDim.new(0,10)
UIPadding_2.PaddingRight = UDim.new(0,2)
UIPadding_2.PaddingTop = UDim.new(0,10)

UIPadding_3.Parent = container_1
UIPadding_3.PaddingRight = UDim.new(0,20)

-- Scripts:

local function SAOKCV_fake_script() -- LInjNotification.script 
	local script = Instance.new('LocalScript', LInjNotification)

	--------------------------------------------------

	-- repeat wait() until game:IsLoaded() == true

	-------------------------------------------------

	local function TypeWrite (Obj, Text)
		for I = 1, #Text, 1 do
			Obj.Text = string.sub (Text, 1, I)
			wait ()
		end
	end

	-------------------------------------------------

	local TweenService = game:GetService('TweenService')

	local Frame = main_1
	local BorderGradient = UIGradient_2
	local InformationBox = information_1

	-------------------------------------------------

	local TWEEN_LENGTH = 0.5
	local function Hide()
		for _, Child in next, Frame.Parent : GetDescendants () do 
			if Child : IsA ("TextLabel") then
				TweenService : Create(Child, TweenInfo.new (TWEEN_LENGTH), {TextTransparency = 1, TextStrokeTransparency = 1}) : Play ()
			elseif Child : IsA ("Frame") then
				TweenService : Create (Child, TweenInfo.new (TWEEN_LENGTH), {BackgroundTransparency = 1}) : Play ()
			elseif Child : IsA ("ImageLabel") then
				TweenService : Create (Child, TweenInfo.new(TWEEN_LENGTH), {ImageTransparency = 1}) : Play ()
			elseif Child : IsA ("UIStroke") then
				TweenService : Create (Child, TweenInfo.new(TWEEN_LENGTH), {Transparency = 1}) : Play ()
			end
		end
	end

	local TweenInf = TweenInfo.new (2.5, Enum.EasingStyle.Sine, Enum.EasingDirection.InOut, -1, true, 0)
	local TweenRt = TweenService : Create (BorderGradient, TweenInf, {Rotation = 360})

	local TweenSwitchFrame = TweenInfo.new(0.7, Enum.EasingStyle.Sine, Enum.EasingDirection.InOut, 0, false, 0)
	local ShowFrame = TweenService : Create (Frame, TweenSwitchFrame, {Position = UDim2.new(1,  -100, 1, -70)})
	local HideFrame = TweenService : Create (Frame, TweenSwitchFrame, {Position = UDim2.new(2,  -100, 1, -70)})

	-------------------------------------------------

	TweenRt : Play ()

	ShowFrame : Play ()

	ShowFrame.Completed : Wait ()

	TypeWrite(InformationBox, "All functions were loaded successfully.\nEnjoy LInjector!")

	wait(3)

	HideFrame : Play ()
end
coroutine.wrap(SAOKCV_fake_script)()
