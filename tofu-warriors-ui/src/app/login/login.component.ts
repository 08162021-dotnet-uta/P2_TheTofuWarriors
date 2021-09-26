import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import { UsersService } from '../users.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  userName: string  =""
  password: string  ="" 
  private usersService: UsersService;
  constructor(userService:UsersService) {
    this.usersService = userService
 }


  ngOnInit(): void {
  }
  login()
  {
    this.usersService.logIn(this.userName, this.password)
      .subscribe(user => console.log(user))
  }

}
