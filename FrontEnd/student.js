export class Student{
    constructor(ime,prezime,index,godina){
        this.ime = ime;
        this.prezime = prezime;
        this.brojIndeksa = index;
        this.godinaStudija = godina;
        this.id=index;
    }

    izmeniStudenta(ime, prezime, index, godina){
        this.ime = ime;
        this.prezime = prezime;
        this.brojIndeksa = index;
        this.godinaStudija = godina;
        this.id=index;
    }
}