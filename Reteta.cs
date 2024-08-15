using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_lav
{
    [Serializable]
    public class Reteta:ICloneable
    {
        private int cod;
        private int nrMed;//nr medicamente
        private string compensata;
        private string[] medicamente;
        private int[] frecventaZi;//de cate ori sa fie luat medicamentul respectiv

        //constr fara param
        public Reteta()
        {
            cod = 0;
            nrMed = 0;
            compensata = "nu";
            medicamente = null;
            frecventaZi = null;
        }
        public Reteta(int c,int nr,string com, string[] m, int[] f)
        {
            cod = c;
            NrMed = nr;
            compensata = com;
            medicamente = (string[])m.Clone();
            frecventaZi = (int[])f.Clone();
        }
        public int Cod { get => cod; set => cod = value; }
        public int NrMed { get => nrMed; set => nrMed = value; }
        
        public string[] Medicamente { get => medicamente; set => medicamente = value; }
        public int[] FrecventaZi { get => frecventaZi; set => frecventaZi = value; }
        public string Compensata { get => compensata; set => compensata = value; }

        public object Clone()//clone e constr de copiere
        {
            Reteta clona = (Reteta)this.MemberwiseClone();
            clona.cod = cod;
            clona.nrMed = nrMed;
            clona.compensata = compensata;
            string[] medicamNoi = (string[])medicamente.Clone();//deep copy
            clona.medicamente = medicamNoi;
            int[] frecvNoua = (int[])frecventaZi.Clone();
            clona.frecventaZi = frecvNoua;
            return clona;
        }
        public override string ToString()
        {
            string rezultat = "reteta cu codul " + cod + "este compensata: " + compensata;
            if (nrMed == 0)
                rezultat += " si nu are medicamente";
            else
            {
                rezultat+=" si are " + nrMed + " medicamente:" + Environment.NewLine;
                for (int i = 0; i < medicamente.Length; i++)
                    rezultat += medicamente[i] + ", ";
                Console.WriteLine();
                for (int i = 0; i < frecventaZi.Length; i++)
                    rezultat += frecventaZi[i] + ", ";
            }

            return rezultat;
        }
    }
}
