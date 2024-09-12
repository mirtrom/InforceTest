import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { PictureInput } from '../models/input/picture-input.model';
import { Picture } from '../models/picture.model';
import { HttpClient } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class PictureService {
  selectedImage: BehaviorSubject<Picture> = new BehaviorSubject<Picture>({id: '', title: '', url: '', fileExtension: '', createdAt: new Date, userEmail: '', albumId: '', album: {id: '', name: '', description: '', createdAt: new Date(), pictures: null, userId: '', userEmail: ''}, likes: 0, dislikes: 0});
  constructor(private http: HttpClient, private cookieService: CookieService) {
  }
  uploadPicture(ImageInput: PictureInput): Observable<Picture>
  {
    const formData = new FormData();
    formData.append('file', ImageInput.file);
    formData.append('title', ImageInput.title);
    formData.append('albumId', ImageInput.albumId);
    return this.http.post<Picture>(`${environment.apiUrl}/picture`, formData, {
      headers: {
        'Authorization': this.cookieService.get('Authorization'),
    }});
  }

  getPictureFromAlbumCount(albumId: string): Observable<number>
  {
    return this.http.get<number>(`${environment.apiUrl}/picture/album/${albumId}/count`);
  }

  getAllPictures(): Observable<Picture[]>
  {
    return this.http.get<Picture[]>(`${environment.apiUrl}/picture`);
  }

  selectPicture(image: Picture): void
  {
    this.selectedImage.next(image);
  }

  onSelectedPicture(): Observable<Picture>
  {
    return this.selectedImage.asObservable();
  }

  getPagedPictures(page: number): Observable<Picture[]>
  {
    return this.http.get<Picture[]>(`${environment.apiUrl}/picture/page/${page}`);
  }

  deletePicture(id: string): Observable<any>
  {
    return this.http.delete(`${environment.apiUrl}/picture/${id}`);
  }

  getPicture(id: string): Observable<Picture>
  {
    return this.http.get<Picture>(`${environment.apiUrl}/picture/${id}`);
  }
}
