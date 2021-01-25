export class Ispit{
    constructor(naziv,sifra) {
        this.naziv=naziv;
        this.sifraPredmeta=sifra;
        this.listaStudenata=[];
        this.amfiteatri=[];
        this.ispitKontejner=null;
        this.tabela = document.createElement("table");
        this.tabela.className = "tabela";
        this.divZaListu = document.createElement("div");
        this.divZaListu.className = "divZaListu";
        this.divZaAmfije = document.createElement("div");
        this.divZaAmfije.className = "divZaAmfije";
    }
    crtaj(host,selected){
        if(!host)
        throw new Error("Nevalidan host");

        console.log(this.tabela);
        console.log("pozvano");
        this.ispitKontejner = document.createElement("div");
        this.ispitKontejner.className = "ispitKontejner";
        this.ispitKontejner = host.childNodes[1];//ovo je divZaIspit na koji treba da dodam div za listu
        console.log(this.ispitKontejner);
        let labela = document.createElement("label");
        labela.style.textAlign = "center";
        labela.innerHTML = this.naziv.toUpperCase();

        while (this.tabela.firstChild) {

            this.tabela.removeChild(this.tabela.lastChild);
          }
          

          const listaPropertija = ["Ime","Prezime","Broj Indeksa","Godina Studija"];
          let header = document.createElement("tr");
          console.log(header);
  
          listaPropertija.forEach(element => {
  
              let th = document.createElement("th");
              th.innerHTML = element;
              th.style.color="grey";
              header.appendChild(th);
              
          });
          this.tabela.appendChild(header);

        let liList = this.tabela.getElementsByTagName("tr");
        this.listaStudenata.forEach((element,index) => {
            if(liList.length<=index+1)
            {
                let tr = document.createElement("tr");
                tr.className="redovi";
                let td1 = document.createElement("td");
                let td2 = document.createElement("td");
                let td3 = document.createElement("td");
                let td4 = document.createElement("td");
                tr.appendChild(td1);
                tr.appendChild(td2);
                tr.appendChild(td3);
                tr.appendChild(td4);

                td1.innerHTML = element.ime;
                td2.innerHTML = element.prezime;
                td3.innerHTML = element.brojIndeksa;
                td4.innerHTML = element.godinaStudija;
                if(index%2==0)
                {
                    tr.style.backgroundColor = "#E2E4FF";
                }

                if(this.ispitniRok)
                {
                    tr.onclick = ev=>{
                        const forma = this.ispitniRok.rokKontejner.childNodes[0].childNodes[0];
                        let podaci = tr.childNodes;
                        console.log(forma);
                        forma.querySelector(".ime").value=podaci[0].innerHTML;
                        forma.querySelector(".prezime").value = podaci[1].innerHTML;
                        forma.querySelector(".indeks").value=podaci[2].innerHTML;
                        forma.querySelector(".godina").value=podaci[3].innerHTML;

                        const stud = this.nadjiStudenta(forma.querySelector(".indeks").value);
                        const dugme3 = forma.querySelector(".dugme3");
                        dugme3.onclick = event=>{
                            if(!forma.querySelector(".ime").value || !forma.querySelector(".prezime").value ||
                            !forma.querySelector(".indeks").value || !forma.querySelector(".godina").value)
                            {
                                alert("Niste popunili sva polja!");
                            }
                            const indexPrePromene =  stud.brojIndeksa;
                            stud.izmeniStudenta(forma.querySelector(".ime").value,forma.querySelector(".prezime").value,
                            forma.querySelector(".indeks").value,forma.querySelector(".godina").value);
                            fetch("https://localhost:5001/Rok/IzmeniStudenta/"+indexPrePromene+"/"+this.sifraPredmeta,{
                                method: "PUT",
                                headers: {
                                            "Content-Type": "application/json"
                                    },
                                body: JSON.stringify({
                                ime: stud.ime,
                                prezime: stud.prezime,
                                brojIndeksa: stud.brojIndeksa,
                                godinaStudija: stud.godinaStudija,
                            })
                        });
                            this.crtaj(this.ispitniRok.rokKontejner,"aa");
                    }
                    }
                }
        
                
                this.tabela.appendChild(tr);
                console.log(liList.length);

            }
            
        });
        const t="select";
        let a;
        while (this.ispitKontejner.firstChild && this.ispitKontejner.lastChild.tagName.toLowerCase()!= t) {

            this.ispitKontejner.removeChild(this.ispitKontejner.lastChild);
          }

            const divZaAmfije = document.createElement("div");
            divZaAmfije.className = "divZaAmfije";
            let lista = host.childNodes;
            lista.forEach(element => {

                if(element.className == "divZaAmfije"){

                    host.removeChild(element);
                }
                
            });
            host.appendChild(this.divZaAmfije);
             this.amfiteatri.forEach(el=>{

                el.ispit = this;//dodajem referencu na ispit zbog brisanja
                el.crtajAmfi(this.divZaAmfije);

             });
             if(selected!=="aa")
             {
                this.ispitniRok.ocistiAmfije(this);

             for(let j=0;j<this.listaStudenata.length;j++)
             {
                this.ispitniRok.popuniAmfije(this);
             }
            }


             this.divZaListu.appendChild(this.tabela);
             this.ispitKontejner.appendChild(labela);
             this.ispitKontejner.appendChild(this.divZaListu);

    }
    dodajStudenta(student){
        if(!student)
        throw new Error("Student ne postoji");
        
        this.listaStudenata.push(student);
    }
    
    dodajAmfiteatar(amfi){
        if(!amfi)
        throw new Error("Amfiteatar ne postoji");

        this.amfiteatri.push(amfi);
    }

    ukloniStudenta(brInd){

        this.listaStudenata = this.listaStudenata.filter(el=>el.brojIndeksa!=brInd);
    }

    nadjiStudenta(brInd){

        return this.listaStudenata.find(el=>el.brojIndeksa==brInd);
    }
}