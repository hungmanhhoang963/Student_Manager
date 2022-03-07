using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentSystemManagement;
using StudentSystemManagement.BLL;
namespace StudentSystemManagement.GUI
{
    public partial class EditScoreForm : Form
    {
        School.Score Score;
        List<School.Student> SinhViens;
        List<School.Score> Diems;
        public EditScoreForm(School.Score score, List<School.Student> sinhViens, ref List<School.Score> diems)
        {
            InitializeComponent();
            Score = score;
            SinhViens = sinhViens;
            Diems = diems;
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void MssvBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditScoreForm_Load(object sender, EventArgs e)
        {
            MidtermScoreBox.TextChanged += MidtermScoreBox_TextChanged;
            OtherScoreBox.TextChanged += MidtermScoreBox_TextChanged;
            MssvBox.Text = Score.MSSV.ToString();
            NameBox.Text = (SinhViens.FirstOrDefault(x => x.MSSV == Score.MSSV)).HoTen;
            MidtermScoreBox.Text = Score.DIEMGIUAKY.ToString();
            FinaltermScoreBox.Text = Score.DIEMCUOIKY.ToString();
            OtherScoreBox.Text = Score.DIEMKHAC.ToString();
            AvgBox.Text = ((Score.DIEMKHAC + Score.DIEMGIUAKY + Score.DIEMCUOIKY) / 3).ToString();
            MssvBox.Enabled = false;
            AvgBox.Enabled = false;
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            if (IsValidInput())
            {
                string Query = string.Format("UPDATE DIEM SET DIEMGK = {0}, DIEMCK = {1}, DIEMKHAC = {2} WHERE MSSV = {3} AND MaMonHoc = '{4}'", MidtermScoreBox.Text, FinaltermScoreBox.Text, OtherScoreBox.Text, Score.MSSV, Score.MaMonHoc);
                SSMBLL.SaveDatabase(Query);
                var score = Diems.FirstOrDefault(x => x.MSSV == Score.MSSV && x.MaMonHoc == Score.MaMonHoc);
                score.DIEMGIUAKY = float.Parse(MidtermScoreBox.Text);
                score.DIEMCUOIKY = float.Parse(FinaltermScoreBox.Text);
                score.DIEMKHAC = float.Parse(OtherScoreBox.Text);
                this.Close();
            }
        }

        private bool IsValidInput()
        {
            bool result = true;
            float midTerm = -1, finalTerm = -1, other = -1;
            if (MidtermScoreBox.Text == string.Empty || FinaltermScoreBox.Text == string.Empty || OtherScoreBox.Text == string.Empty)
            {
                MessageBox.Show("Điểm giữa kì, cuối kì và điểm khác không được để trống");
                result = false;
            }
            else if (!float.TryParse(MidtermScoreBox.Text, out midTerm) || !float.TryParse(FinaltermScoreBox.Text, out finalTerm) || !float.TryParse(OtherScoreBox.Text, out other))
            {
                MessageBox.Show("Điểm giữa kì, cuối kì và điểm khác phải là số thực");
                result = false;
            }
            else if ((midTerm < 0 || midTerm > 10) || (finalTerm < 0 || finalTerm > 10) || (other < 0 || other > 10))
            {
                MessageBox.Show("Điểm giữa kì, cuối kì và điểm khác nằm trong khoảng từ 0.0 đến 10.0");
                result = false;
            }
            return result;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FinaltermScoreBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void MidtermScoreBox_TextChanged(object sender, EventArgs e)
        {
            float midTerm, finalTerm, other;
            if (float.TryParse(MidtermScoreBox.Text, out midTerm) && float.TryParse(FinaltermScoreBox.Text, out finalTerm) && float.TryParse(OtherScoreBox.Text, out other))
            {
                AvgBox.Text = ((midTerm + finalTerm + other) / 3).ToString();
            }
            else
            {
                AvgBox.Text = "...";
            }
        }
    }
}
