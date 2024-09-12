import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
import { Album } from '../models/album.model';
import { environment } from '../../../environments/environment';
import { AlbumInput } from '../models/input/album-input.model';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class AlbumService {
  constructor(private http: HttpClient, private cookieService: CookieService) {}
  getPaginatedAlbums(page: number): Observable<Album[]> {
    return this.http.get<Album[]>(`${environment.apiUrl}/album/page/${page}`);
  }

  getAlbumById(id: string): Observable<Album> {
    return this.http.get<Album>(`${environment.apiUrl}/album/${id}`);
  }

  createAlbum(album: AlbumInput): Observable<Album> {
    return this.http.post<Album>(`${environment.apiUrl}/album`, album, {
      headers: {
        'Authorization': this.cookieService.get('Authorization'),
    }});
  }

  updateAlbum(id: string, album: AlbumInput): Observable<Album> {
    return this.http.put<Album>(`${environment.apiUrl}/album/${id}`, album);
  }

  deleteAlbum(id: string): Observable<any> {
    return this.http.delete(`${environment.apiUrl}/album/${id}`);
  }

  getUsersAlbums(email: string): Observable<Album[]> {
    return this.http.get<Album[]>(`${environment.apiUrl}/album/user/${email}`, {
      headers: {
        'Authorization': this.cookieService.get('Authorization'),
    }});
  }

  getAlbumsCount(): Observable<number> {
    return this.http.get<number>(`${environment.apiUrl}/album/count`);
  }
}
