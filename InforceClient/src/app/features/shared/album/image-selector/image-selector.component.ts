import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { PictureService } from '../../../services/picture.service';
import { Picture } from '../../../models/picture.model';
import { FormsModule, NgForm } from '@angular/forms';
import { environment } from '../../../../../environments/environment';
import { PictureInput } from '../../../models/input/picture-input.model';
import { Router } from '@angular/router';
import { NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-image-selector',
  standalone: true,
  imports: [FormsModule, NgFor, NgIf],
  templateUrl: './image-selector.component.html',
  styleUrl: './image-selector.component.css'
})
export class ImageSelectorComponent implements OnInit {
  @Input() albumId: string = '';
  private file?: File;
  title: string = '';
  imageList: Picture[] = [];
  imageUrl: string = environment.imagesUrl;

  @ViewChild('form', { static: false }) formInput?: NgForm;
  @ViewChild('fileInput', { static: false }) fileInput?: ElementRef; // Added ViewChild for file input

  constructor(private imageService: PictureService, private router: Router) {}
  ngOnInit(): void {
    // this.imageService.getAllImages().subscribe({
    //   next: (images) => {
    //     this.imageList = images;
    //   }
    // });
  }

  OnCancel() {
    console.log("Cancelled");
    this.router.navigate(['/album/myAlbums']);
  }


  selectImage(image: Picture): void {
    console.log('Selected image:', image);
    this.imageService.selectPicture(image);

  }
  uploadImage(): void {
    if (this.file && this.title !== '' && this.albumId !== "") {
      const imageInput: PictureInput = {
        file: this.file,
        title: this.title,
        albumId: this.albumId
      };
      console.log(imageInput);
      this.imageService.uploadPicture(imageInput).subscribe({
        next: (response) => {
          this.formInput?.resetForm();
          this.fileInput!.nativeElement.value = '';
          this.file = undefined;
          this.imageList.push(response);
          console.log("Response" + response);
        }
      });
    } else {
      console.log('No image selected for upload');
    }
  }
}

