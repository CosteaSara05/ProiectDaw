import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Songmodel } from '../songmodel';
@Injectable({
  providedIn: 'root'
})
export class SongService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  listSongs() {
    return this.http.get<Songmodel[]>(this.baseUrl + 'api/Songs/GetSongs');
  }

  loadSong(songID: string) {
    return this.http.get<Songmodel>(this.baseUrl + `api/Songs/GetSong?songID=${songID}`);
  }

  saveSong(song: Songmodel) {
    console.log(song);
    return this.http.post<any>(this.baseUrl + `api/Songs/PostSong`, song);
  }

  deleteSong(songID: string) {
    return this.http.delete<any>(this.baseUrl + `api/Songs/DeleteSong/${songID}`);
  }
}
