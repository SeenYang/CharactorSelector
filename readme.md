# Introduction:

This is a simple web app for user to select one of the provided character and customise their version. There are three
pages:

1. Dashboard: list available character(s) and saved user customise character(s).
2. Character detail page: for user customise the character.
3. Customise detail page: show details of customise character created by users.

There's also a REST-ful Web API for exposing more information. i.e. adding new character, update character, and
create/update options of character.

## For running the project:

1. checkout the repo, or un-compress the zip file.
2. use terminal or IDE to open projects.
3. For BE, First need to maks sure GenerateDocument turn on
   ```XML
    <PropertyGroup Condition="'$(Configuration)|$(Platform)'=='Debug|AnyCPU'">
      <DocumentationFile>bin\$(Configuration)\CharactorSelectorApi.xml</DocumentationFile>
    </PropertyGroup>
   ```
4. Then run in CLI:
   ```
   dotnet restore
   dotnet run --project=CharactorSelectorApi 
   -- Then go to https://localhost:5001/swagger/index.html
   ```
5. For FE, run:
   ```
   npm install
   ng serve
   -- Then go to http://localhost:4200/
   ```

There also a demo video:
<https://drive.google.com/file/d/1IqPITsJcf7NZhX5PnZO-5WltvKlPSqv_/view?usp=sharing>

## Design:

BE project is a .net core 3.1 web api with ef core in-memory db for poc purpose. FE is pure Angular FE using web api to
communicate with BE.

Both of them could be deployed separately to dockerized management environment, i.e. esc. sample dockerfiles have
provided.

### Assumption:

1. Every character could only contain two levels of options for now. i.e. Option `Colour` could contain sub-options
   like `Red`.
2. Data model design already consider unlimited levels of options. Only need to handle this structure in FE.

```json
{
  "character": {
    "options": [
      {
        "optionId": 1,
        "parentOptionId": null,
        "subOptions": [
          {
            "optionId": 2,
            "parentOptionId": 1,
            "subOptions": [
              {
                "optionId": 3,
                "parentOptionId": 2,
                "subOptions": []
              }
            ]
          }
        ]
      }
    ]
  }
}
```

3. User could create customise character and save to db. Customise object design shows below. This design handle one
   case that, user created based on old character model. when character updated, they could just load the design, and
   update based on new character cuz we only store what they selected.

```json
{
  "customiseDto": {
    "id": 1,
    "userId": "fake_user_id",
    "userName": "fake_user_name",
    "characterId": "character_id",
    "selectedOptions": [
      "option_id_1",
      "option_id_2",
      "option_id_3"
    ]
  }
}
```

## Todo-list:

- [x] Back-end design and first implementation. 2020-12-05
- [x] Back-end test. 2020-12-05
- [x] Front-end scaffolding. 2020-12-05
- [x] Hook up Back-end and Front-end. 2020-12-06
- [x] Front-end UI Kit apply. 2020-12-05
- [x] Final test and clean up. 2020-12-06
- [x] Documentation. 2020-12-06

## Plan to do:

- [ ] Update existing user customise character.
- [ ] DB access lock inquiry. (EF already well handled. could be done in architecture level.)
- [ ] FE UI component test.

------------------------------------------------------------------------------------------------

# Expectations:

* The code well written, structured, etc
* The code deployable and portable, probably as a docker service
* Unit tests
* Ability to extend it for changes as required
* The easy of use, speed and size
* The look and feel of the UI

# Task:

You are creating a factory that produces Characters, you could create one of the following characters

* Ninja
* Panda
* Pirate
* Rockstar
* Developer

The customer(user) can choose any character and based on the type of character as listed above, we could customize them,
so for example:
For the Ninjas we can customize

- the ninja-yoroi (their armour)
- the weapons
- the mask;

for the Pandas, we can customize

- the food;

for the Pirate, we can customize：

- the eye patch
- the uniform
- the parrot
- the wooden leg
- the hat;

for the Rockstar, we can customize

- the uniform
- the instruments
- the song genre

for the Developer, we can customize

- the language
- the speed
- the level.

So when the customer(user) chooses a particular type of character, we need to present to the customer the list of things
that can be customized,

Create a web service that can be used using curl (no ui) and a UI to this that can allow for creating new characters and
customisations.

Please do mention roughly how much time you took to complete the task. Once you are done, please send the code files,
the deployment files, etc in zip format with instructions on how to run it and anything to watch out for or configure.
