# Schema Introspection

The `_Schema` output type is automatically defined as followed and can be used to allow introspection either through a Category or an Output field.

<details>

```gql

output _Schema = {
        category(String?) : _Category[String]
        type(String?) : _Type[String]
    }

output _Category = {
        name : String
        resolution : _Resolution
        alias : String[]
    }

enum _Resolution = Single | Sequential | Parallel

output _BaseType<$kind> = {
        name : String
        kind : $kind
    }

output _Type = _BaseType<_Kind.Basic>
      | _BaseType<_Kind.Internal>
      | _BaseType<_Kind.Enum> {
        labels : String[]
    } | _BaseType<_Kind.Input> {
        parameters : String[]
        variants : _InputType[]
    } | _BaseType<_Kind.Output> {
        parameters : String[]
        variants : _OutputType[]
    } | _BaseType<_Kind.Scalar>

enum _Kind = Basic | Enum | Internal | Input | Output | Scalar

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

</details>

## Category

```gql
output _Category = {
        name : String
        resolution : _Resolution
        alias : String[]
    }

enum _Resolution = Single | Sequential | Parallel
```

## Type

```gql
output _BaseType = {
        name : String
        kind : _Kind
    }

output _Type = _BaseType {
        kind = Basic
    } | _BaseType {
        kind = Enum
        labels : String[]
    } | _BaseType {
        kind = Internal
    } | _BaseType {
        kind = Input
    } | _BaseType {
        kind = Output
    } | _BaseType {
        kind = Scalar
    }

enum _Kind = Basic | Enum | Internal | Input | Output | Scalar
```
