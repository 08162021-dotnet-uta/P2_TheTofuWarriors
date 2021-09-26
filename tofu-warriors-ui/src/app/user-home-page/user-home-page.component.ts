import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-user-home-page',
  templateUrl: './user-home-page.component.html',
  styleUrls: ['./user-home-page.component.css']
})
export class UserHomePageComponent implements OnInit {

  currentUser: User | null = null;
  constructor(private usersService: UsersService) { }

  ngOnInit(): void {
    this.currentUser = this.usersService.getCurrentUser();
  }

}
