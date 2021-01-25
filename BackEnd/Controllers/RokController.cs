using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjekatBackend.Models;

namespace ProjekatBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RokController : ControllerBase
    {
        public RokContext Kontekst { get; set; }
        public RokController(RokContext kontekst)
        {
            Kontekst=kontekst;
        }

        [HttpGet]
        [Route("PreuzmiRokove")]//uradjeno
        public async Task<List<IspitniRok>> PreuzmiRokove()
        {
            return await Kontekst.IspitniRokovi.Include(p=>p.listaIspita)
                                                    .ThenInclude(q=>q.Amfiteatri)
                                                .Include(q=>q.listaIspita)
                                                    .ThenInclude(w=>w.listaStudenata)
                                                    .ToListAsync();
        }

        [HttpPost]
        [Route("UpisiRok")]//uradjeno

        public async Task UpisiRok([FromBody]IspitniRok rok)
        {
             var rokovi = from r in Kontekst.IspitniRokovi
                       where r.Naziv==rok.Naziv
                       select r;
            if(!rokovi.Any())
            {
                Kontekst.IspitniRokovi.Add(rok);
                await Kontekst.SaveChangesAsync();
            }
        }

        [HttpDelete]
        [Route("IzbrisiRok/{id}")]//Reseno

        public async Task IzbrisiRok(int id)
        {
            var rok=await Kontekst.IspitniRokovi.FindAsync(id);
            var ispiti = from i in Kontekst.Ispiti
                        where i.IspitniRok==rok
                        select i;
            if(ispiti.Any())
            {
                foreach(Ispit isp in ispiti)
                {
                    Kontekst.Remove(isp);
                }
            }
            if(rok!=null)
            {
                Kontekst.Remove(rok);
                await Kontekst.SaveChangesAsync();
            }
        }

        [HttpPost]
        [Route("UpisiIspit/{idRoka}")]//reseno
        
        public async Task UpisiIspit(int idRoka,[FromBody] Ispit ispit)
        {
            var rok = await Kontekst.IspitniRokovi.FindAsync(idRoka);
            if(rok!=null)
            {
                ispit.IspitniRok=rok;
                Kontekst.Ispiti.Add(ispit);
                await Kontekst.SaveChangesAsync();
            }
        }

        [HttpDelete]
        [Route("IzbrisiIspit/{id}")]

        public async Task IzbrisiIspit(int id)//reseno
        {
            var ispit=await Kontekst.Ispiti.FindAsync(id);
            if(ispit!=null)
            {
                var studenti = from stud in Kontekst.Studenti
                                where stud.Ispit==ispit
                                select stud;
                if(studenti.Any())
                {
                    foreach(Student student in studenti)
                    {
                        Kontekst.Remove(student);
                    }
                }
                var amfii = from amf in Kontekst.Amfiteatri
                            where amf.Ispit==ispit
                            select amf;
                if(amfii.Any())
                {
                   foreach(Amfiteatar a in amfii)
                    {
                        Kontekst.Remove(a);
                    } 
                }
                Kontekst.Remove(ispit);
                await Kontekst.SaveChangesAsync();
            }
        }

        [HttpDelete]
        [Route("IzbrisiAmfiteatar/{id}")]//reseno

        public async Task IzbrisiAmfiteatar(int id)
        {
            var amfi=await Kontekst.Amfiteatri.FindAsync(id);
            if(amfi!=null)
            {
                Kontekst.Remove(amfi);
                await Kontekst.SaveChangesAsync();
            }
        }

        [HttpPost]
        [Route("UpisiStudenta/{idIspita}")]//reseno

        public async Task UpisiStudenta(int idIspita,[FromBody] Student s)
        {
            var ispit = await Kontekst.Ispiti.FindAsync(idIspita);
            if(ispit!=null)
            {
                s.Ispit=ispit;
                Kontekst.Studenti.Add(s);
                await Kontekst.SaveChangesAsync();
            }
        
        }
        [HttpDelete]
        [Route("IzbrisiStudenta/{brIndeksa}/{sifraIspita}")]//Reseno

        public async Task IzbrisiStudenta(int brIndeksa,int sifraIspita)
        {
            Ispit ispit = await Kontekst.Ispiti.FindAsync(sifraIspita);
            var studenti = from stud in Kontekst.Studenti
                            where stud.BrojIndeksa==brIndeksa && stud.Ispit==ispit
                            select stud;
            if(studenti.Any())
            {
                foreach(Student s in studenti)
                {
                    Kontekst.Studenti.Remove(s);
                }
                
                    await Kontekst.SaveChangesAsync();
            }
        }

        [HttpPost]
        [Route("UpisiAmfiteatar/{idIspita}")]//reseno

        public async Task UpisiAmfiteatar(int idIspita,[FromBody] Amfiteatar a)
        {
            Ispit ispit = await Kontekst.Ispiti.FindAsync(idIspita);
            if(ispit!=null)
            {
                a.Ispit=ispit;
                Kontekst.Amfiteatri.Add(a);
                await Kontekst.SaveChangesAsync();
            }
        }

        [HttpPut]
        [Route("IzmeniStudenta/{brojIndeksa}/{sifraIspita}")]

        public async Task IzmeniStudenta(int brojIndeksa, int sifraIspita,[FromBody]Student st)
        {
            Ispit ispit = await Kontekst.Ispiti.FindAsync(sifraIspita);
            var studenti = from stud in Kontekst.Studenti
                            where stud.BrojIndeksa==brojIndeksa && stud.Ispit==ispit
                            select stud;
            if(studenti.Any())
            {
                foreach(Student s in studenti)
                {
                    s.Ime=st.Ime;
                    s.Prezime=st.Prezime;
                    s.BrojIndeksa=st.BrojIndeksa;
                    s.GodinaStudija=st.GodinaStudija;
                    Kontekst.Studenti.Update(s);
                }
                
                    await Kontekst.SaveChangesAsync();
            }
        }

    }
}
