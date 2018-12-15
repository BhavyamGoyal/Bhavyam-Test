# Bhavyam-Test
## How To Run
Clone or Download the project and open in Unity. You can build or directly play from editor.
## Explaining Script and Usage
There are 7 scripts:
* Camera_script.cs
* Cube_object.cs
* Cubes.cs
* Data.cs
* Game_Manager.cs
* Player_script.cs
* UI_manager.cs
#### Camera_script.cs 
It is on camera it is just used to make camera follow the player.
#### Cube_object.cs 
It stores the score that should be added if the player hist the cube basically the cube type.
#### Cubes.cs
It is a class that have to data members String color and int score.
#### Data.cs
It is another class that stores list of objects of Cubes.
#### Game_Manage.cs
It mainly handles the setup of the scene.it loads cube types from data.json in Resources which has 5 types of cube types stored in JSON format the randomly selects any 2 types of cube nd instantial them around the plane Randomly.
#### Player_script.cs
It is responsible for movement of the player and calculating the score keeping streak in mind.
### UI_manager.cs
It is a singleton class which is responsible for all the UI changes and level loading.
