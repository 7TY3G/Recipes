import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { User } from '../../shared/model/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  user = new User();

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  login({ value, valid }: { value: User, valid: boolean }) {
    if (valid) {
      this.http.post<User>(this.baseUrl + 'api/Account/Login', this.user).subscribe(result => {
        this.router.navigate(['/']);
      }, error => console.error(error));
    }
  }

  logout(): void {
    this.http.get(this.baseUrl + 'api/Account/Logout').subscribe(result => {
      this.router.navigate(['/']);
    }, error => console.error(error));
  }

  goToRegistration(): void {
    this.router.navigate(['registration']);
  }
}
