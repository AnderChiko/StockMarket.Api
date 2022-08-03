import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MainComponent } from './features/board/components/main/main.component';
import { NgxLoadingModule } from 'ngx-loading';
import { NgChartsModule } from 'ng2-charts';
import { BoardService } from './features/board/board.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './api/interceptors/token.interceptor';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { VolumeChartComponent } from './features/charts/volume-chart/volume-chart.component';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,   
    VolumeChartComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NgxLoadingModule.forRoot({}),
    NgChartsModule,    
    NgbModule,
  ],
  providers: [
    BoardService,

    // to be used if using angular only to intecept the  request
    //{provide:HTTP_INTERCEPTORS,useClass:TokenInterceptor,multi:true}  
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
