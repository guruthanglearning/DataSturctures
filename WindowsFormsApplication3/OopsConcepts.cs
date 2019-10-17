using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

    }
}
