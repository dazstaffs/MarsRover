using MarsRover.Domain;
using System;

namespace MarsRover.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            IRover roverOne = new Domain.MarsRover("one", 1, 2, 'N');
            string roverOneInstructions = "LMLMLMLMM";
            roverOne.ProcessInstructions(roverOneInstructions);
            Console.WriteLine(roverOne.ToString());

            IRover roverTwo = new Domain.MarsRover("two", 3, 3, 'E');
            string roverTwoInstructions = "MMRMMRMRRM";
            roverTwo.ProcessInstructions(roverTwoInstructions);
            Console.WriteLine(roverTwo.ToString()); 
        }
    }
}
