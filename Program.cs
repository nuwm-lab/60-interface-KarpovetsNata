using System;

namespace TriangleApp
{
    // ======= Абстрактний базовий клас =======
    abstract class TriangleBase
    {
        // Спільні поля
        public double perimeter;

        // Абстрактні методи (обов’язково реалізуються у нащадках)
        public abstract void Init();
        public abstract void Show();
        public abstract double Perimeter();
    }

    // ======= Клас "Рівносторонній трикутник" =======
    class EquilateralTriangle : TriangleBase
    {
        private double side;
        private double angle = 60; // всі кути по 60°

        // Задання значення сторони
        public override void Init()
        {
            Console.Write("Введіть довжину сторони рівностороннього трикутника: ");
            side = Convert.ToDouble(Console.ReadLine());
        }

        // Виведення характеристик
        public override void Show()
        {
            Console.WriteLine("\n--- Рівносторонній трикутник ---");
            Console.WriteLine($"Сторона: {side}");
            Console.WriteLine($"Кути: {angle}, {angle}, {angle}");
        }

        // Обчислення периметра
        public override double Perimeter()
        {
            perimeter = 3 * side;
            Console.WriteLine($"Периметр = {perimeter:F2}");
            return perimeter;
        }
    }

    // ======= Клас "Трикутник" (задані сторона і два кути) =======
    class Triangle : TriangleBase
    {
        private double sideA;
        private double angleB;
        private double angleC;

        // Задання значень сторони і двох кутів
        public override void Init()
        {
            Console.Write("Введіть довжину сторони a: ");
            sideA = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введіть значення кута B (у градусах): ");
            angleB = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введіть значення кута C (у градусах): ");
            angleC = Convert.ToDouble(Console.ReadLine());
        }

        // Виведення характеристик
        public override void Show()
        {
            double angleA = 180 - (angleB + angleC);
            Console.WriteLine("\n--- Звичайний трикутник ---");
            Console.WriteLine($"Сторона a = {sideA}");
            Console.WriteLine($"Кути: A = {angleA}, B = {angleB}, C = {angleC}");
        }

        // Обчислення периметра
        public override double Perimeter()
        {
            double angleA = 180 - (angleB + angleC);
            double radA = angleA * Math.PI / 180;
            double radB = angleB * Math.PI / 180;
            double radC = angleC * Math.PI / 180;

            // закон синусів
            double b = sideA * Math.Sin(radB) / Math.Sin(radA);
            double c = sideA * Math.Sin(radC) / Math.Sin(radA);

            perimeter = sideA + b + c;
            Console.WriteLine($"Периметр = {perimeter:F2}");
            return perimeter;
        }
    }

    // ======= Головна програма =======
    class Program
    {
        static void Main(string[] args)
        {
            int userChoice;
            TriangleBase triangle; // покажчик на базовий абстрактний клас

            do
            {
                Console.WriteLine("\nОберіть тип трикутника:");
                Console.WriteLine("0 - Рівносторонній трикутник");
                Console.WriteLine("1 - Звичайний трикутник (задана сторона і два кути)");
                Console.WriteLine("Інше - вихід");
                Console.Write("Ваш вибір: ");
                userChoice = Convert.ToInt32(Console.ReadLine());

                if (userChoice == 0)
                    triangle = new EquilateralTriangle();
                else if (userChoice == 1)
                    triangle = new Triangle();
                else
                    return;

                // Робота через абстрактний покажчик
                triangle.Init();
                triangle.Show();
                triangle.Perimeter();

            } while (true);
        }
    }
}

