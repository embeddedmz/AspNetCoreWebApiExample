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
            mb.Entity<Salle>().HasData(
                new Salle { Id = 1, Libelle = "Salle IU", Nombre_De_Places = 10 },
                new Salle { Id = 2, Libelle = "Salle Linux", Nombre_De_Places = 11 },
                new Salle { Id = 3, Libelle = "Salle Mobile", Nombre_De_Places = 12 }
                );

            mb.Entity<Machine>().HasData(
                    new Machine
                    {
                        Id = 1,
                        Libelle = "Linux1",
                        Processeur = "AMD",
                        Memoire = "4 Go",
                        Capacite = "500 Go",
                        Taille_Ecran = 19,
                        SalleId = 1
                    },
                    new Machine
                    {
                        Id = 2,
                        Libelle = "Linux2",
                        Processeur = "Intel",
                        Memoire = "8 Go",
                        Capacite = "500 Go",
                        Taille_Ecran = 15,
                        SalleId = 2
                    },
                    new Machine
                    {
                        Id = 3,
                        Libelle = "MacOs1",
                        Processeur = "Intel",
                        Memoire = "16 Go",
                        Capacite = "1 To",
                        Taille_Ecran = 19,
                        SalleId = 3
                    });

            mb.Entity<Cours>().HasData(
                new Cours { Id = 1, Code = "C1", Titre = "Qt/QML Débutant", Durée = 3, Programme = "C++, UI ..." },
                new Cours { Id = 2, Code = "C2", Titre = "Linux embarqué avancé", Durée = 5, Programme = "Buildroot, Yocto ..." },
                new Cours { Id = 3, Code = "C3", Titre = "Programmation mobile iOS", Durée = 4, Programme = "iPhone, Swift ..." }
                );

            mb.Entity<Formation>().HasData(
                new Formation { Id = 1, Libelle = "UI1", DateDebut = new DateTime(2022, 11, 21, 9, 0, 0), CoursId = 1, SalleId = 1 },
                new Formation { Id = 2, Libelle = "LINUX1", DateDebut = new DateTime(2022, 11, 22, 9, 0, 0), CoursId = 2, SalleId = 2 },
                new Formation { Id = 3, Libelle = "MOBILE1", DateDebut = new DateTime(2022, 11, 23, 9, 0, 0), CoursId = 3, SalleId = 3 }
                );
        }
    }
}
