import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { User, Search } from '../models/user';
import { UserService, AuthenticationService } from '../services';
import { Router } from '@angular/router';
import { ModalService } from '../_modal';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent implements OnInit {
    currentUser: User;
    locations = [];
    statusMessage:string = "Loading please wait...";
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
        this.loadAllUserLocations();
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
       .subscribe(data => this.loadAllUserLocations());
      }

    private loadAllUserLocations() {
        this.userService.locations(this.currentUser.id)
            .pipe(first())
            .subscribe(locations => this.locations = locations);
    }

    private searchAllUserLocations(search: Search) {
        this.userService.searchLocations(search)
            .pipe(first())
            .subscribe(() => this.loadAllUserLocations());
    }


    openModal(id: string) {
        this.modalService.open(id);
    }

    closeModal(id: string) {
        let search:Search = { id:this.currentUser.id, query:this.flickerSearchTerm };
        this.searchAllUserLocations(search);
        this.modalService.close(id);
    }
}