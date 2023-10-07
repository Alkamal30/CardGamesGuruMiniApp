# [CardGamesGuruMiniApp](https://t.me/CardGamesGuru_Bot)
Repository of Telegram MiniApp written in ASP.NET C# using React.Js.
The main purpose of this MiniApp is a collection of a certain number of simple card games for a company, where you just need to take information from the card, and interact with your friends.

<img src="https://github.com/Alkamal30/CardGamesGuruMiniApp/assets/111704140/44bd7204-4e9b-4bfd-8342-75fa132a56ba" width="250">

**[Link to the Bot.](https://t.me/CardGamesGuru_Bot)**

> The app was written for a Telegram contest.  **[Contest](https://t.me/contest/327)**

# Games are implemented in mini-app
### This Or That
What Is "This or That"? This or That is an easy-to-play word game in which you must choose between two things. These two options could be funny, mundane, or totally outrageous. Even if neither option appeals to you, you have to choose one or the other.

### Truth Or Dare
Truth or dare? is a mostly verbal party game requiring two or more players. Players are given the choice between answering a question truthfully, or performing a "dare". The game is particularly popular among adolescents and children, and is sometimes used as a forfeit when gambling.

# How-to-Setup

### Prerequisites
Before you begin, ensure you have the following prerequisites installed on your machine:

- Visual Studio or Rider.
- .NET SDK.
- MongoDB installed locally.

### Local Setup - using IDE
**Step 1:** Copy this repository on your local machine.

**Step 2:** Open CardGamesGuruMiniApp.sln file in your Visual Studio or Rider.

**Step 3:** Run mongod.exe for start local mongodb.

**Step 4:** Run Debug version in your IDE.

**Step 5:** First, you need to run a couple of requests to create all the collections and the database itself in mongo.

``https://localhost:5001/api/game/create - for creating game.``

Contract example:
```
{
// The name of the game to be displayed in the game selection start menu.
    "Name":"This Or That",
// The key by which the game is searched.
    "NameIndex":"tot", 
    "Description":"This or that is a simple talking game where players choose which of two items they prefer. Best for: A small group, maybe even two players only.",
// The type of game. Can be: None = 0 (default), NoPlayersJustCards = 1, MultiPlayerGame = 2
    "GameType":"NoPlayersJustCards",
// Address to contoller.
    "Endpoint":"api/tot/",
// Colors for button.
    "Colors" : [ 
        "rgb(45, 89, 134)",
        "rgb(121, 166, 0)"
    ],
    "font": "Monospace"
}
```

``https://localhost:5001/api/tot/create - for creating card for tot game.``

Contract example:
```
{
    "FirstQuestion": "Apple",
    "SecondQuestion": "Android"
}
```
### Local Setup - using Docker

It is also faster to run the project on your machine via docker-compose. You just need to have Docker and that's it.
Go to the project folder and open cmd. 
Use this commad:

``docker-compose up``

After that you can make the same requests for creating collection inside mongo container.

# Install WebApi into the Telegram bot

We have an application running on a local machine that can only be accessed from it. And we need to check how it will work in Telegram itself.

1. Create your own bot. **[Telegram bot creating tutorial](https://core.telegram.org/bots)** 
2. Take the URL of your web page, like ``https://localhost:5001``
3. Change ``localhost`` to ``127.0.0.1``
4. In the BotFather pick to **Edit Main Button Url**.
5. And send him your URL. ``https://127.0.0.1:5001``

# Documentation and Swagger.
To see all possible API requests and contracts, you can use Swagger.

Just add ``/swagger`` to the end: ``https://localhost:5001/swagger``

Other information about mini-app on Wiki: **[CardGamesGuruMiniApp Wiki](https://github.com/Alkamal30/CardGamesGuruMiniApp/wiki)** 
