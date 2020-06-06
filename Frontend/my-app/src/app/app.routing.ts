import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login';
import { RegisterComponent } from './register';
import { AuthGuard } from './helpers';
import { HomeComponent } from './home/home.component';
import { LandmarkComponent } from './landmark/landmark.component';
import { CaptureComponent } from './capture';
import { SuperComponent } from './super';


const routes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path:'home/:id',  component:HomeComponent, canActivate: [AuthGuard] },
    { path:'capture',  component:CaptureComponent, canActivate: [AuthGuard] },
    { path:'super',  component:SuperComponent, canActivate: [AuthGuard] },
    { path:'landmark/:id',  component:LandmarkComponent, canActivate: [AuthGuard] },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const appRoutingModule = RouterModule.forRoot(routes);