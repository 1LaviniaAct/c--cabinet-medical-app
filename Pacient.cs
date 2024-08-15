using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace proiect_lav
{
    [Serializable]
    public class Pacient:ICloneable
    {
        private string nume;
        private int varsta;
        private char sex;
        public List<Reteta> retete;
        private List<Medic> medici;

        public Pacient()
        {
            nume = "Anonim";
            varsta = 0;
            sex = 'M';
            retete = new List<Reteta>();
            medici = new List<Medic>();
        }

        public Pacient(string n, int v, char s, List<Reteta> r,List<Medic> m)
        {
            nume = n;
            varsta = v;
            sex = s;
            retete = r;
            medici = m;
        }

        public string Nume { get => nume; set => nume = value; }
        public int Varsta { get => varsta; set => varsta = value; }
        public char Sex { get => sex; set => sex = value; }
        internal List<Reteta> Retete { get => retete; set => retete = value; }
        public List<Medic> Medici { get => medici; set => medici = value; }

        public object Clone()
        {
            Pacient clona = (Pacient)this.MemberwiseClone();
            List<Reteta> retetaNoua = new List<Reteta>();
            foreach (Reteta r in retete)
                retetaNoua.Add((Reteta)r.Clone());
            clona.retete = retetaNoua;
            List<Medic> medicNou = new List<Medic>();
            foreach (Medic m in medici)
                medicNou.Add((Medic)m.Clone());
            clona.medici = medicNou;
            return clona;
        }

        public override string ToString()
        {
            string rezultat = "Pacientul cu numele " + nume + ", in varsta de " + varsta + ", de sex " + sex + ", care are urmatoarele retete:" + Environment.NewLine;
            foreach (Reteta r in retete)
                rezultat += r.ToString() + Environment.NewLine;
            rezultat += " si reteta a fost oferita de: " + Environment.NewLine;
            foreach (Medic m in medici)
                rezultat += m.ToString() + Environment.NewLine;
            return rezultat;
        }
    }
}
