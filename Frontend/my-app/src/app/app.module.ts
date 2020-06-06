import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ModalModule } from './_modal';
import { appRoutingModule } from './app.routing';
import { JwtInterceptor, ErrorInterceptor } from './helpers';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AlertComponent } from './components';
import { UsersFilterPipe, SafePipe } from './filters/filters';
import { LocationComponent } from './location/location.component';
import { LandmarkComponent } from './landmark/landmark.component';
import { HomeComponent } from './home/home.component';
import { CaptureComponent } from './capture/capture.component';
import { SuperComponent } from './super';

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        appRoutingModule,
        FormsModule,
        ModalModule
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        CaptureComponent,
        LoginComponent,
        RegisterComponent,
        SuperComponent,
        AlertComponent,
        UsersFilterPipe,
        SafePipe,
        LocationComponent,
        LandmarkComponent
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { };