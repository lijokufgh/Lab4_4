namespace Program
{
    public abstract class Program1
    {
        protected abstract void Start();
        protected abstract void Menu();
        protected abstract Dictionary<int, char> index();
        protected abstract void SortVoz(Dictionary<int, char> x);
        protected abstract void SortUb(Dictionary<int, char> x);
        protected abstract void SortOr(Dictionary<int, char> x);
        protected abstract void ConcDy(Dictionary<int, char> x);
        protected abstract void close();
        protected abstract void Count(Dictionary<int, char> x);
        protected abstract void Swap(Dictionary<int, char> x);
        protected abstract void ReSwap(Dictionary<int, char> x);
    }
    public class Program2 : Program1
    {
        List<char> LiOrText = new List<char>(); // Создаём постоянный лист.
        List<char> LiSrText = new List<char>(); // Создаём изменяемый лист.
        List<object> LiZn = new List<object>(); // Создаём лист для хранения изменений символов.
        int zn = 0; // Сумма изменений символов.
        int zm = 0;// Сумма изменений одного символа.
        char swap1 = ' '; // Переменая для смены символов.
        char swap2 = ' '; // Переменая для смены символов.
        string OrText; // Начальный текст.
        protected override void Start()
        {
            Console.WriteLine("Вдите текст:");
            OrText = Console.ReadLine(); // Ввод начального текста.
            Console.Clear();
            if (String.IsNullOrWhiteSpace(OrText) == true) // Проверка на пустой тект.
            {
                Console.Write("Ошибка ввода!!!");
                Environment.Exit(0); // Досрочное завершение программы.
            }
            foreach (char str in OrText) LiOrText.Add(str); // Заплняем лист.
            foreach (char str in OrText) LiSrText.Add(str); // Заплняем лист.
        }
        protected override void Menu()
        {
            Console.WriteLine("Оригинальный текст:");
            foreach (char str in OrText)
            {
                Console.Write(str); // Выводим лист.
            }
            Console.WriteLine("\nНынешний текст:");
            foreach (char str in LiSrText)
            {
                Console.Write(str); // Выводим лист.
            }
            Console.WriteLine("\n\nВыберите пункт:\n1) Вывод символов и их индексов.\n2) Сортировка по возростанию.\n3) Сортировка по убыванию.\n4) Вернуть текст к исходному состоянию.\n5) Подсчитать элементы.\n6) Заменить символ.\n7) История сортировки.\n0) Выход.");
            int y = int.Parse(Console.ReadLine());

            switch (y)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    index();
                    ConcDy(index());
                    break;
                case 2:
                    SortVoz(index());
                    break;
                case 3:
                    SortUb(index());
                    break;
                case 4:
                    SortOr(index());
                    break;
                case 5:
                    Count(index());
                    break;
                case 6:
                    Swap(index());
                    break;
                case 7:
                    ReSwap(index());
                    break;
                default:
                    Console.Clear();
                    Menu();
                    break;
            }
        }
        protected override Dictionary<int, char> index() // Заполнение словоря.
        {
            var DyText1 = new Dictionary<int, char>(); // Создание словоря.
            int keyy = 0;
            for (int i = 0; i < LiOrText.Count; i++)
            {
                if (DyText1.ContainsValue(LiOrText[i]) == false) // Проверка на наличия символа в библиотеки и если элемент отсутствует, то добовляем его.
                {
                    DyText1.Add(keyy, LiOrText[i]);
                    keyy++;
                }
            }
            return DyText1;
        }

        protected override void SortVoz(Dictionary<int, char> x) // Сортировка по возрастанию.
        {
            LiSrText.Clear();
            for (int i = 0; i < x.Count; i++) // Кол-во уникальных символов.
            {
                for (int j = 0; j < LiOrText.Count; j++) // Кол-во всех символов.
                {
                    if (x[i] == LiOrText[j]) // Смотрим на уникальные символы начиная с нулевого элемента и сравниваем с каждым символом текста.
                    {
                        LiSrText.Add(LiOrText[j]);
                    }
                }
            }
            close();
        }

        protected override void SortUb(Dictionary<int, char> x) // Сортировка по убыванию.
        {
            LiSrText.Clear();
            for (int i = 0; i < x.Count; i++) // Кол-во уникальных символов.
            {
                for (int j = 0; j < LiOrText.Count; j++) // Кол-во всех символов.
                {
                    if (x[i] == LiOrText[j]) // Смотрим на уникальные символы начиная с нулевого элемента и сравниваем с каждым символом текста.
                    {
                        LiSrText.Add(LiOrText[j]);
                    }
                }
            }
            LiSrText.Reverse(); // Переворачиваем лист.
            close();
        }

        protected override void SortOr(Dictionary<int, char> x) // Возврат к исходному состоянию текста.
        {
            LiSrText.Clear();
            foreach (char str in OrText) LiSrText.Add(str);
            zn = 0;
            zm = 0;
            LiZn.Clear();
            close();
        }

        protected override void ConcDy(Dictionary<int, char> x) // Вывод библиотеки.
        {
            foreach (var v in x)
            {
                Console.WriteLine(v);
            }
            Console.ReadKey();
            close();
        }

        protected override void close() // Отчистка консоли и возврат в меню.
        {
            Console.Clear();
            Menu();
            Console.Clear();
        }

        protected override void Count(Dictionary<int, char> x) // Подсчёт кол-во символов.
        {
            for (int i = 0; i < x.Count; i++) // Кол-во уникальных символов.
            {
                int count = 0;
                for (int j = 0; j < LiOrText.Count; j++) // Кол-во всех символов.
                {
                    if (x[i] == LiOrText[j]) // Смотрим на уникальные символы начиная с нулевого элемента и сравниваем с каждым символом текста.
                    {
                        count++;
                    }
                }
                Console.WriteLine($"[{x[i]}] - {count}");
            }
            Console.WriteLine($"Всего символов:{LiOrText.Count}");
            Console.ReadKey();
            close();
        }

        protected override void Swap(Dictionary<int, char> x) // Сортировка по возрастанию.
        {
            Console.Write("Введите символ который хотите заменить: ");
            swap1 = Convert.ToChar(Console.ReadLine());
            Console.Write("\nВведите символ на который хотите заменить: ");
            swap2 = Convert.ToChar(Console.ReadLine());
            Console.WriteLine();

            for (int j = 0; j < LiOrText.Count; j++) // Кол-во всех символов.
            {
                if (swap1 == LiSrText[j]) // Смотрим на символ замены начиная с нулевого элемента и сравниваем с каждым символом текста.
                {
                    LiSrText[j] = swap2;
                    zn++;
                    zm++;
                }
            }
            LiZn.Add(swap1);
            LiZn.Add(swap2);
            LiZn.Add(zm);
            zm = 0;
            close();
        }

        protected override void ReSwap(Dictionary<int, char> x) // Возврат к исходному состоянию текста.
        {
            if (zn == 0)
            {
                Console.WriteLine("Замены не были произведины.");
                close();
            }
            else
            {
                Console.WriteLine($"Суммарное кол-ов изменённых символов: {zn}\n");
                for (int i = 0; i < LiZn.Count; i = i + 3)
                {
                    Console.WriteLine($"Символ который меняли: {LiZn[i]}\nСимвол на который меняли: {LiZn[i + 1]}\nКол-во заменённых символов: {LiZn[i + 2]}\n");
                }
                Console.ReadKey();
                close();
            }
        }
        public Program2()
        {
            Start();
            Menu();
        }
    }
    public class ProgramMain
    {
        static void Main()
        {
            Program2 program1 = new Program2();
        }
    }
}