// import {Option} from './option';
// import {Player} from './player';
// import {Team} from './sportTeams';
//
// export const TEAMS: Team[] = JSON.parse('[{\n' +
//   '      "id": "3971013c-f086-4cb4-b9a1-3300ef8d2614",\n' +
//   '      "name": "ThunderBolt3",\n' +
//   '      "logo": "logo/tb3.jpg",\n' +
//   '      "players": [\n' +
//   '        {\n' +
//   '          "id": "d1b8e93e-e36c-4949-9b85-aeea7fa453d2",\n' +
//   '          "teamId": "3971013c-f086-4cb4-b9a1-3300ef8d2614",\n' +
//   '          "firstName": "First1",\n' +
//   '          "lastName": "Last1",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 23\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "914c8d14-e88e-4dfb-b29b-fc660869de13",\n' +
//   '          "teamId": "3971013c-f086-4cb4-b9a1-3300ef8d2614",\n' +
//   '          "firstName": "First2",\n' +
//   '          "lastName": "Last2",\n' +
//   '          "nickname": "Pretty player",\n' +
//   '          "number": 12\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "2b66606a-c480-4d96-a3aa-fafa4468d4e6",\n' +
//   '          "teamId": "3971013c-f086-4cb4-b9a1-3300ef8d2614",\n' +
//   '          "firstName": "First3",\n' +
//   '          "lastName": "Last3",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 8\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "f1d3d8ab-0236-4206-ad7e-6a672c3a685d",\n' +
//   '          "teamId": "3971013c-f086-4cb4-b9a1-3300ef8d2614",\n' +
//   '          "firstName": "First4",\n' +
//   '          "lastName": "Last4",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 65\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "a4875d37-e79e-44cd-86b3-36fe7dae6431",\n' +
//   '          "teamId": "3971013c-f086-4cb4-b9a1-3300ef8d2614",\n' +
//   '          "firstName": "First5",\n' +
//   '          "lastName": "Last5",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 98\n' +
//   '        }\n' +
//   '      ]\n' +
//   '    },\n' +
//   '    {\n' +
//   '      "id": "de7b9e2e-dd0e-4a08-959d-0cc95b3dc50a",\n' +
//   '      "name": "Dear Bear",\n' +
//   '      "logo": "logo/db.jpg",\n' +
//   '      "players": [\n' +
//   '        {\n' +
//   '          "id": "2e5c9bcc-d69a-471b-9585-7d419c465c8d",\n' +
//   '          "teamId": "de7b9e2e-dd0e-4a08-959d-0cc95b3dc50a",\n' +
//   '          "firstName": "First6",\n' +
//   '          "lastName": "Last6",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 23\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "47f92d09-c0a2-44d7-b11e-bf3fbf12b5e5",\n' +
//   '          "teamId": "de7b9e2e-dd0e-4a08-959d-0cc95b3dc50a",\n' +
//   '          "firstName": "First7",\n' +
//   '          "lastName": "Last7",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 11\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "13770701-1185-4e18-b6b1-0fc241eec797",\n' +
//   '          "teamId": "de7b9e2e-dd0e-4a08-959d-0cc95b3dc50a",\n' +
//   '          "firstName": "First8",\n' +
//   '          "lastName": "Last8",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 97\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "54b9eee5-c5f9-4a42-9a88-87b9f2a03478",\n' +
//   '          "teamId": "de7b9e2e-dd0e-4a08-959d-0cc95b3dc50a",\n' +
//   '          "firstName": "First9",\n' +
//   '          "lastName": "Last9",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 87\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "128c60da-e9fc-4f23-bfc8-3b69ae928a45",\n' +
//   '          "teamId": "de7b9e2e-dd0e-4a08-959d-0cc95b3dc50a",\n' +
//   '          "firstName": "First10",\n' +
//   '          "lastName": "Last10",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 26\n' +
//   '        }\n' +
//   '      ]\n' +
//   '    }\n' +
//   '  ]');
//
// export const GAMES: Option[] = JSON.parse('[{\n' +
//   '  "id": "e8bba115-84a7-4b39-b3d2-32ee82f501ba",\n' +
//   '  "date": "2020-11-16T11:39:02.985658+11:00",\n' +
//   '  "teamNames": [\n' +
//   '    "ThunderBolt3",\n' +
//   '    "Dear Bear"\n' +
//   '  ],\n' +
//   '  "teamIds": [\n' +
//   '    "3971013c-f086-4cb4-b9a1-3300ef8d2614",\n' +
//   '    "de7b9e2e-dd0e-4a08-959d-0cc95b3dc50a"\n' +
//   '  ],\n' +
//   '  "teams": [\n' +
//   '    {\n' +
//   '      "id": "3971013c-f086-4cb4-b9a1-3300ef8d2614",\n' +
//   '      "name": "ThunderBolt3",\n' +
//   '      "logo": "logo/tb3.jpg",\n' +
//   '      "players": [\n' +
//   '        {\n' +
//   '          "id": "d1b8e93e-e36c-4949-9b85-aeea7fa453d2",\n' +
//   '          "teamId": "3971013c-f086-4cb4-b9a1-3300ef8d2614",\n' +
//   '          "firstName": "First1",\n' +
//   '          "lastName": "Last1",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 23\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "914c8d14-e88e-4dfb-b29b-fc660869de13",\n' +
//   '          "teamId": "3971013c-f086-4cb4-b9a1-3300ef8d2614",\n' +
//   '          "firstName": "First2",\n' +
//   '          "lastName": "Last2",\n' +
//   '          "nickname": "Pretty player",\n' +
//   '          "number": 12\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "2b66606a-c480-4d96-a3aa-fafa4468d4e6",\n' +
//   '          "teamId": "3971013c-f086-4cb4-b9a1-3300ef8d2614",\n' +
//   '          "firstName": "First3",\n' +
//   '          "lastName": "Last3",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 8\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "f1d3d8ab-0236-4206-ad7e-6a672c3a685d",\n' +
//   '          "teamId": "3971013c-f086-4cb4-b9a1-3300ef8d2614",\n' +
//   '          "firstName": "First4",\n' +
//   '          "lastName": "Last4",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 65\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "a4875d37-e79e-44cd-86b3-36fe7dae6431",\n' +
//   '          "teamId": "3971013c-f086-4cb4-b9a1-3300ef8d2614",\n' +
//   '          "firstName": "First5",\n' +
//   '          "lastName": "Last5",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 98\n' +
//   '        }\n' +
//   '      ]\n' +
//   '    },\n' +
//   '    {\n' +
//   '      "id": "de7b9e2e-dd0e-4a08-959d-0cc95b3dc50a",\n' +
//   '      "name": "Dear Bear",\n' +
//   '      "logo": "logo/db.jpg",\n' +
//   '      "players": [\n' +
//   '        {\n' +
//   '          "id": "2e5c9bcc-d69a-471b-9585-7d419c465c8d",\n' +
//   '          "teamId": "de7b9e2e-dd0e-4a08-959d-0cc95b3dc50a",\n' +
//   '          "firstName": "First6",\n' +
//   '          "lastName": "Last6",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 23\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "47f92d09-c0a2-44d7-b11e-bf3fbf12b5e5",\n' +
//   '          "teamId": "de7b9e2e-dd0e-4a08-959d-0cc95b3dc50a",\n' +
//   '          "firstName": "First7",\n' +
//   '          "lastName": "Last7",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 11\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "13770701-1185-4e18-b6b1-0fc241eec797",\n' +
//   '          "teamId": "de7b9e2e-dd0e-4a08-959d-0cc95b3dc50a",\n' +
//   '          "firstName": "First8",\n' +
//   '          "lastName": "Last8",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 97\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "54b9eee5-c5f9-4a42-9a88-87b9f2a03478",\n' +
//   '          "teamId": "de7b9e2e-dd0e-4a08-959d-0cc95b3dc50a",\n' +
//   '          "firstName": "First9",\n' +
//   '          "lastName": "Last9",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 87\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "128c60da-e9fc-4f23-bfc8-3b69ae928a45",\n' +
//   '          "teamId": "de7b9e2e-dd0e-4a08-959d-0cc95b3dc50a",\n' +
//   '          "firstName": "First10",\n' +
//   '          "lastName": "Last10",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 26\n' +
//   '        }\n' +
//   '      ]\n' +
//   '    }\n' +
//   '  ]\n' +
//   '}]');
//
// export const PLAYERS: Player[] = JSON.parse(
//   ' [{\n' +
//   '          "id": "d1b8e93e-e36c-4949-9b85-aeea7fa453d2",\n' +
//   '          "teamId": "3971013c-f086-4cb4-b9a1-3300ef8d2614",\n' +
//   '          "firstName": "First1",\n' +
//   '          "lastName": "Last1",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 23\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "914c8d14-e88e-4dfb-b29b-fc660869de13",\n' +
//   '          "teamId": "3971013c-f086-4cb4-b9a1-3300ef8d2614",\n' +
//   '          "firstName": "First2",\n' +
//   '          "lastName": "Last2",\n' +
//   '          "nickname": "Pretty player",\n' +
//   '          "number": 12\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "2b66606a-c480-4d96-a3aa-fafa4468d4e6",\n' +
//   '          "teamId": "3971013c-f086-4cb4-b9a1-3300ef8d2614",\n' +
//   '          "firstName": "First3",\n' +
//   '          "lastName": "Last3",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 8\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "f1d3d8ab-0236-4206-ad7e-6a672c3a685d",\n' +
//   '          "teamId": "3971013c-f086-4cb4-b9a1-3300ef8d2614",\n' +
//   '          "firstName": "First4",\n' +
//   '          "lastName": "Last4",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 65\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "a4875d37-e79e-44cd-86b3-36fe7dae6431",\n' +
//   '          "teamId": "3971013c-f086-4cb4-b9a1-3300ef8d2614",\n' +
//   '          "firstName": "First5",\n' +
//   '          "lastName": "Last5",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 98\n' +
//   '        },{\n' +
//   '          "id": "2e5c9bcc-d69a-471b-9585-7d419c465c8d",\n' +
//   '          "teamId": "de7b9e2e-dd0e-4a08-959d-0cc95b3dc50a",\n' +
//   '          "firstName": "First6",\n' +
//   '          "lastName": "Last6",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 23\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "47f92d09-c0a2-44d7-b11e-bf3fbf12b5e5",\n' +
//   '          "teamId": "de7b9e2e-dd0e-4a08-959d-0cc95b3dc50a",\n' +
//   '          "firstName": "First7",\n' +
//   '          "lastName": "Last7",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 11\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "13770701-1185-4e18-b6b1-0fc241eec797",\n' +
//   '          "teamId": "de7b9e2e-dd0e-4a08-959d-0cc95b3dc50a",\n' +
//   '          "firstName": "First8",\n' +
//   '          "lastName": "Last8",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 97\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "54b9eee5-c5f9-4a42-9a88-87b9f2a03478",\n' +
//   '          "teamId": "de7b9e2e-dd0e-4a08-959d-0cc95b3dc50a",\n' +
//   '          "firstName": "First9",\n' +
//   '          "lastName": "Last9",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 87\n' +
//   '        },\n' +
//   '        {\n' +
//   '          "id": "128c60da-e9fc-4f23-bfc8-3b69ae928a45",\n' +
//   '          "teamId": "de7b9e2e-dd0e-4a08-959d-0cc95b3dc50a",\n' +
//   '          "firstName": "First10",\n' +
//   '          "lastName": "Last10",\n' +
//   '          "nickname": "Smart player",\n' +
//   '          "number": 26\n' +
//   '        }]'
// );
