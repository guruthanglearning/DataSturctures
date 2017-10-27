using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ExtensionMethodsDemo1;
namespace WindowsFormsApplication3
{
    public partial class General : Form
    {
        delegate string Del(string s);

        public General()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList data = new ArrayList();
            data.Add("1");
            int i = 2;
            data.Add(i);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hashtable table = new Hashtable();
            table.Add("1", "one");
            table.Add(1, "two");
            table.Add(1, "three");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Del a, b, c, d;
            a = Hello;
            b = Goodbye;
            c = a+b;
            d = c-b;

            string data;
            data = a("Testing Hello");
            MessageBox.Show(data);
            data = b("GoodBye");
            MessageBox.Show(data);
            data = c("Combine a and B");
            MessageBox.Show(data);
            data = d("Combine a and b minus a");
            MessageBox.Show(data);
        }


        private string Hello(string s)
        {
            string data = "Returning from Hello Method " + s;
            //MessageBox.Show(data);
            return data ;
        }

        private string Goodbye(string s)
        {
            string data = "Returning from GoodBye Method " + s;
            //MessageBox.Show(data);
            return data;            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           Circle c = new Circle();
             c.Draw();
            Shape s = (Shape) c ;
            s.Draw();
         

            Circle1 c1 = new Circle1();
            c1.Draw();
            Circle c2 = (Circle)c1;
            c2.Draw();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int? x = null; int y = x ?? -1;
            MessageBox.Show(y.ToString());

            List<int> lt = new List<int>();
            int[] lti = new int[]{};

            object t1 = new object();
            t1= 1;
            MessageBox.Show(t1.ToString());
            object t2 = t1;
            //t1 = 2;

            if (t1.Equals(t2))
            {
                MessageBox.Show(t1.ToString() + "   " + t2.ToString());
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Digit dig = new Digit(7);
            //This call invokes the implicit "double" operator
            double num = dig;
            //This call invokes the implicit "Digit" operator
            Digit dig2 = 12;
            MessageBox.Show(string.Format("num = {0} dig2 = {1}", num, dig2.val));
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ExtMethodDemo test = new ExtMethodDemo();
            test.CallMethod();

            Temp T = new Temp() { ID = 1, Name = "Test" };

            var MyProduct = new
            {
                Name = "Vacuum Cleaner",
                Price = 94.99,
                Description = "Really sucks! Have your carpets clean in no time."
            };
            MessageBox.Show(MyProduct.Description);

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);

            int i=0;
            MessageBox.Show((++i).ToString() + "      " + (i++).ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Hashtable hashTable = new Hashtable();
            //List<string> list = new List<string>();
            
            //for ( int i = 0;i <5000; i++)
            //{
            //    if (list.Where(w=>w == string.Format("{0}-{1}",i.ToString().GetHashCode().ToString(),i.ToString())).Count()>0)
            //    {
            //        MessageBox.Show(list.Where(w => w == string.Format("{0}-{1}", i.GetHashCode().ToString(), i.ToString())).First());
            //        break;
            //    }
            //    list.Add(string.Format("{0}-{1}", i.ToString().GetHashCode().ToString(), i.ToString()));

            //}


            
            hashTable.Add("1000", 10);           
            hashTable.Add("2000", 10);

            
            

            foreach (DictionaryEntry key in hashTable)
            {
                MessageBox.Show(key.GetHashCode().ToString());
            }


       
        }

        private void button9_Click(object sender, EventArgs e)
        {
      

        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Display powers of 2 up to the exponent of 8:
            foreach (int i in Power(2, 8))
            {
                Console.Write("{0} ", i);
            }

        }

        public static System.Collections.Generic.IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var theGalaxies = new Galaxies();
            foreach (Galaxy theGalaxy in theGalaxies.NextGalaxy)
            {
                MessageBox.Show(theGalaxy.Name + " " + theGalaxy.MegaLightYears.ToString());
            }

        }


        public class Galaxies
        {

            public System.Collections.Generic.IEnumerable<Galaxy> NextGalaxy
            {
                get
                {
                    yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                    yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                    yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                    yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
                }
            }

        }

        public class Galaxy
        {
            public String Name { get; set; }
            public int MegaLightYears { get; set; }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            IGeneralInterfaceTest t = new GeneralTest();
            t.Test();

            t = new GeneralInterfaceTest();
            t.Test();
        }

