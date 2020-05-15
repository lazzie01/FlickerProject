import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../services';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrls: ['./location.component.css']
})
export class LocationComponent implements OnInit {

  constructor(private activatedRoute:ActivatedRoute,
              private userService: UserService,
              private router:Router
              ) { }

  landmarks:any[];
  name: string;
  id:number;
  ngOnInit(): void {
    this.id = parseInt(this.activatedRoute.snapshot.paramMap.get('id'));
    this.activatedRoute.queryParams.subscribe(p => this.name = p.name);
    this.loadAllLocationLandmarks(this.id);
  }

  private loadAllLocationLandmarks(id:number) {
    this.userService.locationLandmarks(id)
        .pipe(first())
        .subscribe(landmarks => this.landmarks = landmarks);
}

backToHome():void{
  this.router.navigate(['/home']);
}

navLandmark(id:number):void{
  this.router.navigate(['/landmark',id],
         {
            queryParams: { 'locationId' : this.id, 'locationName' : this.name }
         });
}

}
