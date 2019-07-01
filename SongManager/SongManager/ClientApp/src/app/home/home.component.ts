import { Component } from '@angular/core';
import { SongService } from '../services/song.service';
import { Songmodel } from '../songmodel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
  
export class HomeComponent {
  songs: Songmodel[];

  constructor(private songService: SongService) {
    songService.listSongs().subscribe(res => {
      this.songs = res;
    });
  }

  delete(songId) {
    this.songService.deleteSong(songId).subscribe(x => {
      this.songService.listSongs().subscribe(res => {
        this.songs = res;
      });
    });
  }
}
