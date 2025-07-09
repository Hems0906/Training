using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge3
{
    class Box
    {
        public int Length;
        public int Breadth;

        public void GetBoxData()
        {
            Console.Write("Enter Length: ");
            Length = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Breadth: ");
            Breadth = Convert.ToInt32(Console.ReadLine());
        }

        public void Display()
        {
            Console.WriteLine("Length: " + Length);
            Console.WriteLine("Breadth: " + Breadth);
        }

        public Box Add(Box b)
        {
            Box temp = new Box();
            temp.Length = this.Length + b.Length;
            temp.Breadth = this.Breadth + b.Breadth;
            return temp;
        }
    }

    class Test
    {
        static void Main()
        {
            Box box1 = new Box();
            Box box2 = new Box();

            Console.WriteLine("Enter details for Box 1:");
            box1.GetBoxData();

            Console.WriteLine("Enter details for Box 2:");
            box2.GetBoxData();

            Box box3 = box1.Add(box2);

            Console.WriteLine("Box 3 (Adding Both Box 1&2):");
            box3.Display();
            Console.Read();
        }
    }

}
