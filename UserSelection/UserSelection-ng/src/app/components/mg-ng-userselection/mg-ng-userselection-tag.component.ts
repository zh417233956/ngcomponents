import { Component, OnInit} from '@angular/core';
import {MgNgUserselectionComponent} from './mg-ng-userselection.component';

/**
 *  内容模板
 */
@Component({
  // tslint:disable-next-line:component-selector
  selector: 'userselection-tag',
  template: `
    <section>
      <span class="span">快捷搜索:</span>
      <nz-tag nzMode="default" [nzChecked]="true" class="tag" (click)="checkChange('mydian')">本店</nz-tag>
      <nz-tag nzMode="default" [nzChecked]="true" class="tag" (click)="checkChange('myarea')">本区</nz-tag>
      <nz-tag nzMode="default" [nzChecked]="true" class="tag" (click)="checkChange('myareachild')">本区下属</nz-tag>
      <nz-tag nzMode="default" [nzChecked]="true" class="tag" (click)="checkChange('history')">最近</nz-tag>
      <input nz-input nzSize="default" class="input" placeholder="{{text}}"/>
      <input nz-input nzSize="default" class="input" placeholder="输入组织名称或组织ID"/>
    </section>
    <section *ngIf="showHistory">
      <div style="width: 45%;float: left;background: #CEECEB;height: 200px;margin: 5px;">
        <div style="background: #F1F1F1;height: 30px;">
          <span class="span">历史记录:</span>
          <nz-tag nzMode="default" [nzChecked]="true" [nzColor]="'#75B4D6'" class="tag1" >管理历史记录</nz-tag>
        </div>
      </div>
      <div style="width: 45%;float: left;background: #CEECEB;height: 200px;margin: 5px;">
        <div style="background: #F1F1F1;height: 30px;">
        <span class="span">常用结果:</span>
        </div>
      </div>
    </section>
    <section *ngIf="showSearch">
      <div style="width: 91%;float: left;background: #CEECEB;height: 200px;margin: 5px;">
        <div style="background: #F1F1F1;height: 30px;">
          <span class="span">搜索结果:</span>
        </div>
      </div>
    </section>
    <section *ngIf="showResult">
      <div style="width: 91%;float: left;background: #CEECEB;height: 200px;margin: 5px;">
        <div style="background: #F1F1F1;height: 30px;">
          <span class="span">已选择结果:</span>
        </div>
      </div>
    </section>
  `,
  styleUrls: ['./mg-ng-userselection.component.less'],
  styles: [
    `
      .span{
        padding: 15px;
        font-size: 15px;
        display: inline-block;
        line-height: 2px;
      }
      .tag{
        height: 25px !important;
        border-radius: 15px !important;
        text-align: -webkit-center;
        font-size: 15px;
      }
      .tag1{
        height: 25px !important;
        border-radius: 5px !important;
        text-align: -webkit-center;
        font-size: 12px!important;
        float: right;
        margin-top: 3px!important;
      }
      .input{
        width: 250px !important;
        margin: 0 8px 8px 0!important;
        border-radius: 15px !important;
        font-size: 15px;
      }
    `
  ]
})
export class MgNgUserselectionTagComponent implements OnInit {
  // 是否显示历史记录
  showHistory: boolean;
  // 是否显示搜索结果
  showSearch: boolean;
  // 是否显示搜索结果 多选/单选
  showResult: boolean;
  ngOnInit() {
    this.checkChange('history');
    // this.isduoxuan === true ?  this.showResult = true : this.showResult = false;
    // console.log('第二个模板初始化' +  super.isduoxuan  + '' + this.showResult);
  }
  checkChange(type: string): void {
     if ( type === 'history') {
       this.showHistory = true;
       this.showSearch = false;
     } else {
       this.showHistory = false;
       this.showSearch = true;
     }
  }
}
