import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MoviesComponent } from './movies/movies.component';
import { MovieService } from '../services/movie/movie.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [MoviesComponent],
  imports: [
    CommonModule,
    HttpClientModule
  ],
  providers: [MovieService],
  exports:[MoviesComponent]
})
export class MovieModule { }
