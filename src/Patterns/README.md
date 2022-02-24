# Patterns

## Singleton Pattern

Singletons are used whenever you want one, and only one, of an object in memory at a time.

See: https://en.wikipedia.org/wiki/Singleton_patten

### Examples

```c#
public class Example : Singleton<Example> 
{
...
```

This can then be referred to with the Instance API
```c#
Example.Instance
```

The object will also survive changes in scenes, as it is marked DoNotDestroyOnLoad
