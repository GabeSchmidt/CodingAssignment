import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  selectedCompany!: string;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    
  }

  SelectedCompany(company:string) {
    this.selectedCompany = company;
  }

  title = 'Nextech Coding Assignment';
}
