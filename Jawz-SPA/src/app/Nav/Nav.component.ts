import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_serivces/Auth.service';
import { error } from 'util';

@Component({
  selector: 'app-Nav',
  templateUrl: './Nav.component.html',
  styleUrls: ['./Nav.component.css']
})
export class NavComponent implements OnInit {
 model:any={}
  constructor(private authserivce:AuthService) { }

  ngOnInit() {
  }
login (){
 console.log(this.model);
 this .authserivce.login(this.model).subscribe(next =>{console.log("تم الدخول بنجاج")},error=>{console.log(error)});
 

}
}
