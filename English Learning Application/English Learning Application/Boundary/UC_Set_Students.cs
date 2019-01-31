using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using English_Learning_Application.Controller;
using English_Learning_Application.Boundary;
using English_Learning_Application.Entity;


namespace English_Learning_Application.Boundary
{
    public partial class UC_Set_Students : UserControl
    {
        private int temp_user_create;

        public UC_Set_Students()
        {
            InitializeComponent();
        }

        QuestionBankControl QB = new QuestionBankControl();
        ScoreControl SC = new ScoreControl();
        ShowException SE = new ShowException();

        public void temp(string bank_id, int user_id)
        {
            txtTemp.Text = bank_id;
            this.temp_user_create = user_id;
        }

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
            setDatagridview(dgStudents);
            setDatagridview2(dgSet, txtTemp.Text);
        }

        public void setDatagridview(DataGridView DG)
        {
            DG.DataSource = QB.Get_Users_by_Role("STD");
            //Start Code Data Binding
            DataTable DT = QB.Get_Users_by_Role("STD");
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

            DG.Columns[0].HeaderText = "ID";
            DG.Columns[1].HeaderText = "Full Name";
            DG.Columns[2].HeaderText = "Username";
            DG.Columns[3].Visible = false;
            DG.Columns[4].Visible = false;
            DG.Columns[5].Visible = false;

            DG.Columns[1].Width = 170;
            DG.Columns[2].Width = 130;

            settingHeaderGrid(DG);
        }

        public void setDatagridview2(DataGridView DG, string bank_id)
        {
            DG.DataSource = QB.Get_Set_Users_by_Role(bank_id);
            //Start Code Data Binding
            DataTable DT = QB.Get_Set_Users_by_Role(bank_id);
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

            DG.Columns[0].HeaderText = "Score ID";
            DG.Columns[3].HeaderText = "Full Name";
            DG.Columns[9].HeaderText = "Userame";
            for (int i = 0; i < 10; i++)
            {
                if(i != 0 && i != 3 && i != 9)
                    DG.Columns[i].Visible = false;
            }

            settingHeaderGrid(DG);
        }

        private void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            this.setDatagridview(dgStudents);
        }

        private void bindingSource2_PositionChanged(object sender, EventArgs e)
        {
            this.setDatagridview(dgSet);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        private void dgStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = getColumn(dgStudents, 0);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                int user_id = int.Parse(txtID.Text);
                int bank_id = int.Parse(txtTemp.Text);

                if (SC.Check_Before_Insert(user_id, bank_id) == false)
                {
                    English_Learning_Application.Entity.Score S = new Entity.Score(user_id, bank_id, 0, 0, temp_user_create);
                    SC.InsertScore(S);
                    //MessageBox.Show("Add New User has Successfuly", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //clearField();
                    RefreshGridView();
                }
                else
                {
                    MessageBox.Show("User has been Set to This Question Bank...", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please, Choose the Students to Set...!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgStudents.Focus();
            }
        }

        private void dgSet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = getColumn(dgSet, 0);
            btnUnSet.Enabled = true;
        }


        private void btnUnSet_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                DialogResult dr = MessageBox.Show("Are You Sure to Delete This Set?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    SC.DeleteScore(int.Parse(txtID.Text));
                    if(getColumn(dgSet, 6) == "Not Yet")
                        MessageBox.Show("This Set Has Been UnSet!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("This Set Can't UnSet!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                RefreshGridView();
                txtID.Clear();
                btnUnSet.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please, Choose the Students to UnSet...!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgSet.Focus();
            }
        }

    }
}
