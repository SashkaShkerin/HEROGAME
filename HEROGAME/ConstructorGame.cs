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
    public partial class ConstructorGame : Form
    {


        public ConstructorGame()
        {
            InitializeComponent();
        }

        // переменные для параметров введёных пользователем, передаваемые в конструктор классов героя
        public string gender = "";  // Пол
        public string name = "";   //  Имя 
        public string profession = "";  // Профессия

        private void button6_Click(object sender, EventArgs e)
        {
            label5.Text = "Мужчина";  // выводим выбранный пол
            gender = "Мужчина";  // пользователь выбрал мужской пол
            
            // подставляем подходящую полу картинку в зависимости выбраной професии и полу
            if (profession == "Воин")
            {
                pictureBox1.Image = HEROGAME.Properties.Resources.hm;
            }
            else if (profession == "Рыцарь")
            {
                pictureBox1.Image = HEROGAME.Properties.Resources.rm;
            }
            else if (profession == "Маг")
            {
                pictureBox1.Image = HEROGAME.Properties.Resources.wm;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label5.Text = "Женщина";  // выводим выбранный пол
            gender = "Женщина"; // пользователь выбрал женский пол

            // подставляем подходящую полу картинку в зависимости выбраной професии и полу
            if (profession == "Воин")
            {
                pictureBox1.Image = HEROGAME.Properties.Resources.hw;
            }
            else if (profession == "Рыцарь")
            {
                pictureBox1.Image = HEROGAME.Properties.Resources.rw;
            }
            else if (profession == "Маг")
            {
                pictureBox1.Image = HEROGAME.Properties.Resources.ww;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;  // Выводим имя в label
            name = textBox1.Text;   // сохраняем имя для передачи в конструктор

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // пользователь выбрал профессию маг
            // если пользователь уже выбрал пол, то меняем картинку профессии на подходящий пол

            if (gender == "Мужчина")
            {
                pictureBox1.Image = HEROGAME.Properties.Resources.wm;
                profession = "Маг";
            }
            else if (gender == "Женщина")
            {
                pictureBox1.Image = HEROGAME.Properties.Resources.ww;
                profession = "Маг";
            }
            else
            {
                pictureBox1.Image = HEROGAME.Properties.Resources.Skull;
                profession = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // пользователь выбрал профессию рыцарь
            // если пользователь уже выбрал пол, то меняем картинку профессии на подходящий пол

            if (gender == "Мужчина")
            {
                pictureBox1.Image = HEROGAME.Properties.Resources.rm;
                profession = "Рыцарь";
            }
            else if (gender == "Женщина")
            {
                pictureBox1.Image = HEROGAME.Properties.Resources.rw;
                profession = "Рыцарь";
            }
            else
            {
                pictureBox1.Image = HEROGAME.Properties.Resources.Skull;
                profession = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // пользователь выбрал профессию воин
            // если пользователь уже выбрал пол, то меняем картинку профессии на подходящий пол

            if (gender == "Мужчина")
            {
                pictureBox1.Image = HEROGAME.Properties.Resources.hm;
                profession = "Воин";
            }
            else if (gender == "Женщина")
            {
                pictureBox1.Image = HEROGAME.Properties.Resources.hw;
                profession = "Воин";
            }
            else
            {
                pictureBox1.Image = HEROGAME.Properties.Resources.Skull;
                profession = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // проверяем все условия для создания героя

            if (name == "") label7.Visible = true;
            else label7.Visible = false;

            if (gender == "") label8.Visible = true;
            else label8.Visible = false;

            if (profession == "") label9.Visible = true;
            else label9.Visible = false;

            if (name != "" && gender != "" && profession != "")
            {
                Hero hero = null; 

                // инициализируем тип героя
                if (profession == "Маг") hero = new Mag(name, gender, profession);
                else if (profession == "Воин") hero = new Warrior(name, gender, profession);
                else if (profession == "Рыцарь") hero = new Knight(name, gender, profession);
                else hero = new Warrior(name, gender, profession);

                // предаём георя в следующую ворму и закрываем эту
                Gameplay gameplay = new Gameplay(hero);
                gameplay.Show();    // открываем новую форму
                gameplay.Left = this.Left;  // задаём позицию по X открываемой форме
                gameplay.Top = this.Top;  // задаём позицию по Y открываемой форме
                this.Hide();    // закрываем старую форму
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();    // открываем новую форму
            form1.Left = this.Left;  // задаём позицию по X открываемой форме
            form1.Top = this.Top;  // задаём позицию по Y открываемой форме
            this.Hide();    // закрываем старую форму
        }

    }
}
