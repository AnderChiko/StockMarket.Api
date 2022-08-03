import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
//import { config } from '../../../../config.json';

@Injectable({
  providedIn: 'root',
})
export class BoardService {
  
  private proxyUrl = 'https://alpha-vantage.p.rapidapi.com/query';

  constructor(private http: HttpClient) {}
  
  getDataFromRapidApi(symbol: string) : Observable<any>{
   
    const url = `${this.proxyUrl}`;
    
    let queryParams = new HttpParams()
    .set('function', 'TIME_SERIES_DAILY')
    .set('symbol', symbol)
    .set('outputsize', 'compact')
    .set('datatype', 'json');

    return this.http.get(url, {params:queryParams});
  }

  getDataFromLocalApi(symbol: string) : Observable<any>{
   
    const url =  `https://localhost:44368/api/AlphaVantageIntergration/TimeSeriesDaily`;
    let queryParams = new HttpParams()
    .set('company', symbol);

    return this.http.get(url, {params:queryParams});
  }


}

