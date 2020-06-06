import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class PatientService {
    constructor(private http: HttpClient) { }
    private apiUrl:string ="http://localhost:51431";

    list() {
        return this.http.get<any[]>(`${this.apiUrl}/patient`);
    }
    read(id:any) {
        return this.http.get<any>(`${this.apiUrl}/patient/${id}`);
    }
    create(patient:any) {
        return this.http.post<any>(`${this.apiUrl}/patient`,patient);
    }
    edit(id:any,patient:any) {
        return this.http.put<any>(`${this.apiUrl}/patient/${id}`,patient);
    }
    delete(id:any) {
        return this.http.delete<any>(`${this.apiUrl}/patient/${id}`);
    }

}