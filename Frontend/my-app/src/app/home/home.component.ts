import { Component, OnInit } from '@angular/core';
import { User, Search, Enum } from '../models/models';
import { AuthenticationService } from '../services';
import { Router } from '@angular/router';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent implements OnInit {
    currentUser: User;
    constructor(
        private authenticationService: AuthenticationService,
        private router:Router) {}

    ngOnInit() {
        this.currentUser = this.authenticationService.currentUserValue;
        if(this.currentUser.role.value=='super_admin')
        {
             this.router.navigate(['/super']);
        }

        else if(this.currentUser.role.value=='capturer')
        {
            this.router.navigate(['/capture']);
        }
    }

}