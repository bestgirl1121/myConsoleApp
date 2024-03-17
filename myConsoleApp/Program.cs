using System;

namespace myConsoleApp
{
    public class Program
    {
        static void Main()
        {
            // Ввод исходного массива строк с клавиатуры
            Console.WriteLine("Введите элементы исходного массива строк (чтобы закончить, введите 'end'):");
            string[] originalArray = ReadStringArray();

            // Формирование нового массива из строк, длина которых <= 3
            string[] newArray = FilterArray(originalArray);

            // Вывод нового массива на экран
            Console.WriteLine("\nНовый массив строк из элементов <= 3 символов:");
            foreach (var item in newArray)
            {
                Console.WriteLine(item);
            }
        }

        static string[] ReadStringArray()
        {
            const int initialSize = 5; // Начальный размер массива
            string[] array = new string[initialSize];
            int count = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "end" || count == array.Length)
                {
                    Array.Resize(ref array, count); // Обрезаем массив до фактического размера
                    return array;
                }
                array[count] = input;
                count++;
                if (count == array.Length) Array.Resize(ref array, count * 2); // Увеличиваем размер массива, если он заполнен
            }
        }

        static string[] FilterArray(string[] originalArray)
        {
            int count = 0;

            // Подсчет количества строк, которые удовлетворяют условию
            for (int i = 0; i < originalArray.Length; i++)
            {
                if (originalArray[i] != null && originalArray[i].Length <= 3)
                {
                    count++;
                }
            }

            string[] newArray = new string[count];
            count = 0;

            // Заполнение нового массива со строками длиной <= 3 символов
            for (int i = 0; i < originalArray.Length; i++)
            {
                if (originalArray[i] != null && originalArray[i].Length <= 3)
                {
                    newArray[count] = originalArray[i];
                    count++;
                }
            }

            return newArray;
        }
    }
}