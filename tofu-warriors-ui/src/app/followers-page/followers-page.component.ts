import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-followers-page',
  templateUrl: './followers-page.component.html',
  styleUrls: ['./followers-page.component.css']
})
export class FollowersPageComponent implements OnInit {

  constructor(private users: UsersService) { }
 
  usersList: User[] = [];

  ngOnInit(): void {
 
  }

  loadUsers(): void {
    console.log("loading users 2");
    this.users.getUsers().subscribe(data => {
      console.log(`Got user data: ${data}`)
      this.usersList = data
    });
  }

}
