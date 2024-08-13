import { Component, output } from '@angular/core';
import { AlphaVantageService } from '../../shared/services/alpha-vantage.service';
import { BestMatch } from '../../shared/models/AlphaVantage/BestMatch';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrl: './search.component.css',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule, MatIconModule, MatSelectModule, MatGridListModule, MatCardModule],
})
export class SearchComponent {

  keywords!: string
  data!: BestMatch[];
  selectedSymbol!: string;
  onSelectedCompanyChange = output<string>();

  constructor(private alphaVantageService: AlphaVantageService) { }

  Search() {
    this.selectedSymbol = '';
    if (this.keywords != '' && this.keywords.length != 0) {
      this.alphaVantageService.SearchByKeywords(this.keywords).subscribe(response => {
        this.data = response;
        if (this.data.length == 1) {
          this.CompanySelected(this.data[0].symbol);
        }
      });
    }
  }

  CompanySelected(selectedCompany: string) {
    this.selectedSymbol = selectedCompany;
    this.onSelectedCompanyChange.emit(selectedCompany);
  }

}
