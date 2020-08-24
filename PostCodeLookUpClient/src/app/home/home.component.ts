import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public deliveryOptions: string;
  public inputPostcode: string;
  public baseUrl :string = "https://localhost:44376/";

  constructor(private http: HttpClient){
     //@Inject('BASE_URL') 
    // private baseUrl: string) {

  }
  public onPostcodeSubmit(f: NgForm) {
  
    this.http.get<string>(this.baseUrl + "postcodelookup/" + f.value.inputPostcode)
    .subscribe(result => {
      this.deliveryOptions = result;
    }),
     error => console.error(error) 
  }

}
