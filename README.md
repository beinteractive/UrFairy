# UrFairy

UrFairy (Your fairy) is a set of useful extensions for development in Unity.

To start using UrFairy, copy `Assets/UrFairy` directoy to your project and write `using UrFairy;` in your code.

```C#
using UnityEngine;
using System.Collections;
using UrFairy;
```

## Vector Extensions

### One Liner Modification (Absolute Value)

```C#
transform.localPosition = transform.localPosition.X(10f).Y(20f);
```

Same as:

```C#
var lp = transform.localPosition;
lp.x = 10f;
lp.y = 20f;
transform.localPosition = lp;
```

### One Liner Modification (Relative Value)

```C#
transform.localPosition = transform.localPosition.X((x) => x + 10f).Y((y) => y - 20f);
```

Same as:

```C#
var lp = transform.localPosition;
lp.x += 10f;
lp.y -= 20f;
transform.localPosition = lp;
```

## Transform Extensions

### Reset Transform

```C#
g.transform.parent = transform;
g.transform.Identity();
```

Same as:

```C#
g.transform.parent = transform;
g.transform.localPosition = Vector3.zero;
g.transform.localRotation = Quaternion.identity;
g.transform.localScale = Vector3.one;
```

### Replicate & Restore

```C#
var rep = g.transform.Replicate();
g.transform.parent = transform;
g.transform.Restore(rep);
```

Same as:

```C#
var lp = g.transform.localPosition;
var ls = g.transform.localScale;
var lr = g.transform.localRotation;
g.transform.parent = transform;
g.transform.localPosition = lp;
g.transform.localScale = ls;
g.transform.localRotation = lr;
```

### Auto Restore

```C#
g.transform.AutoRestore(() => {
  g.transform.parent = transform;
});
```

Same as:

```C#
var lp = g.transform.localPosition;
var ls = g.transform.localScale;
var lr = g.transform.localRotation;
g.transform.parent = transform;
g.transform.localPosition = lp;
g.transform.localScale = ls;
g.transform.localRotation = lr;
```

### One Liner Modification

```C#
g.transform.LocalPosition((p) => p.X(10f));
```

Same as:

```C#
var lp = g.transform.localPosition;
lp.x = 10f;
g.transform.localPosition = lp;
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
```

Same as:

```C#
var col = graphics.color;
col.a = 0.5f;
graphics.color = col;
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

## List Extensions

### Shuffle

```C#
// Make order randomly.
list.Shuffle();
```

## Enumerator Extensions

### Object to Enumerable

```C#
var e = default(IEnumerable<string>);
if (list.Count > 0) {
  e = list;
} else {
  e = "It's empty".Enumerable(); // Convert an object to enumerable
}
```

### Add First

```C#
// Insert specified element to first
foreach (var l in g1.GetComponents<Light>().AddFirst(g2.GetComponent<Light>())) {
  l.enabled = false;
}
```

### Add Last

```C#
// Insert specified element to last
foreach (var l in g1.GetComponents<Light>().AddLast(g2.GetComponent<Light>())) {
  l.enabled = false;
}
```

## Object Extensions

### Tap

It is `tap()` in Ruby.

```C#
g.GetComponents<Light>().Where((l) => l.intensity > 1f).Tap((o) => Debug.Log(o.ToList().Count)).Select((l) => l.gameObject);
```
