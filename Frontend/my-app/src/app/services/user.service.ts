import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User, Search, Landmark } from '../models/user';

@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }

    private apiUrl:string ="http://localhost:51431";

    locations(id:number) {
        return this.http.get<Location[]>(`${this.apiUrl}/users/${id}/locations`);
    }

    locationLandmarks(id:number) {
        return this.http.get<Landmark[]>(`${this.apiUrl}/users/location-landmarks/${id}`);
    }

    landmarks(id:number) {
        return this.http.get<Landmark[]>(`${this.apiUrl}/users/landmarks/${id}`);
    }

    register(user: User) {
        return this.http.post(`${this.apiUrl}/users/register`, user);
    }

    searchLocations(search: Search) {
        return this.http.post(`${this.apiUrl}/users/${search.id}/locations`, search);
    }

    deleteLocation(locationId: number,userId: number) {
        return this.http.delete(`${this.apiUrl}/users/delete/${locationId}?userId=${userId}`);
    }
}