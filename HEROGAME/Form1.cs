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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConstructorGame construncotgame = new ConstructorGame();
            construncotgame.Show();    // открываем новую форму
            construncotgame.Left = this.Left;  // задаём позицию по X открываемой форме
            construncotgame.Top = this.Top;  // задаём позицию по Y открываемой форме
            this.Hide();    // закрываем старую форму
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RulesGame rulesgame = new RulesGame();
            rulesgame.Show();    // открываем новую форму
            rulesgame.Left = this.Left;  // задаём позицию по X открываемой форме
            rulesgame.Top = this.Top;  // задаём позицию по Y открываемой форме
            this.Hide();    // закрываем старую форму
        }


        private void button3_Click(object sender, EventArgs e)
        {
            SaveList savelist = new SaveList();
            savelist.Show();    // открываем новую форму
            savelist.Left = this.Left;  // задаём позицию по X открываемой форме
            savelist.Top = this.Top;  // задаём позицию по Y открываемой форме
            this.Hide();    // закрываем старую форму
        }

    }
}
