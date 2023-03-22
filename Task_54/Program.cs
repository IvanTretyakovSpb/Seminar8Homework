// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит 
// по убыванию элементы каждой строки двумерного массива.
/////////////////////////////////////////////////////////////////////////////////////////////////
Console.Clear();
int rows = GetNumberFromUser("Укажите количество строк массива: ", "Ошибка ввода!");
int columns = GetNumberFromUser("Укажите количество столбцов массива: ", "Ошибка ввода!");
int minValue = GetNumberFromUser("Укажите минимальное значение для элемента массива: ", "Ошибка ввода!");
int maxValue = GetNumberFromUser("Укажите максимальное значение для элемента массива: ", "Ошибка ввода!");
int[,] array = GetArray(rows, columns, minValue, maxValue);
Console.WriteLine("Исходный массив");
PrintArray(array);
Console.WriteLine("Отсортированный построчно по убыванию массив");
GetSortedArray(array);
PrintArray(array);
//////////////////////////////////////////////////////////////////////////////////
// Описание методов
// Запрашивает у пользователя целое положительное число
int GetNumberFromUser(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);
        if (isCorrect && userNumber > 0)
        {
            return userNumber;
        }
        Console.WriteLine(errorMessage);
    }
}
// создаём двумерный массив, заполненный случайными числами
int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}
// В двумерном массиве упорядоченными по убыванию элементы каждой строки.
void GetSortedArray(int[,] arr)
{
    int[] tempArray = new int[arr.GetLength(1)]; // создаём временный одномерный массив для записи элементов каждой строки
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            tempArray[j] = arr[i, j];
        }
        BubbleSort(tempArray); // вспомогательный метод для сортировки элементов одномерного массива по убыванию
        InsertString(i, tempArray, arr); // вспомогательный метод для вставки отсортированного одномерного массива обратно в строку двумерного
    }
}
// Сортировка одномерного массива методом пузырька
void BubbleSort(int[] inArray)
{
    for (int i = 0; i < inArray.Length; i++)
        for (int j = 0; j < inArray.Length - i - 1; j++)
        {
            if (inArray[j] < inArray[j + 1])
            {
                int temp = inArray[j];
                inArray[j] = inArray[j + 1];
                inArray[j + 1] = temp;
            }
        }
}
// Метод для вставки одномерного массива в строку двумерного массива
void InsertString(int stringNumber, int[] array1, int[,] array2)
{
    for (int i = 0; i < array1.Length; i++)
    {
        array2[stringNumber, i] = array1[i];
    }
}
// выводим в консоль элементы двумерного массива построчно
void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]}\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}