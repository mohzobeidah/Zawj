import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { error } from 'util';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {
 value :any;
  constructor(private http:HttpClient) { 


  }

  ngOnInit() {
    this.getVlue();
  }
   getVlue(){
     this.http.get("http://localhost:5000/api/values",{

      
     }).subscribe(Response=>{

      this.value=Response;
      console.log(Response);
     },error=>{console.log(error);
     }
     )
   }

}
