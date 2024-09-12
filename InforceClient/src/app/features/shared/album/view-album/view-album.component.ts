import { Component, OnInit } from '@angular/core';
import { AlbumService } from '../../../services/album.service';
import { Album } from '../../../models/album.model';
import { environment } from '../../../../../environments/environment';
import { User } from '../../../models/user.model';
import { PictureService } from '../../../services/picture.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-view-album',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './view-album.component.html',
  styleUrl: './view-album.component.css'
})
export class ViewAlbumComponent implements OnInit{
  user: User | undefined;
  id = this.route.snapshot.paramMap.get('id');
  model: Album =
  {
    id: '',
    name: '',
    description: '',
    pictures: [],
    userId: '',
    userEmail: '',
    createdAt: new Date()
    };
    currentPage: number = 1;
    totalPages: number = 1;
  imageUrl = environment.imagesUrl;
  constructor(private albumService: AlbumService,
     private pictureService: PictureService,
      private route: ActivatedRoute,
    private authService: AuthService,
  private router: Router) { }
  ngOnInit(): void {
    this.loadAlbum(this.currentPage);
    this.authService.user().subscribe(user => {
      this.user = user;
      console.log(this.user);
    });

    this.user = this.authService.getUser();
  }
  loadAlbum(page: number): void {
    this.albumService.getAlbumById(this.id!).subscribe(album => {
      this.model = album;
      this.pictureService.getPagedPictures(page).subscribe(response => {
        this.model.pictures = response; // Assume 'albums' is the response data
        this.currentPage = page;
        console.log(this.model);
    });});
  }

  changePage(page: number): void {
    if (page >= 1 && page <= this.totalPages) {
      this.loadAlbum(page);
    }
  }

  deletePicture(id: string): void {
    this.pictureService.deletePicture(id).subscribe({
      next: () => {
        this.loadAlbum(this.currentPage); // Reload current page after deleting
      },
      error: (error) => {
        console.log(error);
  }});}
  onClick(id: string): void {
    console.log('Clicked');
    this.router.navigate(['/picture', id]);
  }
}
