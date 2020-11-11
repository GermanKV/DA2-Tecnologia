import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateMovieComponent } from '../movie/create-movie/create-movie.component';
import { MoviesComponent } from '../movie/movies/movies.component';
import { IndexHomeComponent } from './index-home/index-home.component';


const routes: Routes = [
  {
    path:'',
    component: IndexHomeComponent,
    children:[
      {
        path:'',
        component: MoviesComponent
      },
      {
        path:'create',
        component: CreateMovieComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
