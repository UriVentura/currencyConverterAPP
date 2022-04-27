import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ApiService {

    private urlCoin: string = "http://localhost:63547/api/moneda";

    constructor(private http: HttpClient) { }


    getMonedas(): Observable<IMonedas[]> {
        return this.http.get<IMonedas[]>(this.urlCoin);
    }
}

export interface IMonedas {
    id: number;
    NomMoneda: string;
    CodMoneda: string;
    rate: number;
};
