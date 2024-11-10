import { HttpClient, HttpErrorResponse  } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { Component, EnvironmentInjector, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MeterReadingResults } from './meter-reading-result';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, FormsModule, ReactiveFormsModule,],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'MeterReadingsAngularApp';
  httpClient = inject(HttpClient)

  success:boolean = false;
  uploadError:boolean = false;
  uploadErrorDetails:string = "";

  public uploadResults = new MeterReadingResults();

  myForm = new FormGroup({
    file: new FormControl('', [Validators.required]),
    fileSource: new FormControl('', [Validators.required])
  });

  get f(){
    return this.myForm.controls;
  }

  onFileChange(event:any) {
    
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.myForm.patchValue({
        fileSource: file
      });
    }
  } 

  submit(){
    const formData = new FormData();
  
    const fileSourceValue = this.myForm.get('fileSource')?.value;
  
    if (fileSourceValue !== null && fileSourceValue !== undefined) {
        formData.append('file', fileSourceValue);
    }

    this.httpClient.post<MeterReadingResults>('https://localhost:44358/MeterReadings/meter-reading-uploads', formData)
    .pipe(
      catchError(error =>{
        this.success = false;
        this.uploadError = true;
        this.uploadErrorDetails = error.message;
        this.uploadResults.successfulReadings = 0;
        this.uploadResults.failedReadings = 0;
        return throwError(() => new Error('Oops! Something went wrong. Please try again later.'));
      })
    )
    .subscribe(result=>{
      console.log(result);
      this.success = true;
      this.uploadError = false;
      this.uploadResults = result;
    });

  }
}
