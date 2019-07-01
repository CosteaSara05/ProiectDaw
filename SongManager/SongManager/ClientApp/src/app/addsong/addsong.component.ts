import { Component, OnInit } from '@angular/core';
import { Songmodel } from '../songmodel';
import { SongService } from '../services/song.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-addsong',
  templateUrl: './addsong.component.html',
  styleUrls: ['./addsong.component.css']
})
export class AddsongComponent implements OnInit {

  song = new Songmodel();
  constructor(private router: Router,
    private songService: SongService) { }

  

  save() {
    this.songService.saveSong(this.song).subscribe(res => {
      console.log(this.song);
      this.router.navigate(['']);
    });
  }


  ngOnInit() {
  }
}
