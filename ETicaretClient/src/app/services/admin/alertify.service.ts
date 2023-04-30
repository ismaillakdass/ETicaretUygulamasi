import { Injectable } from '@angular/core';
declare var  alertify : any;

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

  constructor() { }
    message(message: string, options: Required<AlertifyOptions>) {
      alertify.set('notifier','position', options.position);
      alertify.set('notifier','delay', options.delay);
      const msj = alertify[options.messageType](message);
      if(options.dismissOuther)
        msj.dismissOuther();
    }
    dismissAll() {
      alertify.dismissAll();
    }
}

export class AlertifyOptions{
  messageType : AlertifyMessageType = AlertifyMessageType.Message;
  position: AlertifyMessagePosition = AlertifyMessagePosition.TopCenter;
  delay: number= 3;
  dismissOuther: boolean = false;
}

export enum AlertifyMessageType {
  Error = "error",
  Message = "message",
  Notify = "notify",
  Success = "success",
  Warning = "warning"

}

export enum AlertifyMessagePosition {
  TopRight = "top-right",
  TopCenter = "top-center",
  TopLeft = "top-left",
  BottomRight = "bottom-right",
  BottomCenter = "bottom-center",
  BottomLeft = "bottom-left"

}
