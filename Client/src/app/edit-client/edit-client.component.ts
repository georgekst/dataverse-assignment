import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientsService } from '../clients.service';
import { Client } from '../models/client';
import { ContactInfo } from '../models/contact-info';

@Component({
  selector: 'app-edit-client',
  templateUrl: './edit-client.component.html',
  styleUrls: ['./edit-client.component.css'],
})
export class EditClientComponent implements OnInit {
  clientId!: number;
  client!: Client;
  editClientForm = this.formBuilder.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    contactInfo: this.formBuilder.group({
      home: [''],
      work: [''],
      mobile: [''],
    }),
    address: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
  });

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private clientsService: ClientsService
  ) {}

  ngOnInit(): void {
    this.retrieveClient();
  }

  retrieveClient(): void {
    this.clientId = parseInt(this.route.snapshot.params['id']);
    this.clientsService.get(this.clientId).subscribe({
      next: (response) => {
        this.client = response.data;
        let homeNumberToDisplay: ContactInfo;
        let workNumberToDisplay: ContactInfo;
        let mobileNumberToDisplay: ContactInfo;
        this.client.contactInfo.forEach((contact) => {
          contact.contactType === 'Home' ? (homeNumberToDisplay = contact) : '';
          contact.contactType === 'Work' ? (workNumberToDisplay = contact) : '';
          contact.contactType === 'Mobile'
            ? (mobileNumberToDisplay = contact)
            : '';
          this.editClientForm.patchValue({
            firstName: this.client.firstName,
            lastName: this.client.lastName,
            contactInfo: {
              home: homeNumberToDisplay?.phoneNumber,
              work: workNumberToDisplay?.phoneNumber,
              mobile: mobileNumberToDisplay?.phoneNumber,
            },
            address: this.client.address,
            email: this.client.email,
          });
        });
      },
      error: (e) => console.error(e),
    });
  }

  get contactInfo() {
    return this.editClientForm?.get('contactInfo');
  }

  get email() {
    return this.editClientForm?.get('email');
  }

  onSubmit(): void {
    const contactInfo: Object[] = [];
    Object.keys(this.editClientForm?.value.contactInfo).map((k) => {
      const value = this.editClientForm?.value.contactInfo[k];
      if (value) {
        const contact = this.client?.contactInfo.find(
          (c) => c.contactType === k.charAt(0).toUpperCase() + k.slice(1)
        );
        contactInfo.push({
          id: contact?.id,
          phoneNumber: value,
          contactType: k.charAt(0).toUpperCase() + k.slice(1),
        });
      }
    });
    if (this.editClientForm?.value.contactInfo.length === 0) {
      this.editClientForm?.controls['contactInfo'].setErrors({
        required: 'At least 1 number is required',
      });
    }
    const payload = {
      ...this.editClientForm?.value,
      contactInfo,
    };
    this.clientsService.update(this.clientId, payload).subscribe({
      next: (res) => {
        this.router.navigate(['/clients']);
      },
      error: (e) => console.error(e),
    });
  }
}
