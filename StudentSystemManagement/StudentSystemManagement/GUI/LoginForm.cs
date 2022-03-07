using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentSystemManagement.BLL;
using StudentSystemManagement;
using School;
using StudentSystemManagement.GUI;

namespace StudentSystemManagement.GUI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure to exit this form?", "STUDENT SYSTEM MANAGEMENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Init()
        {
            UsernameBox.Text = PasswordBox.Text = string.Empty;
        }
        private bool IsValidInput()
        {
            if (UsernameBox.Text.TrimEnd() == string.Empty || PasswordBox.Text == string.Empty)
            {
                return false;
            }
            return true;
        }

        private void StaffFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (IsValidInput())
            {
                var Account = SSMBLL.IsAccount(UsernameBox.Text.ToLower().TrimEnd(), PasswordBox.Text);
                if (Account != null)
                {
                    if (Account.TYPE == LoginType.ACADEMICSTAFF)
                    {
                        var staffFrm = new AcademicStaffForm();
                        staffFrm.Show();
                        this.Hide();
                        staffFrm.FormClosed += StaffFrm_FormClosed;
                    }
                    else
                    {
                        var StudentFrm = new StudentForm(Account);
                        StudentFrm.Show();
                        this.Hide();
                        StudentFrm.FormClosed += StaffFrm_FormClosed;
                    }
                }
                else
                {
                    MessageBox.Show("Username or password are incorrect", "STUDENT SYSTEM MANAGEMENT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Username or password are not empty", "STUDENT SYSTEM MANAGEMENT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(sender, e);
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
