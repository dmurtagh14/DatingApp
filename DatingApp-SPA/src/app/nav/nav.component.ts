import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};

  constructor(public authService: AuthService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(
      next => {
        this.alertify.success('Logged in successfully!');
      }, error => {
        this.alertify.error(error);
      }, () => {
        // annyoumous function
        this.router.navigate(['/matches']);
      }
    );
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  loggedOut() {
    localStorage.removeItem('token');
    this.alertify.message('Logged out!');
    this.router.navigate(['/home']);
    this.model.name = '';
    this.model.password = '';
  }

}
