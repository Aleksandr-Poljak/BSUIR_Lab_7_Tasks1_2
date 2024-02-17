using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSUIR_Lab_7_Tasks1_2
{
    public class Bird: IWalk, IFlay
    {
        static readonly string[] directions = { "N", "E", "S", "W", "NE", "SE", "SW", "NW" };
        string name = "unknown";
        string species = "unknown";

        private int height;
        private int speed;
        private string? direction;
        private int steps;
        public int Height
        {
            get { return height; }
            set { if (value >= 0) { height = value; } else throw new Exception("Height Inccorect"); }
        }
        public int Speed
        {
            get { return speed; }
            set { if (value >= 0) speed = value; else throw new Exception("Speed incorrect"); }
        }
        public string? Direction
        {
            get { return direction; }
            set { if (directions.Contains(value) || directions is null) direction = value; else throw new Exception("Incorrect direction"); }
        }
        public int Steps
        {
            get { return steps; }
            set { if (value > steps) steps = value; }
        }


        public Bird() { }
        public Bird(string name, string species) : base()
        {
            this.name = name;
            this.species = species;
        }

        public void AddStep(int step)
        {
            // Метод подсчета шагов
            if (step < 1) throw new Exception("Шагов должен быть больше 0");
            Steps += step;
        }
        // Кастинг
        int IFlay.Acceleration(int add_speed)
        {
            // Метод для ускорения. Увеличивает  текущую скорость. Ограничвает максимальное ускорение при полете
            if (add_speed <= 0) throw new Exception();
            if (add_speed > 20) throw new Exception("слишком высокая скорость.");
            Speed += add_speed;
            return Speed;
        }
        // Кастинг
        int IWalk.Acceleration(int add_speed)
        {
            // Метод для ускорения. Увеличивает  текущую скорость. Ограничвает максимальное ускорение при ходьбе
            if (add_speed <= 0) throw new Exception();
            if (add_speed > 5) throw new Exception("слишком высокая скорость.");
            Speed += add_speed;
            return Speed;
        }
        // Переименование (кастинг + обертывание) 
        public int Accelerate(int add_speed)
        {
            // Добавляет ускорение в зависимости от высоты. Если высота 0 используется реализация метода  интерфейса IWalk
            // Если выше 0 - используется реализация метода  интерфейса IFlay.
            if (Height == 0) return ((IWalk) this).Acceleration(add_speed);
            else
            {
                return ((IFlay)this).Acceleration(add_speed);
            }
        }
        // Склеивание
        public int Deceleration(int r_speed)
        {
            // Метод для уменьшения скорости.
            if (r_speed <= 0) throw new Exception();
            Speed -= r_speed;
            return Speed;
        }
        // Склеивание
        public int GetCurrentSpeed() => Speed; // Получить текущую скорость движения
        // Склеивание
        public string GetDirection() => Direction; // Получить текущее направление движения
        // Склеивание
        public string? SetDirection(string? new_direction)
        {
            // Метод задает направление движения.
            if (Speed == 0 && new_direction is not null) throw new InvalidOperationException("Недвижимому объекту не может быть задано направление движения." +
                $"Текущая скорость {GetCurrentSpeed()} км/ч.");
            Direction = new_direction;
            return Direction;
        }

        public int Down(int r_height)
        {
            // Метод дя снижения высоты
            if (r_height < 1) throw new Exception("Incorrect value");
            Height -= r_height;
            return Height;
        }
        public int Up(int add_height)
        {
            // Метод для набора высота.
            if (add_height < 1) throw new Exception("Incorrect value");
            Height += add_height;
            return Height;
        }

        public override string ToString()
        {
            return $"Птица. Имя: {name}. Вид: {species}. Высота: {Height}м. Скорость: {GetCurrentSpeed()}км/ч. Направление {Direction}." +
                $" Пройдено шагов: {Steps}";
        }
        public void Print()
        {
            Console.WriteLine(this);
        }
    }
}
