import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User, Search, Landmark, Enum } from '../models/models';

@Injectable({ providedIn: 'root' })
export class EnumService {
    constructor(private http: HttpClient) { }

    private apiUrl:string ="http://localhost:51431";

    enums(id:string) {
        return this.http.get<Enum[]>(`${this.apiUrl}/enums/${id}`);
    }

    testcentres() {
        return this.http.get<any[]>(`${this.apiUrl}/testcentres`);
    }

}