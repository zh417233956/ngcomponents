import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
// 引入组件
import { MangomodelModule } from './mangomodel/mangomodel.module';
import {NzTagModule} from 'ng-zorro-antd';
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    MangomodelModule,
  ],
  providers: [],
  exports: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
