import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { User } from '../../shared/models/user';
import { AccountService } from '../../shared/services/account.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html'
})
export class RegistrationComponent {
  user = new User();

  constructor(private router: Router, private accountService: AccountService) {
  }

  register() {
    this.accountService.register(this.user)
      .subscribe((user: User) => {
        this.router.navigate(['/']);

        // TODO: Route to user account
      },
      (error: any) => console.log(error),
      () => console.log('register called'));
  }
}
