import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { IndexHomeComponent } from './index-home/index-home.component';
import { LayoutModule } from '../layout/layout.module';
import { MovieModule } from '../movie/movie.module';


@NgModule({
  declarations: [IndexHomeComponent],
  imports: [
    CommonModule,
    HomeRoutingModule,
    MovieModule,
    LayoutModule
  ],
  bootstrap:[]
})
export class HomeModule { }
