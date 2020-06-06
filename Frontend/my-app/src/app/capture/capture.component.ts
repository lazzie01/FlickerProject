import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { User, Search, Enum } from '../models/models';
import { UserService, AlertService, AuthenticationService,PatientService } from '../services';
import { Router } from '@angular/router';
import { ModalService } from '../_modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EnumService } from '../services/enum.service';

@Component({ templateUrl: 'capture.component.html' })
export class CaptureComponent implements OnInit {
    currentUser: User;
    patients: any[];
    createPatientForm: FormGroup;
    editPatientForm: FormGroup;
    searchTerm:string;
    patient: any;
    idEnums: Enum[];
    provinceEnums: Enum[];
    countryEnums: Enum[];
    sexEnums: Enum[];
    portOfEntryEnums: Enum[];
    submitted = false;

    constructor(
        private authenticationService: AuthenticationService,
        private modalService: ModalService,
        private formBuilder: FormBuilder,
        private alertService: AlertService,
        private enumService:EnumService,
        private patientService:PatientService
        ) {}

    ngOnInit() {
        this.currentUser = this.authenticationService.currentUserValue;
        this.patientService.list()
        .pipe(first())
        .subscribe(u => this.patients = u);

        //pull enums 
        this.enumService.enums('id-type')
        .pipe(first())
        .subscribe(u => this.idEnums = u);

        this.enumService.enums('province')
        .pipe(first())
        .subscribe(u => this.provinceEnums = u);

        this.enumService.enums('country')
        .pipe(first())
        .subscribe(u => this.countryEnums = u);

        this.enumService.enums('sex')
        .pipe(first())
        .subscribe(u => this.sexEnums = u);

        this.enumService.enums('port-of-entry')
        .pipe(first())
        .subscribe(u => this.portOfEntryEnums = u);
        
        this.createPatientForm = this.formBuilder.group({
            name: ['', Validators.required],
            surname: ['',Validators.required],
            idNumber: ['', Validators.required],
            idType: ['', Validators.required],
            homeAddress: ['',Validators.required],
            phoneNumber: ['',Validators.required],
            provinceId: ['', Validators.required],
            nationalityId: ['',Validators.required],
            disabled: ['', Validators.required],
            dob: ['', Validators.required],
            previousCountryId: ['',Validators.required],
            sexId: ['', Validators.required],
            previousCountryCity: ['', Validators.required],
            occupation: ['', Validators.required],
            //NextOfKin
            nFullname: ['', Validators.required],
            nAddress: ['', Validators.required],
            nPhone: ['', Validators.required],
            //PortOfEntry
            pPortOfEntryId: ['', Validators.required],
            pDateOfArrival: ['', Validators.required]
        });
    }

    // convenience getter for easy access to form fields
   // get ef() { return this.editUserForm.controls; }
    get cf() { return this.createPatientForm.controls; }

    openCreatePatientModal(id: string){
        this.modalService.open(id);
        this.createPatientForm.reset();
    }
    closeCreatePatientModal (id: string){
        this.modalService.close(id);
        this.createPatientForm.reset();
    }

    onSubmitCreatedPatient(){
        this.submitted = true;
       // console.log('power');

        // reset alerts on submit
        this.alertService.clear();

        // stop here if form is invalid
        if (this.createPatientForm.invalid) {
            return;
        }
        //save model
        let patientModel:any =
        {
            name : this.cf.name.value,
            surname : this.cf.surname.value,
            idNumber : this.cf.idNumber.value,
            idType : Number(this.cf.idType.value),
            homeAddress : this.cf.homeAddress.value,
            phoneNumber : this.cf.phoneNumber.value,
            provinceId : Number(this.cf.provinceId.value),
            nationalityId : Number(this.cf.nationalityId.value),
            disabled : Boolean(this.cf.disabled.value),
            dob : this.cf.dob.value,
            previousCountryId : Number(this.cf.previousCountryId.value),
            sexId : Number(this.cf.sexId.value),
            previousCountryCity : this.cf.previousCountryCity.value,
            occupation : this.cf.occupation.value,
            nextOfKin : {
                fullname : this.cf.nFullname.value,
                address : this.cf.nAddress.value,
                phone : this.cf.nPhone.value
            },
            portOfEntry : {
                portOfEntryId : Number(this.cf.pPortOfEntryId.value),
                dateOfArrival : this.cf.pDateOfArrival.value
            }
            
        };

         this.patientService.create(patientModel)
         .pipe(first())
         .subscribe(
             data => {
                 this.modalService.close('custom-modal-4');
                 this.patientService.list()
                 .pipe(first())
                 .subscribe(u => this.patients = u);
             },
             error => {
                 console.log(error);
                  this.alertService.error(error);
             });
        //reset form after submission
        //this.modalService.close('custom-modal-4');
    }
    openViewPatientModal(id: string, itemId:number){
        this.modalService.open(id);
        this.patientService.read(itemId)
        .pipe(first())
        .subscribe(u => this.patient = u);
    }
    closeViewPatientModal(id: string) {
        this.modalService.close(id);
    }

