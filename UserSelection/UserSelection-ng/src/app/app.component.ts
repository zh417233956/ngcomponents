import {Component, OnInit} from '@angular/core';
import {NzMessageService} from 'ng-zorro-antd/message';
import {Data} from './components/model/data';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {
  data = new Data();
  title: string;
  bodyStyle = { 'width.px': 100, 'height.px': 100 };
  constructor(public msg: NzMessageService) { }
  mgOnOk(data): void {
    // tslint:disable-next-line:no-console
    console.info('所选择的数据:' + JSON.stringify(data));
  }
  mgOnCancel(data): void {
    // tslint:disable-next-line:no-console
    console.info(data);
  }
  mgAfterClose(data): void {
    // tslint:disable-next-line:no-console
    console.info(data);
  }
  mgAfterOpen(data): void {
    // tslint:disable-next-line:no-console
    console.info(data);
  }
  ngOnInit(): void {
    this.data.title = '用户选择';
    this.data.a = { n: '1'};
    console.log(this.data);
  }
  test(): void {
    this.msg.error('11111');
  }
}
