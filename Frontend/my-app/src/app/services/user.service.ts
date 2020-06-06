import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User, Search, Landmark } from '../models/models';

@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }

    private apiUrl:string ="http://localhost:51431";

    list() {
        return this.http.get<User[]>(`${this.apiUrl}/users`);
    }

    read(id:number) {
        return this.http.get<User>(`${this.apiUrl}/users/${id}`);
    }

    delete(id:number) {
        return this.http.delete(`${this.apiUrl}/users/${id}`);
    }

    edit(id:number, user:any) {
        return this.http.put<any>(`${this.apiUrl}/users/${id}`,user);
    }

    create(user:any) {
        return this.http.post<any>(`${this.apiUrl}/users/register`,user);
    }

    //junk
    locations(id:number) {
        return this.http.get<Location[]>(`${this.apiUrl}/locations/${id}`);
    }

    searchLocations(search: Search) {
        return this.http.post(`${this.apiUrl}/locations/${search.id}`, search);
    }

    locationLandmarks(id:number) {
        return this.http.get<Landmark[]>(`${this.apiUrl}/locations/${id}/landmarks`);
    }

    landmarks(id:number) {
        return this.http.get<Landmark[]>(`${this.apiUrl}/landmarks/${id}`);
    }

    deleteLocation(locationId: number,userId: number) {
        return this.http.delete(`${this.apiUrl}/locations/${locationId}?userId=${userId}`);
    }
  
    register(user: User) {
        return this.http.post(`${this.apiUrl}/users/register`, user);
    }

}