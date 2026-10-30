**Game Engine Design & Implementation Project Check-In**
--------------------------------------
**Group Formation:**

**Our strategies for creating the group**                                                                                                  
For creating our group we strategized by teaming up with our GDW group. Originally we planned on using our GDW game,
but due to its lack of playability progress, discomfort in using Unreal engine and working on past in-class activities 
in different engines, we decided to create a new game in Unity for this project. The pros of this is that we have worked
before in 2nd year as a GDW team, understand each other's workflows and have already established communication between members.
We hope to sharpen these skills in Unity and get the concepts solid before venturing into using them with Unreal Engine.


**Ashley** 	
Audio Manager,
Orb Factory,
Hat Command Pattern,
Any Art/Visuals, and
Documentation (Aside from each persons individual)

**Iris**
Gameplay programming,
Scene Manager,
Power Ups Factory,
Death Replay System, and
Implementing DLL 

**Zach**
Gameplay programming,
Game Manager,
Enemy Factory, and
Button Remapping

**Gantt Chart:**

<img width="512" height="331" alt="Yellow and Purple Simple Project Timeline Gantt Chart" src="https://github.com/user-attachments/assets/29601890-d66b-4c55-b480-b84092021313" />

--------------------------------------
**Interactive Media Scenario Information:**

The purpose of this project is to create a game that best showcases the learning objectives of the Game Engine Design and Implementation
course. The game we are creating is 2D platformer based on stylistic concepts from our main GDW game. In this game the players main 
objective is to collect all the red, blue and green orbs without running into enemies.The player can pick up different powerups as well
to help them evade enemies and platform easier.There is 2 levels, the player wins when all the orbs have been collected from both levels,
the player loses if they run into an enemy, fall into the void or run out of time, the game then restarts. 

********ADD SCREENSHOTS W/ ANNOTATIONS, LEGENDS AND/OR LABELS HERE 
--------------------------------------
**Singleton**

**Implementation 1 : Audio Manager**
By: Ashley 

Explanation:

My Audio Manager singleton was implemented by first inheriting from a generic singleton class which when instanced insures there is only one of those instances in a scene and destroy the rest.The audio manager has 2 methods a PlaySound and PlayMusic method. These methods are able to be called in any other class to play a sound or music from that object.  It was implemented this way for simplicity and keeping the code cleaner within the game. it benefits our game by controlling sound instances and keeping overall organization with audio. 

Flowchart:

<img width="563" height="389" alt="AudioManagerCheckInDiagram" src="https://github.com/user-attachments/assets/d3b6f709-ffc0-4bd0-ab0c-eeb429eba66e" />


**Implementation 2 : Scene Manager**
By: Iris

Explanation:

Has basic scene switching functionality as a singleton, so any object can call scene changes when it's needed. This is necessary to be in a singleton because scene switching functionality inside an object that is inside the scene itself would be awkward. This script is also responsible for loading death replays, and carries the input data so it's not cleared between scene switches.

Pseudocode:

Class SceneManager

bool isReplay = false
bool inputRecording = List of Input Data

SetSceneByInt(int scene_num): Load scene by its index

SetSceneByName(string scene_name): Load scene by its name

ReloadScene(): Load the active scene

LoadReplayScene():
    Invert the replay state
    Get reference to inputReader object
    Set inputRecording to inputReader's recorded input data
    Reload the scene


**Implementation 3 : Game Manager**
By: Zach

Explanation:

The Game Manager similarly implements and inherits from the Singleton base, protecting and isolating the class as a singleton for all scenes. it houses a simple set of boolean values as references for the current game state (paused, menu, fail state), and a Timer variable from the attached DLL which acts as a loss condition for the player, it then contains two methods to be called by other scripts, OnOrbCollected which simply attaches a gameplay effect of increasing the remaining time to the orbs, and a PauseGame method, which as it would imply, pauses the game time. the reason behind it's implementation is to maintain an easy reference object for any and all gamestate related variables to be accessed through and manage tasks related to tracking the gamestate without populating levels with redundant copies.

Pseudocode, UML, or a flowchart:

class GameManager

