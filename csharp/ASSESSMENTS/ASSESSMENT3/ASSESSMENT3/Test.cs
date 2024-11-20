using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSESSMENT3
{
    class Box
    {
        public int Length { get; set; }
        public int Breadth { get; set; }
        public Box(int length, int breadth)
        {
            Length = length;
            Breadth = breadth;
        }

        public static Box Add(Box box1, Box box2)
        {
            int newLength = box1.Length + box2.Length;
            int newBreadth = box1.Breadth + box2.Breadth;

            return new Box(newLength, newBreadth);
        }

        public void Display()
        {
            Console.WriteLine($"Length: {Length}, Breadth: {Breadth}");
        }
    }

    class Test
    {
        static void Main()
        {
            Console.WriteLine("Enter dimensions for Box 1:");
            Console.Write("Length: ");
            int length1 = int.Parse(Console.ReadLine());
            Console.Write("Breadth: ");
            int breadth1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter dimensions for Box 2:");
            Console.Write("Length: ");
            int length2 = int.Parse(Console.ReadLine());
            Console.Write("Breadth: ");
            int breadth2 = int.Parse(Console.ReadLine());

            Box box1 = new Box(length1, breadth1);
            Box box2 = new Box(length2, breadth2);
            Box box3 = Box.Add(box1, box2);

            Console.WriteLine("\nDetails of the 3rd Box:");
            box3.Display();
            Console.Read();
        }
    }
}
