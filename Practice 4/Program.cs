namespace Practice_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.SetCursorPosition(15, 2);
            Console.WriteLine("Что это?");
            string input = Console.ReadLine();
            string otvet = input.ToLower();
            while (otvet != "ежедневник" | otvet != "ежендевник")
            {
                otvet = input.ToLower();
                Console.WriteLine("Нет, попробуй ещё");
                Thread.Sleep(700);
                Console.Clear();
                Console.SetCursorPosition(15, 2);
                Console.WriteLine("Что это?");
                otvet = Console.ReadLine();

            }*/
            /*Console.ReadKey();
            Console.Clear();*/

            Console.CursorVisible = false;
            DateTime TodayData = DateTime.Today;
            DateTime DataTime = DateTime.Today;


            string DataStokToday = ($"  Сегодняшняя дата - {TodayData.ToShortDateString()}");
            Console.WriteLine(DataStokToday);
            Console.WriteLine($"  Выбрана дата: {DataTime.ToShortDateString()}");
            Console.WriteLine("  ! Создать заметку.");

            List<Notes> notes = new List<Notes>();

            Notes zam1 = new Notes();
            zam1.Data = TodayData;
            zam1.Name = "Придти на пары";
            zam1.Description = "Отсидеть 5 пар";

            Notes zam2 = new Notes();
            zam2.Data = TodayData;
            zam2.Name = "Сделать практическую по C# за неделю";
            zam2.Description = "Вот это вызов";

            Notes zam3 = new Notes();
            zam3.Data = DataTime;
            zam3.Name = "Выполнить дискретную математику";
            zam3.Description = "Законы алгебры логики";

            notes.Add(zam1);
            notes.Add(zam2);
            notes.Add(zam3);

            Console.Write("  1. ");
            Console.WriteLine(zam1.Name);
            Console.Write("  2. ");
            Console.WriteLine(zam2.Name);

            int position = 1;

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.DownArrow)
                {
                    position = Arrows(key, position, TodayData, DataTime);
                }
                else if (position == 1 && ((key.Key == ConsoleKey.RightArrow) || (key.Key == ConsoleKey.LeftArrow)))
                {
                    DataTime = DataChange(key, DataTime);
                    if (DataTime != TodayData)
                    {
                        Console.WriteLine("  ! Создать заметку.");

                        Console.SetCursorPosition(2, 3);
                        for (int i = 0; i < zam3.Name.Length; i++)
                        {
                            Console.Write("  ");
                        }

                        Console.SetCursorPosition(2, 4);
                        for (int i = 0; i < zam3.Name.Length; i++)
                        {
                            Console.Write("  ");
                        }
                        if (DataTime == TodayData.AddDays(1))
                        {
                            Console.SetCursorPosition(2, 3);
                            Console.Write("1. ");
                            Console.WriteLine(zam3.Name);

                        }
                    }
                    else
                    {
                        Console.WriteLine("  ! Создать заметку.");
                        Console.Write("  1. ");
                        Console.WriteLine(zam1.Name);
                        Console.Write("  2. ");
                        Console.WriteLine(zam2.Name);
                    }
                }
                else if ((key.Key == ConsoleKey.Enter && position == 3 && DataTime == TodayData) || position == 4)
                {
                    Description(DataTime, TodayData, position, notes);
                    Console.Clear();
                    Console.WriteLine(DataStokToday);
                    Console.WriteLine($"  Выбрана дата: {DataTime.ToShortDateString()}");
                    Console.WriteLine("  ! Создать заметку.");
                    Console.Write("  1. ");
                    Console.WriteLine(zam1.Name);
                    Console.Write("  2. ");
                    Console.WriteLine(zam2.Name);
                }
                else if (key.Key == ConsoleKey.Enter && position == 3 && DataTime == TodayData.AddDays(1))
                {
                    Description(DataTime, TodayData, position, notes);
                    Console.Clear();
                    Console.WriteLine(DataStokToday);
                    Console.WriteLine($"  Выбрана дата: {DataTime.ToShortDateString()}");
                    Console.WriteLine("  ! Создать заметку.");
                    Console.Write("  1. ");
                    Console.WriteLine(zam3.Name);
                }
                else if (key.Key == ConsoleKey.Enter && position == 2)
                {
                    notes = CreateNote(notes, DataTime);
                    if (DataTime == TodayData)
                    {
                        var DaysNotes = notes.Where(x => x.Data == TodayData).ToList();

                        Console.WriteLine(DataStokToday);
                        Console.WriteLine($"  Выбрана дата: {DataTime.ToShortDateString()}");
                        Console.WriteLine("  ! Создать заметку.");
                        Console.Write("  1. ");
                        Console.WriteLine(zam1.Name);
                        Console.Write("  2. ");
                        Console.WriteLine(zam2.Name);
                        Console.Write("  3. " );
                        Console.WriteLine(DaysNotes[position + 1].Name);


                    }
                }
                else if (position == 5 && key.Key == ConsoleKey.Enter && DataTime == TodayData)
                {
                    Description(DataTime, TodayData, position, notes);
                }
            }
        }
        static int Arrows(ConsoleKeyInfo key, int position, DateTime TodayData, DateTime DataTime)
        {
            int last_position = 0;

            if (key.Key == ConsoleKey.UpArrow)
            {
                if (position == 0)
                {
                    position = 0;
                    last_position = 0;

                }
                else if (position == 1)
                {
                    position = 1;
                    last_position = 1;
                }
                else
                {
                    position--;
                    last_position = position + 1;
                }
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (position == 6)
                {
                    position = 6;
                    last_position = position - 1;
                }

                else
                {
                    position++;
                    last_position = position - 1;
                }
            }
            Console.SetCursorPosition(0, last_position);
            Console.WriteLine("  ");
            Console.SetCursorPosition(0, position);
            Console.Write("->");

            return position;
        }
        static DateTime DataChange(ConsoleKeyInfo key, DateTime DataTime)
        {
            if (key.Key == ConsoleKey.RightArrow)
            {
                DataTime = DataTime.AddDays(1);
            }
            if (key.Key == ConsoleKey.LeftArrow)
            {
                DataTime = DataTime.AddDays(-1);
            }
            Console.SetCursorPosition(16, 1);
            Console.WriteLine(DataTime.ToShortDateString());
            return DataTime;
        }
        static int Description(DateTime DataTime, DateTime TodayData, int position, List<Notes> notes)
        {
            Console.Clear();
            int a = 0;
            if ((DataTime == TodayData && position == 3) || position == 4 || position == 5)
            {
                var DaysNotes = notes.Where(x => x.Data == DataTime).ToList();

                Console.SetCursorPosition(0, 0);
                Console.Write(">>> ");
                Console.WriteLine(DaysNotes[position - 3].Name);
                Console.WriteLine("_________________________");
                Console.Write("Описание: ");
                Console.WriteLine(DaysNotes[position - 3].Description);
                Console.Write("Дата: ");
                Console.WriteLine(DaysNotes[position - 3].Data);
                Console.WriteLine("_________________________");
            }
            else if (DataTime == TodayData.AddDays(1) && position == 3)
            {
                var DaysNotes = notes.Where(x => x.Data.AddDays(1) == DataTime).ToList();

                Console.Write(">>> ");
                Console.WriteLine(DaysNotes[position - 1].Name);
                Console.WriteLine("_________________________");
                Console.Write("Описание: ");
                Console.WriteLine(DaysNotes[position - 1].Description);
                Console.Write("Дата: ");
                Console.WriteLine(DaysNotes[position - 1].Data);
                Console.WriteLine("_________________________");
            }

            Console.WriteLine("Нажмите на \"Enter\", чтобы выйти.\nPress \"Enter\" to exit.");
            while (a != 1)
            {
                ConsoleKeyInfo press = Console.ReadKey(true);

                if (press.Key != ConsoleKey.Enter)
                {
                    Console.Write("");
                }
                else
                {
                    a = 1;
                }
            }
            return a;
        }
        static List<Notes> CreateNote(List<Notes> notes, DateTime DataTime)
        {
            Console.Clear();
            Console.CursorVisible = true;
            /*bool access = false;*/

            Notes newNote = new Notes();
            newNote.Data = DataTime;

            Console.WriteLine("Напишите название заметки: ");
            newNote.Name = Console.ReadLine();
            Console.WriteLine("Описание для заметки: ");
            newNote.Description = Console.ReadLine();

            notes.Add(newNote);

            Console.CursorVisible = true;

            Console.Clear();
            return notes;
        }

    }
}