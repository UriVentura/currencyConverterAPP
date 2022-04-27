import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ApiRate, IRates } from '../../services/api-rates.service';
import { IMonedas } from '../../services/api-service.service';
@Component({
    selector: 'app-conversor',
    templateUrl: './conversor.component.html',
})

export class ConversorComponent implements OnInit {
    pageTitle: string = 'Lista de Monedas';
    rates: IRates[] = [];

    monedaGuardar: IRates;

    monedaOrigen: string = '';
    monedaDestino: string = '';
    conversion: number;

    monedaResultado: number;
    monedaCantidad: number;
    conversionO: any;
    monedaGuardarO: IRates;

    constructor(private apiRate: ApiRate) { }

    ngOnInit(): void {
        this.apiRate.getRates().subscribe(data => {

            if (data) {
                this.rates = data;
                console.log("data" + data[0].monedaOrigen);
            }
        }, error => {
            console.log("error" + error)
        });
    }

    monedaSelectOrigen(evento: any): void {
        this.monedaOrigen = evento.target.value;
        this.monedaGuardar = this.rates.find(x => x.monedaDestino == this.monedaOrigen);

        this.conversion = this.monedaGuardar.conversion;

    }

    getRate(iRate: IRates) {
        return iRate.monedaDestino === this.monedaOrigen;
    }

    getResultado(): void {
        this.monedaGuardar = this.rates.find(x => x.monedaDestino == this.monedaOrigen);
        this.monedaGuardarO = this.rates.find(y => y.monedaDestino == this.monedaDestino);
        this.conversionO = this.monedaGuardarO.conversion;
        this.conversion = this.monedaGuardar.conversion;
        this.monedaResultado = this.monedaCantidad * (this.conversionO / this.conversion);
        console.log(this.conversion);
        console.log(this.monedaGuardar);
    }
}