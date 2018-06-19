import { Injectable } from '@angular/core';
import { AuthenticationService } from './authentication.service';
import { Router } from '@angular/router';

@Injectable()
export class AuthGuardService {

	constructor(private authentication: AuthenticationService, private router: Router) { }

	canActivate(redirect: boolean): boolean | Promise<boolean> {
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
		return true;
	}

	resetToken(){
		this.authentication.logout();
	}

	redirectToLoginPage() {
		this.router.navigate(['/login']);
	}

}
