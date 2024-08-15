using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace proiect_lav
{
    public partial class Form4 : Form
    {
        string connString;
        public Form4()
        {
            InitializeComponent();
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = medicamente.accdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                //MessageBox.Show("s-a deschis!");
                OleDbCommand comanda = new OleDbCommand();
                comanda.CommandText = "SELECT * FROM medicamente";
                comanda.Connection = conexiune;

                OleDbDataReader reader = comanda.ExecuteReader();
                while (reader.Read())//atata timp cat pot citi din el
                {
                    ListViewItem itm = new ListViewItem(reader["cod"].ToString());
                    itm.SubItems.Add(reader["nume"].ToString());
                    itm.SubItems.Add(reader["categorie"].ToString());
                    itm.SubItems.Add(reader["substanta_activa"].ToString());
                    itm.SubItems.Add(reader["doza_zilnica"].ToString());
                    itm.SubItems.Add(reader["pret"].ToString());
                    listView1.Items.Add(itm);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();//mereu trebuie inchisa conexiunea
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            try
            {
                conexiune.Open();
                OleDbCommand comanda = new OleDbCommand();
                comanda.Connection = conexiune;
                foreach (ListViewItem itm in listView1.Items)
                {
                    if (itm.Checked)
                    {
                        int cod = Convert.ToInt32(itm.SubItems[0].Text);
                        comanda.CommandText = "UPDATE medicamente SET pret='" + textBox1.Text + "' WHERE cod=" + cod;
                        comanda.ExecuteNonQuery();//folosesc asa pt ca e un update
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();//mereu trebuie inchisa conexiunea
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.ShowDialog();
        }
    }
}
