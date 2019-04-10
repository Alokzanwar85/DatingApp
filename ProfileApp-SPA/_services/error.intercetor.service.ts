import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler , HttpEvent, HttpErrorResponse, HTTP_INTERCEPTORS} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import { catchError } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class ErrorIntercetorService implements HttpInterceptor {

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError(error => {
      if (error instanceof HttpErrorResponse) {
        if(error.status === 401)        {
          throwError(error.statusText);
        }
  const applicationError = error.headers.get('Application-Error');
  if (applicationError) {
    return throwError(applicationError);
    }
    }
  })
  );
}

constructor() { }

}

export const ErrorIntercetorProvide = {
  provide: HTTP_INTERCEPTORS,
  useClass : ErrorIntercetorService,
  multi: true

};
