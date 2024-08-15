using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiect_lav
{
    public partial class Form3 : Form
    {
        double[] vect = new double[20];
        int nrElem = 0;
        bool vb = false;//ma ajuta sa validez daca am citit sau nu cu succes

        Graphics gr;//un obiect din clasa Graphics
        const int marg = 10;
        Color culoare = Color.BlueViolet;
        public Form3()
        {
            InitializeComponent();
            gr = panel1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("frecventa.txt");
            string linie = null;
            while ((linie = sr.ReadLine()) != null)
            {
                vect[nrElem] = Convert.ToDouble(linie);
                nrElem++;
                vb = true;
            }
            sr.Close();
            MessageBox.Show("date incarcate!");
            panel1.Invalidate();//sa declanseze panel1_Paint
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (vb == true)//daca am citit cu succes
            {
                Rectangle rec = new Rectangle(panel1.ClientRectangle.X + marg,
                    panel1.ClientRectangle.Y + 2 * marg,
                    panel1.ClientRectangle.Width - 2 * marg,
                    panel1.ClientRectangle.Height - 3 * marg);//x este coordonata pe orizontala
                Pen pen = new Pen(Color.Red, 3);
                gr.DrawRectangle(pen, rec);

                double latime = rec.Width / nrElem / 2;//acel /2 ca sa fie o distanta intre dreptunghiuri
                double distanta = (rec.Width - nrElem * latime) / (nrElem + 1);
                double vMax = vect.Max();//e o functie care afla elem maxim al vectorului

                Brush br = new SolidBrush(culoare);

                Rectangle[] recs = new Rectangle[nrElem];//vector de dreptunghiuri
                for (int i = 0; i < nrElem; i++)
                {
                    recs[i] = new Rectangle((int)(rec.Location.X + (i + 1) * distanta + i * latime),
                        (int)(rec.Location.Y + rec.Height - vect[i] / vMax * rec.Height),
                        (int)latime,
                        (int)(vect[i] / vMax * rec.Height));
                    // gr.FillRectangle(br, recs[i]);//asta deseneaza dreptunghi cu dreptunghi, pe rand
                    //gr.FillEllipse(br, recs[i]);
                    //gr.DrawRectangle(pen, recs[i]);
                    gr.DrawString(vect[i].ToString(), this.Font,
                        new SolidBrush(Color.Black), (int)(recs[i].Location.X + latime / 2 - 5),
                        (int)(recs[i].Location.Y + recs[i].Height / 2 - this.Font.Height));
                    //uita te in seminar la partea asta de sus ca a mai facut ceva si tu n ai apucat sa vezi
                    gr.DrawLine(pen, new Point((int)(recs[i].Location.X + latime / 2), recs[i].Location.Y),
                        new Point((int)(recs[i].Location.X + latime / 2), recs[i].Location.Y + recs[i].Height));
                }
                //gr.FillRectangles(br, recs);//asta deseneaza tot vectorul odata

                for (int i = 0; i < nrElem - 1; i++)//asta e ca sa apara linia aia de sus care le uneste pe toate celelalte
                {
                    gr.DrawLine(pen, new Point((int)(recs[i].Location.X + latime / 2),
                        recs[i].Location.Y),
                        new Point((int)(recs[i + 1].Location.X + latime / 2),
                        recs[i + 1].Location.Y));
                }
            }
        }

        private void pd_print(object sender, PrintPageEventArgs e)
        {
            if (vb == true)//daca am citit cu succes
            {
                gr = e.Graphics;
                Rectangle rec = new Rectangle(e.PageBounds.X + marg,
                    e.PageBounds.Y + 2 * marg,
                    e.PageBounds.Width - 2 * marg,
                    e.PageBounds.Height - 3 * marg);//x este coordonata pe orizontala
                Pen pen = new Pen(Color.Red, 3);
                gr.DrawRectangle(pen, rec);

                double latime = rec.Width / nrElem / 2;//acel /2 ca sa fie o distanta intre dreptunghiuri
                double distanta = (rec.Width - nrElem * latime) / (nrElem + 1);
                double vMax = vect.Max();//e o functie care afla elem maxim al vectorului

                Brush br = new SolidBrush(culoare);

                Rectangle[] recs = new Rectangle[nrElem];//vector de dreptunghiuri
                for (int i = 0; i < nrElem; i++)
                {
                    recs[i] = new Rectangle((int)(rec.Location.X + (i + 1) * distanta + i * latime),
                        (int)(rec.Location.Y + rec.Height - vect[i] / vMax * rec.Height),
                        (int)latime,
                        (int)(vect[i] / vMax * rec.Height));
                    // gr.FillRectangle(br, recs[i]);//asta deseneaza dreptunghi cu dreptunghi, pe rand
                    gr.FillEllipse(br, recs[i]);
                    //gr.DrawRectangle(pen, recs[i]);
                    gr.DrawString(vect[i].ToString(), this.Font,
                        br, recs[i].Location.X, recs[i].Location.Y - this.Font.Height);
                    //uita te in seminar la partea asta de sus ca a mai facut ceva si tu n ai apucat sa vezi
                }
                //gr.FillRectangles(br, recs);//asta deseneaza tot vectorul odata

                for (int i = 0; i < nrElem - 1; i++)
                {
                    gr.DrawLine(pen, new Point((int)(recs[i].Location.X + latime / 2),
                        recs[i].Location.Y),
                        new Point((int)(recs[i + 1].Location.X + latime / 2),
                        recs[i + 1].Location.Y));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_print);
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = pd;
            dlg.ShowDialog();
        }

        private void schimbaCuloareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                contextMenuStrip1.SourceControl.BackColor = dlg.Color;
        }

        private void schimbaFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                this.Font = dlg.Font;
        }
    }
}
