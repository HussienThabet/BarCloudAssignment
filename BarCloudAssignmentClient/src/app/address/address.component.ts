import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AddressDto, AddressServiceProxy } from 'src/shared/service-proxies/service-proxies';
import { AddressCreateOrEditComponent } from './address-create-or-edit/address-create-or-edit.component';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css']
})
export class AddressComponent implements OnInit {

  addresses : AddressDto []=[];
  constructor(private _service : AddressServiceProxy,
    private _modalService: BsModalService) { 

  }
  ngOnInit(): void {
  }
getAddresses(){
  this._service.getAddresses().subscribe(res => {
    this.addresses = res;
    console.log(res);
  }, err => {
    console.log(err);

  })
}
createOrEdit(address : AddressDto | undefined){
  let viewcreate: BsModalRef;
  viewcreate = this._modalService.show(
    AddressCreateOrEditComponent,
    {
      class: 'modal-lg',
      initialState: {
        address: address,
        isCreate: address ? true:false
      },
    }
  );
  //viewcreate.content.newEmitter.next(res =>{})

}
Delete(address : AddressDto | undefined){
  this._service.deleteAddress(address).subscribe(res=>{
    console.log(res)
  },err=>{
    console.log(err)
  })
}
}
