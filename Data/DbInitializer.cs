using AplicatieManagementStudenti.Data;
using AplicatieManagementStudenti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicatieManagementStudenti.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Studenti.
            if (context.Studenti.Any())
            {
                return;   // DB has been seeded
            }

            var studenti = new Student[]
            {
                new Student{Nume="Carson",Prenume="Alexander",DataInscrierii=DateTime.Parse("2020-09-01")},
                new Student{Nume="Meredith",Prenume="Alonso",DataInscrierii=DateTime.Parse("2018-09-01")},
                new Student{Nume="Arturo",Prenume="Anand",DataInscrierii=DateTime.Parse("2019-09-01")},
                new Student{Nume="Gytis",Prenume="Barzdukas",DataInscrierii=DateTime.Parse("2018-09-01")},
                new Student{Nume="Yan",Prenume="Li",DataInscrierii=DateTime.Parse("2019-09-01")},
                new Student{Nume="Peggy",Prenume="Justice",DataInscrierii=DateTime.Parse("2017-09-01")},
                new Student{Nume="Laura",Prenume="Norman",DataInscrierii=DateTime.Parse("2019-09-01")},
                new Student{Nume="Nino",Prenume="Olivetto",DataInscrierii=DateTime.Parse("2020-09-01")}
            };

            context.Studenti.AddRange(studenti);
            context.SaveChanges();

            var cursuri = new Curs[]
            {
                new Curs{CursID=1050,Titlu="Algoritmi si Structuri de Date",Credite=3},
                new Curs{CursID=4022,Titlu="Baze De Date",Credite=3},
                new Curs{CursID=4041,Titlu="Macroeconomie",Credite=3},
                new Curs{CursID=1045,Titlu="Finante Publice",Credite=4},
                new Curs{CursID=3141,Titlu="Medii de programare",Credite=4},
                new Curs{CursID=2021,Titlu="Inteligenta Artificiala",Credite=3},
                new Curs{CursID=2042,Titlu="Etica in Afaceri",Credite=4}
            };

            context.Cursuri.AddRange(cursuri);
            context.SaveChanges();

            var inscrieri = new Inscriere[]
            {
                new Inscriere{StudentID=1,CursID=1050,Nota=Nota.Nota_10},
                new Inscriere{StudentID=1,CursID=4022,Nota=Nota.Nota_7},
                new Inscriere{StudentID=1,CursID=4041,Nota=Nota.Nota_6},
                new Inscriere{StudentID=2,CursID=1045,Nota=Nota.Nota_2},
                new Inscriere{StudentID=2,CursID=3141,Nota=Nota.Nota_10},
                new Inscriere{StudentID=2,CursID=2021,Nota=Nota.Nota_3},
                new Inscriere{StudentID=3,CursID=1050},
                new Inscriere{StudentID=4,CursID=1050},
                new Inscriere{StudentID=4,CursID=4022,Nota=Nota.Nota_8},
                new Inscriere{StudentID=5,CursID=4041,Nota=Nota.Nota_7},
                new Inscriere{StudentID=6,CursID=1045},
                new Inscriere{StudentID=7,CursID=3141,Nota=Nota.Nota_10},
            };

            context.Inscrieri.AddRange(inscrieri);
            context.SaveChanges();
        }
    }
}
