using System;
using Shape;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            var comm = "";
            ShapeController controller = new ShapeController();
            while (!comm.Equals("q"))
            {
                controller.Run(comm);
                comm = Console.ReadLine().ToLower();        
            }
        }
    }
}
