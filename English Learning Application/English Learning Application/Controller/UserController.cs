using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using English_Learning_Application.ELAdsTableAdapters;
using English_Learning_Application.Entity;

namespace English_Learning_Application.Controller
{
    class UserController
    {
        TBL_USERTableAdapter TU = new TBL_USERTableAdapter();
        TBL_ROLETableAdapter TR = new TBL_ROLETableAdapter();
        ShowException SE = new ShowException();

        public DataTable Show_User()
        {
            DataTable DT = null;
            try
            {
                DT = TU.GetData();
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
            return DT;
        }

        public DataTable Search_User(string keyword)
        {
            DataTable DT = null;
            try
            {
                DT = TU.Search_User(keyword);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
            return DT;
        }

        //===== Insert New User ==========//

        public void InsertUser(User U)
        {
            try
            {
                TU.InsertUser(U.Name, U.Username, U.Password, U.Role_id);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
        }

        //===== Update User ==========//

        public void UpdateUser(User U, int keyword)
        {
            try
            {
                TU.UpdateUsers(U.Name, U.Username, U.Role_id, keyword);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
        }

        //===== Delete User ==========//

        public void DeleteUser(int keyword)
        {
            try
            {
                TU.DeleteUser(keyword);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
        }

        //Get Role_Name and Role_Id
        //=== START ===========//

        public DataTable getRole()
        {
            DataTable DT = null;
            try
            {
                DT = TR.GetData();
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
            return DT;
        }

        public string getRoleId(string role)
        {
            string ID = null;
            try
            {
                ID = TR.GetRoleId(role).ToString();
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
            return ID;
        }

        //=== END ===========//

        public string Get_RoleID_User(int user_id)
        {
            string ID = null;
            try
            {
                ID = TU.Get_Role_User_by_UserID(user_id).ToString();
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
            return ID;
        }

        public bool Check_Username(string user)
        {
            bool check = false;
            try
            {
                if (TU.GetUsername(user).ToString() != "")
                    check = true;
            }
            catch
            {
                check = false;
            }
            return check;
        }

        //===== Reset Password User ==========//

        public void Reset_Password_User(string new_password, int user_id)
        {
            try
            {
                TU.Reset_Password(new_password, user_id);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
        }
    }
}