        private void button13_Click(object sender, EventArgs e)
        {


            Test tc = new Test();
            tc.i = 1000;
            TestClass(tc);
            MessageBox.Show(tc.i.ToString());

            StructTest t = new StructTest();
            t.i = 1000;
            TestStruct(t);
            MessageBox.Show(t.i.ToString());
        }



        private void TestClass(Test t)
        {
            t.i = 100;
        }

        private void TestStruct(StructTest t)
        {
            t.i = 100;
        }

        class Test
        {
            public int i;
        }

        struct StructTest
        {
            public int i;
        }

        public class A
        {
            public int A1;
        }
        

        public class B : A
        {
            public int B1;
        }

        public string ValidateChain(string input)
        {
            //MessageBox.Show(ValidateChain("4-2;BEGIN-3;3-4;"));
            string good = "GOOD";
            string bad = "BAD";
            string begin = "BEGIN";
            string end = "END";

            if (string.IsNullOrWhiteSpace(input) || !(input.Contains(begin+"-") && input.Contains("-" + end)))
            {
                return bad;
            }

            Dictionary<string, string> pairs = new Dictionary<string, string>();
            foreach (string str in input.Split(';'))
            {
                string[] pair = str.Split('-');
                int count = pair.Count();
                if (count > 0 && count == 2)
                {
                    pairs.Add(pair[0], pair[1]);
                }
                else
                {
                    return bad;
                }
            }

            if (pairs.Count > 0 && pairs.ContainsKey(begin) && pairs.ContainsValue(end))
            {
                string nextAddress = pairs[begin];
                int pairCount = 1;
                while (!string.IsNullOrWhiteSpace(nextAddress))
                {
                    if (pairs.ContainsKey(nextAddress))
                    {
                        nextAddress = pairs[nextAddress];
                        pairCount++;
                        if (nextAddress == end)
                        {
                            break;
                        }
              
                    }
                    else
                    {
                        nextAddress = string.Empty;
                    }

                }

                if (pairCount == pairs.Count)
                {
                    return good;
                }
            }
            return bad;


        }

        private void button14_Click(object sender, EventArgs e)
        {
            StructTestInterface t = new StructTestInterface();
            t.i = 100;
            t.j = -100;
            t.Test();

            MessageBox.Show($"I={t.i.ToString()}, J={t.j.ToString()}");

            Base b = new Derived();
            Derived d = new Derived();
            b.Test();

            AbstractClassDervied ab = new AbstractClassDervied();
            ab.AbstractClassMethod2();           


        }


        abstract class AbstractClass
        {
            public abstract void AbstractClassMethod1();
            public virtual void AbstractClassMethod2()
            {
                MessageBox.Show("Base - Testing Abstract class method");
            }
        }


        class AbstractClassDervied : AbstractClass
        {
            public override void AbstractClassMethod1()
            {
                MessageBox.Show("Testing Abstract class method implementation in dervied class");
            }
            public override void AbstractClassMethod2()
            {
                MessageBox.Show("Testing Abstract class method");
            }
            public void Test()
            {

            }
        }


        class Base
        {
            public int i;

            public virtual void Test()
            {
                MessageBox.Show("Base");
            }
        }

        class Derived : Base
        {
            public override void Test()
            {
                MessageBox.Show("Derived");
            }
        }
        

        private void OutParameterFunction(out int i)
        {
            i = 1;
        }

        private void RefParameterFunction(ref int i)
        {
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int m = 1 ;
            this.RefParameterFunction(ref m);
            this.OutParameterFunction(out m);
            string message = "Ref parameter should be initialized before passing to the calling method \n";
            message += "Out Parameter is not reuqired to initialized before passing to the calling method but inside the calling method it should be initialized";
        }

