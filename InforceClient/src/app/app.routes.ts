import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { AlbumListComponent } from './features/shared/album/album-list/album-list.component';
import { MyAlbumsComponent } from './features/shared/album/my-albums/my-albums.component';
import { EditAlbumComponent } from './features/shared/album/edit-album/edit-album.component';
import { CreateAlbumComponent } from './features/shared/album/create-album/create-album.component';
import { ViewAlbumComponent } from './features/shared/album/view-album/view-album.component';
import { ViewPictureComponent } from './features/shared/picture/view-picture/view-picture.component';

export const routes: Routes = [
  {path: "login", component: LoginComponent},
  {path: "register", component: RegisterComponent},
  {path: "", component: AlbumListComponent},
  {path: "album/myAlbums", component: MyAlbumsComponent},
  {path: "edit-album/:id", component: EditAlbumComponent},
  {path: "create-album", component: CreateAlbumComponent},
  {path: "album/:id", component: ViewAlbumComponent},
  {path: "picture/:id", component: ViewPictureComponent}
];
