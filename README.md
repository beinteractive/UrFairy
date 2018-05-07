# UrFairy

UrFairy (Your fairy) is a set of useful extensions for development in Unity.

## Installation

### <= 2017.x

Copy `Assets/UrFairy` directoy to your `Assets` directory.

### >= 2018.x

Clone this repository into your project's `Packages` directory and checkout `upm` branch.

```bash
$ git submodule add git@github.com:beinteractive/UrFairy.git Packages/UrFairy
$ cd Packages/UrFairy
$ git checkout upm
```

## List of extensions

Extensions for `Vector3`

  - [`.X()` / `.Y()` / `.Z()`](#vector3-xyz) - One Liner Modification

Extensions for `Transform`

  - [`.LocalPosition()`](#transform-localposition) - One Liner Modification
  - [`.LocalRotation()`](#transform-localrotation) - One Liner Modification
  - [`.LocalEulerAngles()`](#transform-localeulerangles) - One Liner Modification
  - [`.LocalScale()`](#transform-localscale) - One Liner Modification
  - [`.Position()`](#transform-position) - One Liner Modification
  - [`.Rotation()`](#transform-rotation) - One Liner Modification
  - [`.EulerAngles()`](#transform-eulerangles) - One Liner Modification
  - [`.Identity()`](#transform-identity) - Reset Transform
  - [`.Children()`](#transform-children) - Traversing Hierarchy
  - [`.FindDesendant()`](#transform-finddesendant) - Finding Desendant

Extensions for `Color`

  - [`.R()` / `.G()` / `.B()` / `.A()`](#color-rgba) - One Liner Modification
  - [`.HSV()`](#color-hsv) - Manipulating HSV

Extensions for `Material`

  - [`.Color()`](#material-color) - One Liner Modification
  - [`.Float()`](#material-float) - One Liner Modification
  - [`.Keyword()`](#material-keyword) - One Liner Modification

Extensions for `Renderer`

  - [`.Material()`](#renderer-material) - One Liner Modification
  - [`.Materials()`](#renderer-materials) - One Liner Modification

Extensions for `int`

  - [`.Color()`](#int-color) - Hex to Color
  - [`.RandomSign()`](#int-randomsign) - Random Sign

Extensions for `float`

  - [`.RandomSign()`](#float-randomsign) - Random Sign

Extensions for `MonoBehaviour`

  - [`.Delay()`](#monobehaviour-delay-frames) - Delay Frames
  - [`.Delay()`](#monobehaviour-delay-seconds) - Delay Seconds

Extensions for `IEnumerable<T>`

  - [`.AsEnumerable()`](#ienumerable-asenumerable) - Object to Enumerable
  - [`.CombineFirst()`](#ienumerable-combinefirst) - Appending Object to First
  - [`.CombineLast()`](#ienumerable-combinelast) - Appending Object to Last
  - [`.Sample()`](#ienumerable-sample) - Picking Random Object
  - [`.Shuffle()`](#ienumerable-shuffle) - Enumerating in Random Order
  - [`.IsEmpty()`](#ienumerable-isempty) - Is Collection Empty
  - [`.Each()`](#ienumerable-each) - Enumerating Elements
  - [`.EachWithIndex()`](#ienumerable-eachwithindex) - Enumerating Elements with Indicies

Extensions for `IEnumerable<T> where T : UnityEngine.Object`

  - [`.ActiveObjects()`](#ienumerable-activeobjects) - Enumerating Not Destroyed Elements

Extensions for `IEnumerable<T> where T : UnityEngine.Component`

  - [`.Actives()`](#ienumerable-actives) - Enumerating Not Destroyed Elements

Extensions for `List<T>`

  - [`.Shuffle()`](#list-shuffle) - Shuffling

Extensions for `Dictionary<K, V>`

  - [`.QueryObject()`](#dictionary-queryobject) - Nullsafe Querying

Extensions for `Dictionary<K, V> where V : UnityEngine.Object`

  - [`.Query()`](#dictionary-query) - Nullsafe Querying

Extensions for `<T>`

  - [`.Tap()`](#t-tap)
  - [`.IfJust()`](#t-ifjust)
  - [`.IfNothing()`](#t-ifnothing)

Other

 - [`Rnd`](#rnd) - PCG Random Number Generator
 - [`Interpolations`](#interpolations) - Time Based Interpolation Alghorithms

Editor Extensions

 - [`Spacebar Hand Tool`](#spacebar-hand-tool)
 - [`Capture Screenshot`](#capture-screenshot)

## Extensions for `Vector3`

### <a name="vector3-xyz"> `.X()` / `.Y()` / `.Z()` - One Liner Modification

Returns a new value with modifying a specified component value:

```C#
var v = new Vector3(1f, 2f, 3f);
var p = v.X(10f).Y(20f);

// p = Vector3(10f, 20f, 3f)
```

Relative value version:

```C#
var v = new Vector3(1f, 2f, 3f);
var p = v.X(x => x + 10f).Y(y => y + 20f);

// p = Vector3(11f, 22f, 3f)
```

## Extensions for `Transform`

### <a name="transform-localposition"> `.LocalPosition()` - One Liner Modification

Set a new value with modifying a current value:

```C#
// Set localPosition.x to 10f
g.transform.LocalPosition(p => p.X(10f));
```

### <a name="transform-localrotation"> `.LocalRotation()` - One Liner Modification

Set a new value with modifying a current value:

```C#
// Multiply localRotation and quaternion
g.transform.LocalRotation(r => r * quaternion);
```

### <a name="transform-localeulerangles"> `.LocalEulerAngles()` - One Liner Modification

Set a new value with modifying a current value:

```C#
// Set localEulerAngles.z to 180f
g.transform.LocalEulerAngles(r => r.Z(180f));
```

### <a name="transform-localscale"> `.LocalScale()` - One Liner Modification

Set a new value with modifying a current value:

```C#
// Set localScale.y to 2f
g.transform.LocalScale(s => s.Y(2f));
```

### <a name="transform-position"> `.Position()` - One Liner Modification

Set a new value with modifying a current value:

```C#
// Set position.x to 10f
g.transform.Position(p => p.X(10f));
```

### <a name="transform-rotation"> `.Rotation()` - One Liner Modification

Set a new value with modifying a current value:

```C#
// Multiply rotation and quaternion
g.transform.Rotation(r => r * quaternion);
```

### <a name="transform-eulerangles"> `.EulerAngles()` - One Liner Modification

Set a new value with modifying a current value:

```C#
// Set eulerAngles.z to 180f
g.transform.EulerAngles(r => r.Z(180f));
```

### <a name="transform-identity"> `.Identity()` - Reset Transform

Set initial values to position, rotation and scale.

```C#
g.transform.Identity();

// Same as:
/*
g.transform.localPosition = Vector3.zero;
g.transform.localRotation = Quaternion.identity;
g.transform.localScale = Vector3.one;
*/
```

### <a name="transform-children"> `.Children()` - Traversing Hierarchy

Enumerates children (not includes desendants):

```C#
foreach (var child in transform.Children())
{
  Debug.Log(child.gameObject.name);
}
```

Enumerates children (includes desendants):

```C#
foreach (var child in transform.Children(true))
{
  Debug.Log(child.gameObject.name);
}
```

### <a name="transform-finddesendant"> `.FindDesendant()` - Finding Desendant

Returns a transform that has a specified name by searching transform hierarchy recursive.

```C#
var d = transform.FindDesendant("DesendantName");
```

## Extensions for `Color`

### <a name="color-rgba"> `.R()` / `.G()` / `.B()` / `.A()` - One Liner Modification

Returns a new value with modifying a specified component value:

```C#
var c = Color.white;
var v = c.A(0.5f);

// v = Color(1f, 1f, 1f, 0.5f)
```

### <a name="color-hsv"> `.HSV()` - Manipulating HSV

Color to HSV:

```C#
var hsv = color.HSV();
```

Modify HSV:

```C#
hsv.s = hsv.s - 0.5f;
```

HSV to Color:

```C#
var col = hsv.Color();
```

## Extensions for `Material`

### <a name="material-color"> `.Color()` - One Liner Modification

Set a new value with modifying existing value (this method is chainable)

```C#
m.Color("_Color", c => c.A(0.5f)).Keyword("_ALPHA_BLEND", true);
```

### <a name="material-float"> `.Float()` - One Liner Modification

Set a new value with modifying existing value (this method is chainable)

```C#
m.Float("_Alpha", a => a * 0.5f).Keyword("_ALPHA_BLEND", true);
```

### <a name="material-keyword"> `.Keyword()` - One Liner Modification

Set a new value with modifying existing value (this method is chainable)

```C#
m.Keyword("_ENABLE_GRAYSCALE", b => !b).Float("_TIME_SCALE", 0.5f);
```

## Extensions for `Renderer`

### <a name="renderer-material"> `.Material()` - One Liner Modification

Set a new material with modifying existing material.

```C#
r.Material(m => m.Color("_Color", Color.red));
```

### <a name="renderer-materials"> `.Materials()` - One Liner Modification

Set a new materials with modifying existing materials.

```C#
r.Materials(m => m.Keyword("_GRAYSCALE", true));
```

## Extensions for `int`

### <a name="int-color"> `.Color()` - Hex to Color

Hex value to Color:

```C#
var c = 0x112233.Color();
```

### <a name="int-randomsign"> `.RandomSign()` - Random Sign

Returns positive or negative value randomly

```C#
var v = 100.RandomSign(); // 100 or -100
```

## Extensions for `float`

### <a name="float-randomsign"> `.RandomSign()` - Random Sign

```C#
var v = 100f.RandomSign(); // 100f or -100f
```

## Extensions for `MonoBehaviour`

### <a name="monobehaviour-delay-frames"> `.Delay()` - Delay Frames

Delay one frame:

```C#
// this is MonoBehaviour
this.Delay(() =>
{
  Debug.Log("One frame after");
});
```

Delay specified frames:

```C#
this.Delay(3, () =>
{
  Debug.Log("Three frames after");
});
```

### <a name="monobehaviour-delay-seconds"> `.Delay()` - Delay Seconds

```C#
// this is MonoBehaviour
this.Delay(3.0f, () =>
{
  Debug.Log("Three seconds after");
});
```

## Extensions for `IEnumerable<T>`

### <a name="ienumerable-asenumerable"> `.AsEnumerable()` - Object to Enumerable

Convert a single object into IEnumerable.

```C#
// e is IEnumerable<int>
var e = 100.AsEnumerable();
```

### <a name="ienumerable-combinefirst"> `.CombineFirst()` - Appending Object to First

Insert a specified element to first.

```C#
var list = new int[] { 1, 2, 3 };
var n = 10;
list.CombineFirst(n); // 10, 1, 2, 3
```

### <a name="ienumerable-combinelast"> `.CombineLast()` - Appending Object to Last

Insert a specified element to last.

```C#
var list = new int[] { 1, 2, 3 };
var n = 10;
list.CombineLast(n); // 1, 2, 3, 10
```

### <a name="ienumerable-sample"> `.Sample()` - Picking Random Object

```C#
// Pick a random element
var e = list.Sample();
```

### <a name="ienumerable-shuffle"> `.Shuffle()` - Enumerating in Random Order

```C#
var shuffled = list.Shuffle();
```

### <a name="ienumerable-isempty"> `.IsEmpty()` - Is Collection Empty

```C#
// Whether enumerable doesn`t have any element
var b = list.IsEmpty();
```

### <a name="ienumerable-each"> `.Each()` - Enumerating Elements

Same as `each()` in Ruby.

```C#
list.Each(e =>
{
  Debug.Log(e);
});
```

### <a name="ienumerable-eachwithindex"> `.EachWithIndex()` - Enumerating Elements with Indicies

Same as `each_with_index()` in Ruby.

```C#
list.EachWithIndex((e, i) =>
{
  Debug.Log($"{i} -> {e}");
});
```

## Extensions for `IEnumerable<T> where T : UnityEngine.Object`

### <a name="ienumerable-activeobjects"> `.ActiveObjects()` - Enumerating Not Destroyed Elements

Enumerates objects that is not null (means has not been destroyed yet)

```C#
var activeObjects = objects.ActiveObjects();
```

## Extensions for `IEnumerable<T> where T : UnityEngine.Component`

### <a name="ienumerable-actives"> `.Actives()` - Enumerating Not Destroyed Elements

Enumerates objects that is not null (means has not been destroyed yet and also related GameObject has not been destroyed)

```C#
var actives = components.Actives();
```

## Extensions for `List<T>`

### <a name="list-shuffle"> `.Shuffle()` - Shuffling

```C#
list.Shuffle();
```

## Extensions for `Dictionary<K, V>`

### <a name="dictionary-queryobject"> `.QueryObject()` - Nullsafe Querying

Calls a closure with a object in a dictionary if exists and is not null.

```C#
dictionary.QueryObject("Foo", o => Debug.Log(o));
```

## Extensions for `Dictionary<K, V> where V : UnityEngine.Object`

### <a name="dictionary-query"> `.Query()` - Nullsafe Querying

Calls a closure with a object in a dictionary if exists and is not null (means has not been destroyed).

```C#
gameObjects.Query("Player", g => Debug.Log(g));
```

## Extensions for `<T>`

### <a name="t-tap"> `.Tap()`

Same as `tap()` in Ruby.

```C#
particle.main.Tap(m => m.startColor = Color.red);
```

### <a name="t-ifjust"> `.IfJust()`

Calls a closure if object is not null.

```C#
// Invoke callback if not null
callback.IfJust(f => f());
```

In .NET 4.6 script backend, it's recommended to use a null conditional operator.

```C#
callback?.Invoke();
```

### <a name="t-ifnothing"> `.IfNothing()`

Calls a closure if object is null.

```C#
Resources.Load<GameObject>("Prefab").IfNothing(Debug.Log("Prefab is not found"));
```

## Other

### <a name="rnd"> `Rnd`

Implementation of PCG Random Number Generation.

```C#
// With specified seed
var r = new Rnd(12345U, 678910U);
// Auto seed
var r = new Rnd();

// float
r.Value;
// uint
r.Value32;
// float range
r.Range(0.5f, 1.5f);
// uint range
r.Range(50, 150);
```

### <a name="interpolations"> `Interpolations`

Time based interpolation alghrothims from [Klak](https://github.com/keijiro/Klak).

By passing a destination value, a current value, a speed and a delta time, an interpolated new current value will be returned.

```C#
// Approaching "to" by exponential algorhithm.
transform.localPosition = Interpolations.Expo(to, transform.localPosition, 30f, Time.deltaTime);

// Approaching "to" by critically damped spring smoothing.
transform.localPosition = Interpolations.CriticallyDamped(to, transform.localPosition, 30f, Time.deltaTime);
```

## Editor Extensions

### <a name="spacebar-hand-tool"> `Spacebar Hand Tool`

Toggle hand tool while pressing a space key in the scene view like Photoshop.

### <a name="capture-screenshot"> `Capture Screenshot`

Capture the game view and save png image to project directory by editor menu `UrFairy | Capture Screenshot`.

## License

Copyright 2016 Oink Games, Inc. and other contributors.

Code licensed under the MIT License: http://opensource.org/licenses/MIT
