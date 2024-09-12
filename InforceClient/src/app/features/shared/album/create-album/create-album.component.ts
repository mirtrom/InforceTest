import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Album } from '../../../models/album.model';
import { environment } from '../../../../../environments/environment';
import { Router } from '@angular/router';
import { ImageSelectorComponent } from "../image-selector/image-selector.component";
import { CommonModule } from '@angular/common';
import { AlbumService } from '../../../services/album.service';
import { AuthService } from '../../../services/auth.service';
import { User } from '../../../models/user.model';

@Component({
  selector: 'app-create-album',
  standalone: true,
  imports: [FormsModule, ImageSelectorComponent, CommonModule],
  templateUrl: './create-album.component.html',
  styleUrl: './create-album.component.css'
})
export class CreateAlbumComponent {
  isImageSelectorVisible: boolean = false;
  imageUrl: string = environment.imagesUrl;
  user: User | undefined;
  model: Album = {
    id: '',
    name: '',
    description: '',
    pictures: [],
    userId: '',
    userEmail: localStorage.getItem('user-email') || '',
    createdAt: new Date()
  };

  constructor(private router: Router,
     private albumService: AlbumService,
     private authService: AuthService,
    ) { }

  ngOnInit(): void {
    this.authService.user().subscribe(user => {
      this.user = user;
    });

    this.user = this.authService.getUser();
    console.log(this.user);
  }

  onSubmit(): void {
    this.albumService.createAlbum(this.model).subscribe({
      next: () => {
        this.router.navigate(['/album/myAlbums']);
      },
      error: (error) => {
        console.error('Error creating album:', error);
      }
    });
  }
  onCancel() {
    console.log("Cancelled");
    this.router.navigate(['/album/myAlbums']);
  }

}
