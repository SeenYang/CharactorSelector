import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {MessagesComponent} from './Components/messages/messages.component';
import {ENV, getEnv} from '../environments/environment.provider';
import {CharacterDetailComponent} from './Components/character-detail/character-detail.component';
import {CharacterDashboardComponent} from './Components/character-dashboard/character-dashboard.component';
import { CustomiseDetailComponent } from './Components/customise-detail/customise-detail.component';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,

    // The HttpClientInMemoryWebApiModule module intercepts HTTP requests
    // and returns simulated server responses.
    // Remove it when a real server is ready to receive requests.
    // HttpClientInMemoryWebApiModule.forRoot(
    //   InMemoryDataService, {dataEncapsulation: false}
    // )
  ],
  providers: [
    {provide: ENV, useFactory: getEnv}
  ],
  declarations: [
    AppComponent,
    CharacterDetailComponent,
    MessagesComponent,
    CharacterDashboardComponent,
    CustomiseDetailComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
