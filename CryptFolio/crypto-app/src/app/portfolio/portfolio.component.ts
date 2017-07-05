import { Component } from '@angular/core';
import { Portfolio } from "app/models/portfolio";
import { MdSnackBar, MdSnackBarRef } from '@angular/material';
import { FileUploadComponent } from "app/md-components/snack-bar/file-upload/file-upload.component";

@Component({
  selector: 'app-portfolio',
  templateUrl: './portfolio.component.html',
  styleUrls: ['./portfolio.component.scss']
})
export class PortfolioComponent {
  selectedPortfolio: Portfolio;
  selectedTab: Number = 0;
  uploadSnackbarRef: MdSnackBarRef<FileUploadComponent>;
  
  constructor(public snackBar: MdSnackBar) { }

  createPortfolio() {
    this.selectedPortfolio = new Portfolio();
    this.selectedPortfolio.name = "New Portfolio";
    this.selectedTab = 1;
  }

  folioUpload(evt) {
    const file = evt.currentTarget.files[0];
    this.uploadSnackbarRef = this.snackBar.openFromComponent(FileUploadComponent);
    this.uploadSnackbarRef.instance.snackBarRefFileUploadComponent = this.uploadSnackbarRef;
    this.uploadSnackbarRef.instance.file = file;
    this.uploadSnackbarRef.instance.parseFile().subscribe(folio => {
      this.selectedPortfolio = folio;
    });
  }

}
