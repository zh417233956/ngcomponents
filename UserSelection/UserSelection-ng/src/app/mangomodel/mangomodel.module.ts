import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
// 引入第三方组件
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzMessageModule } from 'ng-zorro-antd/message';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzTagModule } from 'ng-zorro-antd/tag';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzSpinModule } from 'ng-zorro-antd/spin';
// 引入导出组件
import { MgNgUserselectionComponent } from '../components/mg-ng-userselection/mg-ng-userselection.component';


@NgModule({
  declarations: [
    MgNgUserselectionComponent
  ],
  imports: [
    NzModalModule,
    NzButtonModule,
    BrowserModule,
    NoopAnimationsModule,
    NzTagModule,
    NzInputModule,
    NzMessageModule,
    NzSpinModule,
    HttpClientModule,
    FormsModule
  ],
  exports: [
    MgNgUserselectionComponent
  ]
})
export class MangomodelModule { }
