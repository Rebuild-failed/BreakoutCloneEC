local skynet = require "skynet"
local gateserver = require "snax.gateserver"

local connection={} -- fd -> connection : { fd , ip }
local handler={}

function handler.connect(fd, addr)
    local c={
        fd=fd,
        ip=addr,
    }
    connection[fd]=c
    print("ip:"..addr.."连接")
    gateserver.openclient(fd)
    skynet.send(match,"lua","match",fd,addr);
end
function handler.message(fd, msg, sz)
    print("接收到消息"..fd)
end
function handler.disconnect(fd)
    print(fd.."-断开连接")
end
function handler.command(cmd, source, ...)
local f = assert(CMD[cmd])
return f(source, ...)
end
gateserver.start(handler)