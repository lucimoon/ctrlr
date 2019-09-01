- [Installation](#Installation)
- [Setup](#Setup)
- [Input](#Input)
- [Controllers](#Controllers)
- [Commands](#Commands)
- [Projectiles](#Projectiles)

# Installation

- Clone Repo
- Clone Utils

# Setup

* Create a Commander:
  * create an empty `GameObject`.
  * attach the desired `Commander` to the `GameObject`.
  * TODO: Create a prefab to do this

* Create a Controller:
  * Attach the controller to the player object,  *i.e. TopDownController*.

# Commanders

Commanders are used to map input to desired commands.
They keep the input separate from the implementation.

# Controllers

Controllers give controllable behavior to GameObjects.
Controllers also require the Commands associated with them to be present on GameObject. Unity will add the required Commands for you.

## ThirdPerson(Fixed)

* ThirdPersonController
  * Moves character relative to it's orientation.
  * Forward moves the character in the direction they are facing
  * Left rotates the character to the left (counter-clockwise)
  * Requires `ThirdPersonLeft` & `ThirdPersonRight` commands

* ThirdPersonFixedController
  * Moves character relative to the camera.
  * Forward moves the character north, relative to the camera
  * Left moves the character west, relative to the camera
  * Requires `ThirdPersonFixedLeft` & `ThirdPersonFixedRight` commands

# Commands

Commands are simple objects that contain instructions of how to use a controller. They map themselves to KeyCodes in the relevant InputCommander.

They have a default key that may be overwritten in the Unity Editor.

You may write your own custom Commands.

  - Extend the base command for your controller
  - Implement the ICommand interface
  - Set up a default KeyCode
  - Write custom controller instructions in the `Execute` method
  - Require Command in Controller

Example inheritance:

`public class Fire : ProjectileCommand, ICommand`

Setting default KeyCode:

```
  public KeyCode keyCode = KeyCode.Mouse0;

  protected override void Start()
  {
    base.Start();
    this.commander.CommandMap.Add(keyCode, this);
  }
```

Controller instructions:

```
  public void Execute()
  {
    controller.Fire();
  }
```

Requiring Command in relevant Controller:

`[RequireComponent(typeof(Fire))]`

# Projectiles

*More Soon...*

- Because projectiles collide with and damage health, be sure to assign enemies and players to different layers that do not collide with themselves. Otherwise they may shoot themselves to death.