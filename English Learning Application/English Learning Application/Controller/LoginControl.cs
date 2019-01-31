using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using English_Learning_Application.Entity;
using English_Learning_Application.ELAdsTableAdapters;

namespace English_Learning_Application.Controller
{
    class LoginControl
    {
        TBL_USERTableAdapter TU = new TBL_USERTableAdapter();
        KeyGenerator KG = new KeyGenerator();

        public bool Check_Login(string username, string pass)
        {
            //string temp_password = TU.Get_Password(username).ToString();
            string decrypt_password = KG.EncryptString(pass);
            pass = decrypt_password;

            bool check = false;

            try
            {
                if (TU.GetUser(username, pass).ToString() != "")
                {
                    check = true;
                }
            }
            catch
            {
                check = false;
            }
            return check;
        }

        public String Get_RoleID_User(string user, string pass)
        {
            string decrypt_password = KG.EncryptString(pass);
            pass = decrypt_password;

            string role = null;
            try
            {
                role = TU.Get_RoleID_Users(user, pass).ToString();
            }
            catch
            {
                role = null;
            }
            return role;
        }

        public String Get_UserID(string user, string pass)
        {
            string decrypt_password = KG.EncryptString(pass);
            pass = decrypt_password;

            String user_id = null;
            try
            {
                user_id = TU.Get_UserID(user, pass).ToString();
            }
            catch
            {
                user_id = null;
            }
            return user_id;
        }

        public string Get_Password_User(string username)
        {
            string pass = null;
            try
            {
                pass = TU.Get_Password(username).ToString();
            }
            catch
            {
                pass = null;
            }

            return pass;
        }
    }
}
