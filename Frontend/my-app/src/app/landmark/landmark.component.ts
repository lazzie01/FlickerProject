import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../services';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-landmark',
  templateUrl: './landmark.component.html',
  styleUrls: ['./landmark.component.css']
})
export class LandmarkComponent implements OnInit {

  constructor(private activatedRoute:ActivatedRoute,
    private userService: UserService,
    private router:Router) { }
    landmark:any;
    locationId:number;
    locationName:string;
  ngOnInit(): void {
    let id:number = parseInt(this.activatedRoute.snapshot.paramMap.get('id'));
    this.loadLandmark(id);
  }

  private loadLandmark(id:number) {
    this.userService.landmarks(id)
        .pipe(first())
        .subscribe(landmark => this.landmark = landmark);
   }

   public navLocation(){
    this.activatedRoute.queryParams.subscribe(p => this.locationId = p.locationId);
    this.activatedRoute.queryParams.subscribe(p => this.locationName = p.locationName);
    this.router.navigate(['/location',this.locationId],
    {
      queryParams :{'name':this.locationName}
    });
   }

}
