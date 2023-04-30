import { Injectable } from '@angular/core';
import { Product } from '../../../contracts/product';
import { HttpClientService } from '../http-client.service';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(  private httpClientService : HttpClientService  ) {  }

  create(product:Product, successCallBack?:any) {
    this.httpClientService.post({
      controller: "products"
    }, product).subscribe(result => {
      successCallBack();
    });
  }

}
