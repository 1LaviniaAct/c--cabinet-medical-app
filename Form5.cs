using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiect_lav
{
    public partial class Form5 : Form
    {
        string connString;
        public Form5()
        {
            InitializeComponent();
            connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = medicamente.accdb";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conexiune = new OleDbConnection(connString);
            OleDbCommand comanda = new OleDbCommand();
            comanda.Connection = conexiune;
            try
            {
                conexiune.Open();
                //comanda.CommandText = "SELECT MAX(ID) FROM studenti";
                //int id = Convert.ToInt32(comanda.ExecuteScalar());

                comanda.CommandText = "INSERT INTO medicamente VALUES (?,?,?,?,?,?)";
                comanda.Parameters.Add("cod", OleDbType.Integer).Value = tbCod.Text;
                comanda.Parameters.Add("nume", OleDbType.Char, 30).Value = tbNume.Text;//un sir de caractere de 30 de caractere
                comanda.Parameters.Add("categorie", OleDbType.Char, 2).Value = tbCategorie.Text;
                comanda.Parameters.Add("substanta_activa", OleDbType.Char).Value = tbSubstanta.Text;
                comanda.Parameters.Add("doza_zilnica", OleDbType.Integer, 2).Value = tbDoza.Text;
                comanda.Parameters.Add("pret", OleDbType.Integer, 2).Value = tbPret.Text;
                comanda.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
                tbNume.Clear();
                tbCod.Clear();
                tbCategorie.Clear();
                tbSubstanta.Clear();
                tbDoza.Clear();
                tbPret.Clear();
            }
        }
    }
}
