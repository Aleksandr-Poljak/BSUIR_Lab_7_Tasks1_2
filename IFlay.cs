using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSUIR_Lab_7_Tasks1_2
{
    public interface IFlay
    {
        int Height { get; set; }
        int Speed { get; set; }
        string ?Direction { get; set; }

        int Down( int height); // Метод дя снижения высоты
        int Up( int height); // Метод для набора высота.
        int GetCurrentSpeed(); // Получить текущую скорость движения
        int Acceleration( int speed ); // Метод для ускорения. Увеличивает  текущую скорость.
        int Deceleration( int speed );  // Метод для уменьшения скорости.

        string ?GetDirection(); // Получить текущее направление движения
        string ?SetDirection( string ?direction );  // Метод задает направление движения.


        void Print()
        {
            Console.WriteLine($"Current height: {Height} m.\nCurrent speed: {(double)Speed / 1000} km/h.\nCurrent direction: {Direction}");
        }
    }
}
