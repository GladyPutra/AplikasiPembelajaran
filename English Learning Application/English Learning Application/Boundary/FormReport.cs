using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using English_Learning_Application.Controller;
using English_Learning_Application.Boundary;
using English_Learning_Application.Entity;

namespace English_Learning_Application.Boundary
{
    public partial class FormReport : Form
    {
        private int temp_user_id;

        public FormReport(int user_id)
        {
            InitializeComponent();
            this.temp_user_id = user_id;
        }

        ReportControl RC = new ReportControl();
        UserController UC = new UserController();
        ShowException SE = new ShowException();

        private void settingHeaderGrid(DataGridView DG)
        {
            //=== Make Center Header in Data Grid View
            foreach (DataGridViewColumn col in DG.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }

        public void setDatagridview(DataGridView DG)
        {
            string temp_role_id = UC.Get_RoleID_User(temp_user_id);
            DataTable DT = null;

            if (temp_role_id == "ADM")
            {
                DG.DataSource = RC.Show_Report_Admin();
                //Start Code Data Binding
                DT = RC.Show_Report_Admin();
            }
            else
            {
                DG.DataSource = RC.Show_Report(temp_user_id);
                //Start Code Data Binding
                DT = RC.Show_Report(temp_user_id);            
            }

            
            BindingList<DataTable> listTbl = new BindingList<DataTable>();
            if (DT.Rows.Count > 0)
            {
                int counter = 0, subTblIndex = -1;
                foreach (DataRow dr in DT.Rows)
                {
                    if (counter == 0)
                    {
                        listTbl.Add(DT.Clone());
                        subTblIndex++;
                    }
                    listTbl[subTblIndex].Rows.Add(dr.ItemArray);
                    counter++;
                    if (counter == 10) counter = 0; //counter==10, one page 10 rows
                }
            }
            bindingSource1.DataSource = listTbl;
            bindingNavigator1.BindingSource = bindingSource1;
            DG.DataSource = (DT.Rows.Count > 0 ? listTbl[bindingSource1.Position] : DT);
            //Ending Code Data Binding

            DG.Columns[0].Visible = false;

            DG.Columns[1].Width = 100;  // score
            DG.Columns[2].Width = 120;  // duration
            DG.Columns[3].Width = 250;   // name
            DG.Columns[4].Width = 250;  // title
            DG.Columns[5].Width = 100;  // count
            DG.Columns[6].Width = 120;  // duration of questions

            settingHeaderGrid(DG);

        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            dTPicker.Value = DateTime.Now;
            setDatagridview(dgReport);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            this.setDatagridview(dgReport);
        }
    }
}
