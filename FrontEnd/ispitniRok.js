import {Student} from "./student.js"
export class IspitniRok{
    constructor(naziv){
        this.naziv=naziv;
        this.listaIspita=[];
        this.rokKontejner=null;
    }

    crtaj(host){
        if(!host)
        throw new Error("Host je nevalidan");

        this.rokKontejner = document.createElement("div");
        this.rokKontejner.className = "rokKontejner";
        const h2 = document.createElement("h2");
        h2.innerHTML = `Ispitni rok (${this.naziv})`;
        h2.className = "naslov";
        host.appendChild(h2);
        this.crtajFormu(this.rokKontejner);

        host.appendChild(this.rokKontejner);

    }
    crtajFormu(host){
        if(!host)
        throw new Error("Host je nevalidan");

        const forma = document.createElement("div");
        forma.className = "formaRok";
        const nadForma = document.createElement("div");
        nadForma.appendChild(forma);
        nadForma.className = "nadForma";
        this.rokKontejner.appendChild(nadForma);

        const h3 = document.createElement("h3");
        h3.className = "Unos";
        h3.innerHTML = "Unos podataka"
        forma.appendChild(h3);
        const nizLabela = ["Ime:","Prezime:","Broj Indeksa:","Godina Studija"];
        const nizKlasa = ["ime","prezime","indeks","godina"];
        const nizTipovaInputa = ["text","text","number","number"];
        let labela;
        let input;
        nizLabela.forEach((element,index) => {

            labela = document.createElement("label");
            labela.innerHTML = element;

            input = document.createElement("input");
            input.type=nizTipovaInputa[index];
            input.className = nizKlasa[index];

            forma.appendChild(labela);
            forma.appendChild(input);
            
        });

        labela = document.createElement("label");
        labela.innerHTML = "Predmet za prijavu:";

        input = document.createElement("select");
        let opcija;



        const divZaIspit = document.createElement("div");
        divZaIspit.className = "divZaIspit";
        divZaIspit.appendChild(labela);
        host.appendChild(divZaIspit);


        this.listaIspita.forEach(element => {
            opcija = document.createElement("option");
            opcija.innerHTML = element.naziv;
            opcija.value=element.naziv;
            input.appendChild(opcija);
        });
        let izbor=this.listaIspita.find(ispit=>ispit.naziv==input.options[0].value);
        izbor.crtaj(this.rokKontejner,"a");

        input.onchange = event=>{
            let opt = input.options[input.selectedIndex];
            izbor=this.listaIspita.find(ispit=>ispit.naziv==opt.value);
            izbor.crtaj(this.rokKontejner,"a");
        }
        
        forma.appendChild(labela);
        forma.appendChild(input);

        const dugme = document.createElement("button");
        dugme.innerHTML = "Prijavi";

        dugme.onclick = (event)=>{
            if(!forma.querySelector(".ime").value || !forma.querySelector(".prezime").value ||
            !forma.querySelector(".indeks").value || !forma.querySelector(".godina").value)
            {
                alert("Niste popunili sva polja!");
            }
            else
            {
                
                //izbor.crtaj(this.rokKontejner,"aa");
                const student = new Student(forma.querySelector(".ime").value,forma.querySelector(".prezime").value,
                forma.querySelector(".indeks").value,forma.querySelector(".godina").value);
                console.log(izbor.nadjiStudenta(student.brojIndeksa));
                if(izbor.nadjiStudenta(student.brojIndeksa))
                {
                    alert("Student je vec prijavio ovaj ispit");
                }
                else{
                    
                    izbor.dodajStudenta(student);
                    console.log(izbor);
                    fetch("https://localhost:5001/Rok/UpisiStudenta/"+izbor.sifraPredmeta,{
                        method: "POST",
                        headers: {
                            "Content-Type": "application/json"
                        },
                        body: JSON.stringify({
                            ime: student.ime,
                            prezime: student.prezime,
                            brojIndeksa: student.brojIndeksa,
                            godinaStudija: student.godinaStudija,

                    })
                }).then(p=>{
                        if(p.ok)
                        {
                            for(let i=0;i<izbor.amfiteatri.length;i++){
                                console.log(izbor.naziv);
                                console.log(izbor.amfiteatri);
                                if(izbor.amfiteatri[i].kapacitet>izbor.amfiteatri[i].tren){
                                    
                                    izbor.amfiteatri[i].popuni(izbor.amfiteatri[i].amfiKontejner.childNodes[1]);
                                    //izbor.dodajStudenta(student);
                                    student.amfiteatar = izbor.amfiteatri[i].naziv;
                                    break;
                                }
                                if(i==izbor.amfiteatri.length-1)
                                {
                                    alert("Nema vise mesta u amfiteatrima!");
                                }
                            }
                        }
                        else if(p.status == 400){
                            console.log("nesto je krenulo po zlu");
                        }
                    });
                    izbor.crtaj(this.rokKontejner,"aa");
                }
            }
        }
        forma.appendChild(dugme);

        const dugme2 = document.createElement("button");
        dugme2.innerHTML = "Ponisti prijavu";

        dugme2.onclick = ev=>{

            if(!forma.querySelector(".ime").value || !forma.querySelector(".prezime").value ||
            !forma.querySelector(".indeks").value || !forma.querySelector(".godina").value)
            {
                alert("Niste popunili sva polja!");
            }
            else
            {
                
                izbor.crtaj(this.rokKontejner,"aa");

                fetch("https://localhost:5001/Rok/IzbrisiStudenta/"+forma.querySelector(".indeks").value +"/"+izbor.sifraPredmeta,{
                    method:"DELETE"
                })
                .then(p=>{
                    if(p.ok)
                    {
                        for(let i=0;i<izbor.amfiteatri.length;i++){
                            console.log(izbor.naziv);
                            if(izbor.amfiteatri[i].kapacitet>izbor.amfiteatri[i].tren){
                                izbor.amfiteatri[i].umanji(izbor.amfiteatri[i].amfiKontejner.childNodes[1]);
                                izbor.ukloniStudenta(forma.querySelector(".indeks").value);
                                break;
                            }
                            if(i==izbor.amfiteatri.length-1)
                            {
                                alert("Nema vise mesta u amfiteatrima!");
                            }
                        }
                        izbor.crtaj(this.rokKontejner,"aa");
                    }
                    else if(p.status==400)
                    {
                        console.log("nesto je krenulo po zlu");
                    }
                })
            }

        };
        const dugme3 = document.createElement("button");
        dugme3.innerHTML = "Izmeni podatke"
        dugme3.className = "dugme3";
        
        forma.appendChild(dugme2);
        forma.appendChild(dugme3);
    }
    dodajIspit(ispit){
        ispit.ispitniRok = this;
        this.listaIspita.push(ispit);
    }

    popuniAmfije(izbor){
        for(let i=0;i<izbor.amfiteatri.length;i++){

            if(izbor.amfiteatri[i].kapacitet>izbor.amfiteatri[i].tren){
                
                izbor.amfiteatri[i].popuni(izbor.amfiteatri[i].amfiKontejner.childNodes[1]);
                break;
            }
            if(i==izbor.amfiteatri.length-1)
            {
                alert("Nema vise mesta u amfiteatrima!");
            }
        }
        console.log(this.rokKontejner);
    }

    ocistiAmfije(izbor)
    {
        for(let i=0;i<izbor.amfiteatri.length;i++){

            let n = izbor.amfiteatri[i].tren;
            for(let j=0;j<n;j++)
            {
                izbor.amfiteatri[i].umanji(izbor.amfiteatri[i].amfiKontejner.childNodes[1]);
            }
        }
    }

}