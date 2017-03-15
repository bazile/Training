/*
 * Демонстрация работы с адаптерами потоков
 *      - BinaryReader, BinaryWriter
 *      - StreamReader, StreamWriter
 * Данные классы называются "адаптерами потоков" т.к. они не являются
 *	потоками (наследниками System.IO.Stream) и адаптируют поток для
 *	различных задач. Классы BinaryReader/BinaryWriter для 
 *	структурированной записи двоичных данных.
 *	Классы StreamReader/StreamWriter для работы с текстом.
 *      
 * Также демонстрируется работа с блоком using() { ... }
 */
using System;
using System.IO;

namespace TrainingCenter.LessonIO
{
    class Program
    {
        static void Main()
        {
            BinaryAdaptersDemo();
        }

        private static void BinaryAdaptersDemo()
        {
            // Генерируем случайные данные
            Random rnd = new Random(Environment.TickCount);
            double[] results = new double[5];
            for (int i=0; i<results.Length; i++)
            {
                results[i] = rnd.NextDouble();
                Console.WriteLine("{0:F10}", results[i]);
            }

            // Будем работать с файлом в папке для временных файлов
            string tempFileName = Path.Combine(Path.GetTempPath(), "binary-adapter.bin");

            // Запись данных
            using (FileStream writeStream = File.OpenWrite(tempFileName))
            using (BinaryWriter binWriter = new BinaryWriter(writeStream))
            {
                //  Просим BinaryWriter записать в поток байтовое представление значения типа int
                binWriter.Write(results.Length);
                for (int i = 0; i < results.Length; i++)
                {
                    //  Просим BinaryWriter записать в поток байтовое представление значения типа double
                    binWriter.Write(results[i]);
                }

                // Блок using автоматически закрывает адаптер и поток когда исполнение
                //  дойдет до закрывающей фигурной скобки. Поэтому нет необходимости
                //  писать строки
                //      binWriter.Close();
                //      writeStream.Close();
            }
            Console.WriteLine();

            long expectedLength = sizeof(int) + sizeof(double) * results.Length;
            long realLength = (new FileInfo(tempFileName)).Length;
            if (expectedLength == realLength)
            {
                Console.WriteLine(
                    "Ожидаемая длина файла - {0} {1} - совпадает с реальной длиной файла",
                    expectedLength, expectedLength.PrettyBytes()
                );
            }
            else
            {
                Console.WriteLine(
                    "Ожидаемая длина файла - {0} {1} - не совпадает с реальной длиной файла - {2} {3}"
                    , expectedLength, expectedLength.PrettyBytes()
                    , realLength, realLength.PrettyBytes()
                );
            }
            Console.WriteLine();

            // Чтение
            using (FileStream readStream = File.OpenRead(tempFileName))
            using (BinaryReader binReader = new BinaryReader(readStream))
            {
                //  Просим BinaryReader прочитать из потока байтовое представление
                //      значения типа int, преобразовать его в int и вернуть нам
                int length = binReader.ReadInt32();
                double[] resultsCopy = new double[length];
                for (int i = 0; i < length; i++)
                {
                    //  Просим BinaryReader прочитать из потока байтовое представление
                    //      значения типа double, преобразовать его в double и вернуть нам
                    resultsCopy[i] = binReader.ReadDouble();

                    Console.WriteLine("{0:F10} - {1}", resultsCopy[i], resultsCopy[i] == results[i] ? "Правильное значение" : "Ошибка!");
                }

                // Блок using автоматически закрывает адаптер и поток когда исполнение
                //  дойдет до закрывающей фигурной скобки. Поэтому нет необходимости
                //  писать строки
                //      binReader.Close();
                //      readStream.Close();
            }

            // Удаляем за собой временный файл
            File.Delete(tempFileName);
        }
    }
}
