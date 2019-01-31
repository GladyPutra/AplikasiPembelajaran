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
    class ReportControl
    {
        TBL_SCORETableAdapter TS = new TBL_SCORETableAdapter();
        ShowException SE = new ShowException();

        //============= Show Report ================//
        public DataTable Show_Report(int user_create)
        {
            DataTable DT = null;
            try
            {
                DT = TS.GetData(user_create);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
            return DT;
        }

        public DataTable Show_Report_Admin()
        {
            DataTable DT = null;
            try
            {
                DT = TS.Get_Report_Admin();
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
            return DT;
        }

        public DataTable Show_Report_Students(int student_id)
        {
            DataTable DT = null;
            try
            {
                DT = TS.Get_Report_Score_by_Students(student_id);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
            return DT;
        }
    }
}
