import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {CharacterService} from '../../Services/character.service';
import {OptionService} from '../../Services/option.service';
import {Character} from '../../Models/character';
import {tap} from "rxjs/operators";

@Component({
    selector: 'app-character-dashboard',
    templateUrl: './character-dashboard.component.html',
    styleUrls: ['./character-dashboard.component.css']
})
export class CharacterDashboardComponent implements OnInit {

    constructor(
        private route: ActivatedRoute,
        private characterService: CharacterService,
        private optionService: OptionService
    ) {
    }

    characters: Character[];
    CustomerCharacter: Character[];


    ngOnInit(): void {
        this.getTemplateCharacters();
        this.getCustomiseCharacters();
    }

    getTemplateCharacters() {
        this.characterService.getCharacters()
            .subscribe((result) => {
                this.characters = result;
            });
    }

    getCustomiseCharacters() {
        // this.characterService.getCustomiseCharacters()
        //     .subscribe((result) => {
        //         this.characters = result;
        //     });
    }
}
