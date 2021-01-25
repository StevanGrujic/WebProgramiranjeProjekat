export class Amfiteatar{
    constructor(naziv,kapacitet,color) {
        this.naziv = naziv;
        this.kapacitet=kapacitet;
        this.color = color;
        this.tren = 0;
        this.amfiKontejner=document.createElement("div");
        this.amfiKontejner.className = "amfiKontejner";


        /*if(this.amfiKontejner.childNodes.length<3){
            this.labela = document.createElement("label");
            this.labela.innerHTML = `${this.naziv}(${this.tren}/${this.kapacitet})`;
    
            this.divZaPopunjenost = document.createElement("div");
            this.divZaPopunjenost.className = "divZaPopunjenost";
    
            this.divKockice = document.createElement("div");
            this.divKockice.className = "divKockice";
            this.divZaPopunjenost.appendChild(divKockice);
        }*/
    }

    crtajAmfi(host){
        if(!host){
            throw new Error("Nevalidan host!");
        }

        //host je zapravo divZaAmfije
        if(this.amfiKontejner.childNodes.length<3){
        const labela = document.createElement("label");
        labela.innerHTML = `${this.naziv}(${this.tren}/${this.kapacitet})`;

        const divZaPopunjenost = document.createElement("div");
        divZaPopunjenost.className = "divZaPopunjenost";

        const divKockice = document.createElement("div");
        divKockice.className = "divKockice";
        divZaPopunjenost.appendChild(divKockice);
        
        const dugme = document.createElement("button");
        dugme.innerHTML = "Izbrisi";
        dugme.onclick = ev=>{

            this.ukloniAmfi();

        }

        this.amfiKontejner.appendChild(labela);
        this.amfiKontejner.appendChild(divZaPopunjenost);
        this.amfiKontejner.appendChild(dugme);

        host.appendChild(this.amfiKontejner);
        }

    }

    popuni(host){ //divZaPopunjenost => host
        
        if(!host)
        throw new Error("Nevalidan host!");

        this.tren++;
        this.amfiKontejner.childNodes[0].innerHTML = `${this.naziv}(${this.tren}/${this.kapacitet})`;
        const div = host.childNodes[0];

        div.style.backgroundColor = this.color;
        console.log((202/this.kapacitet)+"px");
        div.style.width = (202/this.kapacitet)*this.tren+"px";
    }

    umanji(host){
        if(!host)
        throw new Error("Nevalidan host!");

        this.tren--;
        this.amfiKontejner.childNodes[0].innerHTML = `${this.naziv}(${this.tren}/${this.kapacitet})`;
        const div = host.childNodes[0];

        div.style.backgroundColor = this.color;
        console.log((202/this.kapacitet)+"px");
        div.style.width = (202/this.kapacitet)*this.tren+"px";
    }

    ukloniAmfi(){
        const parent = this.amfiKontejner.parentNode;
        console.log(parent);
        parent.removeChild(this.amfiKontejner);

        console.log(this.ispit.amfiteatri);
        this.ispit.amfiteatri = this.ispit.amfiteatri.filter(el=>el.naziv!=this.naziv);
        console.log(this.ispit.amfiteatri);

    }
}