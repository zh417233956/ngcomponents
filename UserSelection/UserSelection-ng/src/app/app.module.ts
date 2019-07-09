import { AppComponent } from './app.component';
import {NgModule} from '@angular/core';
import {MangomodelModule} from './mangomodel/mangomodel.module';
// 引入组件
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    MangomodelModule
  ],
  providers: [],
  exports: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
