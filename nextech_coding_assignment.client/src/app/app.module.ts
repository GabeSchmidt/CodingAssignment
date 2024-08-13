import { provideHttpClient } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

import { SearchComponent } from './search/search.component';
import { DailyComponent } from './daily/daily.component';

import { AlphaVantageService } from './../shared/services/alpha-vantage.service';
import { CanvasJSAngularStockChartsModule } from '@canvasjs/angular-stockcharts';
import { NewsFeedComponent } from './news-feed/news-feed.component'

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    CanvasJSAngularStockChartsModule,
    SearchComponent,
    DailyComponent,
    NewsFeedComponent
  ],
  providers: [
    provideAnimationsAsync(),
    provideHttpClient(),
    AlphaVantageService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
