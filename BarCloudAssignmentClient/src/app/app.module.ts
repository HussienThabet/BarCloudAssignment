import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import {TableModule} from 'primeng/table';
import {SidebarModule} from 'primeng/sidebar';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddressServiceProxy, PersonServiceProxy } from 'src/shared/service-proxies/service-proxies';
import { PersonComponent } from './person/person.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { ButtonModule } from 'primeng/button';
import { PersonCreateOrEditComponent } from './person/person-create-or-edit/person-create-or-edit.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { HttpClientJsonpModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { AddressComponent } from './address/address.component';
import { AddressCreateOrEditComponent } from './address/address-create-or-edit/address-create-or-edit.component';
import {DropdownModule} from 'primeng/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
@NgModule({
  declarations: [
    AppComponent,
    PersonComponent,
    SidebarComponent,
    PersonCreateOrEditComponent,
    NavbarComponent,
    AddressComponent,
    AddressCreateOrEditComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule,
    TableModule,
    SidebarModule,
    ButtonModule,
    ModalModule.forRoot(),
    HttpClientJsonpModule,
    DropdownModule
  ],
  exports :[
    TableModule,
    SidebarModule,
    ButtonModule,
    HttpClientJsonpModule,
    BrowserAnimationsModule,
    DropdownModule
  ],
  providers: [AddressServiceProxy,
    PersonServiceProxy],
  bootstrap: [AppComponent]
})
export class AppModule { }
