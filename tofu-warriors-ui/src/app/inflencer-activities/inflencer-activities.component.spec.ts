import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InflencerActivitiesComponent } from './inflencer-activities.component';

describe('InflencerActivitiesComponent', () => {
  let component: InflencerActivitiesComponent;
  let fixture: ComponentFixture<InflencerActivitiesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InflencerActivitiesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InflencerActivitiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
