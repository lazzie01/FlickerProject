import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { User, Search, Enum } from '../models/models';
import { UserService, AlertService, AuthenticationService } from '../services';
import { Router } from '@angular/router';
import { ModalService } from '../_modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EnumService } from '../services/enum.service';

@Component({ templateUrl: 'super.component.html' })
export class SuperComponent implements OnInit {
    currentUser: User;
    users: User[];
    user: User;
    roles: Enum[];
    testcentres: any[];
    searchTerm:string;
    editUserForm: FormGroup;
    createUserForm: FormGroup;
    selectedRoleValue:number;
    submitted = false;

    constructor(
        private authenticationService: AuthenticationService,
        private userService: UserService,
        private router:Router,
        private modalService: ModalService,
        private formBuilder: FormBuilder,
        private alertService: AlertService,
        private enumService:EnumService
        ) 
        {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    ngOnInit() {
        if(this.currentUser.roleId==1)
        {
            //load enums
            this.enumService.enums('role')
            .pipe(first())
            .subscribe(e => 
            {
                this.roles = e;
            });

            this.enumService.testcentres()
            .pipe(first())
            .subscribe(e => 
            {
                this.testcentres = e;
            });

            this.editUserForm = this.formBuilder.group({
                username: ['', Validators.required],
                password: [''],
                name: ['', Validators.required],
                surname: ['', Validators.required],
                organization: [''],
                department: [''],
                phone: ['', Validators.required],
                email: [''],
                activated: ['', Validators.required],
                testCentreName: [''],
                roleId: ['', Validators.required]
            });
            //
            this.createUserForm = this.formBuilder.group({
                username: ['', Validators.required],
                password: ['',Validators.required],
                name: ['', Validators.required],
                surname: ['', Validators.required],
                organization: ['',Validators.required],
                department: ['',Validators.required],
                phone: ['', Validators.required],
                email: [''],
                activated: ['', Validators.required],
                testCentreId: ['',Validators.required],
                roleId: ['', Validators.required]
            });
            this.userService.list()
                     .pipe(first())
                     .subscribe(u => this.users = u);
        }

        else if(this.currentUser.roleId==5)
        {
            console.log(this.currentUser.roleId);
            //open capture page here
          //  this.router.navigate(['/capture']);
        }
    }

    openViewUserModal(id: string, itemId:number) {
        this.modalService.open(id);
        this.userService.read(itemId)
        .pipe(first())
        .subscribe(u => this.user = u);
    }

    closeViewUserModal(id: string) {
        this.modalService.close(id);
    }

     // convenience getter for easy access to form fields
     get ef() { return this.editUserForm.controls; }

     get cf() { return this.createUserForm.controls; }

     openEditUserModal(id: string, itemId:number) {
        this.modalService.open(id);
        this.userService.read(itemId)
        .pipe(first())
        .subscribe(u => 
            {
                this.user = u;
                this.ef.username.setValue(this.user.username);
                this.ef.password.setValue(this.user.password);
                this.ef.name.setValue(this.user.name);
                this.ef.surname.setValue(this.user.surname);
                this.ef.organization.setValue(this.user.organization);
                this.ef.department.setValue(this.user.department);
                this.ef.phone.setValue(this.user.phone);
                this.ef.email.setValue(this.user.email);
                this.ef.activated.setValue(this.user.activated);
                this.ef.testCentreName.setValue(this.user.testCentre.name);
                this.selectedRoleValue = this.user.roleId;
            });
      
    }

    closeEditUserModal(id: string) {
        this.modalService.close(id);
    }

    closeDeleteUserModal(id: string, itemId:number) {
        this.userService.delete(itemId)
        .pipe(first())
        .subscribe(res=>
            {
                this.userService.list()
                .pipe(first())
                .subscribe(u => this.users = u);
            });
  
        this.modalService.close(id);
    }

    openDeleteUserModal(id: string, itemId:number) {
        this.modalService.open(id);
        this.userService.read(itemId)
        .pipe(first())
        .subscribe(u => this.user = u);
    }

    onSubmitEditedUser(id:number){
        this.submitted = true;

        // reset alerts on submit
        this.alertService.clear();

        // stop here if form is invalid
        if (this.editUserForm.invalid) {
            return;
        }

        let userModel:any =
        {
            username : this.ef.username.value,
            password : this.ef.password.value,
            name : this.ef.name.value,
            surname : this.ef.surname.value,
            department : this.ef.department.value,
            phone : this.ef.phone.value,
            email : this.ef.email.value,
            activated : Boolean(this.ef.activated.value),
            testCentreId : this.user.testCentre.id,
            roleId : Number(this.ef.roleId.value),
            organization : this.ef.organization.value,
        };
        this.userService.edit(id, userModel)
            .pipe(first())
            .subscribe(
                data => {
                    this.modalService.close('custom-modal-2');
                    this.userService.list()
                    .pipe(first())
                    .subscribe(u => this.users = u);
                },
                error => {
                     this.alertService.error(error);
                });


    }

    onSubmitCreatedUser(){
        this.submitted = true;

        // reset alerts on submit
        this.alertService.clear();

        // stop here if form is invalid
        if (this.createUserForm.invalid) {
            return;
        }

        let userModel:any =
        {
            username : this.cf.username.value,
            password : this.cf.password.value,
            name : this.cf.name.value,
            surname : this.cf.surname.value,
            organization : this.cf.organization.value,
            department : this.cf.department.value,
            phone : this.cf.phone.value,
            email : this.cf.email.value,
            activated : Boolean(this.cf.activated.value),
            testCentreId : Number(this.cf.testCentreId.value),
            roleId : Number(this.cf.roleId.value),
        };
        this.userService.create(userModel)
        .pipe(first())
        .subscribe(
            data => {
                this.modalService.close('custom-modal-4');
                this.userService.list()
                .pipe(first())
                .subscribe(u => this.users = u);
            },
            error => {
                 this.alertService.error(error);
            });
    }
   
    openCreateUserModal(id: string){
        this.modalService.open(id);
    }

    closeCreateUserModal(id: string) {
        this.modalService.close(id);
    }
}