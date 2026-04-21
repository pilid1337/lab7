using System.Xml.Serialization;

[Serializable]
public struct Toy
{
    private string _name;
    private decimal _price;
    private int _minAge;
    private int _maxAge;

    public Toy(string name, decimal price, int minAge, int maxAge)
    {
        _name = name;
        _price = price;
        _minAge = minAge;
        _maxAge = maxAge;
    }

    public string Name
    {
        get 
        { 
            return _name; 
        }
        private set
        { 
            _name = value; 
        }
    }

    public decimal Price
    {
        get 
        { 
            return _price; 
        }
        private set 
        { 
            _price = value; 
        }
    }

    public int MinAge
    {
        get 
        { 
            return _minAge; 
        }
        private set 
        { 
            _minAge = value; 
        }
    }

    public int MaxAge
    {
        get 
        { 
            return _maxAge; 
        }
        private set 
        { 
            _maxAge = value; 
        }
    }
}

class FirstPart
{

    private static Random _rnd;

    static FirstPart()
    {
        _rnd = new Random();
    }

    public static int Sum(int inpDigit)
    {
        string s = "";
        int intString = 0;
        int sum = 0;
        int lastDigit = -1;

        try
        {
            Console.Write("Введите имя исходного файла: ");
            string name = Console.ReadLine();

            if (!File.Exists(name))
            {
                Console.WriteLine("Файл не найден.");
                return 0;
            }

            using (FileStream fP = new FileStream(name, FileMode.Open))
            using (StreamReader f = new StreamReader(fP))
            {
                while ((s = f.ReadLine()) != null)
                {
                    intString = int.Parse(s);
                    lastDigit = Math.Abs(intString);
                    while (lastDigit > 10)
                    {
                        lastDigit %= 10;
                    }
                    if (lastDigit == inpDigit)
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
        string s = "";
        string[] stringArray = [];
        int[] intArray = [];
        int min = 0;

        try
        {
            Console.Write("Введите имя исходного файла: ");
            string name = Console.ReadLine();

            if (!File.Exists(name))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

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
        string s = "";
        bool hasPunctuation = false;
        char[] punctuationMarks = ['.', ',', '!', '?', '-', ';', '"'];

        try
        {
            Console.Write("Введите имя исходного файла: ");
            string name = Console.ReadLine();

            if (!File.Exists(name))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

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
        int number = 0;
        List<int> uniqueNumbers = new List<int>();
        try
        {
            Console.Write("Введите имя исходного файла: ");
            string name = Console.ReadLine();

            if (!File.Exists(name))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }
            
            ReadBinaryFile(name);
            
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
                    uniqueNumbers = new List<int>();

                    while (inpFile.BaseStream.Position 
                        < inpFile.BaseStream.Length)
                    {
                        number = inpFile.ReadInt32();

                        if (!uniqueNumbers.Contains(number))
                        {
                            uniqueNumbers.Add(number);
                            newFile.Write(number);
                        }
                    }
                }
                Console.WriteLine("Обработка завершена");
                ReadBinaryFile(name);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }
    }

    private static void ReadBinaryFile(string fileName)
    {
        int number = 0;
        if (!File.Exists(fileName))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }

        try
        {
            using (FileStream fs = new FileStream(fileName,
                FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                List<int> numbers = new List<int>();
                while (reader.BaseStream.Position 
                    < reader.BaseStream.Length)
                {
                    number = reader.ReadInt32();
                    numbers.Add(number);
                }

                Console.WriteLine("Содержимое бинарного файла:");
                for (int i = 0; i < numbers.Count; i++)
                {
                    Console.Write(numbers[i] + 
                        (i < numbers.Count - 1 ? " " : "\n"));
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при чтении файла: {e.Message}");
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

            if (!File.Exists(name))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

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

    public static void GenerateTask1File()
    {
        Console.Write("Введите имя файла для генерации: ");
        string fileName = Console.ReadLine();
        Console.Write("Введите количество чисел: ");
        int count;
        try
        {
            count = int.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при вводе: {e.Message}");
            return;
        }
        int number;

        using (FileStream fs = new FileStream(fileName, FileMode.Create))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            for (int i = 0; i < count; i++)
            {
                number = _rnd.Next(-1000, 1001);
                sw.WriteLine(number);
            }
        }
        Console.WriteLine("Файл успешно создан.");
    }

    public static void GenerateTask2File()
    {
        Console.Write("Введите имя файла для генерации: ");
        string fileName = Console.ReadLine();
        int lines;
        int maxNumbersPerLine;
        try
        {
            Console.Write("Введите количество строк: ");
            lines = int.Parse(Console.ReadLine());
            Console.Write("Введите максимальное количество чисел в строке: ");
            maxNumbersPerLine = int.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при вводе: {e.Message}");
            return;
        }

        int numbersInLine;
        string line;
        int number;

        using (FileStream fs = new FileStream(fileName, FileMode.Create))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            for (int i = 0; i < lines; i++)
            {
                numbersInLine = _rnd.Next(1, maxNumbersPerLine + 1);
                line = "";
                for (int j = 0; j < numbersInLine; j++)
                {
                    number = _rnd.Next(-100, 101);
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
        int lines;
        try
        {
            Console.Write("Введите количество строк: ");
            lines = int.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при вводе: {e.Message}");
            return;
        }

        string[] words = { "hello", "world", "csharp", "programming", "file", "text", "random", "simple", "example", "code" };
        char[] punctuation = { '.', ',', '!', '?', '-', ';', '"'};
        int wordCount;
        string sentence;
        string word;

        using (FileStream fs = new FileStream(fileName, FileMode.Create))
        using (StreamWriter sw = new StreamWriter(fs))
        {
            for (int i = 0; i < lines; i++)
            {
                wordCount = _rnd.Next(3, 10);
                sentence = "";
                for (int j = 0; j < wordCount; j++)
                {
                    word = words[_rnd.Next(words.Length)];
                    sentence += word;
                    if (j < wordCount - 1) sentence += " ";
                }
                if (_rnd.Next(0, 2) == 0)
                {
                    sentence += punctuation[_rnd.Next(punctuation.Length)];
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
        int count;
        try
        {
            Console.Write("Введите количество целых чисел: ");
            count = int.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при вводе: {e.Message}");
            return;
        }

        int number;

        using (FileStream fs = new FileStream(fileName, FileMode.Create))
        using (BinaryWriter bw = new BinaryWriter(fs))
        {
            for (int i = 0; i < count; i++)
            {
                number = _rnd.Next(-5, 5);
                bw.Write(number);
            }
        }
        Console.WriteLine("Бинарный файл успешно создан.");
    }

    public static void GenerateTask5File()
    {
        Console.Write("Введите имя XML-файла для генерации: ");
        string fileName = Console.ReadLine();
        int count;
        try
        {
            Console.Write("Введите количество игрушек: ");
            count = int.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при вводе: {e.Message}");
            return;
        }

        List<Toy> toys = new List<Toy>();
        string[] names = { "Кубики", "Мяч", "Пирамидка", "Машинка", "Кукла", "Пазл", "Конструктор", "Лото" };
        decimal[] prices = { 150m, 200m, 300m, 500m, 700m, 250m, 1000m, 400m };
        Toy toy = new Toy("", 0, 0, 0);

        for (int i = 0; i < count; i++)
        {
            toy = new Toy(names[_rnd.Next(names.Length)], prices[_rnd.Next(prices.Length)], _rnd.Next(0, 10), toy.MinAge + _rnd.Next(1, 6));
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