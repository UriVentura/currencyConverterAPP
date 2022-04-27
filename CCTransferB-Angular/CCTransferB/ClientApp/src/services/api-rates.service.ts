import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ApiRate {

    private urlRatio: string = "http://localhost:37122/api/rates";

    constructor(private http: HttpClient) { }


    getRates(): Observable<IRates[]> {
        return this.http.get<IRates[]>(this.urlRatio);
    }
}

export interface IRates {
    id: number;
    monedaOrigen: string;
    monedaDestino: string;
    conversion: number;
};