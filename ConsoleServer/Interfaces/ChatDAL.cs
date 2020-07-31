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
            ChatUser[] users = DAL.select<ChatUser>("SELECT * FROM [datatormim].[dbo].[ChatUser]");
            for (int i = 0; i < users.Length; i++)
            {
                users[i].UserAd = users[i].UserAd.ToLower();
            }
            return users;
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

        public static void UpdateUserChatDetailsToRead(ChatUser readingUser, ChatUser senderUser)
        {
            string query = @"SELECT *  FROM [datatormim].[dbo].[ChatDetail] 
                            where ToUserAd = @readingUser_ADName 
                              and FromUserAd = @senderUser_ADName
                              and ReadOdaa = 0";

            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("@readingUser_ADName", readingUser.UserAd));
            sqlParams.Add(new SqlParameter("@senderUser_ADName", senderUser.UserAd));

            ChatDetails[] details = DAL.select<ChatDetails>(query, sqlParams.ToArray());

            string updateQuery = @"UPDATE [datatormim].[dbo].[ChatDetail] SET ReadOdaa = 1 where id = ";
            for (int i = 0; i < details.Length; i++)
            {
                details[i].ReadOdaa = true;
                DAL.update(updateQuery + details[i].id);
            }
        }

        public static string[] UsersADNamesThatHasUnreadMessagesForMe(string asking_clientADName)
        {
            string query = @"select DISTINCT FromUserAd from [datatormim].[dbo].[ChatDetail] 
                            where ToUserAd = @readingUser_ADName and ReadOdaa = 0";
            System.Data.DataTable dt = DAL.select(
                query, 
                new SqlParameter[] { new SqlParameter("@readingUser_ADName", asking_clientADName)});
            List<string> names = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                names.Add(dt.Rows[i][0].ToString());
            }
            return names.ToArray();
        }

    }
}
