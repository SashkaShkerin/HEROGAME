using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HEROGAME
{
    public partial class RulesGame : Form
    {
        public RulesGame()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();    // открываем новую форму
            form1.Left = this.Left;  // задаём позицию по X открываемой форме
            form1.Top = this.Top;  // задаём позицию по Y открываемой форме
            this.Hide();    // закрываем старую форму
        }

    }
}
