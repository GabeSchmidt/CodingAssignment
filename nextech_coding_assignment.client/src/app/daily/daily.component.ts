import { Component, OnChanges, SimpleChanges, Input, OnInit } from '@angular/core';
import { AlphaVantageService } from '../../shared/services/alpha-vantage.service';
import { Daily } from '../../shared/models/AlphaVantage/Daily';
import { CanvasJSAngularStockChartsModule } from '@canvasjs/angular-stockcharts'
import { MatIconModule } from '@angular/material/icon';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatGridListModule } from '@angular/material/grid-list';

@Component({
  selector: 'app-daily',
  templateUrl: './daily.component.html',
  styleUrl: './daily.component.css',
  standalone: true,
  imports: [CanvasJSAngularStockChartsModule, MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule, MatIconModule, MatSelectModule, MatGridListModule]
})
export class DailyComponent implements OnInit {
  @Input() symbol!: string;

  data!: Daily;
  stockchart: any;
  dps: any = [];
  title!: string;
  dpsMinDate!: Date;
  dpsMaxDate!: Date;

  stockChartOptions = {
    exportEnabled: true,
    theme: "light2",
    title: {
      text: this.title
    },
    charts: [{
      data: [{
        type: "line",
        dataPoints: this.dps
      }]
    }],
    navigator: {
      slider: {
        minimum: this.dpsMinDate,
        maximum: this.dpsMaxDate
      }
    }
  }

  constructor(private alphaVantageService: AlphaVantageService) { }

  ngOnInit() {
    this.GetData();
  }

  ngOnChanges(changes: SimpleChanges) {
    this.symbol = changes['symbol'].currentValue ?? '';
    if (this.symbol != '') {
      this.title = `${this.symbol} Daily Prices`;
      this.GetData();
    }
  }

  GetData() {
    if (this.symbol !== undefined && this.symbol != '') {
      this.alphaVantageService.GetDaily(this.symbol).subscribe(response => {
        this.data = response;
        this.FormatDataForChart(response);
      });
    }
  }

  FormatDataForChart(data: Daily) {
    if (data?.intervals !== null || data?.intervals !== undefined) {

      this.stockChartOptions.title.text = this.title;

      //clear out this array
      this.dps.splice(0, this.dps.length);

      for (const key in data?.intervals) {
        this.dps.push({
          x: new Date(key),
          y: Number(data?.intervals[key].close)
        });
      }

      if (this.dps.length > 0) {
        this.dpsMinDate = this.dps.reduce((acc: Date, val: Date) => {
          return acc < val ? acc : val;
        }).x;

        this.dpsMaxDate = this.dps.reduce((acc: Date, val: Date) => {
          return acc > val ? acc : val;
        }).x;
      }

      if (this.stockchart != null) {
        this.stockchart.options.title.text = this.title;
        this.stockchart.render();
      }
    }
  }

  GetStockChartInstance(instance: any) {
    this.stockchart = instance;
  }
}
