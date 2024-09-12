import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlbumService } from '../../../services/album.service';
import { Album } from '../../../models/album.model';
import { FormBuilder, FormGroup, FormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ImageSelectorComponent } from '../image-selector/image-selector.component';
import { environment } from '../../../../../environments/environment';

@Component({
  selector: 'app-edit-album',
  standalone: true,
  templateUrl: './edit-album.component.html',
  styleUrls: ['./edit-album.component.css'],
  imports: [FormsModule, CommonModule, ImageSelectorComponent]
})
export class EditAlbumComponent implements OnInit {
  imageUrl = environment.imagesUrl;
  albumId: string | null = null;
  isImageSelectorVisible: boolean = false;
  album: Album = {
    id: '',
    name: '',
    description: '',
    pictures: [],
    userId: '',
    userEmail: '',
    createdAt: new Date()
  };

  constructor(
    private albumService: AlbumService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.albumId = this.route.snapshot.paramMap.get('id');
    if (this.albumId) {
      this.albumService.getAlbumById(this.albumId).subscribe(album => {
        this.album = album;
        console.log(this.album);
      });
    }
  }
  onSubmit(): void {
  }

  showImageSelector() {
    this.isImageSelectorVisible = true;
  }

  hideImageSelector() {
    this.isImageSelectorVisible = false;
    console.log(this.album)
  }

  onCancel() {
    console.log('Cancelled');
    this.router.navigate(['/album/myAlbums']);
  }
}
