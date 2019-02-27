import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { User } from '../../shared/models/user';
import { AccountService } from '../../shared/services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  user = new User();

  constructor(private router: Router, private accountService: AccountService) {
  }

  login({ value, valid }: { value: User, valid: boolean }) {
    if (valid) {
      this.accountService.register(this.user)
        .subscribe((user: User) => {
          this.router.navigate(['/']);

          // TODO: Route to user account
        },
        (error: any) => console.log(error),
        () => console.log('register called'));
    }
  }

  logout(): void {
    this.accountService.register(this.user)
      .subscribe((user: User) => {
        this.router.navigate(['/']);

        // TODO: Route to user account
      },
      (error: any) => console.log(error),
      () => console.log('register called'));
  }

  goToRegistration(): void {
    this.router.navigate(['registration']);
  }
}
