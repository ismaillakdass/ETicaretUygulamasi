import { Component,OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { HttpClientService } from 'src/app/services/common/http-client.service';



@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent extends BaseComponent implements OnInit {
  constructor(spinner : NgxSpinnerService, private httpClientService: HttpClientService) {  
    super(spinner);
  }

  ngOnInit(): void {
    
    //this.httpClientService.get({controller: "products"}).subscribe(res=> console.log(res));

    // this.httpClientService.post({
    //   controller: "products"
    // },{
    //   name: "Kalem",
    //   price: 100,
    //   stock: 5
    // }).subscribe();

  }
}
