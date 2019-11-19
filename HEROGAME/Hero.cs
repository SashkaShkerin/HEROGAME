using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEROGAME
{
    public abstract class HERO
    {
        static Random r = new Random();

        public string Name = "Герой"; // Имя
        public string Type = "Воин"; // Тип героя
        public string Status = "В игре";  // Статус ( в игре, мертвый, пенсионер, победитель )
        public string Gender = "Мужчина";   //  Пол
        public string Profession = "Воин";   //  Профессия
        public string ActivityStatus = "";   //  выполненое действие игроком, которое выводится в label для уведомление ирока
        public double Level = 1;  // Уровень
        public double Experience = 0;  // Опыт
        public double Age = 15; // Возраст
        public double Health = 150;  // Здоровье
        public double maxEnergy = 300;  // максимальная энергия
        public double Energy = 300;  // Энергия
        public double Stength = 25;  // Сила
        public double Agility = 15;  // Ловкость
        public double Intelligence = 20;  // Интеллект
        public double Gold = r.Next(1000, 1501);  // Золото

        public void checkingFields(Gameplay gameplay) // проверка полей на условия игры
        {
            // округляем поля героя
            this.Level = Math.Round(Level, 0);
            this.Experience = Math.Round(Experience, 0);
            this.Age = Math.Round(Age, 0);
            this.Gold = Math.Round(Gold, 0);
            this.Health = Math.Round(Health, 0);
            this.Stength = Math.Round(Stength, 0);
            this.Energy = Math.Round(Energy, 0);
            this.Agility = Math.Round(Agility, 0);
            this.Intelligence = Math.Round(Intelligence, 0);

            // Проверяем здоровье
            if (this.Health <= 0)
            {
                this.Health = 0;
                this.ActivityStatus = "Игрок умер";
                this.Status = this.ActivityStatus;
                this.gameOverHero(gameplay, this.Status);
            }
            else if (this.Health > 150)
            {
                this.Health = 150;
            }

            // контроль опыта
            if (this.Experience >= 100)
            {
                this.Experience -= 100;
                this.Level++;
                this.Gold += 500;
                this.Intelligence += 5;  // Интеллект
                this.ActivityStatus = "Уровень повышен: золота +500, интелект +5";
            }

            // контроль уровня
            if (this.Level == 10)
            {
                this.ActivityStatus = "Игрок победил";
                this.Status = this.ActivityStatus;
                this.gameOverHero(gameplay, this.Status);
            }

            // Проверяем возраст
            if (this.Age >= 100) 
            {
                this.Age = 100;
                this.ActivityStatus = "Игрок состарелся";
                this.Status = this.ActivityStatus;
                this.gameOverHero(gameplay, this.Status);
            }

            // проверяем максимальное возможное значение энергии
            int shiftEner = -10;
            for (int ageCount = 15; ageCount < 100; ageCount += 5)
            {
                shiftEner += 10;
                if (this.Age >= ageCount && this.Age <= ageCount + 4) this.maxEnergy = 300 - shiftEner;
            }

            // проверяем энергию
            if (this.Energy > this.maxEnergy)
            {
                this.Energy = this.maxEnergy;
            }
            else if (this.Energy <= 0)
            {
                this.Energy = 0;
                this.ActivityStatus = "Надо бы отдохнуть";
                // прячим все кнопки действия кроме отдыхать
                gameplay.button3.Visible = false;
                gameplay.button5.Visible = false;
                gameplay.button6.Visible = false;
                gameplay.button7.Visible = false;
                gameplay.button1.Visible = false;
                gameplay.button2.Visible = false;
                gameplay.button11.Visible = false;
                gameplay.button12.Visible = false;
                gameplay.button13.Visible = false;
                gameplay.button8.Visible = false;
                gameplay.button9.Visible = false;
                gameplay.button10.Visible = false;
            }

            if (this.Gold <= 0)
            {
                this.Gold = 0;
                this.ActivityStatus = "Золото закончилось";
            }
        }

        public abstract void info(Gameplay gameplay);  // Вывод информации о герои
        public virtual void job()  // Работать
        {
            this.Energy -= 7;
            this.Gold += 150;
            this.ActivityStatus = "Поработали: энергия -7, золото +150";
        }
        public void rest() // Отдых
        {
            this.Health = 150;
            this.Age += 1;
            this.Energy = maxEnergy;

            this.ActivityStatus = "Отдохнули: здоровье "+this.Health+ ", энергии " + this.Energy + ", возраст +1:" + this.Age;

        }
        public void eat(string eat) // Кушать
        {
            if (eat == "хлеб")
            {
                if (this.Gold >= 30)
                {
                    this.Health += 5;
                    this.Energy += 10;
                    this.Gold -= 30;
                    this.ActivityStatus = "Покушали: здоровье +5, энергии +10, золота -30";
                }
                else this.ActivityStatus = "Не хватает денег!";
            }
            else if (eat == "яблоко")
            {
                if (this.Gold >= 50)
                {
                    this.Health += 7;
                    this.Energy += 15;
                    this.Gold -= 50;
                    this.ActivityStatus = "Покушали: здоровье +7, энергии +15, золота -50";
                }
                else this.ActivityStatus = "Не хватает денег!";
        }
            else if (eat == "рис")
            {
                if (this.Gold >= 120)
                {
                    this.Health += 10;
                    this.Energy += 30;
                    this.Gold -= 120;
                    this.ActivityStatus = "Покушали: здоровье +10, энергии +30, золота -120";
                }
                else this.ActivityStatus = "Не хватает денег!";
            }
        }
        public void trainings(string train) // тренировки
        {
            if (train == "сила")
            {
                if (this.Gold >= 100)
                {
                    int stength = r.Next(1, 6);
                    this.Stength += stength;
                    this.Energy -= 5;
                    this.Gold -= 100;
                    this.ActivityStatus = "Потренировались: сила +" + stength + ", энергии -5, золота -100";
                }
                else this.ActivityStatus = "Не хватает денег!";
            }
            else if (train == "интелект")
            {
                if (this.Gold >= 100)
                {
                    int intelligence = r.Next(1, 6);
                    this.Intelligence += r.Next(1, 6);
                    this.Energy -= 5;
                    this.Gold -= 100;
                    this.ActivityStatus = "Потренировались: сила +" + intelligence + ", энергии -5, золота -100";
                }
                else this.ActivityStatus = "Не хватает денег!";
            }
            else if (train == "ловкость")
            {
                if (this.Gold >= 100)
                {
                    int agility = r.Next(1, 6);
                    this.Agility += r.Next(1, 6);
                    this.Energy -= 5;
                    this.Gold -= 100;
                    this.ActivityStatus = "Потренировались: сила +" + agility + ", энергии -5, золота -100";
                }
                else this.ActivityStatus = "Не хватает денег!";
            }
        }
        public void adventure(Gameplay gameplay)  // Поиск приключений
        { 
            double probability = r.Next(0, 51);  // вероятность события
            // 0 - 9 = ничего (вероятность 10)
            // 10 - 14 = клад (вероятность 5)
            // 15 - 35 = монст (вероятность 21)
            // 36 - 45 = испытание (вероятность 10)
            // 46 - 50 = фонтан здоровья (вероятность 5)

            if (probability >= 0 && probability <= 9)  // ничего не происходит
            {
                this.ActivityStatus = "Не повезло, ничего не случилось, а может и удачно.. ";
            }
            else if (probability >= 10 && probability <= 14)  // найден клад
            {
                int gold = r.Next(500, 701);
                int experience = r.Next(10, 21);

                this.Gold += gold;
                this.Experience += experience;
                this.Energy += 10;

                this.ActivityStatus = "Найден клад: золото +" + gold + ", опыт +" + experience + ", энергия +10";
            }
            else if (probability >= 15 && probability <= 35)  // наткнулись на монстра
            {
                this.ActivityStatus = "Наткнулись на монстра";  // изменяем статус игры
                gameplay.battlefield(true);  // создаём поле битвы
            }
            else if (probability >= 36 && probability <= 45)  // испытание
            {
                int stength = r.Next(5, 11);
                int agility = r.Next(5, 11);
                int intelligence = r.Next(5, 11);

                this.Stength += stength; 
                this.Agility += agility;
                this.Intelligence += intelligence;
                this.Energy -= 10;

                this.ActivityStatus = "Испытание: сила +" + stength + ", ловкость +" + agility + ", интелект +" + intelligence + ", энергия -10";

            }
            else if (probability >= 46 && probability <= 50)  // фонтан здоровья
            {
                this.Health = 150;
                this.Energy = maxEnergy;
                this.ActivityStatus = "Найден фонтан здоровья: здоровье max, энергия max";
            }

        }
        
        async public void gameOverHero(Gameplay gameplay, string status)  // Конец игры
        {
            // скрываем главные функциональные кнопки
            gameplay.button3.Visible = false;
            gameplay.button4.Visible = false;
            gameplay.button5.Visible = false;
            gameplay.button6.Visible = false;
            gameplay.button7.Visible = false;

            await Task.Delay(3000);

            gameplay.pictureBox1.Location = new Point(130, 45);
            gameplay.finishHideFormElem(this.Status);
            gameplay.button14.Visible = true;

            if (status == "Игрок умер")
            {
                gameplay.pictureBox1.Image = HEROGAME.Properties.Resources.Skull;
                gameplay.label26.Text = status;
            }
            else if (status == "Игрок победил")
            {
                gameplay.label26.Text = status;
            }
            else if (status == "Игрок состарелся")
            {
                gameplay.pictureBox1.Image = HEROGAME.Properties.Resources.Skull;
                gameplay.label26.Text = status;
            }
        }
    }

    public class Hero : HERO
    { 

        public override void info(Gameplay gameplay)  // Вывод информации о герои
        {
            this.checkingFields(gameplay);
            //this.gameOverHero(gameplay, "Умер");

            gameplay.label2.Text = Name;
            gameplay.label3.Text = ActivityStatus;
            gameplay.label12.Text = Level.ToString();
            gameplay.label13.Text = Experience.ToString();
            gameplay.label14.Text = Age.ToString();
            gameplay.label15.Text = Gold.ToString();
            gameplay.label16.Text = Health.ToString();
            gameplay.label17.Text = Stength.ToString();
            gameplay.label18.Text = Energy.ToString();
            gameplay.label19.Text = Agility.ToString();
            gameplay.label20.Text = Intelligence.ToString();
        }
    }

    public class Warrior : Hero  // Воины
    {

        public Warrior(string name, string gender, string profession)
        {
            Name = name; // Имя
            Gender = gender;   //  Пол
            Profession = profession;   //  Профессия
            Type = "Воин";   //  Тип
            if (Gender == "Мужчина")
            {
                Stength = 25;  // Сила
                Agility = 15;  // Ловкость
            }
            else if (Gender == "Женщина")
            {
                Stength = 15;  // Сила
                Agility = 25;  // Ловкость
            }

        }
        public override void job()  // Работать
        {
            this.Energy -= 10;
            this.Gold += 200;
            this.ActivityStatus = "Поработали: энергия -10, золото +200";
        }
    }

    public class Mag : Hero  // Маги
    {

        public Mag(string name, string gender, string profession)
        {
            Name = name; // Имя
            Type = "Маг";   //  Тип
            Gender = gender;   //  Пол
            Profession = profession;   //  Профессия
            if (Gender == "Мужчина")
            {
                Stength = 25;  // Сила
                Agility = 15;  // Ловкость
            }
            else if (Gender == "Женщина")
            {
                Stength = 15;  // Сила
                Agility = 25;  // Ловкость
            }
        }
        public override void job()  // Работать
        {
            this.Energy -= 5;
            this.Gold += 200;
            this.ActivityStatus = "Поработали: энергия -5, золото +200";
        }

    }

    public class Knight : Hero  // Рыцари
    {
        public Knight(string name, string gender, string profession)
        {
            Name = name; // Имя
            Type = "Рыцарь";   //  Тип
            Gender = gender;   //  Пол
            Profession = profession;   //  Профессия
            if (Gender == "Мужчина")
            {
                Stength = 25;  // Сила
                Agility = 15;  // Ловкость
            }
            else if (Gender == "Женщина")
            {
                Stength = 15;  // Сила
                Agility = 25;  // Ловкость
            }
        }
        public override void job()  // Работать
        {
            this.Energy -= 15;
            this.Gold += 250;
            this.ActivityStatus = "Поработали: энергия -15, золото +250";
        }
    }

}
