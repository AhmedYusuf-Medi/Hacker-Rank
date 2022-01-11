namespace _02.FizzBuzz
{
    using System;

    class Program
    {
        //If the number is divisible by 3 then print “fizz”
        //If the number is divisible by 5 then print “buzz”
        //If the number is divisible by both 5 and 3 then print “fizzbuzz”
        //Otherwise just print the number itself

        private const string MultipliedByThreeAndFive = "{0}: FizzBuzz";
        private const string MultipliedByThree = "{0}: Fizz";
        private const string MultipliedByFive = "{0}: Buzz";
        private const string Outside_Of_Constrains = "{0}: out of constrainst!";

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                bool canBeMultipliedByFive = ValidateCanBeMultiplied(i, 5);
                bool canBeMultipliedByThree = ValidateCanBeMultiplied(i, 3);

                if (canBeMultipliedByFive && canBeMultipliedByThree)
                {
                    Console.WriteLine(string.Format(MultipliedByThreeAndFive, i));
                }
                else if (canBeMultipliedByThree)
                {
                    Console.WriteLine(string.Format(MultipliedByThree, i));
                }
                else if (canBeMultipliedByFive)
                {
                    Console.WriteLine(string.Format(MultipliedByFive, i));
                }
                else
                {
                    Console.WriteLine(string.Format(Outside_Of_Constrains, i));
                }
            }
        }

        static bool ValidateCanBeMultiplied(int sourceNumber, int targetNumber)
        {

            return (sourceNumber % targetNumber) == 0;
        }
    }
}