import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Ingredient, MeasureUnit } from './ingredient';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class IngredientService {

  constructor(
    private http: HttpClient
  ) { }

  getIngredients(): Observable<Ingredient[]> {
    return this.http.get<Ingredient[]>(`${environment.tofuWarriorsApiUrl}/Ingredients`);
  }

  getMeasureUnits(): Observable<MeasureUnit[]> {
    return this.http.get<MeasureUnit[]>(`${environment.tofuWarriorsApiUrl}/MeasureUnits`);
  }
}