        private void button15_Click_1(object sender, EventArgs e)
        {

        }
    }


    public struct StructTestInterface : IGeneralInterfaceTest
    {
        public int i;
        public int j;
        

        public void Test()
        {
            this.i = 1000;
            this.j = i;            
        }   
    }

    interface IGeneralInterfaceTest
    {
       void Test();
    }

    class GeneralInterfaceTest : IGeneralInterfaceTest
    {
        public virtual void Test()
        {
            MessageBox.Show(this.GetType().Name);
        }
    }

    class GeneralTest: GeneralInterfaceTest, IGeneralInterfaceTest
    {
       
    }

    class Temp
    {
        public int ID;
        public string Name;
    }


    public class Shape
    {
        // A few example members
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Height { get; set; }
        public int Width { get; set; }

        // Virtual method
        public virtual void Draw()
        {
            MessageBox.Show("Performing base class drawing tasks");
        }
    }

    class Circle : Shape
    {
        public sealed override  void Draw()
        {
            // Code to draw a circle...
            MessageBox.Show("Drawing a circle");            
        }
    }
    class Rectangle : Shape
    {
        public override void Draw()
        {
            // Code to draw a rectangle...
            MessageBox.Show("Drawing a rectangle");
        }
    }
    class Triangle : Shape
    {
        public override void Draw()
        {
            // Code to draw a triangle...
            MessageBox.Show("Drawing a triangle");
        }
    }

    class Circle1 : Circle
    {

        public new void Draw()
        {
            MessageBox.Show("Drawing a Circle1");
        }
    }


    class Digit
    {
        public Digit(double d) { val = d; }
        public double val;
        // ...other members

        // User-defined conversion from Digit to double
        public static implicit operator double(Digit d)
        {
            return d.val;
        }
        //  User-defined conversion from double to Digit
        public static implicit operator Digit(double d)
        {
            return new Digit(d);
        }
    }
}

// Define an interface named IMyInterface.
namespace DefineIMyInterface
{
    using System;

    public interface IMyInterface
    {
        // Any class that implements IMyInterface must define a method
        // that matches the following signature.
        void MethodB();
    }
}


// Define extension methods for IMyInterface.
namespace Extensions
{
    using System;
    using DefineIMyInterface;

    // The following extension methods can be accessed by instances of any 
    // class that implements IMyInterface.
    public static class Extension
    {
        public static void MethodA(this IMyInterface myInterface, int i)
        {
            Console.WriteLine
                ("Extension.MethodA(this IMyInterface myInterface, int i)");
        }

        public static void MethodA(this IMyInterface myInterface, string s)
        {
            Console.WriteLine
                ("Extension.MethodA(this IMyInterface myInterface, string s)");
        }

        // This method is never called in ExtensionMethodsDemo1, because each 
        // of the three classes A, B, and C implements a method named MethodB
        // that has a matching signature.
        public static void MethodB(this IMyInterface myInterface)
        {
            Console.WriteLine
                ("Extension.MethodB(this IMyInterface myInterface)");
        }
    }
}


// Define three classes that implement IMyInterface, and then use them to test
// the extension methods.
namespace ExtensionMethodsDemo1
{
    using System;
    using Extensions;
    using DefineIMyInterface;

    class A : IMyInterface
    {
        public void MethodB() { Console.WriteLine("A.MethodB()"); }
    }

    class B : IMyInterface
    {
        public void MethodB() { Console.WriteLine("B.MethodB()"); }
        public void MethodA(int i) { Console.WriteLine("B.MethodA(int i)"); }
    }

    class C : IMyInterface
    {
        public void MethodB() { Console.WriteLine("C.MethodB()"); }
        public void MethodA(object obj)
        {
            Console.WriteLine("C.MethodA(object obj)");
        }
    }

    class ExtMethodDemo
    {
        public void CallMethod()
        {
            // Declare an instance of class A, class B, and class C.
            A a = new A();
            B b = new B();
            C c = new C();

            // For a, b, and c, call the following methods:
            //      -- MethodA with an int argument
            //      -- MethodA with a string argument
            //      -- MethodB with no argument.

            // A contains no MethodA, so each call to MethodA resolves to 
            // the extension method that has a matching signature.
            a.MethodA(1);           // Extension.MethodA(object, int)
            a.MethodA("hello");     // Extension.MethodA(object, string)

            // A has a method that matches the signature of the following call
            // to MethodB.
            a.MethodB();            // A.MethodB()

            // B has methods that match the signatures of the following
            // nethod calls.
            b.MethodA(1);           // B.MethodA(int)
            b.MethodB();            // B.MethodB()

            // B has no matching method for the following call, but 
            // class Extension does.
            b.MethodA("hello");     // Extension.MethodA(object, string)

            // C contains an instance method that matches each of the following
            // method calls.
            c.MethodA(1);           // C.MethodA(object)
            c.MethodA("hello");     // C.MethodA(object)
            c.MethodB();            // C.MethodB()

        }
    }
}