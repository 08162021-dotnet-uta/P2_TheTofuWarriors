import { Component, Input, OnInit } from '@angular/core';
import { Recipe } from '../recipe';
import { User } from '../user';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-inflencer-activities',
  templateUrl: './inflencer-activities.component.html',
  styleUrls: ['./inflencer-activities.component.css']
})
export class InflencerActivitiesComponent implements OnInit {

  constructor(private userService:UsersService) { }

  @Input() userName: string | null = null;
  @Input() userRecipes: Recipe[] | null = null;
  ngOnInit(): void {
    //this.loadUserRecipe();
  }
  
// loadUserRecipe():void{
//   if(this.user)
// this.userService.getRecipeUserId(this.user.userId).subscribe(data =>{
//   this.userRecipeList =data;
// })
// }
}
