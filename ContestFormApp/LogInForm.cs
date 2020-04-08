using ContestFormApp.Services;

using System;

using System.Windows.Forms;

namespace ContestFormApp
{
    public partial class LogInForm : Form
    {
        ContestController controller;
        public LogInForm(ContestController ser)
        {
            this.controller = ser;
            InitializeComponent();
            passText.PasswordChar = '-';
        }

        private void logInBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.controller.LogIn(userText.Text,passText.Text);
                this.Hide();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
    }
}
