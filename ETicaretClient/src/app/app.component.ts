import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CustomtoastrService, ToastrMessagePosition, ToastrMessageType } from './services/ui/customtoastr.service';

declare var  $ : any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ETicareClient';

  constructor() {

    
    
  }

}
