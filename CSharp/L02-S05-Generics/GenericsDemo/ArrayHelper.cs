using System;
using System.Linq;

namespace GenericsDemo
{
    static class ArrayHelper
    {
        static Random rnd = new Random();

        /// <summary>
        /// Обобщенный метод для перемешивания массивов любого типа
        /// Используется алгоритм Фишера–Йетса
        /// https://ru.wikipedia.org/wiki/%D0%A2%D0%B0%D1%81%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5_%D0%A4%D0%B8%D1%88%D0%B5%D1%80%D0%B0%E2%80%93%D0%99%D0%B5%D1%82%D1%81%D0%B0
        /// </summary>
        /// <typeparam name="T">Тип-параметр с именем T обозначает тип элемента массива</typeparam>
        /// <param name="array">Массив содержимое которого нужно перемешать</param>
        public static void Shuffle<T>(T[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(0, i + 1);
                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}
