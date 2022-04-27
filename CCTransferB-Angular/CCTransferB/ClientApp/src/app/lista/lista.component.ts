import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiRate, IRates } from '../../services/api-rates.service';
import { Pipe, PipeTransform } from "@angular/core";

@Component({
    selector: 'app-lista',
    templateUrl: './lista.component.html',
    styleUrls: ['./lista.component.scss']
})
export class ListaComponent implements OnInit {
    search = "";
    numero: number = 1;
    num: number = 0;

    listaCurrencies: IRates[];

    constructor(private apiRate: ApiRate, http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    }

    ngOnInit() {
        this.apiRate.getRates().subscribe(monedaApi =>
            this.listaCurrencies = monedaApi, error => console.error(error));
    }
}
@Pipe({ name: "search" })
export class CustomFilter implements PipeTransform {
    transform(value: any, campo: string, args: string): any {
        if (!value) return null;
        if (!args) return value;

        return value.filter(singleItem =>
            singleItem[campo].toLowerCase().includes(args.toLocaleLowerCase()))
    }
}