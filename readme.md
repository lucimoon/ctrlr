## Prerequesites

* Add an [EventManager](https://bitbucket.org/bitfieldgames/utils/src/master/) to the scene.

---

## Input

Commanders are used to map input to desired commands.
They keep the input separate from the implementation.

## Commanders

A `Commander` is responsible for issuing commands to a controller. Currently, the input can come from:

* A desktop (keyboard & mouse)
* An enemy (AI)

To use a commander:
  * Create an empty GameObject, named 'Input'.
  * Name it 'Input'. Seriously, that's how we know where to look.
  * Attach the desired commander to the GameObject
  * TODO: Create a prefab to do this

  ---

## Controllers

`Controllers` define the explicit behavior for `GameObjects`. For instance, if an object can be translated forward, the translation code lives in the `Controller`. It's usually exposed via a public method. That public method will be called by a `Command`.

`Controllers` require the Commands associated with them to be present on the GameObject they control or are attached to. Unity will add the required Commands for you when you atach the `Controller` to the `GameObject`.

To use a Controller:

  * Attach the controller to the relevant GameObject
  * i.e. Attach TopDownController to player.

---

## Commands

`Commands` are simple classes that contain instructions of how to use a controller. A `Command` may directly call a public method on a controller. It may also call a series of methods in a complex sequence. The logic for exactly how the `Controller` should be called lives inside each `Command`. It is like a puppeteer that only does one conceptual task. 

`Commands` map themselves to `KeyCodes` in the relevant `InputCommander`.

They have a default key that may be overwritten in the Unity Editor.

You may write your own custom Commands.

  * Extend the base command for your controller
  * Implement the ICommand interface
  * Set up a default KeyCode
  * Write custom controller instructions in the `Execute` method
  * Require Command in Controller

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