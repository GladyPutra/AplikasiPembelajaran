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
    class RunControl
    {
        TBL_BANK_DETAILTableAdapter TBD = new TBL_BANK_DETAILTableAdapter();
        ShowException SE = new ShowException();

        public DataTable Show_Question(int bank_id)
        {
            DataTable DT = null;
            try
            {
                DT = TBD.GetData(bank_id);
            }
            catch (Exception ex)
            {
                SE.ShowMessage(ex.ToString(), "Failed");
            }
            return DT;
        }
    }
}
