using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicatieManagementStudenti.Models
{
    public enum Nota
    {
        Nota_1,
        Nota_2,
        Nota_3,
        Nota_4,
        Nota_5,
        Nota_6,
        Nota_7,
        Nota_8,
        Nota_9,
        Nota_10
    }

    public class Inscriere
    {
        public int InscriereID { get; set; }
        public int CursID { get; set; }
        public int StudentID { get; set; }
        public Nota? Nota { get; set; }

        public Curs Curs { get; set; }
        public Student Student { get; set; }
    }
}

