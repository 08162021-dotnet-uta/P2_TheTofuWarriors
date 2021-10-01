import { Component, Input, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Recipe } from '../recipe';
import { User } from '../user';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-recipe-display',
  templateUrl: './recipe-display.component.html',
  styleUrls: ['./recipe-display.component.css']
})
export class RecipeDisplayComponent implements OnInit {

  constructor(
    private usersService: UsersService
  ) { }
  
  @Input() recipe: Recipe | null = null;
  @Input() displayComments: boolean = true;
  
  users: User[] = [];

  subscriptions: Subscription[] = [];

  ngOnInit(): void {
    if (this.displayComments) {
      this.subscriptions.push(this.usersService.getUsers().subscribe(users => this.users = users));
    }
  }

  ngOnChanges(): void {
    console.log("recipe display:", this.recipe);
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(s => s.unsubscribe());
  }

  getTagClass(tagType: number): string {
    switch (tagType) {
      case 1:
        return 'bg-primary';
      case 2:
        return 'bg-secondary';
      case 3:
        return 'bg-danger';
      case 5:
        return 'bg-success';
      case 4:
        return 'bg-info';
      case 6:
        return 'bg-primary';
      default:
        return '';
    }
  }

}
