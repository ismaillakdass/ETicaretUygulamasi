import { Component } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';


export class BaseComponent {

  constructor(private spinner : NgxSpinnerService) { 

  }

  showSpinner(spinnerType:SpinnerType){
    this.spinner.show(spinnerType);

    setTimeout(() => {
      this.spinner.hide(spinnerType);
    }, 2500);
  }

  hideSpinner(spinnerType: SpinnerType){
    this.spinner.hide(spinnerType);

  }

}

export enum SpinnerType{

  BallScale="s1",
  BallAtom="s2",
  BallNewtonCradle="s3",
  BallSpinClockWiseFade="s4"

}