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
    class QuestionBankControl
    {
        TBL_BANK_SOALTableAdapter TQ = new TBL_BANK_SOALTableAdapter();
        TBL_BANK_DETAILTableAdapter TDQ = new TBL_BANK_DETAILTableAdapter();
        TBL_USERTableAdapter TU = new TBL_USERTableAdapter();
        TBL_SCORETableAdapter TS = new TBL_SCORETableAdapter();
        ShowException SE = new ShowException();

        public DataTable Show_Question_Bank(int user_id)
        {
            DataTable DT = null;
            try
            {
                DT = TQ.GetData(user_id);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
            return DT;
        }

        public DataTable Search_Question_Bank(string keyword, int user_id)
        {
            DataTable DT = null;
            try
            {
                DT = TQ.SearchQuestionBank(keyword, user_id);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
            return DT;
        }

        //===== Insert New Question Bank ==========//

        public void InsertQuestonBank(QuestionBank Q)
        {
            try
            {
                TQ.InsertQuestonBank(Q.Title, Q.Count, Q.Duration, Q.Status, Q.User_create);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
        }

        //===== Update Question Bank ==========//

        public void UpdateQuestonBank(QuestionBank Q, int keyword)
        {
            try
            {
                TQ.UpdateQuestionBank(Q.Title, Q.Count, Q.Duration, Q.Status, keyword);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
        }

        //===== Delete Question Bank With Flag and Change the Field Deleted To True ==========//

        public void DeleteQuestonBank(int keyword)
        {
            try
            {
                TQ.DeleteQuestionBank(keyword);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
        }

        //===== Insert Questions ==========//

        public void InsertQuestion(Questions Q)
        {
            try
            {
                TDQ.InsertQuestions(Q.Bank_id, Q.Question_number, Q.Question, Q.Type, Q.Answer1, Q.Answer2, Q.Answer3, 
                    Q.Answer4, Q.Answer5, Q.Answer6, Q.Answer7, Q.True_answer, Q.Count_of_choice);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
        }

        //===== Update Questions ==========//

        public void UpdateQuestion(Questions Q, int keyword)
        {
            try
            {
                TDQ.UpdateQuestion(Q.Question_number, Q.Question, Q.Type, Q.Answer1, Q.Answer2, Q.Answer3, Q.Answer4, Q.Answer5, Q.Answer6, 
                    Q.Answer7, Q.True_answer, Q.Count_of_choice, keyword);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
        }

        // ==== Update Count of Question Has Been Added ======= //

        public void UpdateCount_of_Question(int new_count, int keyword)
        {
            try
            {
                TQ.UpdateCount_of_Question(new_count, keyword);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
        }

        // ==== Get Count of Question by Bank ID ======= //

        public int GetCount_of_Question(int bank_id)
        {
            int temp = 0;
            try
            {
                temp = int.Parse(TDQ.Get_Count_Questions(bank_id).ToString());
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }

            return temp;
        }

        // ==== Get Count of Question by Bank ID ======= //

        public int GetCount_of_Question_in_Bank(int bank_id)
        {
            int temp = 0;
            try
            {
                temp = int.Parse(TQ.Get_Count_Questions(bank_id).ToString());
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }

            return temp;
        }

        // ========= Show Questions ==============//

        public DataTable Show_Question(int bank_id)
        {
            DataTable DT = null;
            try
            {
                DT = TDQ.GetData(bank_id);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
            return DT;
        }

        // ========= Search Questions ==============//

        public DataTable Search_Question(int bank_id, string keyword)
        {
            DataTable DT = null;
            try
            {
                DT = TDQ.SearchQuestion(bank_id, keyword);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
            return DT;
        }

        //===== Delete Question With Flag and Change the Field Deleted To True ==========//

        public void DeleteQuestions(int keyword)
        {
            try
            {
                TDQ.Delete_Question(keyword);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
        }

        //================ Set Students ===================//
        public DataTable Get_Users_by_Role(string keyword)
        {
            DataTable DT = null;
            try
            {
                DT = TU.Get_Users_by_Role(keyword);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
            return DT;
        }

        //================ Set Students ===================//
        public DataTable Get_Set_Users_by_Role(string bank_id)
        {
            DataTable DT = null;
            try
            {
                DT = TS.Get_Score_by_Role(bank_id);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
            return DT;
        }

        public bool Check_Title(string title)
        {
            bool check = false;
            try
            {
                if (TQ.GetTitle(title).ToString() != "")
                    check = true;
            }
            catch
            {
                check = false;
            }
            return check;
        }

    }
}
