using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace proiect_lav
{
    public partial class Form2 : Form
    {
        List<Pacient> lista2;
        public Form2(List<Pacient> lista)
        {
            InitializeComponent();
            lista2 = lista;
            foreach (Pacient p in lista)
                textBox1.Text += p.ToString() + Environment.NewLine;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void salvareFisierTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "(*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                sw.WriteLine(textBox1.Text);//scriu continutul din textbox ul din form ul 2 in fisier
                sw.Close();
                textBox1.Clear();
            }
        }

        private void citireFisierTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                textBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void serializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("fisier.dat", FileMode.Create, FileAccess.Write);
            //bf.Serialize(fs, textBox1.Text);
            bf.Serialize(fs, lista2);
            fs.Close();
            textBox1.Clear();
        }

        private void deserializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("fisier.dat", FileMode.Open, FileAccess.Read);
            //textBox1.Text=(string)bf.Deserialize(fs);
            List<Pacient> lista3 = (List<Pacient>)bf.Deserialize(fs);
            foreach (Pacient p in lista3)
                textBox1.Text += p.ToString() + Environment.NewLine;
            fs.Close();
        }
    }
}
