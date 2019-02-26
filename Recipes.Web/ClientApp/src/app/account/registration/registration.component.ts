import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { User } from '../../shared/model/user';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html'
})
export class RegistrationComponent {
  user = new User();

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  register() {
    this.http.post<User>(this.baseUrl + 'api/Account/Register', this.user).subscribe(result => {
      this.router.navigate(['/']);
    }, error => console.error(error));
  }
}
