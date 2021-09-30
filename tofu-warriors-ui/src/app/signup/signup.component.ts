import { Component, OnInit } from '@angular/core';
import { UsersService } from '../users.service';
import { User } from '../user';
import { Router } from '@angular/router';
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  private router: Router;
  private usersService: UsersService;
  userId: number = 0;
  firstName: string = "";
  lastName: string = "";
  email: string = "";
  userName: string = "";
  password: string = "";
  constructor(userService:UsersService, router: Router) {
      this.usersService = userService,
      this.router = router;
   }

  ngOnInit(): void {
  }
  signUp():void{
    let classThis = this;
    let result = this.usersService.newUser({
      userId: classThis.userId,
      firstName: classThis.firstName,
      lastName: classThis.lastName,
      email: classThis.email,
      userName: classThis.userName,
      password: classThis.password
    });
    result.subscribe(u => {
      console.log(u)
      this.router.navigate(["home"]);
    })
  }

}
