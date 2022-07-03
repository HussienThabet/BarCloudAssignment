import { Component, EventEmitter, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AddressDto, AddressServiceProxy, PersonDto, PersonServiceProxy } from 'src/shared/service-proxies/service-proxies';

@Component({
  selector: 'app-address-create-or-edit',
  templateUrl: './address-create-or-edit.component.html',
  styleUrls: ['./address-create-or-edit.component.css']
})
export class AddressCreateOrEditComponent implements OnInit {


  public newEmitter: EventEmitter<any> = new EventEmitter();
  controlForm: FormGroup = this.formBuilder.group({
    id: [null],
    buildingNumber: ["", Validators.required],
    description: ["", Validators.required],
    landmark: ["", Validators.required],
    personId: [""],
    person: ["", Validators.required],
  });
  saving = false;
  isCreate = true;
  modeltitle = "Create"
  address : AddressDto | undefined;
  people : PersonDto []=[];
  selectedPerson: PersonDto | undefined;

  constructor(
    private _service: AddressServiceProxy,
    private _personService: PersonServiceProxy, 
    public bsModalRef: BsModalRef,
    private formBuilder: FormBuilder) { }

 getPeople(){
    this._personService.getPeople().subscribe(res => {
      this.people = res;
      console.log(res);
    }, err => {
      console.log(err);

    })
  }

  
  ngOnInit(): void {
    this.getPeople()
    if (this.address) {
      this.controlForm.patchValue(this.address);
    }
  }

  get controlDtoform(): any {
    return this.controlForm.controls;
  }

  save() {
    console.log(this.address)
    this.saving = true;
    if (!this.controlForm.valid) {
      return;
    }
    if (!this.isCreate) {
      debugger
      let _address: AddressDto = this.controlForm.value;
      _address.personId = this.selectedPerson?.id;
      this._service.createAddress(_address).subscribe(res => {
        console.log(res);
        this.closeModal();
        this.newEmitter.emit()

      }, err => {
        console.log(err);
        this.closeModal();
      }
      );
    }
    else{
      debugger
      let _address: AddressDto = this.controlForm.value;
      _address.personId = this.selectedPerson?.id;
      this._service.editAddress(_address).subscribe(res => {
        console.log(res);
        this.closeModal();
        this.newEmitter.emit()

      }, err => {
        console.log(err);
        this.closeModal();
      }
      );
    }
  }
  closeModal() {
    this.bsModalRef.hide();
  }


  
}
