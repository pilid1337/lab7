class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== ЗАДАНИЕ 1: Метод Sum ===");
        FirstPart.GenerateTask1File();
        int digit;
        do
        {
            Console.Write("Введите цифру (0–9) для отбора чисел: ");
        } while (!int.TryParse(Console.ReadLine(), out digit) || digit < 0 || digit > 9);
        int result = FirstPart.Sum(digit);
        Console.WriteLine($"Результат: {result}\n");


        Console.WriteLine("=== ЗАДАНИЕ 2: Метод Delta ===");
        FirstPart.GenerateTask2File();
        FirstPart.Delta();


        Console.WriteLine("\n=== ЗАДАНИЕ 3: Метод Rewrite ===");
        FirstPart.GenerateTask3File();
        FirstPart.Rewrite();
        Console.WriteLine("Готово. Проверьте созданный файл.\n");


        Console.WriteLine("=== ЗАДАНИЕ 4: Метод NoRepeats ===");
        FirstPart.GenerateTask4File();
        FirstPart.NoRepeats();
        Console.WriteLine("Готово. Проверьте выходной бинарный файл.\n");


        Console.WriteLine("=== ЗАДАНИЕ 5: Метод BinaryAndStruct ===");
        FirstPart.GenerateTask5File();
        FirstPart.BinaryAndStruct();


        Console.WriteLine("\n=== ЗАДАНИЕ 6: Симметрическая разность списков ===");
        SecondPart.Task6_SymmetricDifference();


        Console.WriteLine("\n=== ЗАДАНИЕ 7: Удаление элементов между min и max (LinkedList) ===");
        SecondPart.Task7_RemoveBetweenMinMax();


        Console.WriteLine("\n=== ЗАДАНИЕ 8: Анализ телешоу (HashSet) ===");
        SecondPart.Task8_TVShows();


        Console.WriteLine("\n=== ЗАДАНИЕ 9: Поиск цифр в текстовом файле ===");
        SecondPart.Task9_FindDigitsInTextFile();


        Console.WriteLine("\n=== ЗАДАНИЕ 10: Самый старший человек ===");
        SecondPart.Task10_OldestPerson();
    }
}