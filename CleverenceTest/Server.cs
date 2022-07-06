namespace CleverenceTest
{
    public static class Server
    {
        //Вывод в консоль добавлена исключительно для наглядности тестового задания
        private static int Count { get; set; } = 0;
        private static bool lockedByWriter { get; set; } = false;
        private static object obj = new();

        public static int GetCount()
        {
            try
            {
                //Проверка на то, пишут ли сейчас писатели
                if (!lockedByWriter)
                {
                    //Console.WriteLine("Enter in read without lock");
                    //Console.WriteLine($"ReadCount without lock: count = {count}");
                    //Console.WriteLine("Exit from read without lock");
                    return Count;
                }
                else
                {
                    //Ожидание объекта, если объект занят писателем
                    lock (obj)
                    {
                        //Console.WriteLine("Enter in read with lock");
                        //Console.WriteLine($"ReadCount with lock: count = {count}");
                        //Console.WriteLine("Exit from read with lock");
                        return Count;

                    }
                }
            }
            catch { throw; }
        }

        public static void AddToCount(int value)
        {
            try
            {
                //Писатели пишут последовательно
                lockedByWriter = true;
                lock (obj)
                {
                    //Console.WriteLine("Enter in write");
                    Count += value;
                    //Console.WriteLine($"AddToCount: count = {count}");
                    //Console.WriteLine("Exit from write");
                }
                lockedByWriter = false;
            }
            catch { throw; }
            finally { lockedByWriter = false; }
        }
    }
}