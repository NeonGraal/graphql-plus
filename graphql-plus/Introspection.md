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
    | _TypeObject<_Kind.Input _InputBase _InputField>
    | _TypeObject<_Kind.Output _OutputBase _OutputField>
    | _TypeScalar

output _BaseType<$kind> = _Named {
        kind : $kind
    }

enum _Kind = Basic | Enum | Internal | Input | Output | Scalar

output _TypeObject<$kind $base $field> =_BaseType<$kind> {
        parameters : _Named[]
        base: $base?
        fields: $field[]
        alternates: $_TypeRef<$base>[]
    }

output _TypeRef<$base> = _BaseType<_Kind.Internal>
    | _TypeSimple
    | $base

output _TypeField<$base> = {
      field: String
      type: _TypeRef<$base>
      modifiers: _TypeModifier[]
    }

output _TypeSimple = _BaseType<_Kind.Basic>
    | _BaseType<_Kind.Scalar>
    | _BaseType<_Kind.Enum>

output _TypeModifier = _BaseModifier<_Modifier.Optional>
    | _BaseModifier<_Modifier.List>
    | _ModifierDictionary

enum _Modifier = Optional | List | ModifierDictionary

output _BaseModifier<$kind> = {
        kind: $kind
    }

output _ModifierDictionary = _BaseModifier<_Modifier.Dictionary> {
        by: _TypeSimple
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
output _InputBase = {
        input: String
        arguments: _TypeRef<_InputBase>[]
    }
    | "TypeParameter" String

output _InputField = _TypeField<_InputBase>
```

## Output

```gqlp
output _OutputBase = {
        input: String
        arguments: _OutputArgument[]
    }
    | "TypeParameter" String

output _OutputField = _OutputEnum {
        field: String
    }
    | _TypeField<_OutputBase>

output _OutputArgument = _OutputEnum
    | _TypeRef<_OutputBase>

output _OutputEnum = _BaseType<_Kind.Enum> {
        label: String
    }
```

## Scalar

```gqlp
enum _Scalar = Boolean | Number | String

output _TypeScalar = _BaseScalar<_Scalar.Boolean>
    | _ScalarNumber
    | _ScalarString

output _BaseScalar<$base> = _BaseType<_Kind.Scalar> {
        base: $base
    }

output _ScalarNumber = _BaseScalar<_Scalar.Number> {
        ranges: _ScalarRange[]
    }

output _ScalarRange = {
        from: Number?
        fromInclusive: Boolean
        to: Number?
        toInclusive: Boolean
    }

output _ScalarString = _BaseScalar<_Scalar.String> {
        regexes: _ScalarRegex[]
    }

output _ScalarRegex {
        regex: String
        exclude: Boolean
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
