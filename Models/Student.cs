using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicatieManagementStudenti.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public DateTime DataInscrierii { get; set; }

        public ICollection<Inscriere> Inscrieri { get; set; }
    }
}
