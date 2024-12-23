namespace lb9
{
    using System.Diagnostics;
    using System.IO;
    using System.Linq.Expressions;
    using System.Threading;
    class Program
    {
        static void Main(string[] args)
        {
            string src1 = @"C:\Users\artem\OneDrive\Рабочий стол\Введение.docx";
            string src2 = @"C:\Users\artem\OneDrive\Рабочий стол\test5laba.docx";

            string dest1 = @"C:\Users\artem\OneDrive\Рабочий стол\Doc1.docx";
            string dest2 = @"C:\Users\artem\OneDrive\Рабочий стол\Doc2.docx";
            try
            {
                if (File.Exists(src1))
                {
                    Stopwatch stopwatch1 = new Stopwatch();
                    stopwatch1.Start();
                    FileInfo f1 = new FileInfo(src1);
                    f1.CopyTo(dest1, true);
                    stopwatch1.Stop();
                    Console.WriteLine("Первый файл успешно скопирован");
                    Console.WriteLine("Время выполнения первого копирования: " + stopwatch1.Elapsed.ToString());

                }
                else
                {
                    Console.WriteLine("Копируемый файл не найден");
                }
                if (File.Exists(src2))
                {
                    Stopwatch stopwatch2 = new Stopwatch();
                    stopwatch2.Start();
                    FileInfo f2 = new FileInfo(src2);
                    f2.CopyTo(dest2, true);
                    stopwatch2.Stop();
                    Console.WriteLine("Второй файл успешно скопирован");
                    Console.WriteLine("Время выполнения второго копирования: " + stopwatch2.Elapsed.ToString());
                }
                else
                {
                    Console.WriteLine("Копируемый файл не найден");
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }

            Thread thread1 = new Thread(FirstFileThread);
            Thread thread2 = new Thread(SecondFilethread);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Parallel.Invoke(FirstFileThread, SecondFilethread);

        }
        public static void FirstFileThread()
        {
            string src1 = @"C:\Users\artem\OneDrive\Рабочий стол\Введение.docx";
            string dest1 = @"C:\Users\artem\OneDrive\Рабочий стол\Doc1.docx";
            try
            {
                if (File.Exists(src1))
                {
                    Stopwatch stopwatch1 = new Stopwatch();
                    stopwatch1.Start();
                    FileInfo f1 = new FileInfo(src1);
                    f1.CopyTo(dest1, true);
                    stopwatch1.Stop();
                    Console.WriteLine("Первый файл успешно скопирован");
                    Console.WriteLine("Время выполнения первого копирования: " + stopwatch1.Elapsed.ToString());

                }
                else
                {
                    Console.WriteLine("Копируемый файл не найден");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
        public static void SecondFilethread()
        {
            string src2 = @"C:\Users\artem\OneDrive\Рабочий стол\test5laba.docx";
            string dest2 = @"C:\Users\artem\OneDrive\Рабочий стол\Doc2.docx";
            try
            {
                if (File.Exists(src2))
                {
                    Stopwatch stopwatch2 = new Stopwatch();
                    stopwatch2.Start();
                    FileInfo f2 = new FileInfo(src2);
                    f2.CopyTo(dest2, true);
                    stopwatch2.Stop();
                    Console.WriteLine("Второй файл успешно скопирован");
                    Console.WriteLine("Время выполнения второго копирования: " + stopwatch2.Elapsed.ToString());
                }
                else
                {
                    Console.WriteLine("Копируемый файл не найден");
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
    }
}
