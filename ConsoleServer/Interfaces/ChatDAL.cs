using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public static ChatDetails[] GetChatDetailsForUsers(ChatUser a, ChatUser b)
        {
            string query = @"SELECT *  FROM [datatormim].[dbo].[ChatDetail] 
                            where (FromUserAd = @userA_ADName or FromUserAd = @userB_ADName)
                            and 
                                (ToUserAd = @userA_ADName or ToUserAd = @userB_ADName) ";

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@userA_ADName", a.UserAd));
            sqlParams.Add(new SqlParameter("@userB_ADName", b.UserAd));

            return DAL.select<ChatDetails>(query, sqlParams.ToArray());
        }
    }
}
