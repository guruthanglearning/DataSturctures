using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Threading;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Employee emp = new Employee();
            emp.Id = 1;
            emp.Name = "Testing1";
            emp.salary = 1000;

            float salary = emp.salary;

            Employee shallowCopy = (Employee)emp.Clone();
            shallowCopy.salary = 2000;
            MessageBox.Show("Origian Value:= " + emp.salary.ToString() + " Shallow copy:=" + shallowCopy.salary.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create an instance of Person and assign values to its fields.
            Person p1 = new Person();
            p1.Age = 42;
            p1.Name = "Sam";
            p1.IdInfo = new IdInfo(6565);

            // Perform a shallow copy of p1 and assign it to p2.
            Person p2 = (Person)p1.ShallowCopy();
            DisplayValues(p1);
            DisplayValues(p2);

            p1.Age = 32;
            p1.Name = "Frank";
            p1.IdInfo.IdNumber = 7878;
            DisplayValues(p1);
            DisplayValues(p2);
            
            //Person p3 = p1.DeepCopy();            
            //p1.Name = "George";
            //p1.Age = 39;
            //p1.IdInfo.IdNumber = 8641;
            //DisplayValues(p1);            
            //DisplayValues(p3);


        }

        public void DisplayValues(Person p)
        {
            MessageBox.Show(string.Format("Name: {0:s}, Age: {1:d},Value: {0:d}", p.Name, p.Age.ToString(), p.IdInfo.IdNumber.ToString()));            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Abstract factory #1

            AbstractFactory factory1 = new ConcreteFactory1();

            Client client1 = new Client(factory1);

            client1.Run();



            // Abstract factory #2

            AbstractFactory factory2 = new ConcreteFactory2();

            Client client2 = new Client(factory2);

            client2.Run();
 
 

        }


        enum test
        {
            A =1,
            B=2
        }

        private void button4_Click(object sender, EventArgs e)
        {
            object m = "fsdfadf";
            long t = 0;
            if (long.TryParse(m.ToString(), out t))
            {
                MessageBox.Show(t.ToString());
            }
            MessageBox.Show(Convert.ToInt32(test.A).ToString());
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            XElement elements = XElement.Load(@"C:\Personal\Study\WindowsFormsApplication3\XMLFile1.xml");
            foreach(XElement x in elements.Descendants())
            {
                string fileName = x.Attribute("Name").Value;
                if (File.Exists(fileName))
                { 
                    try
                    {
                    
                        using (StreamWriter writer = File.AppendText(fileName))
                        {
                            writer.Write(' ');
                        }
                        File.AppendAllText(@"E:\Temp\TempLog\Success.txt", $"{fileName} \n");
                    }
                    catch(Exception ex)
                    {
                        File.AppendAllText(@"E:\Temp\TempLog\Failure.txt", $"{fileName} {ex.StackTrace} \n");
                    }
                }
                else
                {
                    File.AppendAllText(@"E:\Temp\TempLog\FileNotExists.txt", $"{fileName} \n");
                }
            }

            MessageBox.Show("Completed");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int workerThreads = 0;
            int completionThreads = 0;
            ThreadPool.GetMaxThreads(out workerThreads, out completionThreads);
            MessageBox.Show($"Worker Threads{workerThreads} Completion Threads {completionThreads}");
        }
    }

    public class Employee
    {
        public string Name;
        public int Id;
        public float salary;

        public Employee Clone()
        {
            return (Employee) this.MemberwiseClone();
        }
    }

    public class Person
    {
        public int Age;
        public string Name;
        public IdInfo IdInfo;

        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person other = (Person)this.MemberwiseClone();
            other.IdInfo = new IdInfo(this.IdInfo.IdNumber);
            return other;
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int IdNumber)
        {
            this.IdNumber = IdNumber;
        }
    }


    /// <summary>

    /// The 'AbstractFactory' abstract class

    /// </summary>

    abstract class AbstractFactory
    {

        public abstract AbstractProductA CreateProductA();

        public abstract AbstractProductB CreateProductB();

    }





    /// <summary>

    /// The 'ConcreteFactory1' class

    /// </summary>

    class ConcreteFactory1 : AbstractFactory
    {

        public override AbstractProductA CreateProductA()
        {

            return new ProductA1();

        }

        public override AbstractProductB CreateProductB()
        {

            return new ProductB1();

        }

    }



    /// <summary>

    /// The 'ConcreteFactory2' class

    /// </summary>

    class ConcreteFactory2 : AbstractFactory
    {

        public override AbstractProductA CreateProductA()
        {

            return new ProductA2();

        }

        public override AbstractProductB CreateProductB()
        {

            return new ProductB2();

        }

    }



    /// <summary>

    /// The 'AbstractProductA' abstract class

    /// </summary>

    abstract class AbstractProductA
    {

    }



    /// <summary>

    /// The 'AbstractProductB' abstract class

    /// </summary>

    abstract class AbstractProductB
    {

        public abstract void Interact(AbstractProductA a);

    }





    /// <summary>

    /// The 'ProductA1' class

    /// </summary>

    class ProductA1 : AbstractProductA
    {

    }



    /// <summary>

    /// The 'ProductB1' class

    /// </summary>

    class ProductB1 : AbstractProductB
    {

        public override void Interact(AbstractProductA a)
        {

            MessageBox.Show(this.GetType().Name +

              " interacts with " + a.GetType().Name);

        }

    }



    /// <summary>

    /// The 'ProductA2' class

    /// </summary>

    class ProductA2 : AbstractProductA
    {

    }



    /// <summary>

    /// The 'ProductB2' class

    /// </summary>

    class ProductB2 : AbstractProductB
    {

        public override void Interact(AbstractProductA a)
        {

            MessageBox.Show(this.GetType().Name +

              " interacts with " + a.GetType().Name);

        }

    }



    /// <summary>

    /// The 'Client' class. Interaction environment for the products.

    /// </summary>

    class Client
    {

        private AbstractProductA _abstractProductA;

        private AbstractProductB _abstractProductB;



        // Constructor

        public Client(AbstractFactory factory)
        {

            _abstractProductB = factory.CreateProductB();

            _abstractProductA = factory.CreateProductA();

        }



        public void Run()
        {

            _abstractProductB.Interact(_abstractProductA);

        }

    }

}
