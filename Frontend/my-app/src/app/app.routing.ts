import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login';
import { RegisterComponent } from './register';
import { AuthGuard } from './helpers';
import { LocationComponent } from './location/location.component';
import { LandmarkComponent } from './landmark/landmark.component';
import { LocationListComponent } from './home';

const routes: Routes = [
    { path: '', component: LocationListComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path:'location/:id',  component:LocationComponent, canActivate: [AuthGuard] },
    { path:'landmark/:id',  component:LandmarkComponent, canActivate: [AuthGuard] },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const appRoutingModule = RouterModule.forRoot(routes);