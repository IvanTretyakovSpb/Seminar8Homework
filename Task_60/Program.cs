/* Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1) */
/////////////////////////////////////////////////////////////////////////////////////////////////
Console.Clear();
int dimension1 = GetNumberFromUser("Укажите высоту трехмерного массива: ", "Ошибка ввода!");
int dimension2 = GetNumberFromUser("Укажите длину трехмерного массива: ", "Ошибка ввода!");
int dimension3 = GetNumberFromUser("Укажите глубину трехмерного массива: ", "Ошибка ввода!");
int[,,] cube = GetArray(dimension1, dimension2, dimension3);
PrintArray(cube);
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
// создаём двумерный массив, заполненный случайными неповторяющимися двузначными числами
int[,,] GetArray(int dimension1, int dimension2, int dimension3)
{
    int[,,] cubeArray = new int[dimension1, dimension2, dimension3];
    for (int i = 0; i < cubeArray.GetLength(0); i++)
    {
        for (int j = 0; j < cubeArray.GetLength(1); j++)
        {
            for (int l = 0; l < cubeArray.GetLength(2); l++)
            {
                do
                {
                    cubeArray[i, j, l] = new Random().Next(-99, 100);
                } while (IsEqualsAnotherCubeElement(cubeArray[i, j, l], i, j, l, cubeArray));
            }
        }
    }
    return cubeArray;
}
// Вспомогательный метод для проверки наличия равного значения элемента в кубическом массиве
bool IsEqualsAnotherCubeElement(int elementCubeValue, int i, int j, int l, int[,,] cubeArray)
{
    bool IsEquals = false;
    for (int m = 0; m <= i; m++)
    {
        for (int n = 0; n < cubeArray.GetLength(1); n++)
        {
            for (int k = 0; k < cubeArray.GetLength(2); k++)
            {
                if (elementCubeValue == cubeArray[m, n, k] && !(m == i && n == j && k == l)) // исключаем случай сравнивания элемента с самим сабой в вошедшем массиве
                {
                    IsEquals = true;
                }
            }
        }
    }
    return IsEquals;
}
// выводим в консоль элементы трехмерного массива по каждому измерению
void PrintArray(int[,,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            for (int l = 0; l < inArray.GetLength(2); l++)
            {

                Console.Write($"{inArray[i, j, l]} ({i}, {j}, {l})\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}