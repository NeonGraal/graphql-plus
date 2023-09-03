# Schema Introspection

The `_Schema` output type is automatically defined as followed and can be used to allow introspection either through a Category or an Output field.

<details>

``` GraphQL-plus

output _Schema = {
        category(String?) : _Category[String]
        type(String?) : _Type[String]
    }

output _Category = {
        name : String
        resolution : _Resolution
        alias : String[]
    }

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

enum _Resolution = Single | Sequential | Parallel

enum _Kind = Basic | Enum | Internal | Input | Output | Scalar 

```

</details>

## Category

``` GraphQL-plus
output _Category = {
        name : String
        resolution : _Resolution
        alias : String[]
    }

enum _Resolution = Single | Sequential | Parallel
```

## Type

``` GraphQL-plus
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
