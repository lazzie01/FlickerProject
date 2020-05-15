import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { User, Search } from '../models/user';
import { UserService, AuthenticationService } from '../services';
import { Router } from '@angular/router';
import { ModalService } from '../_modal';

@Component({ templateUrl: 'location-list.component.html' })
export class LocationListComponent implements OnInit {
    currentUser: User;
    locations = [];
    searchTerm:string;
    flickerSearchTerm: string;
    constructor(
        private authenticationService: AuthenticationService,
        private userService: UserService,
        private router:Router,
        private modalService: ModalService) 
        {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    ngOnInit() {
        this.loadLocations();
    }

    explore(id:number,name:string):void{
         this.router.navigate(['/location',id],
         {
            queryParams: { 'name' : name }
         });
       }

    delete(id:number):void{
       this.userService.deleteLocation(id,this.currentUser.id)
       .pipe(first())
       .subscribe(data => this.loadLocations());
      }

    loadLocations() {
        this.userService.locations(this.currentUser.id)
            .pipe(first())
            .subscribe(locations => this.locations = locations);
    }

    searchLocations(search: Search) {
        this.userService.searchLocations(search)
            .pipe(first())
            .subscribe(() => this.loadLocations());
    }


    openModal(id: string) {
        this.modalService.open(id);
    }

    closeModal(id: string) {
        let search:Search = { id:this.currentUser.id, query:this.flickerSearchTerm };
        this.searchLocations(search);
        this.modalService.close(id);
    }
}