using System;

namespace Lesson2_2
{
    class Program
    {
        public class TestCase
        {
            public int Input { get; set; }

            public int Expected { get; set; }
        }

        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        } // Асимптотическая сложность бинарного поиска - O(log(N))


        static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        var temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }

            }

            return array;
        }
        static void Main(string[] args)
        {
            int[] myArray = new int[] { 10, 58, 1, 12, 42, 15, 65, 110, 17 };

            int[] sortMyArray = BubbleSort(myArray);

            Console.WriteLine("Вывод отсортированного массива:");

            for (int i = 0; i < sortMyArray.Length; i++)
            {
                Console.Write($"{sortMyArray[i]}\t");
            }

            int result = BinarySearch(sortMyArray, 12);

            Console.WriteLine($"\n\nИскомый номер находится под элементом №{result}");

            var testData = new TestCase[2];

            testData[0] = new TestCase()
            {
                Input = 58,
                Expected = 6
            };

            testData[1] = new TestCase()
            {
                Input = 17,
                Expected = 2 // после сортировки число 17 расположено  sortMyArray[4]
            };

            foreach (var testCase in testData)
            {
                var testResult = BinarySearch(sortMyArray, testCase.Input);
                if (testResult == testCase.Expected)
                {
                    Console.WriteLine("Все верно!");
                }
                else
                {
                    Console.WriteLine("Ошибка!");
                }
            }


        }
    }
}
