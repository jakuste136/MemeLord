import { Injectable } from '@angular/core';
import { AuthenticationService } from './authentication.service';
import { Router } from '@angular/router';

@Injectable()
export class AdminAuthGuardService {

	constructor(private authentication: AuthenticationService, private router: Router) {

	}

	canActivate(redirect: boolean) {
		let currnetUser = this.authentication.getToken();

		if (!currnetUser) {
			if (redirect) {
				console.error("User is not authenticated.");
				this.redirectToLoginPage();
			}
			return false;
		}

		if (Date.now() > currnetUser.expires) {
			this.authentication.logout();

			if (redirect) {
				console.error("User is not authenticated.");
				this.redirectToLoginPage();
			}
			return false;
		}

		if (currnetUser.role != "Admin") {
			console.error("User is not permitted to do that.");

			this.redirectToMainPage();
			return false;
		}
		return true;
	}

	redirectToLoginPage() {
		this.router.navigate(['/login']);
	}

	redirectToMainPage() {
		this.router.navigate(['/user']);
	}

}
