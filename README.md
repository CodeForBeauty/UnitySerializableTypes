# Unity Serializable Types

Dictionary, HashSet, Stack, Queue wrappers compatible with Unity's serializer and JsonUtility.

Additionaly having inspector drawers for polymorphic subclass selection for SerializeReference.

## Requirements

Unity 2022.3+

## Implemented Types

SerializableDictionary - Dictionary

SerializableSet - HashSet

SerializableStack - Stack

SerializableQueue - Queue

RefWrapper - SerializeReference wrapper

## Usage

Dictionary variable.

```C#
[SerializeField] private SerializableDictionary<string, string> _stringTest;
```

Stack variable.

```C#
[SerializeField] private SerializableStack<int>  _intStack;
```

All of the implemented collections have basic API implementation of their respective types.

Adding an element into a HashSet will look like this:

```C#
_intSet.Add(someValue);
```

The key of this project is it makes these types exposable and editable in editor. 
So adding [SerializeField] or making a variable public will expose it in editor.

### SerializeReference

This project also adds support for polymorphic subclass selection in editor.
Simply adding SubclassSelector to SerializeReference will create inspector drawer for your variable.

```C#
[SerializeReference, SubclassSelector] private EffectBase _effect;
```

Or alternatively there is a wrapper class RefWrapper.

```C#
[SerializeField] private RefWrapper<EffectBase> _wrapperTest;
```

This wrapper can be used in conjunction with implemented collection types, like Dictionary.

```C#
[SerializeField] private SerializableDictionary<string, RefWrapper<EffectBase>> _refTest;
```

More extensive examples can be found in Assets/SerializableTypes/Examples.

## Setup

If you are starting a new project this project can be copied as a whole.

When adding into existing project the contents of Assets folder can be copied into your projects Assets folder.

## Performance

These wrappers are written more for direct compatibility with Unity and editor access.

It is not recommended to use these wrappers in performance demanding areas.

There is some overhead when using these wrappers and they use twice as much memory to hold the same amount of data as the raw Collections.
