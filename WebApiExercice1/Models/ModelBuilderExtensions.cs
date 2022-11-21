using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cegefos.Api.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder mb)
        {
            List<Machine> machines = new List<Machine>()
            {
                new Machine
                {
                    Id = 1,
                    Libelle = "Linux1",
                    Processeur = "AMD",
                    Memoire = "4 Go",
                    Capacite = "500 Go",
                    Taille_Ecran = 19
                },

                new Machine
                {
                    Id = 2,
                    Libelle = "Linux2",
                    Processeur = "Intel",
                    Memoire = "8 Go",
                    Capacite = "500 Go",
                    Taille_Ecran = 15
                },

                new Machine
                {
                    Id = 3,
                    Libelle = "MacOs1",
                    Processeur = "Intel",
                    Memoire = "16 Go",
                    Capacite = "1 To",
                    Taille_Ecran = 19
                }
            };

            List<Salle> salles = new List<Salle>()
            {
                new Salle { Id = 1, Libelle = "IU", Machines = machines[0], Nombre_De_Places = 10 },
                new Salle { Id = 2, Libelle = "Linux", Machines = machines[1], Nombre_De_Places = 11 },
                new Salle { Id = 3, Libelle = "Mobile", Machines = machines[2], Nombre_De_Places = 12 }
            };

            List<Cours> cours = new List<Cours>()
            {
                new Cours { Id = 1, Code = "C1", Titre = "Qt/QML Débutant", Durée = 3, Programme = "C++, UI ..." },
                new Cours { Id = 2, Code = "C2", Titre = "Linux embarqué avancé", Durée = 5, Programme = "Buildroot, Yocto ..." },
                new Cours { Id = 3, Code = "C3", Titre = "Programmation mobile iOS", Durée = 4, Programme = "iPhone, Swift ..." }
            };

            List<Formation> formations = new List<Formation>()
            {
                new Formation { Id = 1, Libelle = "UI1", Cours = cours[0], Salle = salles[0], DateDebut = new DateTime(2022, 11, 21, 9, 0, 0) },
                new Formation { Id = 2, Libelle = "LINUX1", Cours = cours[1], Salle = salles[1], DateDebut = new DateTime(2022, 11, 22, 9, 0, 0) },
                new Formation { Id = 3, Libelle = "MOBILE1", Cours = cours[2], Salle = salles[2], DateDebut = new DateTime(2022, 11, 23, 9, 0, 0) }
            };

            mb.Entity<Machine>().HasData(machines);
            mb.Entity<Salle>().HasData(salles);
            mb.Entity<Cours>().HasData(cours);
            mb.Entity<Formation>().HasData(formations);
        }
    }
}
