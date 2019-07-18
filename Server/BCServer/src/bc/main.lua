local skynet = require "skynet"

local max_client = 64
local gate
skynet.start(function()
    skynet.error("Server start")
    if not skynet.getenv "daemon" then
        local console = skynet.newservice("console")
    end
    skynet.newservice("debug_console",8000)
    gate=skynet.newservice("bcgate");
    local config={
        address ="0.0.0.0",
        port=1997,
        maxclient = max_client,
        nodelay = true,
    }
    skynet.call(gate, "lua", "open" , config)
    skynet.exit()
end)