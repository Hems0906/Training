using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public delegate void UserDelegate(string message);
    class MultiDeligates
    {
    
        public static void DisplayUser(string Message)
        {
            Console.WriteLine($"{Message} User");
        }

        public static void DisplayAdmin(string Message)
        {
            Console.WriteLine($"{Message} Admin");
        }

       static void Main()
        {
           
            UserDelegate userDelegate = new UserDelegate(DisplayUser);
            userDelegate -= DisplayAdmin;

            userDelegate.Invoke("invoked the UserDelegate");
            Console.Read();
           
        }
    }
}