bool gamePaused
bool gameOver
bool mainMenu
Timer timer
float timeRemaining

TimerRanOut(): kill player

OrbCollected(): up timer 10 seconds

PauseGame(): 
if (unpaused)
    pause 
else 
    unpause

--------------------------------------

**Command Design Pattern**

**Implementation 1 : Hat Command Pattern**
By: Ashley 

Explanation: 

My Command pattern was implemented by firstly creating a command interface called ICommand that stores both execute and undo methods. I then have a concrete method that inherits from the interface to give the execute and undo methods the toggle functionality. It then goes to the toggler which gets the game object and does the setting active of the gameobject. As its not just turning the hat on and off and its actually executing and undoing there is an invoker that stores the toggling input for and stores it into a stack for the commands.Lastly the HatCommander is the input to get the toggle  and execute the invoker commands. It was implemented this way because I felt with the basics down of the single hat some changes could be made to better to to stack the hats on the players head and be able to undo with the stack in future progress. It benefits our game by being fun, It is a funny idea we have for our GDW game and I wanted to add this concept into our platformer variation. 

UML:

<img width="518" height="314" alt="CommandDiagram" src="https://github.com/user-attachments/assets/fe1f2f54-7ec0-4e3c-95bb-6b19eafa0306" />


**Implementation 2 : Death Replay System**
By: Iris

Explanation:

The command pattern is used to record all the inputs the player makes. If they die, the inputs are replayed to show the player (the replay can be ended prematurely by pressing space). The command pattern was necessary for this because otherwise it would be significantly more complicated to save the player's inputs every frame. This code is also easily expandable for more complex characters by adding new inputs to InputRoot, which will then be saved to the array and played back with no additional effort.


Flowchart:

<img width="550" height="315" alt="image" src="https://github.com/user-attachments/assets/f33b7e25-1795-4aef-b2bf-c85ffabb1a80" />



**Implementation 3 : Button Remapping**
By: Zach

Explanation:

this command pattern implements an interface called ICommandPlus, which has a bare bones execute function that takes a gameobject as parameter, a series of control commands override the execute and get a playerMovement component from the gameObject where they execute the movement and jump functions when detecting input. the inputs are detected from the inputReader in the processData function, and when appropriate values are detected inputReader calls the specific commands. the key rebinder has a set of three functions to attach to UI buttons for rebinding each control, when called the they call the secondary Rebind function, passing the inputActions binding name and a call to get the key index, the rebind function then instances the inputActions object and disables the action temporarily. then unity performs its rebinding functions, some cleanup is performed because the functions don't automatically garbage collect.

Pseudocode, UML, or a flowchart:
Class Rebinding

InputActions inputActions
RebindOberation rebindOperation

