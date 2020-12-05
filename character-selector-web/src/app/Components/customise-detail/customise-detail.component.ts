import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {CharacterService} from '../../Services/character.service';
import {MessageService} from '../../Services/message.service';
import {Location} from '@angular/common';
import {Customise} from '../../Models/customise';

@Component({
  selector: 'app-customise-detail',
  templateUrl: './customise-detail.component.html',
  styleUrls: ['./customise-detail.component.css']
})
export class CustomiseDetailComponent implements OnInit {

  constructor(
      private route: ActivatedRoute,
      private characterService: CharacterService,
      private messageService: MessageService,
      private location: Location
  ) { }

  customiseId: string;
  customise: Customise;


  ngOnInit(): void {
    this.customiseId = this.route.snapshot.paramMap.get('id');
    this.getCustomise(this.customiseId);
  }

  getCustomise(id: string): void {
    this.characterService.getCustomiseById(id)
        .subscribe(c => {
          this.customise = c;
        });
  }

  back(): void {
    this.location.back();
  }

}
