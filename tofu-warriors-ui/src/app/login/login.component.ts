import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
  private router: Router;
  constructor(userService:UsersService, router: Router) {
    this.usersService = userService
    this.router = router;
 }


  ngOnInit(): void {
  }
  login()
  {
    this.usersService.logIn(this.userName, this.password)
      .subscribe(user => {
        console.log(user)
        this.router.navigate(["home"]);
      })
  }

}
