Code Breakdown:

GameManger: I tried to make it the main entry point for the game, it holds ref to all the other managers that’s why I used the singleton pattern (implemented in a very lazy way).

 Buildings: the base class have the shared info between the different types of building also created a quick factory to create the desired building type.

Production manager: I make the production as encapsulated behaviour in a strategy pattern so I can change the way the building produce resources dynamically and if we wanted to add a power up or anything in the future to make the manuel production be an automatic one that will be just changing the type in the runtime.

Resource Manager: it holds a dictionary of resource type and implement the observer pattern to notify the subscribers to the change of the resources (increase or decrease)

If I had more time: 

The UI implementation will be refactored to have a stack of panels and each panel own it’s code instead of throwing all the ui code in the UI manager.


Also I would make a grid manager that return a free cell to hold the building I want to build instead of now throwing the buildings in fixed positions (Sorry for that), make the player changes the building position and make the building snaps to the grid,also I will update the grid visually to have a visual difference between the 2 game modes.

Make the 2 game modes into a game state that make everything react accordingly instead of just buttons to show menus.

Make all the buildings into a scriptable objects that will be much cleaner way to handle the meta data and instantiating the buildings.
