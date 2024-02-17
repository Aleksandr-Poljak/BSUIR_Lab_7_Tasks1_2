using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BSUIR_Lab_7_Tasks1_2
{
    public class Bee: IFlay
    {
        static readonly string[] directions = {"N", "E", "S", "W", "NE", "SE", "SW", "NW"};

        string name = "unknown";

        private int height;
        private int speed;
        private string? direction;
        public int Height {
            get {  return height; }           
            set{ if (value >= 0) { height = value; } else throw new Exception("Height Inccorect"); }
                  }
        public int Speed {
            get { return speed; }
            set { if (value >= 0) speed = value; else throw new Exception("Speed incorrect"); }
        }
        public string? Direction 
        {
            get { return direction; }
            set { if (directions.Contains(value) || directions is null) direction = value; else throw new Exception("Incorrect direction"); }
        }

        public Bee() { }
        public Bee(string name) : base()
        {
            this.name = name;
        }

        public int Down( int r_height)
        {
            if (r_height < 1) throw new Exception("Incorrect value");
            Height -= r_height;
            return Height;
        }
        public int Up(int add_height)
        {
            if (add_height < 1) throw new Exception("Incorrect value");
            Height += add_height;
            return Height;
        }

        public int GetCurrentSpeed() => Speed;
        public int Acceleration(int add_speed)
        {
            if (add_speed <= 0) throw new Exception();
            Speed += add_speed;
            return Speed;
        }
        public int Deceleration(int r_speed)
        {
            if (r_speed <= 0) throw new Exception();
            Speed -= r_speed;
            return Speed;
        }
        public void Stop()
        {
            Speed = 0;
            Direction = null;
            Height = 0;

        }

        public string ?GetDirection() => Direction;
        public string ?SetDirection(string? new_direction)
        {
            if (Speed == 0 && new_direction is not null) throw new InvalidOperationException("Недвижимому объекту не может быть задано направление движения." +
                $"Текущая скорость {GetCurrentSpeed()} км/ч.");
            Direction = new_direction;
            return Direction;
        }
        public override string ToString()
        {
            return $"Пчела. Имя: {name}. Высота: {Height}м. Скорость: {GetCurrentSpeed()}км/ч. Направление {Direction}";
        }
        public void Print()
        {
            Console.WriteLine(this);
        }
    }
}
