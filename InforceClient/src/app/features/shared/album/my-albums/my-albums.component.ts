import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { AlbumService } from '../../../services/album.service';
import { Router } from '@angular/router';
import { User } from '../../../models/user.model';
import { Album } from '../../../models/album.model';
import { CommonModule } from '@angular/common';
import { environment } from '../../../../../environments/environment';

@Component({
  selector: 'app-my-albums',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './my-albums.component.html',
  styleUrls: ['./my-albums.component.css']
})
export class MyAlbumsComponent implements OnInit {
  imageUrl = environment.imagesUrl;
  user: User | undefined;
  albums: Album[] = [];
  userEmail = '';
  constructor(
    private authService: AuthService,
    private albumService: AlbumService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.authService.user().subscribe(user => {
      this.user = user;
    });

    this.user = this.authService.getUser();
    console.log(this.user);
    //this.userEmail = localStorage.getItem('user-email') || '';
    if (this.user) {
      this.userEmail = this.user.email;
    }
    this.fetchAlbums(this.userEmail);
  }


  fetchAlbums(email: string): void {
    this.albumService.getUsersAlbums(email).subscribe(albums => {
      this.albums = albums;
    });
  }

  onCreateAlbum(): void {
    this.router.navigate(['/create-album']); // Redirect to create album page
  }

  onDeleteAlbum(id: string): void {
    if (confirm('Are you sure you want to delete this album?')) {
      this.albumService.deleteAlbum(id).subscribe({
        next: () => {
          this.fetchAlbums(this.user?.email || ''); // Refresh the list
        },
        error: (error) => {
          console.error('Error deleting album:', error);
        }
      });
    }
  }

  onEditAlbum(id: string): void {
    this.router.navigate(['/edit-album', id]); // Redirect to edit album page
  }
}
