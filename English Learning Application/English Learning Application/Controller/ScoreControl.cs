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
    class ScoreControl
    {
        TBL_BANK_SOALTableAdapter QB = new TBL_BANK_SOALTableAdapter();
        TBL_BANK_DETAILTableAdapter QD = new TBL_BANK_DETAILTableAdapter();
        TBL_SCORETableAdapter TS = new TBL_SCORETableAdapter();
        TBL_SCORE_DETAILTableAdapter SD = new TBL_SCORE_DETAILTableAdapter();
        ShowException SE = new ShowException();

        //===== Insert Score ==========//

        public void InsertScore(Score S)
        {
            try
            {
                TS.Insert_to_Score(S.User_id, S.Bank_id, S.Scoring, S.Duration, S.User_create);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
        }

        //===== Delete Score ==========//

        public void DeleteScore(int score_id)
        {
            try
            {
                TS.Delete_Set_Users(score_id);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
        }

        //============ Check Before Insert When There Is Some Data ============ //

        public bool Check_Before_Insert(int user_id, int bank_id)
        {
            bool check = false;
            try
            {
                if (TS.Check_Before_Insert(user_id, bank_id).ToString() != "")
                    check = true;
            }
            catch
            {
                check = false;
            }
            return check;
        }

        //========= Show Questions Bank by Users ==================//

        public DataTable Show_Question_Bank_by_Users(int user_id)
        {
            DataTable DT = null;
            try
            {
                DT = TS.Get_Question_Bank_by_Users(user_id);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
            return DT;
        }

        //===== Save Score ==========//

        public void SaveScore(double score, double duration, int score_id)
        {
            try
            {
                TS.Save_Score(score, duration, score_id);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
        }

        public String Get_User_Id(int score_id)
        {
            String temp = null;
            try
            {
                temp = TS.Get_User_ID(score_id).ToString();
            }
            catch
            {
                temp = null;
            }
            return temp;
        }

        public String Get_Title_Bank_Id(int bank_id)
        {
            String temp = null;
            try
            {
                temp = QB.Get_Title_Bank_Id(bank_id).ToString();
            }
            catch
            {
                temp = null;
            }
            return temp;
        }

        //============== INSERT DETAIL SCORE =================//

        public void Insert_Detail_Score(int score_id, int bank_detail_id, string status_answer)
        {
            try
            {
                SD.Insert_Detail_Score(score_id, bank_detail_id, status_answer);
            }
            catch(Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
        }

        //================ Get Duration ==========//

        public String Get_Duration(int bank_id)
        {
            String temp = null;
            try
            {
                temp = QB.Get_Duration(bank_id).ToString();
            }
            catch
            {
                temp = null;
            }
            return temp;
        }

        //================ Get User Create the Questions Bank ==========//

        public String Get_User_Create(int bank_id)
        {
            String temp = null;
            try
            {
                temp = QB.Get_User_Create_Bank(bank_id).ToString();
            }
            catch
            {
                temp = null;
            }
            return temp;
        }
    }
}
