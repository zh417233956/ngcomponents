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
import { DelonMockModule } from '@delon/mock';
// 引入导出组件
import { MgNgUserselectionComponent } from '../components/mg-ng-userselection/mg-ng-userselection.component';
// mock模拟请求配置
import * as MOCKDATA from '../../../_mock';
// 只对开发环境有效
import { environment } from '../../environments/environment';
const MOCKMODULE = !environment.production ? [ DelonMockModule.forRoot({ data: MOCKDATA }) ] : [];

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
    FormsModule,
    DelonMockModule,
    ...MOCKMODULE
  ],
  exports: [
    MgNgUserselectionComponent
  ]
})
export class MangomodelModule { }
