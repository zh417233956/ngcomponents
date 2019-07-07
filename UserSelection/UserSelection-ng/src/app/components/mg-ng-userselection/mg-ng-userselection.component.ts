import {Component, Input, Output, OnInit, EventEmitter, TemplateRef, Type} from '@angular/core';


@Component({
  selector: 'mg-ng-userselection',
  templateUrl: './mg-ng-userselection.component.html',
  styleUrls: ['./mg-ng-userselection.component.less']
})
/**
 * 员工选择组件
 */
export class MgNgUserselectionComponent<T = any> implements OnInit {
  constructor() {
    this.title = '用户选择';
    this.cancleText = '取消';
    this.okText = '确认';
    this.bodyStyle = {};
    this.closable = true;
    this.okLoading = false;
    this.cancelLoding = false;
    this.okDisabled = false;
    this.cancelDisabled = false;
    this.keyboard = true;
    this.mask = true;
    this.maskClosable = false;
    this.maskStyle = null;
    this.okType = 'primary';
    this.floatStyle = null;
    this.width = 520;
    this.className = '';
    this.wrapClassName = '';
    this.zIndex = 1000;
    this.isduoxuan = false;
    this.ispinyin = true;
    this.text = '输名称、拼音或员工编号,敲回车搜索';
    this.pizeSize = 20;
    this.existResults = '';
    this.ispowerorg = true;
    this.isShowDeleted = true;
    this.setIsJJr = [];
    this.setMustOrgId = [];
    this.setOrgId = null;
    this.canSelectId = true;
    this.maxSelectNumber = 5;
  }

  // 是否显示弹窗
  isVisible = false;
  // 弹窗标题 可以为空
  @Input()
  title: string;
  // 取消弹窗按钮文字
  @Input()
  cancleText: string;
  // 确认弹窗按钮文字
  @Input()
  okText: string;
  // body自定义样式
  @Input()
  bodyStyle: any;
  // 是否显示右上角关闭按钮
  @Input()
  closable: boolean;
  // 确认按钮是否显示loading
  @Input()
  okLoading: boolean;
  // 取消按钮是否显示loading
  @Input()
  cancelLoding: boolean;
  // 确认按钮是否禁用
  @Input()
  okDisabled: boolean;
  // 取消按钮是否禁用
  @Input()
  cancelDisabled: boolean;
  // 键盘esc关闭弹窗
  @Input()
  keyboard: boolean;
  // 是否开启遮罩层
  @Input()
  mask: boolean;
  // 点击遮罩层是否关闭弹窗
  @Input()
  maskClosable: boolean;
  // 遮罩层自定义样式
  @Input()
  maskStyle: T;
  // 确认按钮类型 'primary' | 'dashed' | 'danger' | 'default' | 'link'
  @Input()
  okType: string;
  // 悬浮样式 { top: '20px' }
  @Input()
  floatStyle: T;
  // 对话框宽度 使用数字时，默认单位为px
  @Input()
  width: string | number;
  // 对话框class自定义名字
  @Input()
  className: string;
  // 对话框外层容器class自定义名字
  @Input()
  wrapClassName: string;
  // zIndex
  zIndex: number;
  // 弹窗内容
  content: string | TemplateRef<{}> | Component | Type<T>;
  // 是否多选 默认 false（功能类）
  @Input()
  isduoxuan: boolean;
  // 是否开启拼音  默认true    （功能类）
  @Input()
  ispinyin: boolean;
  // 搜索框默认文字 可以为空（功能类）
  @Input()
  text: string;
  // 默认每页显示 默认20（功能类）
  @Input()
  pizeSize: number;
  // 用来接收已存在信息并显示到结果栏  （功能类）
  @Input()
  existResults: string;
  // 是否只能选择可视组织（限制类）
  @Input()
  ispowerorg: boolean;
  // 是否显示离职员工 （限制类）
  @Input()
  isShowDeleted: boolean;
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
  canSelectId: boolean;
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

  // 弹窗开启之后回调事件
  afterOpen(): void {
    this.mgAfterOpen.emit('弹窗打开了');
  }
  // 弹窗关闭之后回调事件
  afterClose(): void {
    this.mgAfterClose.emit('弹窗关闭了');
  }
  ngOnInit() {
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
}
