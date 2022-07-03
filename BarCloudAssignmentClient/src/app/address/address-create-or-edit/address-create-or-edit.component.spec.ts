import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddressCreateOrEditComponent } from './address-create-or-edit.component';

describe('AddressCreateOrEditComponent', () => {
  let component: AddressCreateOrEditComponent;
  let fixture: ComponentFixture<AddressCreateOrEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddressCreateOrEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddressCreateOrEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
