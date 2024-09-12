import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { environment } from '../../../environments/environment';
import { ReactionInput } from '../models/input/reaction-input.model';
import { Reaction } from '../models/reaction.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReactionService {

  constructor(private http: HttpClient, private cookieService: CookieService) { }
  doReaction(reactionInput: ReactionInput): any {
    return this.http.post(`${environment.apiUrl}/reaction`, reactionInput);
  }
  getReactions(pictureId: string): Observable<Reaction[]> {
    return this.http.get<Reaction[]>(`${environment.apiUrl}/reaction/${pictureId}`);
  }
}
