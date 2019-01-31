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
    public partial class FormRun : Form
    {
        private int bank_id = 0, temp_score_id = 0;
        private int hours, minutes, second;

        public FormRun(int bank_id, int score_id)
        {
            InitializeComponent();
            this.bank_id = bank_id;
            this.temp_score_id = score_id;
        }

        RunControl RC = new RunControl();
        QuestionBankControl QB = new QuestionBankControl();
        ScoreControl SC = new ScoreControl();
        ShowException SE = new ShowException();

        public void setDatagridview(DataGridView DG)
        {
            DG.DataSource = RC.Show_Question(bank_id);
            //int count_of_questions = QB.GetCount_of_Question(int.Parse(txtID.Text));

            for (int i = 0; i < 14; i++)
            {
                if (i == 2)
                    DG.Columns[2].HeaderText = "NUMBER";
                else
                    DG.Columns[i].Visible = false;
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

        private string getRow(DataGridView dg)
        {
            return dg.CurrentRow.Index.ToString();
        }

        private void FormRun_Load(object sender, EventArgs e)
        {
            txtID.Text = bank_id.ToString();
            lblTitle.Text = SC.Get_Title_Bank_Id(bank_id);
            Convert_Duration();
            setDatagridview(dgTemp);
            RefreshGridView();
        }

        private void RefreshGridView()
        {
            int count_done = dgTemp.Rows.Count;
            int count_of_questions = QB.GetCount_of_Question(bank_id);
            int score_id = 0;

            double score = double.Parse(txtTempPoin.Text) / count_of_questions;
            if (count_done == 0)
            {
                DialogResult dr = MessageBox.Show("FINISH. Your Score : " + score, "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    timer1.Stop();
                    this.Close();
                    if (temp_score_id != 0)
                    {
                        score_id = int.Parse(SC.Get_User_Id(temp_score_id));
                        FormQuis FQ = new FormQuis(score_id);
                        FQ.ShowDialog();
                        FQ.RefreshGridView();
                    }
                    else
                    {
                        int temp_user_id = Convert.ToInt32(SC.Get_User_Create(bank_id));
                        FormBank FB = new FormBank(temp_user_id);
                        FB.ShowDialog();
                    }
                    
                }
            }
        }       

        private void btnClose_Click(object sender, EventArgs e)
        {
            double count_question = QB.GetCount_of_Question(int.Parse(txtID.Text));
            double score = double.Parse(txtTempPoin.Text) / count_question;

            DialogResult dr = MessageBox.Show("Are You Sure to End this Question?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
                if (temp_score_id != 0)
                {
                    SC.SaveScore(score, Get_Finish_Time(), temp_score_id);

                    int score_id = int.Parse(SC.Get_User_Id(temp_score_id));
                    FormQuis FQ = new FormQuis(score_id);
                    FQ.ShowDialog();
                    FQ.RefreshGridView();
                }
                else
                {
                    int temp_user_id = Convert.ToInt32(SC.Get_User_Create(bank_id));
                    FormBank FB = new FormBank(temp_user_id);
                    FB.ShowDialog();
                }                
            }
        }

        private void VisibleRun(bool value1, bool value2)
        {
            gbQuestion.Visible = true;
            gbChoice.Visible = value1;
            cbAnswer.Visible = value2;
        }

        private void Visible()
        {
            gbQuestion.Visible = false;
            gbChoice.Visible = false;
            cbAnswer.Visible = false;
            btnYes.Enabled = false;
        }

        private void VisibleChoice(bool value1, bool value2, bool value3, bool value4, bool value5, bool value6, bool value7)
        {
            rbChoice1.Visible = value1;
            rbChoice2.Visible = value2;
            rbChoice3.Visible = value3;
            rbChoice4.Visible = value4;
            rbChoice5.Visible = value5;
            rbChoice6.Visible = value6;
            rbChoice7.Visible = value7;
        }

        private void dgTemp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clear_choice();
            int rowIndex = dgTemp.CurrentRow.Index;
            txtRow.Text = rowIndex.ToString();

            txtQuestion.Text = getColumn(dgTemp, 3);
            txtTemp.Text = getColumn(dgTemp, 12);
            VisibleRun(true, false);

            if (txtTemp.Text != "")
            {
                string type = getColumn(dgTemp, 4);
                string answer1 = getColumn(dgTemp, 5);
                string answer2 = getColumn(dgTemp, 6);
                string answer3 = getColumn(dgTemp, 7);
                string answer4 = getColumn(dgTemp, 8);
                string answer5 = getColumn(dgTemp, 9);
                string answer6 = getColumn(dgTemp, 10);
                string answer7 = getColumn(dgTemp, 11);
                int count_of_choice = int.Parse(getColumn(dgTemp, 13));

                if (type == "Multiple Choice")
                {
                    rbChoice1.Text = answer1;
                    rbChoice2.Text = answer2;
                    rbChoice3.Text = answer3;
                    rbChoice4.Text = answer4;
                    rbChoice5.Text = answer5;
                    rbChoice6.Text = answer6;
                    rbChoice7.Text = answer7;

                    if (count_of_choice == 3)
                        VisibleChoice(true, true, true, false, false, false, false);
                    else if (count_of_choice == 5)
                        VisibleChoice(true, true, true, true, true, false, false);
                    else if (count_of_choice == 7)
                        VisibleChoice(true, true, true, true, true, true, true);
                }
                else if (type == "True - False")
                {
                    VisibleRun(false, true);
                }

                btnYes.Enabled = true;
            }
            else
            {
                Visible();
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are You Sure?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string answer = "", status = "";
                int count_question = QB.GetCount_of_Question(int.Parse(txtID.Text));
                int temp_bank_detail_id = int.Parse(getColumn(dgTemp, 0));

                double poin = 0, sum_poin = double.Parse(txtTempPoin.Text);

                if (rbChoice1.Checked == true)
                {
                    answer = "Answer 1";
                }
                else if (rbChoice2.Checked == true)
                {
                    answer = "Answer 2";
                }
                else if (rbChoice3.Checked == true)
                {
                    answer = "Answer 3";
                }
                else if (rbChoice4.Checked == true)
                {
                    answer = "Answer 4";
                }
                else if (rbChoice5.Checked == true)
                {
                    answer = "Answer 5";
                }
                else if (rbChoice6.Checked == true)
                {
                    answer = "Answer 6";
                }
                else if (rbChoice7.Checked == true)
                {
                    answer = "Answer 7";
                }
                else if (cbAnswer.Text == "True")
                {
                    answer = cbAnswer.Text;
                }
                else if (cbAnswer.Text == "False")
                {
                    answer = cbAnswer.Text;
                }

                if (answer == txtTemp.Text)
                {
                    poin = 100;
                    status = "True";
                }
                else
                {
                    poin = 0;
                    status = "False";
                }
                sum_poin = sum_poin + poin;
                double score = (sum_poin / count_question);
                txtTempPoin.Text = sum_poin.ToString();
                lblPoin.Text = "Poin : " + sum_poin + " Score : " + score;

                if (temp_score_id != 0)
                {
                    // Insert Score Detail
                    SC.Insert_Detail_Score(temp_score_id, temp_bank_detail_id, status);

                    //Save Score
                    SC.SaveScore(score, Get_Finish_Time(), temp_score_id);
                }

                int rowindex = int.Parse(txtRow.Text);
                dgTemp.Rows.RemoveAt(rowindex); // Delete Question has been done

                RefreshGridView();
                Visible();
                txtTemp.Clear();
            }

        }

        private void clear_choice()
        {
            rbChoice1.Checked = false;
            rbChoice2.Checked = false;
            rbChoice3.Checked = false;
            rbChoice4.Checked = false;
            rbChoice5.Checked = false;
            rbChoice6.Checked = false;
            rbChoice7.Checked = false;
            cbAnswer.Text = "Choose";
        }

        private void Convert_Duration()
        {
            int duration = Convert.ToInt32(SC.Get_Duration(bank_id));
            //MessageBox.Show(duration.ToString());
            
            int second = Convert.ToInt32(duration * 60);
            int hours, minutes;
            hours = second / 3600;
            second = second - ((60 * 60) * hours);
            minutes = second / 60;
            second = second - (60 * minutes);

            lblTempH.Text = hours.ToString();
            lblTempM.Text = minutes.ToString();
            lblTempS.Text = second.ToString();

            Run_Duration();
        }

        private void Run_Duration()
        {
            this.hours = Convert.ToInt32(lblTempH.Text);
            this.minutes = Convert.ToInt32(lblTempM.Text);
            this.second = Convert.ToInt32(lblTempS.Text);
            
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            second = second - 1;
            if (second == -1)
            {
                minutes = minutes - 1;
                second = 59;
            }

            if (minutes == -1)
            {
                hours = hours - 1;
                minutes = 59;
            }

            if (hours == 0 && minutes == 00 && second == 00)
            {
                timer1.Stop();
                int count_of_questions = QB.GetCount_of_Question(bank_id);

                double score = double.Parse(txtTempPoin.Text) / count_of_questions;
                DialogResult dr = MessageBox.Show("TIMES UP. Your Score : " + score, "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    this.Close();
                    SC.SaveScore(score, Get_Finish_Time(), temp_score_id);
                    int score_id = int.Parse(SC.Get_User_Id(temp_score_id));
                    FormQuis FQ = new FormQuis(score_id);
                    FQ.ShowDialog();
                    FQ.RefreshGridView();
                }
            }

            lblHours.Text = Convert.ToString(hours);
            lblMinutes.Text = Convert.ToString(minutes);
            lblSecond.Text = Convert.ToString(second);
        }

        private double Get_Finish_Time()
        {
            double time, h, m, s;
            h = Convert.ToDouble(lblHours.Text);
            m = Convert.ToDouble(lblMinutes.Text);
            s = Convert.ToDouble(lblSecond.Text);
            time = (h * 60) + m + (s / 60);

            return time;
        }
    }
}

