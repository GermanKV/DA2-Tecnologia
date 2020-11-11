import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/services/movie/movie.service';
import { MovieBasicInfo } from 'src/app/models/movie-basic-info';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {
  movies: MovieBasicInfo[] = [{id: 1, name: "Enola Holme", rank: 1, image:"hola"}as MovieBasicInfo, {id: 1, name: "Transformers", rank: 1, image:"hola"}as MovieBasicInfo];
  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    //this.movieService.getAll().subscribe(moviesResponse => this.finishGetAll(moviesResponse), (error: string) => this.showError(error));
  }

  private finishGetAll(moviesResponse: MovieBasicInfo[]){
    this.movies = moviesResponse;
    console.log(JSON.stringify(this.movies));
  }

  private showError(message: string){
    console.log(message);
  }

  selectedMovie(movie: MovieBasicInfo){
    alert(JSON.stringify(movie));
  }
}
