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
    public partial class FormQuis : Form
    {
        private int temp_user_id;
        public FormQuis(int user_id)
        {
            InitializeComponent();
            this.temp_user_id = user_id;
        }

        ScoreControl SC = new ScoreControl();
        ReportControl RC = new ReportControl();
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

        public void RefreshGridView()
        {
            setDatagridview(dgQuestion);
        }

        public void setDatagridview(DataGridView DG)
        {
            DG.DataSource = SC.Show_Question_Bank_by_Users(temp_user_id);
            //Start Code Data Binding
            DataTable DT = SC.Show_Question_Bank_by_Users(temp_user_id);
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

            DG.Columns[0].Visible = false;  // score_id
            DG.Columns[1].Visible = false;  // score
            DG.Columns[2].HeaderText = "Duration (Minutes)";    // Duration
            DG.Columns[3].Visible = false;  // name of Students
            DG.Columns[4].HeaderText = "Title"; // title
            DG.Columns[5].HeaderText = "Count of Questions";    // count
            DG.Columns[6].Visible = false;  // duration_questions
            DG.Columns[7].HeaderText = "Status";    // status
            DG.Columns[8].Visible = false;  // bank_Id
            
            DG.Columns[2].Width = 120;
            DG.Columns[4].Width = 200;
            DG.Columns[5].Width = 120;
            DG.Columns[7].Width = 70;

            settingHeaderGrid(DG);

        }

        private void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            this.setDatagridview(dgQuestion);
        }

        private void FormQuis_Load(object sender, EventArgs e)
        {
            txtID.Text = temp_user_id.ToString();
            setDatagridview(dgQuestion);
            setDatagridview_Report_Students(dgReport);
        }

        private void dgQuestion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTemp.Text = getColumn(dgQuestion, 0);
            txtTitle.Text = getColumn(dgQuestion, 4);
            CountQuestion.Text = getColumn(dgQuestion, 5);
            txtDuration.Text = getColumn(dgQuestion, 2);
            txtStatus.Text = getColumn(dgQuestion, 7);

            if (txtTemp.Text != "")
            {
                btn_Start.Enabled = true;
            }
            else
            {
                btn_Start.Enabled = false;
            }
        }

        private string getColumn(DataGridView dg, int i)
        {
            string kolom = null;
            try
            {
                kolom = dg[dg.Columns[i].Index, dg.CurrentRow.Index].Value.ToString();
            }
            catch
            {
                SE.ShowMessage("", "Failed");
            }
            return kolom;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            string bank_id = getColumn(dgQuestion, 8);
            string score_id = getColumn(dgQuestion, 0);

            DialogResult dr = MessageBox.Show("Are You Sure to Start this Question?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                FormRun FR = new FormRun(int.Parse(bank_id), int.Parse(score_id));
                FR.ShowDialog();
                this.Close();
            }
        }



        //================================================================== REPORT STUDENTS ==========================================================//
        
        public void setDatagridview_Report_Students(DataGridView DG)
        {
            DG.DataSource = RC.Show_Report_Students(temp_user_id);
            //Start Code Data Binding
            DataTable DT = RC.Show_Report_Students(temp_user_id);
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
            bindingSource2.DataSource = listTbl;
            bindingNavigator2.BindingSource = bindingSource2;
            DG.DataSource = (DT.Rows.Count > 0 ? listTbl[bindingSource2.Position] : DT);
            //Ending Code Data Binding

            DG.Columns[0].Visible = false;
            DG.Columns[1].Width = 100;  // score
            DG.Columns[2].Width = 120;  // duration
            DG.Columns[3].Visible = false; ;   // name
            DG.Columns[4].Width = 250;  // title
            DG.Columns[5].Width = 120;  // count
            DG.Columns[6].Width = 200;  // duration of questions
            DG.Columns[7].Width = 100;  // status

            settingHeaderGrid(DG);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            FormChangePassword FCP = new FormChangePassword(temp_user_id);
            FCP.ShowDialog();
            this.Close();
        }
    }
}
