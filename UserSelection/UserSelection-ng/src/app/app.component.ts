import { Component,OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit {
  title = '用户选择';
  bodyStyle = { 'width.px': 100, 'height.px': 100 };
  constructor() { }
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
  }
}
