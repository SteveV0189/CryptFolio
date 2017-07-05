import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HeaderComponent } from './header/header.component';
import { FolderComponent } from './folder/folder.component';
import * as $ from 'jquery';
import { DataService } from './data/data.service';
import { PortfolioComponent } from './portfolio/portfolio.component';
import { SideNavComponent } from './side-nav/side-nav.component';
import { PortfolioService } from './data/portfolio.service';
import { FileUploadComponent } from './md-components/snack-bar/file-upload/file-upload.component';
import { EtherwalletService } from './data/etherwallet.service';

@NgModule({
   declarations: [
      AppComponent,
      HeaderComponent,
      FolderComponent,
      PortfolioComponent,
      SideNavComponent,
      FileUploadComponent
   ],
   imports: [
      BrowserModule,
      FormsModule,
      HttpModule,
      BrowserAnimationsModule,
      BrowserModule, 
      MaterialModule,
      FlexLayoutModule
   ],
   providers: [DataService, PortfolioService, EtherwalletService],
   bootstrap: [AppComponent],
   entryComponents: [FileUploadComponent]
})
export class AppModule { }
