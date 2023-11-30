# Schema Introspection

The `_Schema` output type is automatically defined as followed and can be used to allow introspection either through a Category or an Output field.

## Schema

```gqlp
output _Schema {
        category(_CategoryFilter): _Category[String]
        directive(_Filter): _Directive[String]
        type(_TypeFilter): _Type[String]
    }

input _Filter  {
        names: String[]
        includeReferencedTypes: Boolean = false
    | "Names" String[]?
    }

input _CategoryFilter {
    : _Filter
        resolutions: _Resolution[]
    }

input _TypeFilter {
    : _Filter
        kinds: _TypeKind[]
    }

output _Aliased {
    : _Named
        aliases: String[]
    }

output _Named {
        name: String
        description: String?
    }
```

## Category

```gqlp
output _Category {
    : _Aliased
        resolution: _Resolution
        type: _Type[String]
    }

enum _Resolution { Single Sequential Parallel }
```

## Directive

```gqlp
output _Directive {
    : _Aliased
        parameters: _Parameter[]
        repeatable: Boolean
        locations: _Location[]
    }

```

## Type

```gqlp
output _Type {
    | _BaseType<_TypeKind.Basic>
    | _BaseType<_TypeKind.Internal>
    | _TypeEnum
    | _TypeObject<_TypeKind.Input _InputBase _InputField>
    | _TypeObject<_TypeKind.Output _OutputBase _OutputField>
    | _TypeScalar
    }

output _BaseType<$kind> {
    : _Aliased
        kind: $kind
    }

enum _TypeKind { Basic Enum Internal Input Output Scalar }

output _TypeSimple {
    | _BaseType<_TypeKind.Basic>
    | _BaseType<_TypeKind.Scalar>
    | _BaseType<_TypeKind.Enum>
    }
```

## Enum

```gqlp
output _TypeEnum {
    : _BaseType<_TypeKind.Enum>
        base: String?
        labels: _Aliased[]
    }
```

## Object Union Type

```gqlp
output _TypeObject<$kind $base $field> {
    : _BaseType<$kind>
        typeParameters: _Named[]
        base: $base?
        fields: $field[]
        alternates: _Alternate<$base>[]
    }

output _Ref<$base> {
    | _BaseType<_TypeKind.Internal>
    | _TypeSimple
    | $base
    }

output _Alternate<$base> {
      type: _Ref<$base>
      modifiers: _Modifier[]
    }

output _Field<$base> {
    : _Aliased
      type: _Ref<$base>
      modifiers: _Modifier[]
    }

output _Parameter {
    : _Ref<_InputBase>
        modifiers: _Modifier[]
        default: _Constant
    }

output _Modifier = {
    | _BaseModifier<_ModifierKind.Optional>
    | _BaseModifier<_ModifierKind.List>
    | _ModifierDictionary
    }

enum _ModifierKind { Optional List ModifierDictionary }

output _BaseModifier<$kind> {
        kind: $kind
    }

output _ModifierDictionary {
    : _BaseModifier<_ModifierKind.Dictionary>
        by: _TypeSimple
    }
```

## Input

```gqlp
output _InputBase {
        input: String
        arguments: _Ref<_InputBase>[]
    | "TypeParameter" String
    }

output _InputField {
    | _Field<_InputBase>
    }
```

## Output

```gqlp
output _OutputBase {
        output: String
        arguments: _OutputArgument[]
    | "TypeParameter" String
    }

output _OutputField {
    : _Field<_OutputBase>
        parameter: _Parameter[]
    | _OutputEnum
    }

output _OutputArgument {
    : _BaseType<_TypeKind.Enum>
        label: String
    | _Ref<_OutputBase>
    }

output _OutputEnum {
    : _BaseType<_TypeKind.Enum>
        field: String
        label: String
    }
```

## Scalar

```gqlp
enum _Scalar { Number String }

output _TypeScalar {
    | _ScalarNumber
    | _ScalarString
    }

output _BaseScalar<$base> {
    : _BaseType<_TypeKind.Scalar>
        base: $base
    }

output _ScalarNumber {
    : _BaseScalar<_Scalar.Number>
        ranges: _ScalarRange[]
    }

output _ScalarRange {
        from: Number?
        fromInclusive: Boolean
        to: Number?
        toInclusive: Boolean
    }

output _ScalarString {
    : _BaseScalar<_Scalar.String>
        regexes: _ScalarRegex[]
    }

output _ScalarRegex {
        regex: String
        exclude: Boolean
    }
```

