import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MoviesComponent } from './movies/movies.component';
import { MovieService } from '../services/movie/movie.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CreateMovieComponent } from './create-movie/create-movie.component';



@NgModule({
  declarations: [MoviesComponent, CreateMovieComponent],
  imports: [
    FormsModule,
    CommonModule,
    HttpClientModule
  ],
  providers: [MovieService],
  exports:[MoviesComponent, CreateMovieComponent]
})
export class MovieModule { }
