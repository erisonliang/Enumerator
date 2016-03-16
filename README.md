# Enumerator

A fast, value-type enumerator for arrays in .NET.

## Installation

Run this from the NuGet console:

```powershell
Install-Package Enumerator
```

## What is this for?

If you're building your own collection class in .NET and it uses an array as its backing store, then this is the package for you. What it does is essentially provide optimized, value-type implementations of `GetEnumerator` so when a user does a `foreach` through your collection it'll be as fast as lightning.

## Usage

```csharp
public class MyCollection<T> : IEnumerable<T>
{
    private T[] array;
    
    public StructEnumerator<T> GetEnumerator() =>
        Enumerator.Struct(array);
    
    IEnumerator<T> IEnumerable<T>.GetEnumerator() =>
        Enumerator.Class(array); // avoid boxing of value types
    
    IEnumerator IEnumerable.GetEnumerator() =>
        this.GetEnumerator();
}
```