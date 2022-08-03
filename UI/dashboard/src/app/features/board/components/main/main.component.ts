import { Component, OnInit } from '@angular/core';
import { Board } from '../../board.model';
import { BoardService } from '../../board.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  public  page: number = 1;
  public pageSize : number = 5;
  loading = false;

  errorMessage = '';
  data!: Board[];
  listOfCompanies : string = 'MSFT,AAPL,NFLX,FB,AMZN';
  //listOfCompanies : string[]= ['MSFT'];

  constructor( private boardService: BoardService) { }

  ngOnInit(): void {

    this.data = [];
    this.populateCompanyData(this.listOfCompanies);
   
  }

  //loadData(){
   // this.loading = true;
   // this.errorMessage = '';
   // this.repos = [];    
    //for(let i=0; i < this.listOfCompanies.length; i++){  
    //  setTimeout(() => {
     //     this.populateCompanyData(this.listOfCompanies[i]);
     //               },
     //               5000);
   // };
   // this.loadGraphs = true;
  //}

 populateCompanyData(companyName: string){

  this.loading = true;
    this.errorMessage = '';
    this.data = [];
  this.boardService.getDataFromLocalApi(companyName).subscribe((response) => {

     this.data = response.data;
     console.log('this.repos',this.data);

     // when using typescript only
    //let MetaData = response['Meta Data'];       
   // let newBoard = new Board(MetaData['2. Symbol'],MetaData['3. Last Refreshed'],MetaData['4. Output Size'],response['Time Series (Daily)']);     
    //this.repos.push(newBoard);

    this.loading = false;

  },
 (error) => {
                 this.errorMessage = error.message; 
                 this.loading = false; 
              },
     () => {
      this.loading = false;
    });
}

public handleSelectRowClick(index: number) {
 
}
}

