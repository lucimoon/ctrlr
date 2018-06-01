### Input

Commanders are used to map input to desired commands.
They keep the input separate from the implementation.

To use a commander:
  - create an empty GameObject
  - attach the desired commander to the GameObject
  - TODO: Create a prefab to do this

### Controllers

Controllers give controllable behavior to GameObjects.
Controllers also require the Commands associated with them to be present on GameObject. Unity will add the required Commands for you.

To use a Controller:

  - Attach the controller to the relevant GameObject
  - *i.e. Attach TopDownController to player.

### Commands

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

### Projectiles

*More Soon...*

- Because projectiles collide with and damage health, be sure to assign enemies and players to different layers that do not collide with themselves. Otherwise they may shoot themselves to death.