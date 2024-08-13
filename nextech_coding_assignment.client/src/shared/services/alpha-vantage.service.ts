import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BestMatch } from '../models/AlphaVantage/BestMatch';
import { Daily } from '../models/AlphaVantage/Daily';
import { NewsFeed } from '../models/AlphaVantage/NewsFeed';

@Injectable({
  providedIn: 'root'
})
export class AlphaVantageService {

  constructor(private http: HttpClient)
  {

  }

  SearchByKeywords(keywords: string) {
    return this.http.get<BestMatch[]>(`/api/AlphaVantage/SearchByKeywords/${keywords}`);
  }

  GetDaily(symbol: string) {
    return this.http.get<Daily>(`/api/AlphaVantage/GetDaily/${symbol}`);
  }

  GetNewsFeed(symbol: string) {
    return this.http.get<NewsFeed>(`/api/AlphaVantage/GetNewsFeed/${symbol}`);
  }
  
}
