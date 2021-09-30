import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-user-display',
  templateUrl: './user-display.component.html',
  styleUrls: ['./user-display.component.css']
})
export class UserDisplayComponent implements OnInit {

  constructor(private users: UsersService) { }

  usersList: User[] = [];

  ngOnInit(): void {
    console.log("loading users");
    this.loadUsers();
  }

  loadUsers(): void {
    console.log("loading users 2");
    this.users.getUsers().subscribe(data => {
      console.log(`Got user data: `, data)
      this.usersList = data
    });
  }

}
