import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AuthGuard } from './guards/auth.guard';
import { IndexHomeComponent } from './home/index-home/index-home.component';
import { LoginComponent } from './login/login.component';
import { MoviesComponent } from './movie/movies/movies.component';


const routes: Routes = [
  {
    path:'',
    redirectTo:'home',
    pathMatch:'full'
  },
  {
    path:'home',
    canActivate: [AuthGuard],
    loadChildren: () => import('./home/home.module').then(mod => mod.HomeModule)
  },
  {
    path:'login',
    component: LoginComponent
  },
  {
    path:'**',
    redirectTo:'home'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
