# UrFairy

UrFairy (Your fairy) is a set of useful extensions for development in Unity.

## Installation

### <= 2017.x

Copy `Assets/UrFairy` directoy to your `Assets` directory.

### >= 2018.x

Clone this repository into your project's `Packages` directory and checkout `upm` branch.

```
$ git submodule add git@github.com:beinteractive/UrFairy.git Packages/UrFairy
$ cd Packages/UrFairy
$ git checkout upm
```

## Vector Extensions

### One Liner Modification (Absolute Value)

```C#
transform.localPosition = transform.localPosition.X(10f).Y(20f);

// Same as:
/*
var lp = transform.localPosition;
lp.x = 10f;
lp.y = 20f;
transform.localPosition = lp;
*/
```

### One Liner Modification (Relative Value)

```C#
transform.localPosition = transform.localPosition.X((x) => x + 10f).Y((y) => y - 20f);

// Same as:
/*
var lp = transform.localPosition;
lp.x += 10f;
lp.y -= 20f;
transform.localPosition = lp;
*/
```

## Transform Extensions

### One Liner Modification

```C#
g.transform.LocalPosition((p) => p.X(10f));

// Same as:
/*
var lp = g.transform.localPosition;
lp.x = 10f;
g.transform.localPosition = lp;
*/
```

### Reset Transform

```C#
g.transform.parent = transform;
g.transform.Identity();

// Same as:
/*
g.transform.parent = transform;
g.transform.localPosition = Vector3.zero;
g.transform.localRotation = Quaternion.identity;
g.transform.localScale = Vector3.one;
*/
```

### Replicate & Restore

```C#
var rep = g.transform.Replicate();
g.transform.parent = transform;
g.transform.Restore(rep);

// Same as:
/*
var lp = g.transform.localPosition;
var ls = g.transform.localScale;
var lr = g.transform.localRotation;
g.transform.parent = transform;
g.transform.localPosition = lp;
g.transform.localScale = ls;
g.transform.localRotation = lr;
*/
```

### Auto Restore

```C#
g.transform.AutoRestore(() => {
  g.transform.parent = transform;
});

// Same as:
/*
var lp = g.transform.localPosition;
var ls = g.transform.localScale;
var lr = g.transform.localRotation;
g.transform.parent = transform;
g.transform.localPosition = lp;
g.transform.localScale = ls;
g.transform.localRotation = lr;
*/
```

### Enumerate Children

Children (not includes desendants):

```C#
foreach (var child in transform.Children()) {
  Debug.Log(child.gameObject.name);
}
```

Children (includes desendants):

```C#
foreach (var child in transform.Children(true)) {
  Debug.Log(child.gameObject.name);
}
```

### Find Desendant

```C#
var d = transform.FindDesendant("DesendantName");
```

## Color Extensions

### Hex to Color

```C#
var c = 0x112233.Color();
```

### One Liner Modification

```C#
graphics.color = graphics.color.A(0.5f);

// Same as:
/*
var col = graphics.color;
col.a = 0.5f;
graphics.color = col;
*/
```

### HSV

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

## Mono Behaviour Extensions

### Delay Frame

Delay one frame:

```C#
// this is MonoBehaviour
this.Delay(() => {
  Debug.Log("One frame after");
});
```

Delay specified frames:

```C#
this.Delay(3, () => {
  Debug.Log("Three frames after");
});
```

### Delay Seconds

```C#
// this is MonoBehaviour
this.Delay(3.0f, () => {
  Debug.Log("Three seconds after");
});
```

## Random Extensions

### Random Sign

```C#
// Get positive or negative value randomly.
var n = Random.Range(2f, 3f).RandomSign();
```

## Enumerator Extensions

### Object to Enumerable

```C#
// e is IEnumerable<string>
var e = "It's empty".AsEnumerable(); // Convert an object to enumerable
}
```

### Combine First

```C#
// Insert specified element to first
foreach (var l in g1.GetComponents<Light>().CombineFirst(g2.GetComponent<Light>())) {
  l.enabled = false;
}
```

### Combine Last

```C#
// Insert specified element to last
foreach (var l in g1.GetComponents<Light>().CombineLast(g2.GetComponent<Light>())) {
  l.enabled = false;
}
```

### Sample

```C#
// Pick a random element
var e = list.Sample();
```

### Is Empty

```C#
// Whether enumerable has any element
var b = list.IsEmpty();
```

### Actives / ActiveObjects

Choose objects that is not null (means not destroyed yet)

```C#
// for UnityEngine.Component
var actives = components.Actives();
// for UnityEngine.Object
var activeObjects = objects.ActiveObjects();
```

### Each

Same as `each()` in Ruby.

```C#
list.Each((e) => {
  Debug.Log(e);
});
```

### EachWithIndex

Same as `each_with_index()` in Ruby.

```C#
list.EachWithIndex((e, i) => {
  Debug.Log(i + " -> " + e);
});
```

## List Extensions

### Shuffle

```C#
// Make order randomly.
list.Shuffle();
```

## Dictionary Extensions

### Query / QueryObject

Calls a closure with a object that has been stored to dictionary as key if exists and is not null.

```C#
// for UnityEngine.Object
gameObjects.Query("Foo", g => g.SetActive(true));
// for other objects / values
values.QueryObject("Foo", o => Debug.Log(o));
```

## Object Extensions

### Tap

Same as `tap()` in Ruby.

```C#
g.GetComponents<Light>().Where((l) => l.intensity > 1f).Tap((o) => Debug.Log(o.ToList().Count)).Select((l) => l.gameObject);
```

## License

Copyright 2016 Oink Games, Inc. and other contributors.

Code licensed under the MIT License: http://opensource.org/licenses/MIT
