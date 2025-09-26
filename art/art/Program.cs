using System;
class Program
{
    static void Main()
    {
        int height =50;  

        for (int i = 1; i <= height; i++)
        {
            
            for (int j = 0; j < height - i; j++)
            {
                Console.Write(" ");
            }

            for (int k = 0; k < (2 * i - 1); k++)
            {
              Console.Write("*");
            }

            Console.WriteLine();
        }

        for (int i = height - 1; i >= 1; i--)
        {
           
            for (int j = 0; j < height - i; j++)
            {
                Console.Write(" ");
            }

            for (int k = 0; k < (2 * i - 1); k++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }
    }
}