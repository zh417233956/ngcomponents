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
      .tag2{
        margin: 4px 0 0 4px !important;
      }
      .input{
        width: 200px !important;
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
      .div-three{
        width: 99%;
        background: #EAF5FF;
      }
      .div-last{
        width: 99%;
        background: #F1F1F1;
      }
      .chlid-top{
        background: #F1F1F1;
        height: 15%;
      }
      .chlid-top-last{
        background: #ffffff;
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
  // 是否显示加载
  loading: boolean;
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
  // 是否开启传入Id搜员工功能搜索框
  @Input()
  canSelectId = false;
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
  // 所选择的结果
  selectUserList = [];
  // 搜索结果
  userList = [];
  // 历史记录用户信息
  historyUserList = [];
  // 常用用户信息
  changyongUserList = [];
  // 全选状态
  checkInfo = [false, false, false];
  // 公用搜索参数
  param = {
    type: '',
    action: 'user',
    pagename : 'noPageName',
    page : 1,
    size: this.pizeSize,
    ischangyong: 1,
    selectIds: '',
    ispowerorg: this.ispowerorg,
    isShowDeleted: this.isShowDeleted,
    orgId: ''
  };
  // 弹窗开启之后回调事件
  afterOpen(): void {
    this.mgAfterOpen.emit('弹窗打开了');
    // TODO 不知道可不可以调用初始化方法 现在调用为了打开窗口清空之前所选
    this.ngOnInit();
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
    this.mgOnOk.emit(this.selectUserList);
  }
  // 取消提交
  handleCancel(): void {
    this.isVisible = false;
    this.mgOnCancel.emit('取消选择用户');
  }
  // 查询种类切换
  checkChange(type: string): void {
    if (type === 'history') {
      this.showHistory = true;
      this.showSearch = false;
    } else {
      this.showHistory = false;
      this.showSearch = true;
    }
    this.bianData(type);
  }
  // 点击用户
  checkUser(user, e: boolean): void {
    user.checked = e;
    this.selectUser();
    if (!this.isduoxuan) {
       this.handleOk();
    }
  }
  // 管理历史记录
  refHistory(): void {
    this.msg.warning(`暂未实现`);
  }
  // 关掉tags
  handleClose(removedTag): void {
    this.selectUserList.find( e =>  e.UserId === removedTag.UserId).checked = false;
  }
  // 全选
  checakAll(type: number): void {
    this.checkInfo[type] = !this.checkInfo[type];
    if (type === 0) {
      this.historyUserList.forEach( e =>  e.checked = this.checkInfo[type]);
    } else if (type === 1) {
      this.changyongUserList.forEach( e =>  e.checked = this.checkInfo[type]);
    } else if (type === 2) {
      this.userList.forEach( e =>  e.checked = this.checkInfo[type]);
    }
    this.selectUser();
  }
  // 选择结果重组
  selectUser(): void {
     this.selectUserList = this.userList.filter( e => e.checked === true);
  }
  // 回车事件绑定
  enter(v: string, $event): void {
    if ($event.which === 13) {
      this.bianData(v);
    }
  }
  // 获取数据
  bianData(type: string): void {
    this.param.type = type;
    this.loading = true;
    this.httpService.get('/webcomponent/index', this.param, false).subscribe(res => {
      this.loading = false;
      if (res.flag === 1) {
          if (res.data.data.length > 0) {
            this.userList = [];
            this.changyongUserList = [];
            this.historyUserList = [];
           // this.selectUserList = [];
            const dataList = res.data.data;
            this.userList = dataList;
            if (type === 'history') {
              const changyong = res.data.changyong;
              const history = res.data.history;
              changyong.forEach(e => {
                const changyongUser = dataList.find( a => a.UserId === e );
                this.changyongUserList.push(changyongUser);
              });
              this.changyongUserList = this.changyongUserList.sort( (a, b) => {
                return a.UserId - b.UserId;
              });
              history.forEach(e => {
                const historyUser = dataList.find( a => a.UserId === e );
                this.historyUserList.push(historyUser);
              });
              this.historyUserList = this.historyUserList.sort(  (a, b) => {
                return a.UserId - b.UserId;
              });
            }
        } else {
            this.msg.error(res.data.msg);
        }
      } else {
        this.msg.error('程序异常');
      }
    });
  }
}
