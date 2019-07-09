import { Component, Input, Output, OnInit, EventEmitter } from '@angular/core';
import { HttpService } from '../mg-ng-service/http-service.service';
import { NzMessageService } from 'ng-zorro-antd/message';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'mg-ng-userselection',
  templateUrl: './mg-ng-userselection.component.html',
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
      .div{
        width: 49%;
        float: left;
        background: #CEECEB;
        height: 200px;
        margin: 4px;
        overflow-y: auto;
      }
      .last{
        width: 99%;
      }
      .div .chlid-top{
        background: #F1F1F1;
        height: 15%;
      }
    `
  ]
})
/**
 * 员工选择组件
 */
export class MgNgUserselectionComponent<T = any> implements OnInit {
  constructor(private httpService: HttpService , public msg: NzMessageService) {
  }
  // 是否显示弹窗
  isVisible = false;
  // 是否显示历史记录
  showHistory: boolean;
  // 是否显示搜索结果
  showSearch: boolean;
  // 是否显示搜索结果 多选/单选
  showResult: boolean;
  // 清求数据url
  @Input()
  url = '';
  // 弹窗标题 可以为空
  @Input()
  title = '';
  // 取消弹窗按钮文字
  @Input()
  cancleText = '取消';
  // 确认弹窗按钮文字
  @Input()
  okText = '确认';
  // body自定义样式
  @Input()
  bodyStyle = { 'height.px': 500 };
  // 是否显示右上角关闭按钮
  @Input()
  closable = true;
  // 确认按钮是否显示loading
  @Input()
  okLoading = false;
  // 取消按钮是否显示loading
  @Input()
  cancelLoding = false;
  // 确认按钮是否禁用
  @Input()
  okDisabled = false;
  // 取消按钮是否禁用
  @Input()
  cancelDisabled = false;
  // 键盘esc关闭弹窗
  @Input()
  keyboard = true;
  // 是否开启遮罩层
  @Input()
  mask = true;
  // 点击遮罩层是否关闭弹窗
  @Input()
  maskClosable = true;
  // 遮罩层自定义样式
  @Input()
  maskStyle: object;
  // 确认按钮类型 'primary' | 'dashed' | 'danger' | 'default' | 'link'
  @Input()
  okType = 'primary';
  // 悬浮样式 { top: '20px' }
  @Input()
  floatStyle: object;
  // 对话框宽度 使用数字时，默认单位为px
  @Input()
  width = '1000';
  // 对话框class自定义名字
  @Input()
  className: string;
  // 对话框外层容器class自定义名字
  @Input()
  wrapClassName: string;
  // zIndex
  zIndex = 400;
  // 弹窗内容
  // content: string | TemplateRef<{}> | Component | Type<T>;
  // 是否多选 默认 false（功能类）
  @Input()
  isduoxuan = true;
  // 是否开启拼音  默认true    （功能类）
  @Input()
  ispinyin = true;
  // 搜索框默认文字 可以为空（功能类）
  @Input()
  text = '输名称、拼音或员工编号,敲回车搜索';
  // 默认每页显示 默认20（功能类）
  @Input()
  pizeSize = 20;
  // 用来接收已存在信息并显示到结果栏  （功能类）
  @Input()
  existResults: string;
  // 是否只能选择可视组织（限制类）
  @Input()
  ispowerorg = true;
  // 是否显示离职员工 （限制类）
  @Input()
  isShowDeleted = true;
  // 是否限制经纪人等级 （限制类）
  @Input()
  setIsJJr: number[];
  // 打开时显示的组织员工，可以为空，默认为登录人所在组织（区以上组织无效）（限制类）
  @Input()
  setMustOrgId: number[];
  // 打开时显示的组织员工，可以为空，默认为登录人所在组织（区以上组织无效）（快捷操作类）
  @Input()
  setOrgId: number;
  // 是否根据员工或组织id搜索 默认true
  @Input()
  canSelectId = true;
  // 最大选择数 默认5
  @Input()
  maxSelectNumber: number;
  // 确认事件输出
  @Output()
  mgOnOk = new EventEmitter();
  // 取消事件输出
  @Output()
  mgOnCancel = new EventEmitter();
  // 弹窗开启之后回调事件输出
  @Output()
  mgAfterOpen = new EventEmitter();
  // 弹窗关闭之后回调事件输出
  @Output()
  mgAfterClose = new EventEmitter();

  tags = ['选择全部', 'Tag 2', 'Tag 3'];
  historyUserList = [];
  changyongUserList = [];
  // 弹窗开启之后回调事件
  afterOpen(): void {
    this.mgAfterOpen.emit('弹窗打开了');
  }
  // 弹窗关闭之后回调事件
  afterClose(): void {
    this.mgAfterClose.emit('弹窗关闭了');
  }
  ngOnInit() {
    console.log('初始化');
    this.checkChange('history');
    this.isduoxuan === true ?  this.showResult = true : this.showResult = false;
  }
  // 显示弹窗
  showModal(): void {
    this.isVisible = true;
  }
  // 确定提交
  handleOk(): void {
    this.isVisible = false;
    this.mgOnOk.emit(new Array({id: 1, username : '邵文', orgname : '研发部'}));
  }
  // 取消提交
  handleCancel(): void {
    this.isVisible = false;
    this.mgOnCancel.emit('取消选择用户');
  }
  // 查询种类切换
  checkChange(type: string): void {
    if ( type === 'history') {
      this.showHistory = true;
      this.showSearch = false;
    } else {
      this.showHistory = false;
      this.showSearch = true;
    }
    this.bianData(type);
  }
  // 管理历史记录
  refHistory(): void {
    this.msg.warning(`暂未实现`);
  }
  // 关掉tags
  handleClose(removedTag: {}): void {
    this.tags = this.tags.filter(tag => tag !== removedTag);
  }
  sliceTagName(tag: string): string {
    const isLongTag = tag.length > 20;
    return isLongTag ? `${tag.slice(0, 20)}...` : tag;
  }
  // 获取数据
  bianData(type: string): void {
    const param = {
      type,
      action: 'user',
      pagename : 'noPageName',
      page : 1,
      size: this.pizeSize,
      ischangyong: 1,
      selectIds: '',
      ispowerorg: this.ispowerorg,
      isShowDeleted: this.isShowDeleted
    };
    this.httpService.get('/webcomponent/index', param, false).subscribe(res => {
      if (res.flag === 1) {
        if ( type === 'history') {
          if (res.data.data.length > 0) {
            const dataList = res.data.data;
            const changyong = res.data.changyong;
            const history = res.data.history;
            changyong.forEach(e => {
              this.changyongUserList.push(dataList.find( a => a.UserId === e ));
            });
            history.forEach(e => {
              this.historyUserList.push(dataList.find( a => a.UserId === e ));
            });
          } else {
            this.msg.error(res.data.msg);
          }
        }
      } else {
        this.msg.error('程序异常');
      }
    });
  }
}
