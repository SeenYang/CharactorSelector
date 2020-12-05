import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {Location} from '@angular/common';
import {Option} from '../../Models/option';
import {OptionService} from '../../Services/option.service';
import {v4 as guid} from 'uuid';
import {MessageService} from '../../Services/message.service';
import {CharacterService} from '../../Services/character.service';
import {Character} from '../../Models/character';

@Component({
    selector: 'app-character-detail',
    templateUrl: './character-detail.component.html',
    styleUrls: ['./character-detail.component.css']
})
export class CharacterDetailComponent implements OnInit {

    constructor(
        private route: ActivatedRoute,
        private characterService: CharacterService,
        private optionService: OptionService,
        private messageService: MessageService,
        private location: Location
    ) {
    }

    customiseCharacter: Character;
    characterId: string;
    character: Character;

    ngOnInit(): void {
        this.characterId = this.route.snapshot.paramMap.get('id');
        this.getCharacter(this.characterId);
        this.customiseCharacter = {
            selectedOptions: []
        } as Character;
    }

    getCharacter(id: string): void {
        this.characterService.getCharactersById(id)
            .subscribe(c => this.character = c);
    }

    goBack(): void {
        this.location.back();
    }

    save(): void {
        const msgPrefix = `${new Date().toLocaleString('en-AU', {timeZone: 'UTC'})} -> `;
        const newCharacter = {} as Character;
        this.characterService.addCustomerCharacter(newCharacter)
            .subscribe((result) => {
                console.log(result);
                this.messageService.add(msgPrefix + `New character ${result}`);
                // todo: redirect to new character page.
            });
    }

    selectSuboption(option: Option) {
        if (this.customiseCharacter.selectedOptions.indexOf(option.id) !== -1) {
            this.customiseCharacter.selectedOptions = this.customiseCharacter.selectedOptions.filter(c => c !== option.id);
        } else {
            this.customiseCharacter.selectedOptions.push(option.id);
        }

        this.messageService.add(`Selected Option ${option.name}`);
    }

}
