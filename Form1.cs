using proiect_lav;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiect_lav
{
    public partial class Form1 : Form
    {
        List<Reteta> listaRet = new List<Reteta>();
        List<Pacient> listaPacienti = new List<Pacient>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbCod.Text == "")
                errorProvider1.SetError(tbCod, "introduceti codul!");
            else
                if (tbNrMed.Text == "")
                errorProvider1.SetError(tbNrMed, "introduceti nr de medicamente!");
            else
                if (cbCompensata.Text == "")
                errorProvider1.SetError(cbCompensata, "selectati daca reteta este sau nu compensata!");
            else
                if (tbMedicamente.Text == "")
                errorProvider1.SetError(tbMedicamente, "introduceti denumirea medicamentelor!");
            else
                if (tbFrecventa.Text == "")
                errorProvider1.SetError(tbFrecventa, "introduceti de cate ori trebuie luat fiecare medicament prescris!");
            else
            {
                errorProvider1.Clear();
                try
                {
                    //MessageBox.Show("merge baby");
                    int cod = Convert.ToInt32(tbCod.Text);
                    int nrMed = Convert.ToInt32(tbNrMed.Text);
                    string compensata = cbCompensata.Text;
                    string[] medicamente = tbMedicamente.Text.Trim().Split(',');
                    string[] frecventaZiR = tbFrecventa.Text.Trim().Split(',');
                    int[] frecventaZi = new int[frecventaZiR.Length];
                    for (int i = 0; i < nrMed; i++)
                    {
                        frecventaZi[i] = Convert.ToInt32(frecventaZiR[i]);
                    }
                    Reteta r = new Reteta(cod, nrMed, compensata, medicamente, frecventaZi);
                    listaRet.Add(r);
                    MessageBox.Show(r.ToString());

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally//aici golesc casutele, intra pe partea asta orice ar fi
                {
                    tbCod.Clear();
                    tbNrMed.Clear();
                    cbCompensata.Text = "";
                    tbMedicamente.Clear();
                    tbFrecventa.Clear();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //listView1.Items.Clear();
            foreach (Reteta r in listaRet)
            {
                ListViewItem itm = new ListViewItem(r.Cod.ToString());
                itm.SubItems.Add(r.NrMed.ToString());
                itm.SubItems.Add(r.Compensata);

                // Adăugați sub-elementele separate pentru vectorii "medicamente" și "frecventaZi"
                string medicamenteConcatenate = string.Join(", ", r.Medicamente);
                itm.SubItems.Add(medicamenteConcatenate);

                string frecventaZiConcatenata = string.Join(", ", r.FrecventaZi);
                itm.SubItems.Add(frecventaZiConcatenata);

                listView1.Items.Add(itm);
            }
        }

        private void schimbaCuloareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void schimbaFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tbNume.Text == "")
                errorProvider1.SetError(tbNume, "introdu numele!");
            else
                if (tbVarsta.Text == "")
                errorProvider1.SetError(tbVarsta, "introdu varsta!");
            else
                if (cbSex.Text == "")
                errorProvider1.SetError(cbSex, "alege sexul!");
            //if (tbCod.Text == "")
            //    errorProvider1.SetError(tbCod, "introduceti codul!");
            //else
            //    if (tbNrMed.Text == "")
            //    errorProvider1.SetError(tbNrMed, "introduceti nr de medicamente!");
            //else
            //    if (cbCompensata.Text == "")
            //    errorProvider1.SetError(cbCompensata, "selectati daca reteta este sau nu compensata!");
            //else
            //    if (tbMedicamente.Text == "")
            //    errorProvider1.SetError(tbMedicamente, "introduceti denumirea medicamentelor!");
            //else
            //    if (tbFrecventa.Text == "")
            //    errorProvider1.SetError(tbFrecventa, "introduceti de cate ori trebuie luat fiecare medicament prescris!");
            else
            {
                errorProvider1.Clear();
                try
                {
                    string nume = tbNume.Text;
                    int varsta = Convert.ToInt32(tbVarsta.Text);
                    char sex = Convert.ToChar(cbSex.Text);
                    List<Medic> med = new List<Medic>();
                    for(int i=0;i<checkedListBox1.CheckedItems.Count;i++)
                    {
                        Medic m = new Medic(i, checkedListBox1.CheckedItems[i].ToString());
                        med.Add(m);
                    }

                    Pacient p = new Pacient(nume, varsta, sex, listaRet,med);
                    listaPacienti.Add(p);

                    MessageBox.Show("pacient adaugat cu succes!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    tbNume.Clear();
                    tbVarsta.Clear();
                    cbSex.Text = "";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(listaPacienti);
            frm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem itm in listView1.Items)
            {
                if(itm.Checked)
                {
                    int cod = Convert.ToInt32(itm.SubItems[0].Text);
                    for(int i=0;i<listaRet.Count;i++)
                    {
                        if (listaRet[i].Cod == cod)
                            listaRet.RemoveAt(i);
                    }
                    itm.Remove();
                }
            }
        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem itm in listView1.Items)
            {
                if (itm.Selected)
                {
                    int cod = Convert.ToInt32(itm.SubItems[0].Text);
                    for (int i = 0; i < listaRet.Count; i++)
                    {
                        if (listaRet[i].Cod == cod)
                            listaRet.RemoveAt(i);
                    }
                    itm.Remove();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.ShowDialog();
        }
    }
}
