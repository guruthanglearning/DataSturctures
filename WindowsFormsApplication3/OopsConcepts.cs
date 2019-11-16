using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
namespace WindowsFormsApplication3
{
    public partial class OopsConcepts : Form
    {
        public OopsConcepts()
        {
            InitializeComponent();
        }

        public class ProtectedAccessSpecifierBase
        {
            protected int data = 0;

            protected void Display(string input)
            {
                MessageBox.Show(this.GetType() + " " + input);
            }
        }

        public class ProtectedAccessSpecifierDerived : ProtectedAccessSpecifierBase
        {
           public void Display()
            {
                this.data = 100;
            }
        }



        private void btn_Protected_Access_Specifier_Click(object sender, EventArgs e)
        {
            ProtectedAccessSpecifierDerived b = new ProtectedAccessSpecifierDerived();
            b.Display();

        }


        public class BaseClassForAbstractClass
        {
            public void BaseClassForAbstractClass_Method1()
            {
                MessageBox.Show("BaseClassForAbstractClass_Method1");
            }
        }

       public abstract class AbstractClassCreatingInstance : BaseClassForAbstractClass
        {
            private int test = 0;
            protected AbstractClassCreatingInstance()
            {

            }


            public abstract void AbstractClassCreatingInstance_Method1();

            public virtual void AbstractClassCreatingInstance_Method2()
            {
                
                MessageBox.Show("Abstract class AbstractClassCreatingInstance_Method2");                
            }

            public void AbstractClassCreatingInstance_Method3()
            {
                MessageBox.Show("AbstractClassCreatingInstance_Method3");
            }
        }

        public class DerivedClassForAbstractClassWhichInsertNormalClass: AbstractClassCreatingInstance
        {            
            public DerivedClassForAbstractClassWhichInsertNormalClass()
            {
               
            }

            public override void AbstractClassCreatingInstance_Method1()
            {
                MessageBox.Show("DerivedClassForAbstractClassWhichInsertNormalClass.AbstractClassCreatingInstance_Method1");
            }

            public void AbstractClassCreatingInstance_Method3()
            {
                MessageBox.Show("DerivedClassForAbstractClassWhichInsertNormalClass.AbstractClassCreatingInstance_Method3");
            }

        }

        private void btn_Abstract_Class_Click(object sender, EventArgs e)
        {
            //AbstractClassCreatingInstance[] i = new AbstractClassCreatingInstance[10];
            DerivedClassForAbstractClassWhichInsertNormalClass t = new DerivedClassForAbstractClassWhichInsertNormalClass();
            t.BaseClassForAbstractClass_Method1();
            t.AbstractClassCreatingInstance_Method1();
            t.AbstractClassCreatingInstance_Method3();


            StaticMemberTest test = new StaticMemberTest();
            
        }

        public class BaseProtected
        {
            protected int count;
        }

        public class DerivedProtected : BaseProtected
        {
            public int Test()
            {
                return this.count = 0;
            }
        }


        public class StaticMemberTest
        {
            public const int TestingConstanct = 1234;
            public static int Test1;
            public static int Test2;
            public int Test3;

            public int Test()
            {

                return Test1;
            }

            public static int StaticTestFunction()
            {
                return Test2;
            }

            public static int StaticTestFunction(int t)
            {
                return t;
            }

        }

        private void btn_Static_Constructor_in_Sealed_Class_Click(object sender, EventArgs e)
        {
            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-constructors
                Thread t1 = new Thread(TestForStaticConstructor.GetInstance);                
                Thread t2 = new Thread(TestForStaticConstructor.GetInstance);
                t1.Name = "t1";
                t2.Name = "t2";

                t1.Start();
                t2.Start();
    

        }

        public sealed class TestForStaticConstructor
        {

            public static readonly TestForStaticConstructor instance;

            private TestForStaticConstructor()
            {

            }

            static TestForStaticConstructor()
            {                
                instance = new TestForStaticConstructor();
                MessageBox.Show($"Static TestForStaticConstructor { Thread.CurrentThread.Name}");
            }

            public static TestForStaticConstructor Instance
            {
                get
                {                   
                    return instance;
                }
            }

            public static void GetInstance()
            {
               var t =  TestForStaticConstructor.Instance;
                MessageBox.Show($"GetInstance Method { Thread.CurrentThread.Name}");
            }


        }

        private void btn_Shallow_Copy_vs_Deep_Copy_Click(object sender, EventArgs e)
        {
            /*
                Shallow Copy means its copies the structure behind the scenes both objects reference the same memory address;
                https://docs.microsoft.com/en-us/dotnet/api/system.object.memberwiseclone?view=netframework-4.8

            The MemberwiseClone method creates a shallow copy by creating a new object, and then copying the nonstatic fields of the current object to the new object. If a field is a value type, 
            a bit-by-bit copy of the field is performed. If a field is a reference type, the reference is copied but the referred object is not; therefore, the original object and its clone refer 
            to the same object.

            For example, consider an object called X that references objects A and B. Object B, in turn, references object C. A shallow copy of X creates new object X2 that also references objects 
            A and B. In contrast, a deep copy of X creates a new object X2 that references the new objects A2 and B2, which are copies of A and B. B2, in turn, references the new object C2, 
            which is a copy of C. The example illustrates the difference between a shallow and a deep copy operation.

            There are numerous ways to implement a deep copy operation if the shallow copy operation performed by the MemberwiseClone method does not meet your needs. These include the following:

            Call a class constructor of the object to be copied to create a second object with property values taken from the first object. This assumes that the values of an object are entirely
            defined by its class constructor.

            Call the MemberwiseClone method to create a shallow copy of an object, and then assign new objects whose values are the same as the original object to any properties or fields whose 
            values are reference types. The DeepCopy method in the example illustrates this approach.

            Serialize the object to be deep copied, and then restore the serialized data to a different object variable.

            Use reflection with recursion to perform the deep copy operation.
             */

            StringBuilder result = new StringBuilder();

            ShallowVsDeepCopy shallow1 = new ShallowVsDeepCopy() { Data1 = 1, Data2 = 2 };

            result.AppendLine($"{nameof(shallow1)} : Data1 : {shallow1.Data1} Data2 :{shallow1.Data1}" );
            ShallowVsDeepCopy shallow2 = shallow1.Clone();
            shallow2.Data2 = 3;
            result.AppendLine($"{nameof(shallow2)} : Data1 : {shallow2.Data1} Data2 :{shallow2.Data2}");
            result.AppendLine($"{nameof(shallow1)} : Data1 : {shallow1.Data1} Data2 :{shallow1.Data2}");
            ShallowVsDeepCopy shallow3 = shallow1.DeepClone();
            result.AppendLine($"{nameof(shallow3)} : Data1 : {shallow3.Data1} Data2 :{shallow3.Data2}");
            MessageBox.Show(result.ToString());



        }

        public class ShallowVsDeepCopy
        {
            public int Data1;
            public int Data2;

            public ShallowVsDeepCopy Clone()
            {
                return (ShallowVsDeepCopy)this.MemberwiseClone() ;
            }

            public ShallowVsDeepCopy DeepClone()
            {
                ShallowVsDeepCopy c = (ShallowVsDeepCopy)this.MemberwiseClone();
                c.Data1 = 4;
                c.Data2 = 6;
                return c;
            }

        }

    }

}
