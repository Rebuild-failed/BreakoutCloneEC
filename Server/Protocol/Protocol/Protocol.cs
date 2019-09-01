using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protocol
{
    public class Protocol
    {
        public enum MATCH
        {
            MATCH_START = 1000,
            MATCH_SUCCEED = 1001,
        }
        public enum Game
        {
            GAME_READY =2001,
            GAME_START =2002,
            GAME_OVER =2003,
        }
    }
}
