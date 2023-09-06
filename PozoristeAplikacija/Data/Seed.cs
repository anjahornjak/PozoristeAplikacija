using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Identity;
using PozoristeAplikacija.Data.Enum;
using PozoristeAplikacija.Models;
using PozoristeAplikacija.Data.Enum;
using PozoristeAplikacija.Models;
using static System.Formats.Asn1.AsnWriter;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Net;

namespace PozoristeAplikacija.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Pozorista.Any())
                {
                    context.Pozorista.AddRange(new List<Pozoriste>()
                    {
                        new Pozoriste()
                        {
                            Naziv = "Srpsko Narodno Pozoriste",
                            Opis = "Srpsko narodno pozoriste je osnovano 16/28. jula 1861. godine u Novom Sadu, u tadasnjoj Carevini Austriji (od 1867. Austrougarska monarhija). U Vojvodini je do tada vec postojala duga pozorisna tradicija, od djackih diletantskih predstava, pa sve do privatnih profesionalnih pozorisnih trupa. Pozoriste je osnivano u vreme budjenja nacionalne svesti i borbe za nacionalnu slobodu.",
                            Fotografija = "https://carolinatheatre.org/wp-content/uploads/2023/05/23_FletcherHallStage_GenericHeader_1440x810-1280x720.png",
                            Adresa = new Adresa()
                            {
                                Ulica = "Pozorisni Trg 1",
                                Grad = "Novi Sad"

                            }
                         },
                        new Pozoriste()
                        {
                            Naziv = "Pozoriste Mladih",
                            Opis = "Pozoriste mladih osnovano je 1932. godine kao Lutkarsko pozoriste, pri Sokolskom drustvu u Novom Sadu. Pozoriste je nastalo iz Sokolske sekcije lutkara, koja je formirana 1930. godine, uz veliku podrsku staresina Sokola, dr Vladimira Belajcica i dr Ignjata Pavlasa.",
                            Fotografija = "https://carolinatheatre.org/wp-content/uploads/2023/05/23_FletcherHallStage_GenericHeader_1440x810-1280x720.png",
                            Adresa = new Adresa()
                            {
                                Ulica = "Ignjata Pavlasa 4",
                                Grad = "Novi Sad"

                            }
                         },
                        new Pozoriste()
                        {
                            Naziv = "Pozoriste Promena",
                            Opis = "Potrebu za osnivanjem studentskog teatra imali su jer su njihove predstave svojim kvalitetom parirale tadasnjoj sirokoj sceni nekadasnje SFRJ, te su predstave Promene gostovale na svim relevantnim festivalima u okviru cele Jugoslavije.",
                            Fotografija = "https://carolinatheatre.org/wp-content/uploads/2023/05/23_FletcherHallStage_GenericHeader_1440x810-1280x720.png",
                            Adresa = new Adresa()
                            {
                                Ulica = "Djure Jaksica 7",
                                Grad = "Novi Sad"
                            }
                         },
                        new Pozoriste()
                        {
                            Naziv = "Akademsko Pozoriste SKC Nis",
                            Opis = "Mladi umetnici su se okupili oko tada vodeceg studentskog casopisa Mladost, koji je donosio novosti o aktuelnoj muzickoj, filmskoj i pozorisnoj umetnosti, sto je bilo presudno za osnivanje kamerne scene M 1964. godine, preteče današnjeg Akademskog pozorišta.",
                            Fotografija = "https://carolinatheatre.org/wp-content/uploads/2023/05/23_FletcherHallStage_GenericHeader_1440x810-1280x720.png",
                            Adresa = new Adresa()
                            {
                                Ulica = "Sumatovacka 10",
                                Grad = "Nis"

                            }
                         },
                        new Pozoriste()
                        {
                            Naziv = "Deciji kulturni centar Beograd",
                            Opis = "Decji kulturni centar Beograd je ustanova kulture ciji je osnivac Gradska uprava grada Beograda. Osnovan je 1952. godine kao Dom pionira Beograda.",
                            Fotografija = "https://carolinatheatre.org/wp-content/uploads/2023/05/23_FletcherHallStage_GenericHeader_1440x810-1280x720.png",
                            Adresa = new Adresa()
                            {
                                Ulica = "Takovska 8",
                                Grad = "Beograd"

                            }
                         },
                        new Pozoriste()
                        {
                            Naziv = "Dorcol Platz",
                            Opis = "Udruzenje gradjana DORCOL PLATZ je osnovano radi ostvarivanja ciljeva u oblasti kulture, podizanja svesti u oblasti ekologije i njene vaznosti, novih tehnologija i njihovog zanacaja u razvoju pojedinaca, sirenja svesti o osnovnim ljudskim slobodama i pravima, u cilju zastite od svake vrste diskriminacije",
                            Fotografija = "https://carolinatheatre.org/wp-content/uploads/2023/05/23_FletcherHallStage_GenericHeader_1440x810-1280x720.png",
                            Adresa = new Adresa()
                            {
                                Ulica = "Dobracina 59b",
                                Grad = "Beograd"

                            }
                         },
                        new Pozoriste()
                        {
                            Naziv = "Dom Omladine Beograda",
                            Opis = "Dom omladine Beograda je ustanova kultura i obrazovanja Grada Beograda, koja vec 50 godina, jos od 1964. godine, kreira i organizuje programe za mlade i u saradnji sa mladima.",
                            Fotografija = "https://carolinatheatre.org/wp-content/uploads/2023/05/23_FletcherHallStage_GenericHeader_1440x810-1280x720.png",
                            Adresa = new Adresa()
                            {
                                Ulica = "Makedonska 22",
                                Grad = "Beograd"

                            }
                         },
                        new Pozoriste()
                        {
                            Naziv = "Narodno Pozoriste Pirot",
                            Opis = "Prvi pisani tragovi o pozorisnom zivotu u Pirotu datiraju još od davne 1887. god. osnivanjem pirotske pozorišne druzine. Kao u slucaju vecine srpskih pozorista, pocetak teatarskog zivota u Pirotu vezan je za sredinu cetrdesetih godine proslog veka.",
                            Fotografija = "https://carolinatheatre.org/wp-content/uploads/2023/05/23_FletcherHallStage_GenericHeader_1440x810-1280x720.png",
                            Adresa = new Adresa()
                            {
                                Ulica = "Branka Radicevica 1",
                                Grad = "Pirot"

                            }
                         }
                    });
                    context.SaveChanges();
                }

                //Predstave
                if (!context.Predstave.Any())
                {
                    context.Predstave.AddRange(new List<Predstava>()
                    {
                        new Predstava()
                        {
                            Naziv = "Aida",
                            Opis = "Aida je kompleksno delo, viseslojno, duboko. Jedna od tema je sudbina harizmaticnog lidera koji je spreman da se zrtvuje za zajednicu. ",
                            Fotografija = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Tekst = "Djuzepe Verdi",
                            Rezija = "Aleksandar Nikolic",
                            Trajanje = "200",
                            VrstaPredstave = VrstaPredstave.Opera,
                            PozoristeId = 1

                        },
                       new Predstava()
                        {
                            Naziv = "Bolest Mladosti",
                            Opis = "Bruknerova Bolest mladosti, dovodi na scenu mlade studente medicine razapete između konvencija građanskog života, mladalačkog osećanja izgubljenosti i cinizma savremenog društva.",
                            Fotografija = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Tekst = "Ferdinand Brukner",
                            Rezija = "Jovana Tomic",
                            Trajanje = "120",
                            VrstaPredstave = VrstaPredstave.Drama,
                            PozoristeId = 2

                       },
                        new Predstava()
                       {
                            Naziv = "1984",
                            Opis = "Rat je mir. Sloboda je ropstvo. Neznanje je snaga.",
                            Fotografija = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Tekst = "Dzordz Orvel",
                            Rezija = "Alia Luke",
                            Trajanje = "80",
                            VrstaPredstave = VrstaPredstave.Drama,
                            PozoristeId = 3
                        },
                        new Predstava()
                        {
                            Naziv = "Branin zablji orfeum",
                            Opis = "Jedna vesela zablja porodica ima svoje malo putujuce lutkarsko pozoriste. Kao što je „neki put - izmedju dva rata“, najomiljeniji deciji pisac Beograda, Srbije i Jugoslavije Brana Cvetkovic imao svoje putujuce pozoriste „Branin ORFEUM“",
                            Fotografija = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Tekst = "Brana Cvetkovic",
                            Rezija = "Brana Stefanovic",
                            Trajanje = "60",
                            VrstaPredstave = VrstaPredstave.Decija,
                            PozoristeId = 5
                        },
                        new Predstava()
                        {
                            Naziv = "Lazljivi zivot odraslih",
                            Opis = "Djovana je jedinica u porodici situiranih srednjoskolskih profesora. Devojcica koja ulazi u pubertet i koja se menja, a njeno lepo lice, barem kako misli njen otac, postaje ruzno, nalik na ono njene tetke Viktorije.",
                            Fotografija = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Tekst = "Elena Ferante",
                            Rezija = "Sebastijan Horvat",
                            Trajanje = "160",
                            VrstaPredstave = VrstaPredstave.Drama,
                            PozoristeId = 4
                        },
                        new Predstava()
                        {
                            Naziv = "Hamlet u pikantnom sosu",
                            Opis = "Kao što je dobar zacin neophodan za ukusno jelo, tako je dobar i radoznao kuvar sa svojom svitom neophodan začin dvorskih spletki. Kada je pri tom u pitanju kuvar na danskom dvoru, a jedan od konzumenata kraljevic Hamlet, tada prica poprima neocekivani tragicni tok koji nesvesno pokrece upravo kuvar koji pokusava da opstane u vreme smene kraljevske vlasti.",
                            Fotografija = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Tekst = "Aldo Nikolaj",
                            Rezija = "Robert Saponja",
                            Trajanje = "55",
                            VrstaPredstave = VrstaPredstave.Komedija,
                            PozoristeId = 6

                        },
                        new Predstava()
                        {
                            Naziv = "Zaljubljeni Sekspir",
                            Opis = "Sekspirov nov dom na kinematografskom trzistu tako što je elizabetanski svet pretocio u holivudski, filmski, drveni studio gde potraznja za blokbasterom radja konvencionalno pisanje, „ljubav i komad sa psom“. ",
                            Fotografija = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Tekst = "Mark Norman",
                            Rezija = "Ana Tomovic",
                            Trajanje = "55",
                            VrstaPredstave = VrstaPredstave.Drama,
                            PozoristeId = 7

                        },
                        new Predstava()
                        {
                            Naziv = "Labudovo Jezero",
                            Opis = "Princ Zigfrid cita legendu o carobnjaku koji pretvara lepe devojke, princeze, u labudove i cuva ih na skrivenom jezeru u sumi.",
                            Fotografija = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Tekst = "Petar Ilic Cajkovski",
                            Rezija = "Konstantin Kostjukov",
                            Trajanje = "55",
                            VrstaPredstave = VrstaPredstave.Balet,
                            PozoristeId = 1

                        }
                    }); ;
                    context.SaveChanges();
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.Korisnik))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Korisnik));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<KorisnikAplikacije>>();
                string adminUserEmail = "teddysmithdeveloper@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new KorisnikAplikacije()
                    {
                        UserName = "anjah123",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Adresa = new Adresa()
                        {
                            Ulica = "Cirpanova 1",
                            Grad = "Novi Sad",                            
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new KorisnikAplikacije ()
                    {
                        UserName = "korisnik",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Adresa = new Adresa()
                        {
                            Ulica = "Lasla Gala 13",
                            Grad = "Novi Sad",                           
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.Korisnik);
                }
            }
        }
    }
}