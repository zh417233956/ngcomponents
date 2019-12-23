import { Component, Input, Output, OnInit, EventEmitter, TemplateRef, Type } from '@angular/core';
import { HttpService } from '../mg-ng-service/http-service.service';
import { NzMessageService } from 'ng-zorro-antd/message';
import {User} from '../model/user';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'mg-ng-userselection',
  templateUrl: './mg-ng-userselection.component.html',
  styleUrls: ['./mg-ng-userselection.component.less']
})
/**
 * 员工选择组件
 */
export class MgNgUserselectionComponent<T = any> implements OnInit {
  constructor(private http: HttpService, public msg: NzMessageService) {
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
  // 是否显示上次所选的值
  showPrev: boolean;
  // 请求数据url
  @Input()
  url = '';
  // 请求数据类型
  type: string;
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
  content: string | TemplateRef<{}> | Component | Type<T>;
  // 是否多选 默认 false（功能类）
  @Input()
  isduoxuan = true;
  // 是否开启拼音  默认true    （功能类）
  @Input()
  ispinyin = true;
  // 搜索框默认文字 可以为空（功能类）
  @Input()
  text = '输名称、拼音或员工编号,敲回车搜索';
  // 当前页数
  pageIndex = 1;
  // 总条数
  total: number;
  // 是否开启分页
  onPaging = false;
  // 默认每页显示 默认20（功能类）
  @Input()
  pizeSize = 20;
  // 用来接收已存在信息并显示到结果栏  （功能类）
  @Input()
  existResults = '';
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
  maxSelectNumber = 5;
  // 员工id逗号分隔
  selectIds = '';
  // 组织id
  orgId = [];
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
  selectUserList: User[] = [];
  // 搜索结果
  userList: User[] = [];
  // 历史记录用户信息
  historyUserList: User[] = [];
  // 常用用户信息
  changyongUserList: User[] = [];
  // 全选状态
  checkInfo = {
    0: {
      checked: false,
      title: '选择全部',
      userList: []
    },
    1: {
      checked: false,
      title: '选择全部',
      userList: []
    },
    2: {
      checked: false,
      title: '选择全部',
      userList: []
    }
  };
  // 弹窗开启之后回调事件
  afterOpen(): void {
    this.mgAfterOpen.emit('弹窗打开了');
    // 打开窗口清空之前所选
    // this.ngOnInit();
  }
  // 弹窗关闭之后回调事件
  afterClose(): void {
    this.mgAfterClose.emit('弹窗关闭了');
  }
  ngOnInit() {
    console.log('初始化');
    this.isduoxuan === true ? this.showResult = true : this.showResult = false;
    this.existResults === '' ? this.showPrev = false : this.showPrev = true;
    this.checkChange('history');
    this.bindExistResults();
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
    this.type = type;
    this.bianData();
  }
  // 点击用户
  checkUser(user: User, e: boolean): void {
    if (!this.isduoxuan) {
      this.handleOk();
    } else {
      user.checked = e;
      if (e) {
        this.pushSelectUser(user);
      } else {
        this.deleteSelectUser(user);
      }
    }
  }
  // 添加所选用户
  pushSelectUser(user: User): void {
    this.checkMaxSelect();
    this.selectUserList.push(user);
  }
  // 检查是否超过最大选择数(多选时触发)
  checkMaxSelect(): void {
    if (this.maxSelectNumber === this.selectUserList.length) {
      this.selectUserList[this.selectUserList.length - 1].checked = false;
      this.selectUserList = this.selectUserList.slice(0, this.maxSelectNumber - 1);
    }
  }
  // 管理历史记录
  refHistory(): void {
    this.msg.warning(`暂未实现`);
  }
  // 关掉tags
  handleClose(removedTag): void {
    this.deleteSelectUser(removedTag);
  }
  // 删除所选用户
  deleteSelectUser(selectUser: User): void {
    this.selectUserList = this.selectUserList.filter(e => e !== selectUser);
    if (this.selectUserList.length === 0) { this.showPrev = false; }
    const user = this.userList.find(e => e.UserId === selectUser.UserId);
    if (user) {
      user.checked = false;
    }
  }
  // 全选
  checkAll(type: number): void {
    // 全部取消
    if (type === 3) {
      this.userList.forEach(e => e.checked = false);
      this.selectUserList = [];
      this.showPrev = false;
    } else {
      // 选择状态取反
      this.checkInfo[type].checked = !this.checkInfo[type].checked;
      // 替换标题
      this.checkInfo[type].title = this.checkInfo[type].title === '选择全部' ? '全部取消' : '选择全部';
      // 选择状态为true
      if (this.checkInfo[type].checked) {
        // 未在选择结果中的
        let unSelectUserList = this.userList.filter(a => !this.selectUserList.some(e => e.UserId === a.UserId));
        // 限制选择个数
        if (this.selectUserList.length === this.maxSelectNumber) {
          this.selectUserList.forEach(user => user.checked = false);
          this.selectUserList = [];
          unSelectUserList = unSelectUserList.splice(0, this.maxSelectNumber);
        } else {
          unSelectUserList = unSelectUserList.splice(0, this.maxSelectNumber - this.selectUserList.length);
        }
        if (unSelectUserList.length > 0) {
          unSelectUserList.forEach(e => {
            e.checked = this.checkInfo[type].checked;
            this.pushSelectUser(e);
          });
        }
      } else {
        this.checkInfo[type].userList.forEach(e => {
          this.deleteSelectUser(e);
        });
      }
    }
  }
  // 回车事件绑定
  enter(v: string, $event): void {
    if ($event.which === 13) {
      this.type = v;
      this.bianData();
      this.showHistory = false;
      this.showSearch = true;
    }
  }
  // 翻页事件
  pageChange(pageIndex: number): void {
    this.pageIndex = pageIndex;
    this.bianData();
  }
  // 获取数据
  bianData(): void {
    // 公用搜索参数
    const param = {
      type: this.type,
      action: 'user',
      pagename: 'noPageName',
      page: this.pageIndex,
      size: this.pizeSize,
      ischangyong: 1,
      selectIds: this.selectIds,
      ispowerorg: this.ispowerorg,
      isShowDeleted: this.isShowDeleted,
      orgId: this.orgId
    };
    this.loading = true;
    this.http.get('/a10_common/a1020_selection/Actions/UserAction.ashx', param, false).subscribe(res => {
      this.loading = false;
      if (res.flag === 1) {
        if (res.data.data.length > 0) {
          this.userList = res.data.data;
          if (this.selectUserList.length > 0) {
            this.selectUserList.forEach(e => {
              const user = this.userList.find(f => f.UserId === e.UserId);
              if (user) {
                user.checked = true;
              }
            });
          }
          if (this.type === 'history') {
            this.changyongUserList = [];
            this.historyUserList = [];
            const changyong = res.data.changyong;
            const history = res.data.history;
            changyong.forEach(e => {
              const changyongUser = this.userList.find(a => a.UserId === e);
              if (changyongUser) {
                this.changyongUserList.push(changyongUser);
              }
            });
            history.forEach(e => {
              const historyUser = this.userList.find(a => a.UserId === e);
              if (historyUser) {
                this.historyUserList.push(historyUser);
              }
            });
            this.checkInfo['0'].userList = this.historyUserList;
            this.checkInfo['1'].userList = this.changyongUserList;
          } else {
            if (this.userList.length > this.pizeSize) {
              this.onPaging = true;
              this.total = res.data.count;
            } else {
              this.onPaging = false;
            }
          }
          this.checkInfo['2'].userList = this.userList;
        } else {
          this.userList = [];
          this.changyongUserList = [];
          this.historyUserList = [];
          if (res.data.msg.length > 0) {
            this.msg.error(res.data.msg);
          }
        }
      } else {
        this.msg.error(res.data.msg);
      }
    });
  }
  // 获取已存在信息
  bindExistResults(): void {
    // 公用搜索参数
    const param = {
      action: 'getids',
      ids: this.existResults
    };
    this.loading = true;
    this.http.get('/a10_common/a1020_selection/Actions/UserAction.ashx', param, false).subscribe(res => {
      this.loading = false;
      if (res.flag === 1) {
        if (res.data.data.length > 0) {
          const existUserList: User[] = res.data.data;
          existUserList.forEach(a => {
            const user = this.userList.find(e => e.UserId === a.UserId);
            if (user) {
              user.checked = true;
              this.selectUserList.push(user);
            } else {
              a.checked = true;
              this.selectUserList.push(a);
            }
          });
        } else {
          if (res.data.msg.length > 0) {
            this.msg.error(res.data.msg);
          }
        }
      } else {
        this.msg.error(res.data.msg);
      }
    });
  }
}
