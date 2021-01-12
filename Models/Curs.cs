using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicatieManagementStudenti.Models
{
    public class Curs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CursID { get; set; }
        public string Titlu { get; set; }
        public int Credite { get; set; }

        public ICollection<Inscriere> Inscrieri { get; set; }
    }
}
