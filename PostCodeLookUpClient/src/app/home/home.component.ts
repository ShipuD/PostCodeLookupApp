import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { Postcode } from './postcode';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public deliveryOptions: string;
  public inputPostcode: string;
  public inputPostcodeError: string;
  submitted = false;
  model: any = {};
  url:string;

  constructor(private http: HttpClient){

  }  
  clearOptions(){
    this.submitted = false; 
    this.deliveryOptions = "";
  }
  onSubmit() { 
    this.submitted = true;     
   this.deliveryOptions = "";
   this.inputPostcodeError="";

    this.url = environment.baseUrl + "postcodelookup/" + this.model.postcode;
    this.http.get<string>(this.url)
    .subscribe(result => {
      this.deliveryOptions = result;
    }),
     error => console.error(error) 

  }
  

}
