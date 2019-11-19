using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HEROGAME
{
    public partial class Gameplay : Form
    {
        Random r = new Random();
        public Hero hero;
        public Monstr monstr; 
        public Gameplay()
        {
            InitializeComponent();
        }

        public Gameplay(Hero hero1)
        {
            InitializeComponent();
            hero = hero1;
        }


        private void Gameplay_Load(object sender, EventArgs e)
        {
            hero.info(this);

            // назначаем картинку героя
            if (hero.Type == "Воин")
            {
                if (hero.Gender == "Мужчина") pictureBox1.Image = HEROGAME.Properties.Resources.hm;
                else if (hero.Gender == "Женщина") pictureBox1.Image = HEROGAME.Properties.Resources.hw;
                else pictureBox1.Image = HEROGAME.Properties.Resources.Skull;
            }
            else if (hero.Type == "Маг")
            {
                if (hero.Gender == "Мужчина") pictureBox1.Image = HEROGAME.Properties.Resources.wm;
                else if (hero.Gender == "Женщина") pictureBox1.Image = HEROGAME.Properties.Resources.ww;
                else pictureBox1.Image = HEROGAME.Properties.Resources.Skull;
            }
            else if (hero.Type == "Рыцарь")
            {
                if (hero.Gender == "Мужчина") pictureBox1.Image = HEROGAME.Properties.Resources.rm;
                else if (hero.Gender == "Женщина") pictureBox1.Image = HEROGAME.Properties.Resources.rw;
                else pictureBox1.Image = HEROGAME.Properties.Resources.Skull;
            }
        }

        // подготовка поля битвы с монстром
        async public void battlefield(bool create)    // create == true - создать поле, false - удалить
        {
            if (create)
            {
                hideBtnOption(); // скрываем кнопки вида еды и тренировок
                // скрываем главные функциональные кнопки
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                // показываем елементы взаимодействия с монстром
                button1.Visible = true;
                button2.Visible = true;
                label21.Visible = true;
                label22.Visible = true;
                label23.Visible = true;
                label24.Visible = true;
                label28.Visible = true;
                pictureBox2.Visible = true;
                pictureBox1.Location = new System.Drawing.Point(242, 184);
                pictureBox1.BackColor = Color.FromArgb(133, 255, 94);
                // задаём рандомную картинку монстра
                double monstrVer = r.Next(0, 5);
                if (monstrVer >= 0 && monstrVer < 1) pictureBox2.Image = HEROGAME.Properties.Resources.M1;
                else if (monstrVer >= 1 && monstrVer < 2) pictureBox2.Image = HEROGAME.Properties.Resources.M2;
                else if (monstrVer >= 2 && monstrVer < 3) pictureBox2.Image = HEROGAME.Properties.Resources.M3;
                else if (monstrVer >= 3 && monstrVer <= 4) pictureBox2.Image = HEROGAME.Properties.Resources.M4;
                // создаём монстра
                monstr = new Monstr(r.Next(100, 201), r.Next((int)hero.Stength - 5, (int)hero.Stength + 6)); // здоровье, сила
                label23.Text = monstr.Health.ToString();
                label22.Text = monstr.Stength.ToString();
            }
            else
            {
                // показываем главные функциональные кнопки
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                // прячим елементы взаимодействия с монстром
                button1.Visible = false;
                button2.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                label23.Visible = false;
                label24.Visible = false;
                label28.Visible = false;
                pictureBox2.Visible = false;
                pictureBox1.Location = new System.Drawing.Point(195, 85);
                await Task.Delay(3000);
                pictureBox1.BackColor = Color.Transparent; // смнимаем выделение
                pictureBox2.BackColor = Color.Transparent; // смнимаем выделение
            }
        }


        public bool activeBtntTrainings = false;
        public bool activeBtntEat = false;
        public void hideBtnOption() // скрываем все дополнительные кнопки выбора еды и тренировки 
        {
            activeBtntEat = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            activeBtntTrainings = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
        }
        private void button6_Click(object sender, EventArgs e) // кнопка "тренироваться"
        {
            if (activeBtntTrainings)
            {
                hideBtnOption(); // скрываем все дополнительные кнопки
            }
            else
            {
                hideBtnOption(); // скрываем все ранне открытые дополнительные кнопки
                activeBtntTrainings = true; // показываем кнопки выбора тренировки
                button11.Visible = true;
                button12.Visible = true;
                button13.Visible = true;
            }
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            if (activeBtntEat)
            {
                hideBtnOption(); // скрываем все дополнительные кнопки
            }
            else
            {
                hideBtnOption(); // скрываем все ранне открытые дополнительные кнопки
                activeBtntEat = true;
                button8.Visible = true;
                button9.Visible = true;
                button10.Visible = true;
            }
        }

        // тренируем силу
        private void button11_Click(object sender, EventArgs e)
        {
            hero.trainings("сила");
            hero.info(this);
        }

        // тренируем интелект
        private void button12_Click(object sender, EventArgs e)
        {
            hero.trainings("интелект");
            hero.info(this);
        }

        // тренируем ловкость
        private void button13_Click(object sender, EventArgs e)
        {
            hero.trainings("ловкость");
            hero.info(this);
        }

        // кушаем хлеб
        private void button8_Click(object sender, EventArgs e)
        {
            hero.eat("хлеб");
            hero.info(this);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            hero.eat("яблоко");
            hero.info(this);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            hero.eat("рис");
            hero.info(this);
        }

        // поиск приключений
        private void button3_Click(object sender, EventArgs e)
        {
            hideBtnOption();
            hero.adventure(this);
            hero.info(this);
            pictureBox1.BackColor = Color.Transparent;
        }

        // отдых
        private void button4_Click(object sender, EventArgs e)
        {
            hideBtnOption(); // скрываем все дополнительные кнопки
            hero.info(this);
            hero.rest();
        }
        
        // работать
        private void button5_Click(object sender, EventArgs e)
        {
            hideBtnOption(); // скрываем все дополнительные кнопки
            hero.job();
            hero.info(this);
        }

        // бьём монстра
        async private void button1_Click(object sender, EventArgs e)
        {
                if (hero.Health > 0)
                {
                    monstr.Health -= hero.Stength;
                    if (monstr.Health > 0)
                    {
                        monstr.writeMonstr(this); // выодим информацию о монстре
                        pictureBox2.BackColor = Color.FromArgb(255, 94, 94); // gподсвечиваем монстра красным цветом
                        label25.Text = "Монстр: -" + hero.Stength;  // выводим в центр экрана полученный урон
                        hero.ActivityStatus = "Вы ударили монстра";
                        await Task.Delay(1000); // через секунду

                        pictureBox1.BackColor = Color.Transparent; // смнимаем выделение
                        pictureBox2.BackColor = Color.Transparent; // смнимаем выделение
                        label25.Text = "";
                        await Task.Delay(1000); // через секунду

                        pictureBox2.BackColor = Color.FromArgb(133, 255, 94);   // ход монстра, зелёный
                        await Task.Delay(1000); // через секунду

                        // удаярем игрока и выводи полученный урон 
                        double uron = monstr.hitHero(hero);
                        label25.Text = "Игрок: -" + uron;
                        hero.info(this);
                        pictureBox1.BackColor = Color.FromArgb(255, 94, 94); // получен урок, красный
                        await Task.Delay(1000); // через секунду

                        label25.Text = "";
                        pictureBox1.BackColor = Color.Transparent; // снимаем выделение
                        pictureBox2.BackColor = Color.Transparent; // смнимаем выделение
                        label25.Text = "";
                        if (hero.Health > 0) // если игрок жив, подкрашиваем его ход
                        {
                            pictureBox1.BackColor = Color.FromArgb(133, 255, 94);   // ход персонажа, зелёный
                        }
                        else // иначе проверяем его состояние
                        {
                            battlefield(false); // убираем поле боя 
                            hero.Status = "Умер";
                            hero.info(this);
                        }
                    }
                    else
                    {
                        // монстр убит
                        monstr.Health = 0;  // если жизнь ушла в минус
                        pictureBox2.Image = HEROGAME.Properties.Resources.Skull;    // монстр убит
                        monstr.writeMonstr(this);   // выводим данные монстра
                        // геолй получает опыт
                        hero.Experience += monstr.Stength;
                        hero.ActivityStatus = "Получиенно опыта: +" + monstr.Stength;
                        hero.info(this);
                        await Task.Delay(1000); // через секунду
                        battlefield(false); // убираем поле боя 
                    }
                }
                else
                {
                    battlefield(false); // убираем поле боя 
                    hero.Status = "Умер";
                    hero.info(this);
                }
        }

        async private void button2_Click(object sender, EventArgs e)
        {
            hero.Gold -= Math.Round(hero.Gold * (hero.Intelligence / 100));
            hero.Energy -= monstr.Health;
            hero.ActivityStatus = "Сбежали: золото -" + Math.Round(hero.Gold * (hero.Intelligence / 100), 0) + ", энергия -" + monstr.Health;
            hero.info(this);
            await Task.Delay(1000); // через секунду
            battlefield(false); // убираем поле боя 
        }

        public void finishHideFormElem(string gameStatus) 
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();    // открываем новую форму
            form1.Left = this.Left;  // задаём позицию по X открываемой форме
            form1.Top = this.Top;  // задаём позицию по Y открываемой форме
            this.Hide();    // закрываем старую форму
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // записываем игрока в фаил если он победил
            string path = @"..\..\Players\" + hero.Name.Trim().Replace(" ", "_") + ".txt";

            using (FileStream fs = new FileStream(path, FileMode.Create ))
            {
                using (StreamWriter stream = new StreamWriter(fs))
                {
                    stream.WriteLine(hero.Name);
                    stream.WriteLine(hero.Type);
                    stream.WriteLine(hero.Status);
                    stream.WriteLine(hero.Gender);
                    stream.WriteLine(hero.Profession);
                    stream.WriteLine(hero.ActivityStatus);
                    stream.WriteLine(hero.Level);
                    stream.WriteLine(hero.Experience);
                    stream.WriteLine(hero.Age);
                    stream.WriteLine(hero.Health);
                    stream.WriteLine(hero.maxEnergy);
                    stream.WriteLine(hero.Energy);
                    stream.WriteLine(hero.Stength);
                    stream.WriteLine(hero.Agility);
                    stream.WriteLine(hero.Intelligence);
                    stream.WriteLine(hero.Gold);
                }
            }
        }

        private void button16_MouseEnter(object sender, EventArgs e)
        {
            label27.Text = "В меню";
        }

        private void button16_MouseLeave(object sender, EventArgs e)
        {
            label27.Text = "";
        }

        private void button15_MouseEnter(object sender, EventArgs e)
        {
            label27.Text = "Сохраниться";
        }

        private void button15_MouseLeave(object sender, EventArgs e)
        {
            label27.Text = "";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // записываем игрока в фаил если он победил
            string path = @"..\..\Players\" + hero.Name.Trim().Replace(" ", "_") + ".txt";

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter stream = new StreamWriter(fs))
                {
                    stream.WriteLine(hero.Name);
                    stream.WriteLine(hero.Type);
                    stream.WriteLine(hero.Status);
                    stream.WriteLine(hero.Gender);
                    stream.WriteLine(hero.Profession);
                    stream.WriteLine(hero.ActivityStatus);
                    stream.WriteLine(hero.Level);
                    stream.WriteLine(hero.Experience);
                    stream.WriteLine(hero.Age);
                    stream.WriteLine(hero.Health);
                    stream.WriteLine(hero.maxEnergy);
                    stream.WriteLine(hero.Energy);
                    stream.WriteLine(hero.Stength);
                    stream.WriteLine(hero.Agility);
                    stream.WriteLine(hero.Intelligence);
                    stream.WriteLine(hero.Gold);
                }
            }

            Form1 form1 = new Form1();
            form1.Show();    // открываем новую форму
            form1.Left = this.Left;  // задаём позицию по X открываемой форме
            form1.Top = this.Top;  // задаём позицию по Y открываемой форме
            this.Hide();    // закрываем старую форму
        }

    }
}
