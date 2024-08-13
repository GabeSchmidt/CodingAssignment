import { Component, OnChanges, SimpleChanges, Input, OnInit } from '@angular/core';
import { AlphaVantageService } from '../../shared/services/alpha-vantage.service';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { NewsFeed } from '../../shared/models/AlphaVantage/NewsFeed';

@Component({
  selector: 'app-news-feed',
  templateUrl: './news-feed.component.html',
  styleUrl: './news-feed.component.css',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule, MatIconModule, MatSelectModule, MatGridListModule, MatCardModule]
})
export class NewsFeedComponent {
  @Input() symbol!: string;

  data!: NewsFeed;

  constructor(private alphaVantageService: AlphaVantageService) { }

  ngOnInit() {
    this.GetData();
  }

  ngOnChanges(changes: SimpleChanges) {
    this.symbol = changes['symbol'].currentValue ?? '';
    if (this.symbol != '') {
      
      this.GetData();
    }
  }

  GetData() {
    if (this.symbol !== undefined && this.symbol != '') {
      this.alphaVantageService.GetNewsFeed(this.symbol).subscribe(response => {
        this.data = response;
      });
    }
  }
}
