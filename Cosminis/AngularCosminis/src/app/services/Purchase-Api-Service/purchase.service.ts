import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Order } from '../../Models/Orders';
import { Bundle } from 'src/app/Models/Bundle';


@Injectable({
  providedIn: 'root'
})
export class PurchaseService {
  url : string = environment.api;

  constructor(private http: HttpClient) { }

  BuyGems(userId : number, Amount : number, cost : number) : Observable<Order> {
    return this.http.put(this.url + `Resources/PurchaseGems?userId=${userId}&Amount=${Amount}&cost=${cost}`, userId) as unknown as Observable<Order>;
  } 

  GetReceiptByUserId(userId : number) : Observable<Order[]> {
    return this.http.get(this.url + `Resources/GetReceiptByUserId?userId=${userId}`) as unknown as Observable<Order[]>;
  }
}
