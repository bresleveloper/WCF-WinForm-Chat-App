using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public static class ChatDAL
    {
        public static ChatUser[] GetUsersList()
        {
            DAL.exec("[dbo].[StartChat]");
            return DAL.select<ChatUser>("SELECT * FROM [datatormim].[dbo].[ChatUser]");
        }
    }
}
