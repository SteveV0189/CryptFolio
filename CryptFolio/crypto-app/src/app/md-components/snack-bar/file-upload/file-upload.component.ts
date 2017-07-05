import { Component } from '@angular/core';
import { MdSnackBarRef } from "@angular/material/material";
import { Observable } from "rxjs/Observable";
import { environment } from "environments/environment";
import { Portfolio } from "app/models/portfolio";

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss']
})

export class FileUploadComponent {
  public snackBarRefFileUploadComponent: MdSnackBarRef<FileUploadComponent>;
  public file: File;
  public progress: number;
  public status: string;
  private apiUrl = environment.apiUrl;
  constructor() { }

  parseFile(): Observable<Portfolio> {
    return Observable.create(obs => {
      var read = new FileReader();
      read.onload = (evt: FileReaderEvent) => {
        var obj = JSON.parse(evt.target.result);
        Object.setPrototypeOf(obj, Portfolio.prototype);
        return obj;
      };
      read.readAsText(this.file);
    });
  }

  uploadFile() {
    const data = new FormData();
    const req = new XMLHttpRequest();
    data.append("file", this.file, this.file.name);
    req.onreadystatechange.bind(this.updateStatus(null, req));
    req.upload.onprogress.bind(this.updateProgress(null, req));
    req.open("POST", this.apiUrl, true);
    req.send(data);
  }

  updateProgress(evt: ProgressEvent, xhr: XMLHttpRequest) {
    this.progress = Math.round(evt.loaded / evt.total * 100);
  }

  updateStatus(evt, xhr: XMLHttpRequest) {
    switch(xhr.readyState) {
      case 0:
      case 1: {
        this.status = "Building request..";
        break;
      }
      case 2:
      case 3: {
        this.status = "Waiting for server..";
        break;
      }
      case 4: {
        if (xhr.status == 200) {
          this.status = "Upload complete!";
        } else {
          this.status = "File upload error.";
        }
        setTimeout(() => {
          this.snackBarRefFileUploadComponent.dismiss();
        }, 1000);
      }
    }
  }
}

interface FileReaderEventTarget extends EventTarget {
    result:string
}

interface FileReaderEvent extends Event {
    target: FileReaderEventTarget;
    getMessage():string;
}