import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import {  PersonDto, PersonServiceProxy } from 'src/shared/service-proxies/service-proxies';
import { PersonCreateOrEditComponent } from './person-create-or-edit/person-create-or-edit.component';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  people : PersonDto []=[];
  constructor(private _service : PersonServiceProxy,
    private _modalService: BsModalService) { 

  }

  ngOnInit(): void {
  this.getPeople();
  }
  getPeople(){
    console.log('asd');
    this._service.getPeople().subscribe(res => {
      this.people = res;
      console.log(res);
    }, err => {
      console.log(err);

    })
  }
  createOrEdit(person : PersonDto | undefined){
    let viewcreate: BsModalRef;
    viewcreate = this._modalService.show(
      PersonCreateOrEditComponent,
      {
        class: 'modal-lg',
        initialState: {
          person: person,
          isCreate: person ? true:false
        },
      }
    );
    //viewcreate.content.newEmitter.next(res =>{})

  }
  Delete(person : PersonDto | undefined){
    this._service.deletePerson(person).subscribe(res=>{
      console.log(res)
    },err=>{
      console.log(err)
    })
  }
}