LeftRebind
    Rebind(actionName = "PlayerAction/Walk", bindIndex = GetWalkIndex("PlayerAction/Walk", "negative")
    
    
RightRebind
    Rebind(actionName = "PlayerAction/Walk", bindIndex = GetWalkIndex("PlayerAction/Walk", "positive")
    
JumpRebind
    Rebind(actionName = "PlayerAction/Jump", bindIndex = GetJumpIndex("PlayerAction/Jump")

Rebind(actionName, bindIndex)
    if rebindOperation exists or binding index isn't valid
        return
.    
    action = find action using actionName
    disable action
.
    start rebinding for bindIndex
.
    when rebinding operation completes
        re-enable action
        dispose of operation
        null rebindingOperation
    when rebinding operation stops
        re-enable action
        dispose of operation
        null rebindingOperation
.
    start rebindingOperation

GetJumpIndex(actionName)
    action = find action using actionName
.
    for each binding in action's bindings 
        if it is not a composite
            return index
.
    return invalid index

GetWalkIndex(actionName, Direction)
    action = find action using actionName
    for each binding in action's bindings
        if it is not part of a composite
            return index by direction
.
    return invalid index

--------------------------------------

**Factory Pattern**

**Implementation 1 : Orb Factory**
By: Ashley 

Explanation:

My Factory pattern was implemented by first creating a product interface IOrb that has a method that takes in a sprite renderer (from the player sprite) and the coloured sprite that it will get changed into. Each coloured orb has a concrete product class that calls this method and passes in the corresponding coloured sprite. I then implemented an abstract factory “OrbFactory” which my concrete factories for each colour would inherit from to do the actual orb calling  Finally this factory is managed by an OrbCollision script thats attached to the player, it has an OnTriggerEnter2D method, depending on which coloured orb is collided with the orbfactory creates a new corresponding coloured orb factory which then is used to call ChangeOrb with the related sprite. After that the established orb called/changed too calls the Collect method which finally sets the player sprite to the correct colour. It was implemented this way for ease of change if there is additional function we wanted to add to each orb. It benefits our game as visually it is very fun and a similar aesthetic to our GDW games mechanic of picking up orbs and changing colour, it also gives us a lot of freedom and do some other cool things with the orbs for the final if we choose too.


UML:

<img width="555" height="243" alt="FactoryMethodUML" src="https://github.com/user-attachments/assets/dff38809-b32f-45f2-a8fc-1b6ce70061bb" />


**Implementation 2 : Power-Up Factory**
By: Iris

Explanation: 

PowerupFactory is designed to get references to the three powers on Start(). From there, any script that has a reference to PowerupFactory can call create power, and inputting the powerup and the position it should go to, it's created. PowerupFactory does this using a switch case, and an Enum to determine which powerups are valid inputs. This is useful for quickly populating a level with powerups (as it's used in-game), but the modularity this script gives also allows it to be used for other purposes, and can easily be adapted to fit more powerups.

UML:

<img width="712" height="487" alt="Screenshot_2026-10-29_153451" src="https://github.com/user-attachments/assets/e9dc1278-d84a-40f7-8a6f-833a63f7df34" />


**Implementation 3 : Enemy Factory**
By: Zach

Explanation:

The factory uses a concrete factory class which works through a simple, easily modular switch case implementation. it contains an enemy constructor which intakes a provided enemy type among the EnemyType enum, and a position Vector, then instantiates an enemy of the provided specifications, while there was consideration to separate the factories further and have the switch case call a create value from those, the idea was disregarded as it seemed obtuse and would result in more complexity when modifying the factory with new enemy types. this simpler modular design is far easier for team members to manage, and was chosen for overall readability above all else.


Pseudocode, UML, or a flowchart:

--------------------------------------

**Plugin/DLL**
UML:

<img width="316" height="175" alt="DLL_UML" src="https://github.com/user-attachments/assets/5159b7bf-f321-40bb-a60c-e91ad235e063" />

Flowchart:

<img width="377" height="234" alt="Screenshot 2026-10-29 154926" src="https://github.com/user-attachments/assets/d191befb-2ce8-4033-99d0-9c6569e233e0" />

Pseudocode:

Class Timer

float timeLeft
Action TimesUp

StartTimer(float time): Sets the time left to the input number.

TimeRanOut(): Triggers the TimesUp action to any scripts listening for this event.

RaiseTimer(int increase): Increases the time left by the amount specified. Returns the time left in case the object needs it.

ReduceTimer(int decrease): Decreases the time left by the amount specified, if this causes the time left to be 0, trigger the time left. Returns the time left in case the object needs it.

Explanation:
This DLL is built to be a generic timer that can be incorporated into any project that needs a timer. Since the timer reduction only triggers by a function that needs to be called, any object that uses this plugin can modify the timer at its discretion, leaving the attached object responsible for modifying the timer. This means ReduceTimer can be called in Update, like it is for this project. But also it can be set to reduce at whatever time is convenient for the project, which also means if pause functionality is required, that can be implemented by the implementing object. We felt that for this project the implementation of this DLL made sense to run our timer and possibly plan to use it even more in the final submission to possibly control powerups, enemies spawn, etc.

--------------------------------------
Resources used: 
https://unity.com/resources/design-patterns-solid-ebook
https://reactiveprogramming.io/blog/en/design-patterns/factory-method
https://github.com/PacktPublishing/Game-Development-Patterns-with-Unity-2021-Second-Edition

All audio was either made with jsfxr or found on Freesound -> Creative Commons
