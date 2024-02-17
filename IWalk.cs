using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSUIR_Lab_7_Tasks1_2
{
    public interface IWalk
    {
        int Speed { get; set; }
        string? Direction { get; set; }
        int Steps {  get; set; }

        string? GetDirection(); // Получить текущее направление движения
        string? SetDirection(string ?direction);  // Метод задает направление движения.

        int GetCurrentSpeed(); // Получить текущую скорость движения
        int Acceleration(int speed); // Метод для ускорения. Увеличивает  текущую скорость.
        int Deceleration(int speed);  // Метод для уменьшения скорости.

        void AddStep(int count_step); // Метод подсчета шагов
    }
}
