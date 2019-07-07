import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

 // 引入组件
 import {MangomodelModule} from 'mg-ng-userselection'

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MangomodelModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
