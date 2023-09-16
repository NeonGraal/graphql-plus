# Schema Introspection

The `_Schema` output type is automatically defined as followed and can be used to allow introspection either through a Category or an Output field.

## Schema

```gqlp
output _Schema = {
        category(_Names?) : _Category[String]
        type(_Names?) : _Type[String]
    }

input _Names = String | String[]
```

## Common

```gqlp
output _Named = {
        name : String
        description: String?
    }
```

## Category

```gqlp
output _Category = _Named {
        resolution : _Resolution
        alias : String[]
    }

enum _Resolution = Single | Sequential | Parallel
```

## Type

```gqlp
output _Type = _BaseType<_Kind.Basic>
      | _BaseType<_Kind.Internal>
      | _TypeEnum
      | _TypeObject<_Kind.Input _InputType>
      | _TypeObject<_Kind.Output _OutputType>
      | _BaseType<_Kind.Scalar>

output _BaseType<$kind> = _Named {
        kind : $kind
    }

enum _Kind = Basic | Enum | Internal | Input | Output | Scalar

output _TypeObject<$kind $variant> =_BaseType<$kind> {
        parameters : _Named[]
        variants : $variant[]
    }
```

## Enum

```gqlp
output _TypeEnum = _BaseType<_Kind.Enum> {
        labels : _Named[]
    }
```

## Input

```gqlp
output _InputType = {
        reference : _TypeRef
        modifiers : _Modifier[]
    } | {
        typeParameter : String
        modifiers: _Modifier[]
    } | {
        base : _InputBase
        fields : _
    }

output _InputBase = {

    }
```

## Output

```gqlp
output _OutputType = {

}
```

## Full Definition

```gqlp

input _Names = String | String[]

output _Schema = {
        category(_Names?) : _Category[String]
        type(_Names?) : _Type[String]
    }

output _Category = _Named {
        resolution : _Resolution
        alias : String[]
    }

output _Named = {
        name : String
        description: String?
    }

enum _Resolution = Single | Sequential | Parallel

output _Type = _BaseType<_Kind.Basic>
      | _BaseType<_Kind.Internal>
      | _TypeEnum
      | _TypeObject<_Kind.Input _InputType>
      | _TypeObject<_Kind.Output _OutputType>
      | _BaseType<_Kind.Scalar>

output _BaseType<$kind> = _Named {
        kind : $kind
    }

enum _Kind = Basic | Enum | Internal | Input | Output | Scalar

output _TypeEnum = _BaseType<_Kind.Enum> {
        labels : _Named[]
    }

output _TypeObject<$kind $variant> =_BaseType<$kind> {
        parameters : _Named[]
        variants : $variant[]
    }

output _InputType = {
        reference : _TypeRef
        modifiers : _Modifier[]
    } | {
        typeParameter : String
        modifiers: _Modifier[]
    } | {
        base : _InputBase
        fields : _
    }

output _InputBase = {

    }

```
