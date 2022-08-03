import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpHeaders,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

const apiKey = 'fe0d415354msh1a2685b0980df82p15f6fdjsnee0a5bede820';
const apiHost = 'alpha-vantage.p.rapidapi.com';


@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  private inError = false;

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let jsonReq: HttpRequest<any> = request.clone({
    setHeaders :{ 'Content-Type':'application/json',
                  'X-RapidAPI-Key': apiKey,
                  'X-RapidAPI-Host': apiHost
                }
              });
    return next.handle(jsonReq).pipe(
      tap((response: HttpEvent<any>) => {
        this.inError = false;
      }),
      catchError((error) => {
        if (error instanceof HttpErrorResponse) {
          // eslint-disable-next-line @typescript-eslint/consistent-type-assertions
          const status = (<HttpErrorResponse>error).status;
          switch (status) {
            case 429:
              //
              
              
            case 401:
            default:
              return throwError(error);
          }
        } else {
          return throwError(error);
        }
      })
    );
  }
}
