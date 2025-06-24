using System;

namespace Assignment3
{
    // 1. Create a class called Accounts which has data members/fields like Account no, Customer name, Account type, Transaction type (d/w), amount, balance
    #region
    class Accounts
    {
        int AccNo;
        string CustName;
        string AccTyp;
        char TransType;
        int Amt;
        int Bal;

        public Accounts (int AccNo,string CustName,string AccTyp,char TransType,int Amt,int Bal)
        {
            this.AccNo = AccNo;
            this.CustName = CustName;
            this.AccTyp = AccTyp;
            this.TransType = TransType;
            this.Amt = Amt;
            this.Bal = Bal;

            if (TransType == 'D')
            {
                Credit(Amt);

            }
            else if (TransType == 'W')
            {
                Debit(Amt);
            }
            else
            {
                Console.WriteLine("Invalid Transaction Type Entered...");
            }
        }
        public void Credit(int Amt)
        {
            Bal += Amt;
        }
        public void Debit(int Amt)
        {
            if (Bal <= Amt)
            {
                Bal -= Amt;
            }
            else
            {
                Console.WriteLine("Insufficient Balance ");
            }
        }
        public void ShowData1()
        {
            Console.WriteLine("Account Details");
            Console.WriteLine("####################");
            Console.WriteLine($"Account Number: {AccNo}");
            Console.WriteLine($"Coustomer Name: {CustName}");
            Console.WriteLine($"Account Type: {AccTyp}");
            Console.WriteLine($"Transaction Type: {TransType}");
            Console.WriteLine($"Transaction Amount: {Amt}");
            Console.WriteLine($"Balance Amount: {Bal}");
            Console.WriteLine("####################");
        }
    }
    #endregion

    // 2. Create a class called student which has data members like rollno, name, class, Semester, branch, int[] marks = new int marks[5] (marks of 5 subjects )
    #region
    class Student
    {
        int RollNo;
        string Name;
        string Class;
        int Semester;
        string Branch;
        int[] marks = new int[5];

        public Student(int RollNo, string Name, string Class, int Semester, string Branch)
        {
            this.RollNo = RollNo;
            this.Name = Name;
            this.Class = Class;
            this.Semester = Semester;
            this.Branch = Branch;
        }
        public void GetMarks()
        {
            Console.WriteLine($"Enter Marks for the {Name}:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Subject{i + 1}:");
                marks[i] = int.Parse(Console.ReadLine());
            }
        }
        public void DisplayResult()
        {
            int total = 0;
            bool hasFailed = false;
            foreach (int mark in marks)
            {
                if (mark < 35)
                    hasFailed = true;
                total += mark;
            }
            double average = total / 5.0;
            Console.WriteLine($"Avereage marks : {average}");
            if (hasFailed || average < 50)
            {
                Console.WriteLine("Result:Failed");
            }
            else
            {
                Console.WriteLine("Result:Passed");
            }

        }
        public void DisplayData()
        {
            Console.WriteLine("***Student's Result***");
            Console.WriteLine("----------------------");
            Console.WriteLine($"Roll No :{RollNo}");
            Console.WriteLine($"Name of the Student : {Name}");
            Console.WriteLine($"Class : {Class}");
            Console.WriteLine($"Semester: {Semester}");
            Console.WriteLine($"Branch : {Branch}");
            Console.WriteLine("Marks : " + string.Join(",", marks));


        }
    }
    #endregion

    //3. Create a class called Saledetails which has data members like Salesno,  Productno,  Price, dateofsale, Qty, TotalAmount
    #region

    class Saledetails
    {
        int SalesNo;
        int ProductNo;
        double Price;
        string DateOfSale;
        int Qty;
        double TotalAmount;

        public Saledetails(int SalesNo, int ProductNo,double Price, int Qty,string DateOfSale)
        {
            this.SalesNo = SalesNo;
            this.ProductNo = ProductNo;
            this.Price = Price;
            this.Qty = Qty;
            this.DateOfSale = DateOfSale;

            Sales(Qty, Price);
        }
        public void Sales(int Qty,double Price)
        {
            TotalAmount = Qty * Price;
        }
        public void ShowData2()
        {
            Console.WriteLine("___Sale Details___");
            Console.WriteLine($"Sales No: {SalesNo}");
            Console.WriteLine($"Product No: {ProductNo}");
            Console.WriteLine($"Price : {Price}");
            Console.WriteLine($"Quantity: {Qty}");
            Console.WriteLine($"DateOfSale: {DateOfSale}");
            Console.WriteLine($"Total Amount: {TotalAmount}");
        }
    }


    #endregion
    class Program
    {

     
        static void Main()
        {

            Accounts acc = new Accounts(106, "Hem", "Current", 'D', 5000, 100000);
            acc.ShowData1();

            Student student = new Student(1, "Sid", "Bcom", 2, "Computer Science");
            student.GetMarks();
            student.DisplayData();
            student.DisplayResult();

            Saledetails sale = new Saledetails(2004,308,120.9,18, "25/06/2025");
            sale.ShowData2();
            Console.Read();
        }

    }
}
