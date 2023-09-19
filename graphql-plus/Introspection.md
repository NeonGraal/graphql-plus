# Schema Introspection

The `_Schema` output type is automatically defined as followed and can be used to allow introspection either through a Category or an Output field.

## Schema

```gqlp
output _Schema = {
        category(_CategoryFilter): _Category[String]
        directive(_Filter): _Directive[String]
        type(_TypeFilter): _Type[String]
    }

input _Filter =  {
        names: String[]
        includeReferencedTypes: Boolean = false
    } String[]?

input _CategoryFilter = _Filter {
        resolutions: _Resolution[]
    }

input _TypeFilter = _Filter {
        kinds: _Kind[]
    }

output _Aliased = _Named {
        aliases: String[]
    }

output _Named = {
        name: String
        description: String?
    }
```

## Category

```gqlp
output _Category = _Aliased {
        resolution: _Resolution
        type: _Type[String]
    }

enum _Resolution = Single | Sequential | Parallel
```

## Directive

```gqlp
output _Directive = _Aliased {
    parameter: _Parameter?
    repeatable: Boolean
    locations: _Location[]
}

output _Parameter = _TypeRef<_InputBase> {
        modifiers: _TypeModifier[]
        default: _Constant
    }
```

## Type

```gqlp
output _Type = _BaseType<_Kind.Basic>
    | _BaseType<_Kind.Internal>
    | _TypeEnum
    | _TypeObject<_Kind.Input _InputBase _InputField>
    | _TypeObject<_Kind.Output _OutputBase _OutputField>
    | _TypeScalar

output _BaseType<$kind> = _Aliased {
        kind: $kind
    }

enum _Kind = Basic | Enum | Internal | Input | Output | Scalar

output _TypeObject<$kind $base $field> =_BaseType<$kind> {
        parameters: _Named[]
        base: $base?
        fields: $field[]
        alternates: $_TypeRef<$base>[]
    }

output _TypeRef<$base> = _BaseType<_Kind.Internal>
    | _TypeSimple
    | $base

output _TypeField<$base> = _Aliased {
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
        base: String?
        labels: _Aliased[]
    }
```

## Input

```gqlp
output _InputBase = {
        input: String
        arguments: _TypeRef<_InputBase>[]
    } "TypeParameter" String

output _InputField = _TypeField<_InputBase>
```

## Output

```gqlp
output _OutputBase = {
        output: String
        arguments: _OutputArgument[]
    } "TypeParameter" String

output _OutputField = _TypeField<_OutputBase> {
        parameter: _Parameter?
    } _OutputEnum

output _OutputArgument = _BaseType<_Kind.Enum> {
        label: String
    } _TypeRef<_OutputBase>

output _OutputEnum = _BaseType<_Kind.Enum> {
        field: String
        label: String
    }
```

## Scalar

```gqlp
enum _Scalar = Number | String

output _TypeScalar = _ScalarNumber | _ScalarString

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

## Complete Definition

```gqlp
output _Schema = {
        category(_CategoryFilter): _Category[String]
        directive(_Filter): _Directive[String]
        type(_TypeFilter): _Type[String]
    }

input _Filter =  {
        names: String[]
        includeReferencedTypes: Boolean = false
    } String[]?

input _CategoryFilter = _Filter {
        resolutions: _Resolution[]
    }

input _TypeFilter = _Filter {
        kinds: _Kind[]
    }

output _Aliased = _Named {
        aliases: String[]
    }

output _Named = {
        name: String
        description: String?
    }

output _Category = _Aliased {
        resolution: _Resolution
        type: _Type[String]
    }

enum _Resolution = Single | Sequential | Parallel

output _Directive = _Aliased {
    parameter: _Parameter?
    repeatable: Boolean
    locations: _Location[]
}

output _Parameter = _TypeRef<_InputBase> {
        modifiers: _TypeModifier[]
        default: _Constant
    }

output _Type = _BaseType<_Kind.Basic>
    | _BaseType<_Kind.Internal>
    | _TypeEnum
    | _TypeObject<_Kind.Input _InputBase _InputField>
    | _TypeObject<_Kind.Output _OutputBase _OutputField>
    | _TypeScalar

output _BaseType<$kind> = _Aliased {
        kind: $kind
    }

enum _Kind = Basic | Enum | Internal | Input | Output | Scalar

output _TypeObject<$kind $base $field> =_BaseType<$kind> {
        parameters: _Named[]
        base: $base?
        fields: $field[]
        alternates: $_TypeRef<$base>[]
    }

output _TypeRef<$base> = _BaseType<_Kind.Internal>
    | _TypeSimple
    | $base

output _TypeField<$base> = _Aliased {
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

output _TypeEnum = _BaseType<_Kind.Enum> {
        base: String?
        labels: _Aliased[]
    }

output _InputBase = {
        input: String
        arguments: _TypeRef<_InputBase>[]
    } "TypeParameter" String

output _InputField = _TypeField<_InputBase>

output _OutputBase = {
        output: String
        arguments: _OutputArgument[]
    } "TypeParameter" String

output _OutputField = _TypeField<_OutputBase> {
        parameter: _Parameter?
    } _OutputEnum

output _OutputArgument = _BaseType<_Kind.Enum> {
        label: String
    } _TypeRef<_OutputBase>

output _OutputEnum = _BaseType<_Kind.Enum> {
        field: String
        label: String
    }

enum _Scalar = Number | String

output _TypeScalar = _ScalarNumber | _ScalarString

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
