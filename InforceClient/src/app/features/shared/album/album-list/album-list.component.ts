import { Component, OnInit } from '@angular/core';
import { AlbumService } from '../../../services/album.service';
import { environment } from '../../../../../environments/environment';
import { Album } from '../../../models/album.model';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../../services/auth.service';
import { User } from '../../../models/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-album-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './album-list.component.html',
  styleUrls: ['./album-list.component.css']
})
export class AlbumListComponent implements OnInit {
  model: Album[] = [];
  user: User | undefined;
  imageUrl = environment.imagesUrl;

  currentPage: number = 1; // Track the current page
  totalPages: number = 1; // Track total pages (You should get this from your service)

  constructor(private albumService: AlbumService, private authServise: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.albumService.getAlbumsCount().subscribe(count => {
      this.totalPages = Math.ceil(count / 5);
      });
      console.log(this.totalPages);
    this.loadAlbums(this.currentPage); // Load albums for the initial page

    this.authServise.user().subscribe(user => {
      this.user = user;
      console.log(this.user);
    });

    this.user = this.authServise.getUser();
  }

  loadAlbums(page: number): void {
    this.albumService.getPaginatedAlbums(page).subscribe(response => {
      this.model = response; // Assume 'albums' is the response data
      this.currentPage = page;
      console.log(this.model);
    });
  }

  changePage(page: number): void {
    if (page >= 1 && page <= this.totalPages) {
      this.loadAlbums(page);
    }
  }

  deleteAlbum(id: string): void {
    this.albumService.deleteAlbum(id).subscribe({
      next: () => {
        this.loadAlbums(this.currentPage); // Reload current page after deleting
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  ViewAlbum(id: string): void {
    this.router.navigate(['/album', id]);
  }
}
