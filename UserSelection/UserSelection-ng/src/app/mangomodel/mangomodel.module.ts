import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

// 引入第三方组件
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

//引入导出组件
import { MgNgUserselectionComponent } from '../components/mg-ng-userselection/mg-ng-userselection.component';

@NgModule({
  declarations: [MgNgUserselectionComponent],
  imports: [
    CommonModule,
    NzModalModule,
    NzButtonModule,
    NoopAnimationsModule
  ],
  exports: [MgNgUserselectionComponent]
})
export class MangomodelModule { }
