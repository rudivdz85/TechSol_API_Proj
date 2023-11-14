import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private apiUrl = 'http://localhost:5241/api/customers'; // Change to your API URL

  constructor(private http: HttpClient) { }

  getCustomers(): Observable<any> {
    return this.http.get(this.apiUrl);
  }

  addCustomer(customer: any): Observable<any> {
    return this.http.post(this.apiUrl, customer);
  }

  getCustomer(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/${id}`);
  }

  updateCustomer(id: number, customer: Customer): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, customer);
  }

  deleteCustomer(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
