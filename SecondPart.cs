class SecondPart
{
    public static void Task6_SymmetricDifference()
    {
        List<int> L1 = ReadList("первого");
        List<int> L2 = ReadList("второго");

        List<int> result = new List<int>();

        foreach (int item in L1)
        {
            if (!L2.Contains(item) && !result.Contains(item))
            {
                result.Add(item);
            }
        }

        foreach (int item in L2)
        {
            if (!L1.Contains(item) && !result.Contains(item))
            {
                result.Add(item);
            }
        }

        Console.WriteLine("Результирующий список (симметрическая разность):");
        PrintList(result);
    }

    private static List<int> ReadList(string name)
    {
        List<int> list = new List<int>();
        Console.Write($"Введите элементы {name} списка через пробел: ");
        string[] parts = Console.ReadLine().Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries);
        foreach (string part in parts)
        {
            if (int.TryParse(part, out int val))
                list.Add(val);
            else
                Console.WriteLine($"Некорректное число '{part}' пропущено.");
        }
        return list;
    }

    private static void PrintList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
            Console.Write(list[i] + (i < list.Count - 1 ? " " : ""));
        Console.WriteLine();
    }

    public static void Task7_RemoveBetweenMinMax()
    {
        LinkedList<int> list = ReadLinkedList();
        if (list.Count < 3)
        {
            Console.WriteLine("Список слишком короткий, удаление невозможно.");
            return;
        }

        LinkedListNode<int> minNode = list.First;
        LinkedListNode<int> maxNode = list.First;
        LinkedListNode<int> current = list.First;
        while (current != null)
        {
            if (current.Value < minNode.Value) 
            {
                minNode = current;
            }
            if (current.Value > maxNode.Value) 
            {
                maxNode = current;
            }
            current = current.Next;
        }

        if (IndexOf(list, minNode) > IndexOf(list, maxNode))
        {
            LinkedListNode<int> temp = minNode;
            minNode = maxNode;
            maxNode = temp;
        }

        LinkedListNode<int> node = minNode.Next;
        while (node != null && node != maxNode)
        {
            LinkedListNode<int> next = node.Next;
            list.Remove(node);
            node = next;
        }

        Console.WriteLine("Результат после удаления:");
        PrintLinkedList(list);
    }

    private static LinkedList<int> ReadLinkedList()
    {
        LinkedList<int> list = new LinkedList<int>();
        Console.Write("Введите элементы связного списка через пробел: ");
        string[] parts = Console.ReadLine().Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries);
        foreach (string part in parts)
        {
            if (int.TryParse(part, out int val))
            {
                list.AddLast(val);
            }
        }
        return list;
    }

    private static int IndexOf(LinkedList<int> list, 
        LinkedListNode<int> node)
    {
        int index = 0;
        LinkedListNode<int> current = list.First;
        while (current != null)
        {
            if (current == node) return index;
            current = current.Next;
            index++;
        }
        return -1;
    }

    private static void PrintLinkedList(LinkedList<int> list)
    {
        foreach (int val in list)
            Console.Write(val + " ");
        Console.WriteLine();
    }

    public static void Task8_TVShows()
    {
        Console.Write("Введите названия всех телешоу через пробел: ");
        string showsLine = Console.ReadLine();
        string[] showNames = showsLine.Split(new char[] { ' ' }, 
            StringSplitOptions.RemoveEmptyEntries);
        HashSet<string> allShows = new HashSet<string>();
        foreach (string name in showNames)
        {
            allShows.Add(name);
        }

        Console.Write("Введите количество телезрителей: ");
        int viewers = ReadPositiveInt();
        List<HashSet<string>> viewerLikes = new List<HashSet<string>>();
        for (int i = 0; i < viewers; i++)
        {
            Console.WriteLine($"Введите шоу, которые нравятся {i + 1}-му зрителю, через пробел:");
            string[] liked = Console.ReadLine().Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            HashSet<string> likes = new HashSet<string>();
            foreach (string s in liked)
            {
                likes.Add(s);
            }
            viewerLikes.Add(likes);
        }

        HashSet<string> allLike = new HashSet<string>(allShows);
        foreach (var likes in viewerLikes)
        {
            allLike.IntersectWith(likes);
        }

        HashSet<string> someLike = new HashSet<string>();
        foreach (var likes in viewerLikes)
        {
            someLike.UnionWith(likes);
        }

        someLike.ExceptWith(allLike);

        HashSet<string> noneLike = new HashSet<string>(allShows);
        noneLike.ExceptWith(someLike);
        noneLike.ExceptWith(allLike);

        Console.WriteLine("\nШоу, которые нравятся всем зрителям:");
        PrintSet(allLike);
        Console.WriteLine("\nШоу, которые нравятся некоторым зрителям:");
        PrintSet(someLike);
        Console.WriteLine("\nШоу, которые не нравятся никому:");
        PrintSet(noneLike);
    }

    private static void PrintSet(HashSet<string> set)
    {
        if (set.Count == 0)
            Console.WriteLine("(нет)");
        else
        {
            foreach (string s in set)
                Console.WriteLine(s);
        }
    }

    public static void Task9_FindDigitsInTextFile()
    {
        Console.Write("Введите путь к текстовому файлу: ");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }

        HashSet<char> digits = new HashSet<char>();
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                foreach (char ch in line)
                {
                    if (ch >= '0' && ch <= '9')
                        digits.Add(ch);
                }
            }
        }

        Console.WriteLine("Цифры, встречающиеся в файле:");
        if (digits.Count == 0)
            Console.WriteLine("Цифр нет.");
        else
        {
            foreach (char d in digits)
                Console.Write(d + " ");
            Console.WriteLine();
        }
    }

    public static void Task10_OldestPerson()
    {
        Console.Write("Введите количество людей: ");
        int n = ReadPositiveInt();

        SortedList<DateTime, List<string>> peopleByDate = 
            new SortedList<DateTime, List<string>>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите данные {i + 1}-го человека (Фамилия Имя ДД.ММ.ГГГГ):");
            string[] parts = Console.ReadLine().Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 3)
            {
                Console.WriteLine("Неверный формат. Пропускаем.");
                continue;
            }
            string lastName = parts[0];
            string firstName = parts[1];
            if (!DateTime.TryParseExact(parts[2], "dd.MM.yyyy", null,
                System.Globalization.DateTimeStyles.None,
                out DateTime birth))
            {
                Console.WriteLine("Неверный формат даты. Используйте ДД.ММ.ГГГГ. Пропускаем.");
                continue;
            }

            string fullName = lastName + " " + firstName;
            if (peopleByDate.ContainsKey(birth))
            {
                peopleByDate[birth].Add(fullName);
            }
            else
            {
                List<string> names = new List<string>();
                names.Add(fullName);
                peopleByDate.Add(birth, names);
            }
        }

        if (peopleByDate.Count == 0)
        {
            Console.WriteLine("Нет корректных записей.");
            return;
        }

        if (peopleByDate.Values[0].Count == 1)
        {
            Console.WriteLine($"Самый старший: {peopleByDate.Values[0][0]}");
        }
        else
        {
            Console.WriteLine($"Количество самых старших людей: {peopleByDate.Values[0].Count}");
        }
    }

    private static int ReadPositiveInt()
    {
        int result;
        while (!int.TryParse(Console.ReadLine(), out result) 
            || result <= 0)
        {
            Console.Write("Введите положительное целое число: ");
        }
        return result;
    }
}