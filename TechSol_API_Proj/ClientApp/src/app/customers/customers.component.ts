import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Customer } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {
  @ViewChild('customerForm') customerForm!: NgForm;
  customer: Customer = new Customer();
  customers: Customer[] = [];
  //customer: Customer = {}; // Object for binding form data
  isUpdateMode: boolean = false; // Flag to check if it's add or update operation

  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
    this.loadCustomers();
  }

  loadCustomers(): void {
    this.customerService.getCustomers().subscribe(
      data => {
       
        this.customers = data;
        
      },
      error => {
        console.error('Error fetching customers', error);
      }
    );
  }

  submitCustomer(): void {
    // Check if the form is valid
    if (this.customerForm.valid) {
      if (this.isUpdateMode) {
        this.updateCustomer();
      } else {
        this.addCustomer();
      }
    } else {
      // Handle the invalid form case
      console.error('The form is invalid');
    }
  }


  addCustomer(): void {
    this.customerService.addCustomer(this.customer).subscribe(
      data => {
        this.customers.push(data);
        this.customerForm.reset();  // Reset the form here
        this.customer = new Customer(); // Reset the customer object
        this.isUpdateMode = false; // Ensure you're not in update mode
      },
      error => {
        console.error('Error adding customer', error);
      }
    );
  }

  editCustomer(customer: Customer): void {
    this.customer = { ...customer };
    this.isUpdateMode = true;
  }

  updateCustomer(): void {
    if (this.customer && this.customer.id) {
    this.customerService.updateCustomer(this.customer.id , this.customer).subscribe(
      data => {
        // Update the customer list or re-fetch from the server
        this.loadCustomers();
        this.customer = {}; // Reset the form
        this.isUpdateMode = false;

      },
      error => {
        console.error('Error updating customer', error);
      }
    );
    } else {
      console.error('Customer ID is missing');
    }
  }

  deleteCustomer(id: number): void {
    if (confirm('Are you sure you want to delete this customer?')) {
      this.customerService.deleteCustomer(id).subscribe(
        () => {
          // Remove the customer from the list
          this.customers = this.customers.filter(customer => customer.id !== id);
        },
        error => {
          console.error('Error deleting customer', error);
        }
      );
    }
  }
}
