using System;
static void Main()
{
    //variables
    int userInput, counter = 1, currentRow =1, currentCol;
    int[,] table;
    bool isInt;

    //validating user input
    Console.WriteLine("*** MAGIC TABLE ***\n");
    Console.Write("Please enter an odd integer number that is greater than one: ");
    isInt = int.TryParse(Console.ReadLine(), out userInput);
    while(!isInt || userInput <= 1 || userInput % 2 == 0)
    {
        Console.Write("Please enter a valid number: ");
        isInt = int.TryParse(Console.ReadLine(), out userInput);
    }
    Console.WriteLine("\n");

    //initializing the table and the first cell
    table = new int[userInput + 1, userInput + 1];
    table[1, (userInput + 1) / 2] = counter;
    currentCol = (userInput + 1) / 2;

    //program logic
    while (counter < Math.Pow(userInput, 2))
    {
        int tempRow = currentRow - 1 == 0 ? userInput : currentRow - 1;
        int tempCol = currentCol - 1 == 0 ? userInput : currentCol - 1;

        if (table[tempRow, tempCol] == 0)
        {
            table[tempRow, tempCol] = ++counter;
            currentRow = tempRow;
            currentCol = tempCol;
        }
        else
        {
            int tempRow2 = currentRow + 1 > userInput ? 1 : currentRow + 1;
            table[tempRow2, currentCol] = ++counter;
            currentRow = tempRow2;
        }
    }

    //print the table to console
    for (int i = 1; i <= userInput; i++)
    {
        for(int j = 1; j <= userInput; j++)
        {
            Console.Write(table[i, j] + "\t");
        }
        Console.WriteLine("\n\n");
    }

    Console.ReadKey();
}