import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TirpComponent } from './tirp.component';

describe('TirpComponent', () => {
  let component: TirpComponent;
  let fixture: ComponentFixture<TirpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TirpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TirpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
