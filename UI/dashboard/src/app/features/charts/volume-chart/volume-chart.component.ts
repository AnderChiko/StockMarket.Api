import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Chart, ChartConfiguration, ChartOptions } from "chart.js";
import Annotation from 'chartjs-plugin-annotation';
import { BaseChartDirective } from 'ng2-charts';

@Component({
  selector: 'app-volume-chart',
  templateUrl: './volume-chart.component.html',
  styleUrls: ['./volume-chart.component.scss']
})



export class VolumeChartComponent implements OnInit{

  @Input() labels : string[] = ['January', 'February', 'March', 'April', 'May', 'June'];
   @Input() repo : any[] = [];
  constructor() { 
      }
            
  ngOnInit(): void {  
    Chart.register(Annotation);
    this.labels = this.repo[0].datesArray;
    this.changeLabel();

  }

  

  public lineChartData: ChartConfiguration<'line'>['data'] = {
    labels: this.labels,
    datasets: [ ]
  };
  public lineChartOptions: ChartOptions<'line'> = {
    responsive: true,
    plugins: {
      title: {
        display: true,
        text: 'TIME SERIES DAILY',
      },
    },
  };
  public lineChartLegend = true;

  @ViewChild(BaseChartDirective) chart?: BaseChartDirective;

  public changeLabel(): void {   

      this.lineChartData.labels = this.labels;
      this.lineChartData.datasets = [];
      for(let i=0; i < this.repo.length; i++){
          
        this.lineChartData.datasets.push({
            data: this.repo[i].dailyVolumeArray ,
            label: this.repo[i].company,
            fill: false,
            tension: 0.5,
            borderColor: this.generateRandomColor(),
           // backgroundColor: this.generateRandomColor()

          }); 
      }   
    this.chart?.update();
  }

  generateRandomColor(){

    var color = "rgb(" + Math.floor(Math.random() * 255) + "," + Math.floor(Math.random() * 255) + "," +  Math.floor(Math.random() * 255) + ")";  
    return color;
  }
}
