# EnumExtensions

Source generator that generates useful extension and utility methods for enums

## Usage

- Annotate your enum with `[GenerateExtensions]` Attribute
  > You can optionally provide a `ClassName` for the generated class like so: `[GenerateExtensions(ClassName = "NameOfGeneratedClass")]`. By default, the name of the enum followed by the "Extensions" suffix is used as the class name.
  > Similarly, You can also provide an optional `Namespace` for the generated class. Default namespace is the same as the enum.
- Done!

```csharp
using EnumExtensions;

[GenerateExtensions]
enum Direction
{
    Up,
    Down,
    Left,
    Right
}
```

## Installation

### NuGet

TODO

### Unity

TODO

## Generated Methods

- `Is*()`
- `GetValues()`
- `GetNames()`
- `GetValuesEnumerable()`
- `GetNamesEnumerable()`
- `ToStringFast()`
- `Next()`
- `Previous()`
- `GetRandomValue()`
- `GetRandomValueExcluding()`
- `TryParse()`
- `Parse()`
- `ParseOrDefault()`
- `ParseOrThrow()`
- `ParseOrElse()`
- `TryParseIgnoreCase()`
- `ParseIgnoreCase()`
- `ParseOrDefaultIgnoreCase()`
- `ParseOrThrowIgnoreCase()`
- `ParseOrElseIgnoreCase()`
