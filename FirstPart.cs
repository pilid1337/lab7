using System.Xml.Serialization;
class FirstPart
{
    public static int Sum(int inpDigit)
    {
        string s;
        int intString;
        int digit;
        int sum = 0;

        try
        {
            Console.Write("Введите имя исходного файла: ");
            string name = Console.ReadLine();

            using (FileStream fP = new FileStream(name, FileMode.Open))
            using (StreamReader f = new StreamReader(fP))
            {
                while ((s = f.ReadLine()) != null)
                {
                    intString = int.Parse(s);
                    digit = int.Abs(intString);
                    while (digit > 10)
                    {
                        digit /= 10;
                    }
                    if (digit == inpDigit)
                    {
                        sum += intString;
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return 0;
        }

        return sum;
    }

    public static void Delta()
    {
        string s;
        string[] stringArray;
        int[] intArray;
        int min;

        try
        {
            Console.Write("Введите имя исходного файла: ");
            string name = Console.ReadLine();

            using (FileStream fP = new FileStream(name, FileMode.Open))
            using (StreamReader f = new StreamReader(fP))
            {
                while ((s = f.ReadLine()) != null)
                {
                    stringArray = s.Split();
                    intArray = Array.ConvertAll(stringArray, int.Parse);

                    min = intArray[0];

                    foreach (var num in intArray)
                    {
                        if (num < min)
                        {
                            min = num;
                        }
                    }

                    Console.WriteLine("Разница первого с минимальным: "
                        + (intArray[0] - min));
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }
    }

    public static void Rewrite()
    {
        string s;
        bool hasPunctuation;
        char[] punctuationMarks = ['.', ',', '!', '?', '-', ';', '"'];

        try
        {
            Console.Write("Введите имя исходного файла: ");
            string name = Console.ReadLine();

            using (FileStream inpFileP = 
                new FileStream(name, FileMode.Open))
            using (StreamReader inpFile = new StreamReader(inpFileP))
            {
                Console.Write("Введите имя нового файла: ");
                name = Console.ReadLine();

                using (FileStream newFileP = 
                    new FileStream(name, FileMode.Create))
                using (StreamWriter newFile = 
                    new StreamWriter(newFileP))
                {
                    while ((s = inpFile.ReadLine()) != null)
                    {
                        hasPunctuation = false;

                        foreach (var mark in punctuationMarks)
                        {
                            if (s.Contains(mark))
                            {
                                hasPunctuation = true;
                                break;
                            }
                        }

                        if (!hasPunctuation)
                        {
                            newFile.WriteLine(s);
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }
    }

    public static void NoRepeats()
    {
        try
        {
            Console.Write("Введите имя исходного файла: ");
            string name = Console.ReadLine();

            using (FileStream inpFileP = 
                new FileStream(name, FileMode.Open))
            using (BinaryReader inpFile = 
                new BinaryReader(inpFileP))
            {
                Console.Write("Введите имя нового файла: ");
                name = Console.ReadLine();

                using (FileStream newFileP = 
                    new FileStream(name, FileMode.Create))
                using (BinaryWriter newFile = 
                    new BinaryWriter(newFileP))
                {
                    List<int> uniqueNumbers = new List<int>();

                    while (inpFile.BaseStream.Position 
                        < inpFile.BaseStream.Length)
                    {
                        int number = inpFile.ReadInt32();

                        if (!uniqueNumbers.Contains(number))
                        {
                            uniqueNumbers.Add(number);
                            newFile.Write(number);
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }
    }

    [Serializable]
    public struct Toy
    {
        private string name;
        private decimal price;
        private int minAge;
        private int maxAge;

        public string Name
        {
            get 
            { 
                return name; 
            }
            set
            { 
                name = value; 
            }
        }

        public decimal Price
        {
            get 
            { 
                return price; 
            }
            set 
            { 
                price = value; 
            }
        }

        public int MinAge
        {
            get 
            { 
                return minAge; 
            }
            set 
            { 
                minAge = value; 
            }
        }

        public int MaxAge
        {
            get 
            { 
                return maxAge; 
            }
            set 
            { 
                maxAge = value; 
            }
        }

        public override string ToString()
        {
            return $"{Name} (цена: {Price} руб., возраст: {MinAge}–{MaxAge} лет)";
        }
    }

    private static List<Toy> LoadToysFromFile(FileStream reader)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
        return (List<Toy>)serializer.Deserialize(reader);
    }

    public static void BinaryAndStruct()
    {
        try
        {
            Console.Write("Введите имя исходного файла: ");
            string name = Console.ReadLine();

            using (FileStream fP = new FileStream(name, FileMode.Open))
            {
                List<Toy> toys = LoadToysFromFile(fP);

                List<Toy> suitableToys = new List<Toy>();
                for (int i = 0; i < toys.Count; i++)
                {
                    Toy t = toys[i];
                    if (t.MinAge <= 3 && t.MaxAge >= 2)
                    {
                        suitableToys.Add(t);
                    }
                }

                if (suitableToys.Count == 0)
                {
                    Console.WriteLine("Нет игрушек, подходящих для детей 2–3 лет.");
                    return;
                }

                Toy mostExpensive = suitableToys[0];
                for (int i = 1; i < suitableToys.Count; i++)
                {
                    if (suitableToys[i].Price > mostExpensive.Price)
                    {
                        mostExpensive = suitableToys[i];
                    }
                }

                Console.WriteLine("=== Результат ===");
                Console.WriteLine($"Самая дорогая игрушка для детей 2–3 лет: {mostExpensive.Name}");
                Console.WriteLine($"Цена: {mostExpensive.Price} руб., возраст: {mostExpensive.MinAge}–{mostExpensive.MaxAge} лет");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }
    }

    private static Random rnd = new Random();

    public static void GenerateTask1File()
    {
        Console.Write("Введите имя файла для генерации: ");
        string fileName = Console.ReadLine();
        Console.Write("Введите количество чисел: ");
        int count = int.Parse(Console.ReadLine());

        using (FileStream fs = new FileStream(fileName, FileMode.Create))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            for (int i = 0; i < count; i++)
            {
                int number = rnd.Next(-1000, 1001);
                sw.WriteLine(number);
            }
        }
        Console.WriteLine("Файл успешно создан.");
    }

    public static void GenerateTask2File()
    {
        Console.Write("Введите имя файла для генерации: ");
        string fileName = Console.ReadLine();
        Console.Write("Введите количество строк: ");
        int lines = int.Parse(Console.ReadLine());
        Console.Write("Введите максимальное количество чисел в строке: ");
        int maxNumbersPerLine = int.Parse(Console.ReadLine());

        using (FileStream fs = new FileStream(fileName, FileMode.Create))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            for (int i = 0; i < lines; i++)
            {
                int numbersInLine = rnd.Next(1, maxNumbersPerLine + 1);
                string line = "";
                for (int j = 0; j < numbersInLine; j++)
                {
                    int number = rnd.Next(-100, 101);
                    line += number;
                    if (j < numbersInLine - 1) line += " ";
                }
                sw.WriteLine(line);
            }
        }
        Console.WriteLine("Файл успешно создан.");
    }

    public static void GenerateTask3File()
    {
        Console.Write("Введите имя файла для генерации: ");
        string fileName = Console.ReadLine();
        Console.Write("Введите количество строк: ");
        int lines = int.Parse(Console.ReadLine());

        string[] words = { "hello", "world", "csharp", "programming", "file", "text", "random", "simple", "example", "code" };
        char[] punctuation = { '.', ',', '!', '?', '-', ';', '"'};

        using (FileStream fs = new FileStream(fileName, FileMode.Create))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            for (int i = 0; i < lines; i++)
            {
                int wordCount = rnd.Next(3, 10);
                string sentence = "";
                for (int j = 0; j < wordCount; j++)
                {
                    string word = words[rnd.Next(words.Length)];
                    sentence += word;
                    if (j < wordCount - 1) sentence += " ";
                }
                // Иногда добавляем знак пунктуации в конце
                if (rnd.Next(0, 2) == 0)
                {
                    sentence += punctuation[rnd.Next(punctuation.Length)];
                }
                sw.WriteLine(sentence);
            }
        }
        Console.WriteLine("Файл успешно создан.");
    }

    public static void GenerateTask4File()
    {
        Console.Write("Введите имя бинарного файла для генерации: ");
        string fileName = Console.ReadLine();
        Console.Write("Введите количество целых чисел: ");
        int count = int.Parse(Console.ReadLine());

        using (FileStream fs = new FileStream(fileName, FileMode.Create))
        using (BinaryWriter bw = new BinaryWriter(fs))
        {
            for (int i = 0; i < count; i++)
            {
                int number = rnd.Next(-10000, 10001);
                bw.Write(number);
            }
        }
        Console.WriteLine("Бинарный файл успешно создан.");
    }

    public static void GenerateTask5File()
    {
        Console.Write("Введите имя XML-файла для генерации: ");
        string fileName = Console.ReadLine();
        Console.Write("Введите количество игрушек: ");
        int count = int.Parse(Console.ReadLine());

        List<Toy> toys = new List<Toy>();
        string[] names = { "Кубики", "Мяч", "Пирамидка", "Машинка", "Кукла", "Пазл", "Конструктор", "Лото" };
        decimal[] prices = { 150m, 200m, 300m, 500m, 700m, 250m, 1000m, 400m };

        for (int i = 0; i < count; i++)
        {
            Toy toy = new Toy();
            toy.Name = names[rnd.Next(names.Length)];
            toy.Price = prices[rnd.Next(prices.Length)];
            toy.MinAge = rnd.Next(0, 10);
            toy.MaxAge = toy.MinAge + rnd.Next(1, 6);
            toys.Add(toy);
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
        using (FileStream fs = new FileStream(fileName, FileMode.Create))
        {
            serializer.Serialize(fs, toys);
        }
        Console.WriteLine("XML-файл с игрушками успешно создан.");
    }
}