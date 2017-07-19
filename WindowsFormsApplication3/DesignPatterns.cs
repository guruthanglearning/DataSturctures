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
    public partial class DesignPatterns : Form
    {
        public DesignPatterns()
        {
            InitializeComponent();
        }

        private void singleton_Click(object sender, EventArgs e)
        {
            Singleton.
        }
    }


    public sealed class Singleton
    {
        private static volatile Singleton instance;
        private static object syncRoot = new Object();

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Singleton();
                    }
                }

                return instance;
            }
        }

        public string TestProperty
        {
            get
            {
                return string.Empty;
            }
        }
    }
}
