import {IspitniRok} from "./ispitniRok.js"
import {Ispit} from "./ispit.js"
import {Amfiteatar} from "./amfiteatar.js"
import {Student} from "./student.js"


fetch("https://localhost:5001/Rok/PreuzmiRokove").then(p=>p.json()
.then(rokovi=>{
    rokovi.forEach((rok,index) => {
        console.log(rok);

        const ispitniRok = new IspitniRok(rok.naziv);

        rok.listaIspita.forEach(is => {

            const ispit = new Ispit(is.naziv, is.sifra);
            ispitniRok.dodajIspit(ispit);

            
            is.amfiteatri.forEach(el => {
                
                const amfiteatar = new Amfiteatar(el.naziv,el.kapacitet,el.color);
                //amfiteatar.crtajAmfi(ispit.divZaAmfije);
                ispit.dodajAmfiteatar(amfiteatar);

            });

            is.listaStudenata.forEach(el=>{

                const student = new Student(el.ime,el.prezime,el.brojIndeksa,el.godinaStudija);
                //ispitniRok.popuniAmfije(ispit,student);
                ispit.dodajStudenta(student);
            });
            
        });
        
        ispitniRok.crtaj(document.body);
    });
}));

/*const januar = new IspitniRok("Januar");

let matematika = new Ispit("matematika",12313);
matematika.dodajAmfiteatar(new Amfiteatar("A1",10,"blue"));
matematika.dodajAmfiteatar(new Amfiteatar("A2",10,"red"));

let srpski = new Ispit("srpski",12314);
srpski.dodajAmfiteatar(new Amfiteatar("A3",10,"blue"));
srpski.dodajAmfiteatar(new Amfiteatar("A4",10,"red"));

januar.dodajIspit(matematika);
januar.dodajIspit(srpski);
januar.crtaj(document.body);

const februar = new IspitniRok("Februar");

matematika = new Ispit("matematika",12313);
matematika.dodajAmfiteatar(new Amfiteatar("A1",10,"blue"));
matematika.dodajAmfiteatar(new Amfiteatar("A2",10,"red"));

srpski = new Ispit("srpski",12314);
srpski.dodajAmfiteatar(new Amfiteatar("A3",10,"blue"));
srpski.dodajAmfiteatar(new Amfiteatar("A4",10,"red"));

februar.dodajIspit(matematika);
februar.dodajIspit(srpski);
februar.crtaj(document.body);*/