using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HEROGAME
{
    public partial class SaveList : Form
    {
        public SaveList()
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

        private void SaveList_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string path = @"..\..\Players\";       // путь к директории с сохранёными персонажами
            string[] files = Directory.GetFiles(path);      // массив с файлами 
            foreach (string file in files)      // выводим их в listbox
            {
                listBox1.Items.Add(file.Replace(path, "").Replace(".txt", "").Replace("_", " "));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") // если textBox не пустой
            {
                Hero hero = null;   // готовим экземпляр героя
                string path = @"..\..\Players\" + textBox1.Text.Replace(" ", "_") + ".txt"; // путь к файлу сохранения героя
                ArrayList paramHero = new ArrayList() { };  // неопределённый массив для передачи данных о герое

                // передаём информацию о герои из файла в неопределённый массив
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        paramHero.Add(line);
                    }
                }

                // инициализируем тип героя
                if (paramHero[1].ToString() == "Маг") hero = new Mag(paramHero[0].ToString(), paramHero[1].ToString(), paramHero[3].ToString());
                else if (paramHero[1].ToString() == "Воин") hero = new Warrior(paramHero[0].ToString(), paramHero[1].ToString(), paramHero[3].ToString());
                else if (paramHero[1].ToString() == "Рыцарь") hero = new Knight(paramHero[0].ToString(), paramHero[1].ToString(), paramHero[3].ToString());
                else hero = new Warrior(paramHero[0].ToString(), paramHero[1].ToString(), paramHero[3].ToString());

                // перезаписываем поля героя
                hero.Name = (string)paramHero[0]; // Имя
                hero.Type = (string)paramHero[1]; // Тип героя
                hero.Status = (string)paramHero[2];  // Статус ( в игре, мертвый, пенсионер, победитель )
                hero.Gender = (string)paramHero[3];   //  Пол
                hero.Profession = (string)paramHero[4];   //  Профессия
                hero.ActivityStatus = (string)paramHero[5];  //  выполненое действие игроком, которое выводится в label для уведомление ирока
                hero.Level = double.Parse(paramHero[6].ToString());  // Уровень
                hero.Experience = double.Parse(paramHero[7].ToString());  // Опыт
                hero.Age = double.Parse(paramHero[8].ToString()); // Возраст
                hero.Health = double.Parse(paramHero[9].ToString());  // Здоровье
                hero.maxEnergy = double.Parse(paramHero[10].ToString());  // максимальная энергия
                hero.Energy = double.Parse(paramHero[11].ToString());  // Энергия
                hero.Stength = double.Parse(paramHero[12].ToString());  // Сила
                hero.Agility = double.Parse(paramHero[13].ToString());  // Ловкость
                hero.Intelligence = double.Parse(paramHero[14].ToString());  // Интеллект
                hero.Gold = double.Parse(paramHero[15].ToString());  // Золото

                // предаём георя в следующую ворму и закрываем эту
                Gameplay gameplay = new Gameplay(hero);
                gameplay.Show();    // открываем новую форму
                gameplay.Left = this.Left;  // задаём позицию по X открываемой форме
                gameplay.Top = this.Top;  // задаём позицию по Y открываемой форме
                this.Hide();    // закрываем старую форму
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
                textBox1.Text = listBox1.SelectedItem.ToString();
            else textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"..\..\Players\" + textBox1.Text.Replace(" ", "_") + ".txt"; // путь к файлу сохранения героя
            File.Delete(path);
            listBox1.Items.Remove(textBox1.Text);
            textBox1.Text = "";

            //string pathP = @"..\..\Players\";       // путь к директории с сохранёными персонажами
            //string[] files = Directory.GetFiles(pathP);      // массив с файлами 
            //foreach (string file in files)      // выводим их в listbox
            //{
            //    listBox1.Items.Add(file.Replace(pathP, "").Replace(".txt", "").Replace("_", " "));
            //}

        }

        private void SaveList_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }
    }
}
