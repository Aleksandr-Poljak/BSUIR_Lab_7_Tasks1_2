using BSUIR_Lab_7_Tasks1_2;
// TASK 1
Console.WriteLine("TASK 1");

// interface IFlay, IWalk
Bird duck = new Bird("Donald", "duck");
Bird stork = new Bird("Busel", "stork");
Bird hawk = new Bird("Raptor", "hawk");

// interface IFlay
Bee bee1 = new Bee("bee_1");
Bee bee2 = new Bee("bee_2");
Bee bee3 = new Bee("bee_3");

((IFlay)duck).Acceleration(2); // Кастинг
((IWalk)duck).Acceleration(3); // Кастинг
duck.AddStep(10); // interface IWalk
duck.Up(3);  // interface IFlay
duck.Accelerate(14);// Переименование (кастинг + обертывание) 
duck.SetDirection("N"); // Склеивание
duck.Print(); // Склеивание

// TASK 2
Console.WriteLine("\n" + "TASK 2");
IFlay[] critter = {bee1, bee2,duck, stork, bee3, hawk}; 
foreach(var c in critter)
{
    // Добавить 5 шагов, всем кто поддерживает интерфейс IWalk и вывести на консоль.
    (c as IWalk)?.AddStep(5);
    if(c is IWalk)
    {
        c.Print();
    }
}

