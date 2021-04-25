# Football-world-cup-score-board

## How to run the project
```bash
dotnet run --project .\FootballWordCupScoreBoard\
```

## Executing  tests
```bash
dotnet test .\FootballWordCupScoreBoard.UnitTests\
dotnet test .\FootballWordCupScoreBoard.IntegrationTests\
```

## Architecture
For this project, I've split the app into several layers to isolate the domain logic from the implementation details and also making testing easier using the following structure.
Domain contains the app logic, Infrastructure contains the InMemory DB and the presentation layer provides the API to interact with the app. 
```
project | - Domain
        |  | - Models
        |  | - Services  
        | - Infraestructure
        | - Presentation
        
unit tests | - Domain
           |  | - Models
           |  | - Services  

integration tests | - Infrastructure
  
```

## Implementation details and assumptions

To keep things simple and because of the project size I've taken some shortcuts:

 - I didn't use  a DTO to return the board nor to Start/Update/Finish the games
 - The repository is in the root of infrastructure instead of a Persistence folder 
 - Team uniqueness is not validated and is created with the game
 - I didn't create domain exceptions
