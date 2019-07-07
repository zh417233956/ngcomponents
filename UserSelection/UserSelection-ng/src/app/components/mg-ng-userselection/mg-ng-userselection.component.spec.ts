import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MgNgUserselectionComponent } from './mg-ng-userselection.component';

describe('MgNgUserselectionComponent', () => {
  let component: MgNgUserselectionComponent;
  let fixture: ComponentFixture<MgNgUserselectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MgNgUserselectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MgNgUserselectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
