import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ClientsService } from '../clients.service';

@Component({
  selector: 'app-create-client',
  templateUrl: './create-client.component.html',
  styleUrls: ['./create-client.component.css'],
})
export class CreateClientComponent {
  createClientForm = this.formBuilder.group({
    firstName: ['', [Validators.required, Validators.pattern('^[A-Za-z]*$')]],
    lastName: ['', [Validators.required, Validators.pattern('^[A-Za-z]*$')]],
    contactInfo: this.formBuilder.group({
      home: ['', Validators.pattern('^[0-9]*$')],
      work: ['', Validators.pattern('^[0-9]*$')],
      mobile: ['', Validators.pattern('^[0-9]*$')],
    }),
    address: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
  });

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private clientsService: ClientsService
  ) {}

  get firstName() {
    return this.createClientForm.get('firstName');
  }

  get lastName() {
    return this.createClientForm.get('lastName');
  }

  get contactInfo() {
    return this.createClientForm.get('contactInfo');
  }

  get home() {
    return this.createClientForm.controls['contactInfo'].get('home');
  }

  get work() {
    return this.createClientForm.controls['contactInfo'].get('work');
  }

  get mobile() {
    return this.createClientForm.controls['contactInfo'].get('mobile');
  }

  get email() {
    return this.createClientForm.get('email');
  }

  onSubmit(): void {
    const contactInfo: Object[] = [];
    Object.keys(this.createClientForm.value.contactInfo).map((k) => {
      const value = this.createClientForm.value.contactInfo[k];
      if (value) {
        contactInfo.push({
          phoneNumber: value,
          contactType: k.charAt(0).toUpperCase() + k.slice(1),
        });
      }
    });
    if (contactInfo.length === 0) {
      this.createClientForm.controls['contactInfo'].setErrors({
        required: 'At least 1 number is required',
      });
    }
    this.createClientForm.value.contactInfo = contactInfo;
    this.clientsService.create(this.createClientForm.value).subscribe({
      next: (res) => {
        this.router.navigate(['/clients']);
      },
      error: (e) => console.error(e),
    });
  }
}