## Complete Definition

```gqlp
output _Schema {
        category(_CategoryFilter): _Category[String]
        directive(_Filter): _Directive[String]
        type(_TypeFilter): _Type[String]
    }

input _Filter  {
        names: String[]
        includeReferencedTypes: Boolean = false
    | "Names" String[]?
    }

input _CategoryFilter {
    : _Filter
        resolutions: _Resolution[]
    }

input _TypeFilter {
    : _Filter
        kinds: _TypeKind[]
    }

output _Aliased {
    : _Named
        aliases: String[]
    }

output _Named {
        name: String
        description: String?
    }

output _Category {
    : _Aliased
        resolution: _Resolution
        type: _Type[String]
    }

enum _Resolution { Single Sequential Parallel }

output _Directive {
    : _Aliased
        parameters: _Parameter[]
        repeatable: Boolean
        locations: _Location[]
    }


output _Type {
    | _BaseType<_TypeKind.Basic>
    | _BaseType<_TypeKind.Internal>
    | _TypeEnum
    | _TypeObject<_TypeKind.Input _InputBase _InputField>
    | _TypeObject<_TypeKind.Output _OutputBase _OutputField>
    | _TypeScalar
    }

output _BaseType<$kind> {
    : _Aliased
        kind: $kind
    }

enum _TypeKind { Basic Enum Internal Input Output Scalar }

output _TypeSimple {
    | _BaseType<_TypeKind.Basic>
    | _BaseType<_TypeKind.Scalar>
    | _BaseType<_TypeKind.Enum>
    }

output _TypeEnum {
    : _BaseType<_TypeKind.Enum>
        base: String?
        labels: _Aliased[]
    }

output _TypeObject<$kind $base $field> {
    : _BaseType<$kind>
        typeParameters: _Named[]
        base: $base?
        fields: $field[]
        alternates: _Alternate<$base>[]
    }

output _Ref<$base> {
    | _BaseType<_TypeKind.Internal>
    | _TypeSimple
    | $base
    }

output _Alternate<$base> {
      type: _Ref<$base>
      modifiers: _Modifier[]
    }

output _Field<$base> {
    : _Aliased
      type: _Ref<$base>
      modifiers: _Modifier[]
    }

output _Parameter {
    : _Ref<_InputBase>
        modifiers: _Modifier[]
        default: _Constant
    }

output _Modifier = {
    | _BaseModifier<_ModifierKind.Optional>
    | _BaseModifier<_ModifierKind.List>
    | _ModifierDictionary
    }

enum _ModifierKind { Optional List ModifierDictionary }

output _BaseModifier<$kind> {
        kind: $kind
    }

output _ModifierDictionary {
    : _BaseModifier<_ModifierKind.Dictionary>
        by: _TypeSimple
    }

output _InputBase {
        input: String
        arguments: _Ref<_InputBase>[]
    | "TypeParameter" String
    }

output _InputField {
    | _Field<_InputBase>
    }

output _OutputBase {
        output: String
        arguments: _OutputArgument[]
    | "TypeParameter" String
    }

output _OutputField {
    : _Field<_OutputBase>
        parameter: _Parameter[]
    | _OutputEnum
    }

output _OutputArgument {
    : _BaseType<_TypeKind.Enum>
        label: String
    | _Ref<_OutputBase>
    }

output _OutputEnum {
    : _BaseType<_TypeKind.Enum>
        field: String
        label: String
    }

enum _Scalar { Number String }

output _TypeScalar {
    | _ScalarNumber
    | _ScalarString
    }

output _BaseScalar<$base> {
    : _BaseType<_TypeKind.Scalar>
        base: $base
    }

output _ScalarNumber {
    : _BaseScalar<_Scalar.Number>
        ranges: _ScalarRange[]
    }

output _ScalarRange {
        from: Number?
        fromInclusive: Boolean
        to: Number?
        toInclusive: Boolean
    }

output _ScalarString {
    : _BaseScalar<_Scalar.String>
        regexes: _ScalarRegex[]
    }

output _ScalarRegex {
        regex: String
        exclude: Boolean
    }

```
