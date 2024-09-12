import { Component } from '@angular/core';
import { PictureService } from '../../../services/picture.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Picture } from '../../../models/picture.model';
import { CommonModule, NgIf } from '@angular/common';
import { environment } from '../../../../../environments/environment';
import { ReactionService } from '../../../services/reaction.service';
import { ReactionInput } from '../../../models/input/reaction-input.model';
import { AuthService } from '../../../services/auth.service';
import { User } from '../../../models/user.model';
import { ReactionType } from '../../../models/reaction-type.model';

@Component({
  selector: 'app-view-picture',
  standalone: true,
  imports: [CommonModule, NgIf],
  templateUrl: './view-picture.component.html',
  styleUrl: './view-picture.component.css'
})
export class ViewPictureComponent {
  reaction: ReactionInput = {
    reactionType: ReactionType.None,
    pictureId: '',
    userEmail: localStorage.getItem('user-email') || ''
  };
  likes = 0;
  dislikes = 0;
  imageUrl = environment.imagesUrl;
  picture: Picture = {
    id: '',
    title: '',
    url: '',
    albumId: '',
    createdAt: new Date(),
    fileExtension: '',
    album: {
      id: '',
      name: '',
      description: '',
      pictures: [],
      userId: '',
      userEmail: '',
      createdAt: new Date()
    },
    userEmail: '',
    likes: 0,
    dislikes: 0
  }
  user: User | undefined;
  constructor(private pictureService: PictureService,
     private route: ActivatedRoute,
     private reactionService: ReactionService,
     private router: Router,
     private authService: AuthService
    ) { }
  id = this.route.snapshot.paramMap.get('id');
  ngOnInit(): void {
    this.reaction.pictureId = this.id!;
    this.authService.user().subscribe(user => {
      console.log(user)
      this.user = user;
    });

    this.user = this.authService.getUser();
    this.pictureService.getPicture(this.id!).subscribe(picture => {
      this.picture = picture;
      console.log(picture);
    });
  }
  likePicture() {
    this.reaction.reactionType = ReactionType.Like;
    this.reactionService.doReaction(this.reaction).subscribe({
      next: () => {
        this.reactionService.getReactions(this.reaction.pictureId).subscribe(reactions => {
          this.likes = reactions.filter(r => r.reactionType === ReactionType.Like).length;
          this.dislikes = reactions.filter(r => r.reactionType === ReactionType.Dislike).length;
        });
      }
    });
  }
  dislikePicture() {
    this.reaction.reactionType = ReactionType.Dislike;
    console.log(this.reaction);
    this.reactionService.doReaction(this.reaction).subscribe({
      next: () => {
        this.reactionService.getReactions(this.reaction.pictureId).subscribe(reactions => {
          console.log(reactions);
          this.likes = reactions.filter(r => r.reactionType === ReactionType.Like).length;
          console.log(this.picture.likes);
          this.picture.dislikes = reactions.filter(r => r.reactionType === ReactionType.Dislike).length;
          console.log(this.picture.dislikes);
        });
      }
    });
  }
  onCancel() {
    console.log('Cancelled');
    this.router.navigate(['/album/myAlbums']);
  }
}
