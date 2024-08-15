using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_lav
{
    [Serializable]
    public class Medic:ICloneable
    {
        private int id;
        private string nume;
        //private List<Pacient> listaPacienti;
        //trebuie o lista de pacienti

        public Medic()
        {
            this.id = 0;
            this.nume = "Anonim";
            //listaPacienti = new List<Pacient>();
        }
        public Medic(int id,string n)//,List<Pacient> p)
        {
            this.id = id;
            this.nume = n;
            //this.listaPacienti = p;
        }

        public int Id { get => id; set => id = value; }
        public string Nume { get => nume; set => nume = value; }

        //internal List<Pacient> ListaPacienti { get => listaPacienti; set => listaPacienti = value; }

        public object Clone()
        {
            Medic clona = (Medic)this.MemberwiseClone();
            //List<Pacient> pacientiNoi = new List<Pacient>();
            //foreach (Pacient p in listaPacienti)
            //    pacientiNoi.Add((Pacient)p.Clone());
            //clona.listaPacienti = pacientiNoi;
            return clona;
        }

        public override string ToString()
        {
            string rezultat = "medicul cu id-ul "  + id + " si numele " +nume+ Environment.NewLine;
            //foreach (Pacient p in listaPacienti)
            //    rezultat += p.ToString() + Environment.NewLine;
            return rezultat;
        }
    }
}
