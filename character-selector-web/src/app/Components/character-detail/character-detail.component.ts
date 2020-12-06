import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {Location} from '@angular/common';
import {Option} from '../../Models/option';
import {v4 as guid} from 'uuid';
import {MessageService} from '../../Services/message.service';
import {CharacterService} from '../../Services/character.service';
import {Character} from '../../Models/character';
import {Customise} from '../../Models/customise';

@Component({
    selector: 'app-character-detail',
    templateUrl: './character-detail.component.html',
    styleUrls: ['./character-detail.component.css']
})
export class CharacterDetailComponent implements OnInit {

    constructor(
        private route: ActivatedRoute,
        private characterService: CharacterService,
        private messageService: MessageService,
        private location: Location
    ) {
    }

    characterId: string;
    character: Character;
    options: Option[];
    suboptions: Option[];
    customiseCharacter: Customise;

    selectedOption: Option;
    selectedOptions = [];
    selectedSubOption: Option;
    customiseName = '';

    ngOnInit(): void {
        this.characterId = this.route.snapshot.paramMap.get('id');
        this.getCharacter(this.characterId);
        this.customiseCharacter = {
            characterId: this.characterId,
            userId: guid(),
            userName: `FakeUser-${new Date().getMilliseconds()}`,
            selectedOptions: []
        } as Customise;
    }

    getCharacter(id: string): void {
        this.characterService.getCharactersById(id)
            .subscribe(c => {
                this.character = c;
                this.options = c.options;
            });
    }

    goBack(): void {
        this.location.back();
    }

    save(): void {
        const msgPrefix = `${new Date().toLocaleString('en-AU', {timeZone: 'UTC'})} -> `;
        this.customiseCharacter.name = this.customiseName;
        this.characterService.addCustomerCharacter(this.customiseCharacter)
            .subscribe((result) => {
                this.messageService.add(msgPrefix + `New character "${result.name}" created. id: ${result.id}.`);
                this.back();
            });
    }

    selectOption(option: Option) {
        // Reset Suboption container if none of Option selected.
        if (this.selectedOption === option) {
            this.selectedOption = null;
            this.suboptions = null;
        } else {
            this.selectedOption = option;
            this.suboptions = option.subOptions;
        }
    }

    selectSuboption(option: Option) {
        this.selectedSubOption = option;
        if (this.customiseCharacter.selectedOptions.indexOf(option.id) !== -1) {
            this.customiseCharacter.selectedOptions = this.customiseCharacter.selectedOptions.filter(c => c !== option.id);
            this.messageService.add(`Un-Selected Option ${option.name}`);
        } else {
            this.customiseCharacter.selectedOptions.push(option.id);
            this.messageService.add(`Selected Option ${option.name}`);
        }
    }

    reset() {
        this.selectedOption = null;
        this.selectedSubOption = null;
        this.suboptions = null;
        this.customiseCharacter.selectedOptions = [];
        this.messageService.add(`un-select all.`);
    }

    back() {
        this.location.back();
    }

    disableSave(): boolean {
        return !this.customiseName && this.customiseName.trim() !== '';
    }
}
