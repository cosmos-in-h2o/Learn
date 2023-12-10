local wezterm=require('wezterm')
local config={}

config.color_scheme='AdventureTime'

--是否为windows
if "\\" == package.config:sub(1,1) then
    --默认程序
    config.default_prog = { 'powershell' }
end
config.font=wezterm.font('JetBrainsMono NF Medium')
config.font_size=18.0
return config
