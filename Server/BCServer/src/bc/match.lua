local skynet = require "skynet"
local log = require "log"

local match={}

function match.match(fd,addr)
    print("ip:"..addr.."已加入匹配队列")
end
skynet.start(function ()
    skynet.dispatch()
end)