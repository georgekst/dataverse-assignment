import { ContactInfo } from './contact-info';

export interface Client {
  id: number;
  firstName: string;
  lastName: string;
  contactInfo: ContactInfo[];
  address: string;
  email: string;
}
