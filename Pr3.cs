using System;
using System.Windows.Forms;

namespace Pr3
{
    public partial class Pr3 : Form
    {
        int[] A = new int[] { };
        UInt16 vec;

        public Pr3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            textBox2.Visible = false;
            try
            {
                vec = UInt16.Parse(vk.Text);
            }
            catch (Exception)
            {
                button2.Visible = false;
                label5.Visible = false;
                listBox1.Visible = false;
                MessageBox.Show("Некорректная длина вектора", "ErrorLength", MessageBoxButtons.OK, MessageBoxIcon.Error);
                vk.Focus();
                return;
            }
            button2.Visible = true;
            label5.Visible = true;
            listBox1.Visible = true;
            forming(ref A, vec);
            write_Vector(A, listBox1);
            button2.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            textBox2.Visible = true;
            textBox2.Text = rascet(A, vec).ToString();
            createV(A, ref listBox2);
            button3.Focus();
        }

        static void forming(ref int[] ar, int size)
        {
            Array.Resize(ref ar, size);
            Random m = new Random();
            for (int i = 0; i < ar.Length; i++)
                ar[i] = m.Next(size * 2 + 1) - size;
        }

        static void write_Vector(int[] ar, ListBox LB)
        {
            LB.Items.Clear();
            foreach (int el in ar)
                LB.Items.Add(el);
        }

        static Int64 rascet(int[] mas, int size)
        {
            Int64 sum = 0;
            for (int i = 0; i < size; i++)
                if (mas[i] < 0) sum += mas[i];
            return sum;
        }

        static void createV(int[] mas, ref ListBox LB2)
        {
            LB2.Items.Clear();
            for (int i = 0; i < mas.Length; i++)
                if (mas[i] >= 0) LB2.Items.Add(mas[i]);
        }
    }
}
