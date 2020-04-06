using ContestFormApp.Services;
using ContestModel.Domain;
using ContestServices.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
