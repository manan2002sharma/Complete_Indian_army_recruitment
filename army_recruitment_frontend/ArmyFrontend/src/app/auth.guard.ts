import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  const _router = inject(Router);
  let isLoggedIn = localStorage.getItem("isLoggedIn");
  console.log(isLoggedIn);
  if(isLoggedIn!="true"){
    alert("Please login first.");
    _router.navigate(['/test']);
    return false;
  }

  return true;
};
