using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThread3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] names =
            {
                "Alex",
                "Lisa",
                "Benita",
                "Aaron",
                "Lance",
                "Charlie",
                "Blair",
                "James",
                "Matt",
                "Jack",
                "Paul",
                "John",
                "Dave",
                "Marry",
                "Tammy",
                "Gabby",
                "Theresa",
                "Magdalena"
            };
            string email;
            Dictionary<string, string> people = new Dictionary<string, string>();
            foreach (string s in names)
            {
                if (!people.TryGetValue(s, out email))
                    people.Add(s, string.Format("{0}@{0}.com",s));

            }

            TestMultiThread tmt = new TestMultiThread();
            tmt.OnCompletedThread += new GetAString(MyGetAString);
            tmt.ProcessStringArrayInMultipleThreads(people);
        }

        private void MyGetAString(string x)
        {
            if (this.listBox1.InvokeRequired)
            {
                GetAString g = new GetAString(PopulateListBox);
                this.Invoke(g, new object[] { x });
            }
            else
            {
                PopulateListBox(x);
            }
        }

        private void PopulateListBox(string x)
        {
            this.listBox1.Items.Add(x);
            this.listBox1.Refresh();
        }
    }
}
