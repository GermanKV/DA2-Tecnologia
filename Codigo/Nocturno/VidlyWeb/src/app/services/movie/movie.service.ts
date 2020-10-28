import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { MovieBasicInfo } from 'src/app/models/movie-basic-info';

@Injectable()
export class MovieService {
  private uri = environment.URI_BASE+"movies";

  constructor(private http: HttpClient) { }

  getAll():Observable<MovieBasicInfo[]> {
    return this.http.get<MovieBasicInfo[]>(this.uri).pipe(catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse){
    let message: string;

    if(error.error instanceof ErrorEvent){
      //Error de conexion del lado del cliente

      message = "Error: do it again";
    }else{
      //El backend respondio con status code de error
      //el body de la response debe de dar mas informacion

      if(error.status == 0){
        message = "The server is shutdown";
      }else{
        //Depende de como me mande la api la response del error es lo que tengo que agarrar
        message = error.error.message;
      }
    }

    //Retornamos un Observable de tipo error para el que usa el servicio
    return throwError(message);
  }
}
