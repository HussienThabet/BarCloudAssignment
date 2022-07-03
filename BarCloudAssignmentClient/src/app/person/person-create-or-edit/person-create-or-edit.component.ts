import { Component, EventEmitter, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { PersonDto, PersonServiceProxy } from 'src/shared/service-proxies/service-proxies';

@Component({
  selector: 'app-person-create-or-edit',
  templateUrl: './person-create-or-edit.component.html',
  styleUrls: ['./person-create-or-edit.component.css']
})
export class PersonCreateOrEditComponent implements OnInit {
  public newEmitter: EventEmitter<any> = new EventEmitter();
  controlForm: FormGroup = this.formBuilder.group({
    id: [null],
    name: ["", Validators.required]
  });;
  saving = false;
  isCreate = true;
  modeltitle = "Create"

  person: PersonDto | undefined;

  constructor(private _service: PersonServiceProxy, public bsModalRef: BsModalRef,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    if (this.person) {
      this.controlForm.patchValue(this.person);
    }
  }

  get controlDtoform(): any {
    return this.controlForm.controls;
  }

  save() {
    console.log(this.person)
    this.saving = true;
    if (!this.controlForm.valid) {
      return;
    }
    if (!this.isCreate) {
      debugger
      let _person: PersonDto = this.controlForm.value;
      this._service.createPerson(_person).subscribe(res => {
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
      let _person: PersonDto = this.controlForm.value;
      this._service.editPerson(_person).subscribe(res => {
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
