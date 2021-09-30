import { Component, Input, OnInit } from '@angular/core';
import { Subscriber } from 'rxjs';
import { Following } from '../Following';
import { Recipe } from '../recipe';
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
  @Input() user: User | null = null;
  influencerId?: number;
  followingId?:number;
  userRecipeList: Recipe[]=[];
  infulencers: Following[]=[];
  influencerName:string = "";
  ngOnInit(): void {
    this.refreshData();
  }
  refreshData() : void{
    console.log("loading users");
    this.loadUsers();
    this.followingById();
  }

  loadUsers(): void {
    console.log("loading users 2");
    this.users.getUsers().subscribe(data => {
  
    console.log(`Got user data: ${data}`)
      this.usersList = data;
      //should not show the user itself in the list of users in the homepage
 this.usersList=this.usersList.filter(ele=>ele.userId!==this.user?.userId);
    });

  }
  // onSelect(user:User):void{
  
  //   console.log(`here is the infId ${this.influencerId}`)
  //   this.follow();
  // }
 
  hasFollowed(influencerId: number):boolean{
    return this.infulencers.filter(i=> i.influencerId === influencerId).length > 0;
  }
  //follow a user 
  follow(influencer:User):void{
  if(this.user && influencer) {
      console.log( `here is userId${this.user.userId}`)
   this.users.followUser(this.user.userId,influencer.userId)
    .subscribe(data=>
      {
        console.log(data);
        this.refreshData();
      }
    );
  } 

  
  }
  //get followingId for user
   followingById():void{
     if(this.user)
      this.users.getFollowingUserId(this.user.userId).subscribe(data =>{
        this.infulencers=data;
      });


  }
  //unflow
unfollow(influencer:User):void{
  //follower: user
  //influencer
  console.log(this.infulencers);
  console.log(influencer.userId);
 let followings = this.infulencers.filter(ele =>ele.influencerId === influencer.userId)

  if(followings.length>0)
    this.users.unfollowerUser(followings[0].followingId).subscribe(data=>{
      console.log(data);
      this.refreshData();
    });
  }
  showActivities(user:User):void{
    this.influencerName = `${user.firstName} ${user.lastName}`;
    this.users.getRecipeUserId(user.userId).subscribe(data =>{
      this.userRecipeList =data; 
    console.log(data); });
}

}
