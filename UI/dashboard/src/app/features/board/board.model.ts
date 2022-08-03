
export interface IBoard {
    company: string | null;
    lastRefreshed:  string | null;
    outputSize: string | null;
    datesArray: string[]| null;
    dailyTimeSeries : DailyTimeSeries[]| null;
    
}

export class Board implements IBoard {
    company!: string;
    lastRefreshed!:  string;
    outputSize!: string;
    dailyTimeSeries! : DailyTimeSeries[];

    //volume daily chart
    datesArray!: string[];
    dailyVolumesArray!: number[];


    constructor(_company: string,_lastRefreshed: string,_outputSize: string,_dailyTimeSeries: any){
          this.company = _company;
          this.lastRefreshed = _lastRefreshed;
          this.outputSize = _outputSize;
          this.dailyTimeSeries = [];
          this.datesArray = [];
          this.dailyVolumesArray = [];

          for (let [key, value] of Object.entries(_dailyTimeSeries)) {  
                  
            let dailyTimeSeries = new DailyTimeSeries(key,value);           
            this.dailyTimeSeries.push(dailyTimeSeries);
            
            // for volume charts
            this.datesArray.push(key);
            this.dailyVolumesArray.push(dailyTimeSeries.timeSeries.volume);

        }
    }
    
}

export interface IDailyTimeSeries{
    date: string | null;
    
    timeSeries:  TimeSeries | null;

}

export class DailyTimeSeries implements IDailyTimeSeries{
    date!: string;
    datesArray!: string[];
    timeSeries!: TimeSeries;

    constructor(_date: string, _dailyTimeSeries: any){
        this.date = _date;
        this.timeSeries = new TimeSeries(_dailyTimeSeries);
    }
}


export interface ITimeSeries {
    open: number | null;
    high:  number | null;
    low: number | null; 
    close: number | null;
    volume: number | null;
    
}

export class TimeSeries implements ITimeSeries {
    open!: number;
    high!:  number;
    low!: number; 
    close!: number;
    volume!: number;

    constructor(_dailyTimeSeries: object){
           
        for (let [key, _value] of Object.entries(_dailyTimeSeries)) {           
           
           switch(key)
            {
                case '1. open': {
                    this.open = _value;
                    break; 
                 } 
                 case '2. high': {
                    this.high = _value;
                    break; 
                 } 
                 case '3. low': {
                    this.low = _value;
                    break; 
                 } 
                 case '4. close': {
                    this.close = _value;
                    break; 
                 } 
                 case '5. volume': {
                    this.volume = _value;
                    break; 
                 } 
                 default: {                     
                    break; 
                 }             
           }
        }
    }
    
}