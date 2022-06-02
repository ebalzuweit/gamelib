# gamelib

A collection of utility scripts for Unity.

## Installation

Follow the instructions [here](https://docs.unity3d.com/Manual/upm-ui-giturl.html), using the URL `https://github.com/ebalzuweit/gamelib.git#upm`.

## Usage

`using com.ebalzuweit.gamelib;`

### GameEvent & GameEventListener

### Observables

Variable & VariableReference

### Inverse Kinematics

- `IkRoot`
- `EndEffector`

Uses the FABRIK algorithm.

### Chance _(beta)_

#### Dice

#### Loot Table

### Utility Scripts

#### Persistence classes

- `StaticInstance`
	- Base class for a MonoBehaviour with a static instance variable.
- `Singleton`
  - StaticInstance that will destroy itself if another instance already exists.
- `PersistentSingleton`
  - Singleton with DontDestroyOnLoad

#### Helper Functions

- GetWait
- IsOverUI
- GetWorldPositionOfCanvasElement

#### Grid Extensions

- CellToWorldCenter

#### Transform Extensions

- DestroyChildren

#### Vector Extensions

- ComponentAdd

#### Timer

#### Note

#### BillboardSprite

#### Volume

- Spawn
- Trigger
- Teleport