    openEditPatientModal(id: string, itemId:number){
        this.modalService.open(id);
        this.patientService.read(itemId)
            .pipe(first())
        .subscribe(u => 
            {
                this.patient = u;
                this.cf.name.setValue(this.patient.name);
                this.cf.surname.setValue(this.patient.surname);
                this.cf.idNumber.setValue(this.patient.idNumber);
                this.cf.idType.setValue(this.patient.idTypeId);
                this.cf.homeAddress.setValue(this.patient.homeAddress);
                this.cf.phoneNumber.setValue(this.patient.phoneNumber);
                this.cf.provinceId.setValue(this.patient.provinceId);
                this.cf.nationalityId.setValue(this.patient.nationalityId);
                this.cf.disabled.setValue(this.patient.disabled);
                this.cf.dob.setValue(this.patient.dob.substr(0,10));
                this.cf.previousCountryId.setValue(this.patient.previousCountryId);
                this.cf.sexId.setValue(this.patient.sexId);
                this.cf.previousCountryCity.setValue(this.patient.previousCountryCity);
                this.cf.occupation.setValue(this.patient.occupation);
                this.cf.nFullname.setValue(this.patient.nextOfKin.fullname);
                this.cf.nAddress.setValue(this.patient.nextOfKin.address);
                this.cf.nPhone.setValue(this.patient.nextOfKin.phone);
                this.cf.pPortOfEntryId.setValue(this.patient.pPortOfEntryId);
                this.cf.pDateOfArrival.setValue(this.patient.portOfEntry.dateOfArrival.substr(0,10));
            });
    }

    openDeletePatientModal(id: string, itemId:number){
        this.modalService.open(id);
        this.patientService.read(itemId)
        .pipe(first())
        .subscribe(u => this.patient = u);
    }
    closeDeletePatientModal(id: string, itemId:number){
        this.patientService.delete(itemId)
        .pipe(first())
        .subscribe(res=>
            {
                this.patientService.list()
                .pipe(first())
                .subscribe(u => this.patients = u);
            });
  
        this.modalService.close(id);
    }

    onSubmitEditPatient(){
        this.submitted = true;
        // console.log('power');
 
         // reset alerts on submit
         this.alertService.clear();
 
         // stop here if form is invalid
         if (this.createPatientForm.invalid) {
             return;
         }
         //save model
         let patientModel:any =
         {
            name : this.cf.name.value,
            surname : this.cf.surname.value,
            idNumber : this.cf.idNumber.value,
            idType : Number(this.cf.idType.value),
            homeAddress : this.cf.homeAddress.value,
            phoneNumber : this.cf.phoneNumber.value,
            provinceId : Number(this.cf.provinceId.value),
            nationalityId : Number(this.cf.nationalityId.value),
            disabled : Boolean(this.cf.disabled.value),
            dob : this.cf.dob.value,
            previousCountryId : Number(this.cf.previousCountryId.value),
            sexId : Number(this.cf.sexId.value),
            previousCountryCity : this.cf.previousCountryCity.value,
            occupation : this.cf.occupation.value,
            nextOfKin : {
                fullname : this.cf.nFullname.value,
                address : this.cf.nAddress.value,
                phone : this.cf.nPhone.value
            },
            portOfEntry : {
                portOfEntryId : Number(this.cf.pPortOfEntryId.value),
                dateOfArrival : this.cf.pDateOfArrival.value
            }
            
          };
          //console.log(patientModel);
          this.patientService.edit(this.patient.id,patientModel)
          .pipe(first())
          .subscribe(
              data => {
                  this.modalService.close('custom-modal-2');
                  this.patientService.list()
                  .pipe(first())
                  .subscribe(u => this.patients = u);
              },
              error => {
                  console.log(error);
                   this.alertService.error(error);
              });
         //reset form after submission
    }
    closeEditPatientModal(id: string){
        this.modalService.close(id);
    }
}