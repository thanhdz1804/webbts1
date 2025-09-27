using System;
using System.Windows.Forms;
using TNTLibrary;

namespace TNTWFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // Nếu muốn xử lý gì khi nhập tên thì thêm code ở đây
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            HappinessCalculator calc = new HappinessCalculator();
            calc.InputName = txtName.Text;
            calc.Calculate();
            lblResult.Text = calc.GetMessage();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
