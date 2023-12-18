# Schema language definition

> See [Definition](Definition.md) on how to read the definitions below.
>
> Including PEG definitions for Common and Constant terms.

## Schema

```PEG
Schema = Declaration+

Declaration = STRING? ( Category | Directive | Option | Type )
Type = Enum | Input | Output | Scalar

Aliases = '[' alias+ ']'
```

A Schema is one (or more) Declarations. Each declaration can be preceded by a documentation string.

Declarations have the following general form:

> `label name Parameters? Aliases? '{' ( '(' Options ')' )? Definition '}'`

Multiple Declarations with the same label and name are permitted if their Options and Definitions can be merged.
When merging Declarations, Parameters and Aliases will be merged.

The following declarations are implied but can be specified explicitly:

- `category { Query }` and thus `output Query { }`
- `category { (sequential) Mutation }` and thus `output Mutation { }`
- `category { (single) Subscription }` and thus `output Subscription { }`
- `output _Schema { ... }` (see [Introspection](Introspection.md))

### Names and Aliases

Many named items can also have Aliases, which are a list of alternate ids for a given item.

Within any list of named items with Aliases, after merging, Aliases must be unique.
Any conflicts between names and Aliases will be resolved in the favour of the name,
ie. Any Aliases in a list of items that match any of the item's names will simply be removed.

### Merging (and De-duplicating)

Some item lists can be merged and thus de-duplicated.

Merging two (or more) lists will be done by some matching criteria.
If the items are named the default matching criteria is by name.

- List components of any matching items will be merged.
- Other (ie, not lists or part of the matching criteria) required components of any matching items must be the same.
- Optional components, if present, must be the same.
- If only present on some items before merging, optional components will be retained on the merged item.

De-duplicating two (or more) lists will be done by the matching criteria.
As order is significant in most lists, the first item of any duplicates will be kept, possibly updated by any merging.

It is an error if merging of duplicate items is not possible.

## Category declaration

```PEG
Category = 'category' category? Aliases? '{' ( '(' Cat_Option ')' )? output '}'
Cat_Option = 'parallel' | 'sequential' | 'single'
```

A Category is a set of fields defined by an Output type.

A Category has a default name of the Output type name with the first character changed to lowercase.

By default an operation over a Category can specify multiple fields that are resolved in parallel
but this can be changed with the following Category Options:

| Option       | Description                                                                                     |
| ------------ | ----------------------------------------------------------------------------------------------- |
| `parallel`   | Multiple fields specified in an operation of this category will be resolved asynchronously.     |
| `sequential` | Multiple fields specified in an operation of this category will be resolved in the order given. |
| `single`     | One and only one field can be specified in an operation of this category.                       |

Categories can be merged if their Options and Output Types match.

## Directive declaration

```PEG
Directive = 'directive' '@'directive InputParameters? Aliases? '{' Dir_Repeatable? Dir_Location+ '}'
Dir_Repeatable = '(' 'repeatable' ')'
Dir_Location = 'Operation' | 'Variable' | 'Field' | 'Inline' | 'Spread' | 'Fragment'
```

A Directive is defined with a set of Locations where it may appear in an Operation.
A Directive may have Input Parameters.

By default a Directive can only appear once at any Location, but this can be changed with the `repeatable` Directive option.

Directives can be merged if their Options match and their Parameters can be merged.

Locations will be merged by value.

## Option declaration

```PEG
Option = 'option' name Aliases? '{' Opt_Setting* '}'
Opt_Setting = Opt_Kind '=' Boolean
Opt_Kind = 'Strict' | 'GraphQl_Compatibility'
```

An Option defines valid options for the Schema as a whole, including the Schema name and Aliases.
A Schema must have only one name.

Options can be merged if Option Settings are unique.

## Type declarations

Most declarations define a Type.

The names and Aliases of all Types must be unique across all kinds of Types within the Schema.
Merging of Types is only possible if the kinds match.

### Built-In types

```PEG
Internal = 'Null' | 'null' | 'Object' | '%' | 'Void'  # Redefined

Simple = Basic | scalar | enum  # Redefined
```

The above types from [Definition](Definition.md) are redefined for Schemas

<details>
<summary>Built-In types</summary>

<i>The following GraphQlPlus isn't strictly valid but ...</i>

Boolean, Null, Unit and Void are effectively enum types as follows:

```gqlp
enum Boolean [~] { true false }

enum Null [null] { null }

enum Unit [_] { _ }

enum Void { }  # no valid value
```

Number and String are effectively scalar types as follows:

```gqlp
scalar Number [0] { Number }

scalar String [*] { String }
```

Object is a general Dictionary as follows:

```gqlp
"%"
input|output _Object [Object,%] { : _Map<Any> } // recursive

input|output _Most<$T> [Most] { $T | Object | _Most<$T>? | _Most<$T>[] | _Most<$T>[Simple] | _Most<$T>[Simple?] } // recursive! not in _Input or _Output

input _Any [Any] { : _Most<_Input> } // not in _Input
output _Any [Any] { : _Most<_Output> } // not in _Output
scalar _Any [Any] { | Basic | Internal | _Enum | _Scalar } // not in _Scalar
```

The internal types `_Scalar`, `_Output`, `_Input` and `_Enum` are automatically defined to be a union of all Scalar, Output, Input and Enum types respectively.

</details>

## Enum type

```PEG
Enum = 'enum' enum Aliases? '{' ( ':' enum )? En_Value+ '}'
En_Value = STRING? value Aliases?
```

An Enum is a Type defined with one or more Values.

Each Value can be preceded by a documentation string and may have one or more Aliases.

An Enum can extend another Enum, called it's base Enum, and it's Values are merged into the base Enum's Values.
An Enum cannot be based on itself, recursively.

Enums can be merged if their base Enums match and their Values can be merged.

## Scalar type

```PEG
Scalar = 'scalar' scalar Aliases? '{' ScalarDefinition '}'
ScalarDefinition = Scal_Number | Scal_String | Scalar_Union

Scal_Number = 'Number' Scal_Range*
Scal_String = 'String' Scal_Regex*
Scal_Union = 'Union' Scal_Reference+

Scal_Range = ':' '<'? NUMBER | NUMBER '>'? ':' ( '<'? NUMBER )?
Scal_RegEx = REGEX '!'?
Scal_Reference = '|' Simple
```

Scalar types define specific domains of the following kinds:

- Numbers, possibly only those in a given range. Ranges may be upper and/or lower bounded and each bound may be inclusive or exclusive.
- Strings, possibly only those that match (or don't match) one or more regular expressions.
- Union of one or more Simple types. A Scalar Union must not include itself, recursively.

Scalar declarations can be merged if their kinds match and their Ranges or Regexes can be merged.

## Object Union types

Input and Output types are both Object Union types.

```PEG
# base definition
Object = 'object' object TypeParameters? Aliases? '{' Obj_Definition '}'
Obj_Definition = Obj_Object? Obj_Alternate*
Obj_Object = ( ':' STRING? Obj_Base )? Obj_Field+
Obj_Field = STRING? field fieldAlias* ':' STRING? Obj_Reference Modifiers?

Obj_Alternate = '|' STRING? Obj_Reference Modifiers?
Obj_Reference = Internal | Simple | Obj_Base
Obj_Base = '$'typeParameter | object ( '<' STRING? Obj_Reference+ '>' )?

TypeParameters = '<' ( STRING? '$'typeParameter )+ '>'
```

Type parameters can be defined on Object union types. Each parameter can be preceded by a documentation string.

An Object Union type is defined as either:

- an object definition followed by zero or more Alternate object Type references, or
- one or more Alternate object Type references

The order of Alternates is significant.
An Alternate must not include itelf, recursively.

An object Type reference may be an Internal, Simple or another object Type.
If an object Type it may have Type Arguments of object Type references.

An object is defined with an optional base Type and has one or more Fields.
An object most not be based on itself, recursively.

A Field is defined with at least:

- an optional documentation string,
- a Field name
- zero or more Field Aliases
- a type parameter or object type references, the Field's base Type
- zero or more Modifiers

Field names and Field Aliases must be unique within the object, including any base object.
Explicit Field names will override the same name being used as a Field Alias.

Object Unions can be merged if their base Types match and their Fields and Alternates can both be merged.

Fields can be merged if their Modified Types match.

Alternates are merged by Type and can be merged if their Modifiers match.

### Parameter

```PEG
InputParameters = '(' InParam_Type+ ')'
InParam_Type = STRING? In_Reference Modifiers? Default?
```

Input Parameters define one or more Alternate Input type references, possibly with a documentation string, Modifiers and/or a Default.

The order of Alternates is significant.
Alternates are merged by their Input type and can be merged if their Modifiers match.

### Modifiers

Note that Schema Modifiers include Scalar and Enum types as valid Dictionary keys.

<details>
<summary>Modifiers</summary>

<i>The following GraphQlPlus isn't strictly valid but ...</i>

Modifiers are equivalent to predefined generic Input and Output types as follows:

```gqlp
"$T?"
input|output _Opt<$T> [Opt] { $T | Null }

"$T[]"
input|output _List<$T> [List] { $T[] }

"$T[$K]"
input|output _Dict<$K $T> [Dict] { $K: $T }
```

The following GraphQlPlus idioms have equivalent generic Input and Output types.

```gqlp
"$T[*]"
input|output _Map<$T> [Map] { _Dict<String $T> }

"$T[0]"
input|output _Array<$T> [Array] { _Dict<Number $T> }

"$T[~]"
input|output _IfElse<$T> [IfElse] { _Dict<Boolean $T> }

"_[$K]"
input|output _Set<$K> [Set] { _Dict<$K Unit> }

"~[$K]"
input|output _Mask<$K> [Mask] { _Dict<$K Boolean> }
```

These Generic types are the Input types if `$T` is an Input type and Output types if `$T` is an Output type.

`Set`, `Object` and `Mask` are both Input and Output types.

</details>

| Syntax                     | Generic type                             |
| -------------------------- | ---------------------------------------- |
| `String?`                  | Opt<String>                              |
| `String[]`                 | List<String>                             |
| `String[]?`                | Opt<List<String>>                        |
| `String[Number?]`          | Dict<Opt<Number> String>                 |
| `String[][Number][Unit?]?` | Opt<Dict<Opt<Unit> Array<List<String>>>> |

## Input type

```PEG
Input = 'input' input TypeParameters? Aliases? '{' In_Definition '}'
In_Definition = In_Object? In_Alternate*
In_Object = ( ':' STRING? In_Base )? In_Field+
In_Field = STRING? field fieldAlias* ':' STRING? In_Reference Modifiers? Default?

In_Alternate = '|' STRING? In_Reference Modifiers?
In_Reference = Internal | Simple | In_Base
In_Base = '$'typeParameter | input ( '<' STRING? In_Reference+ '>' )?
```

Input types define the type of Output field's Argument.

An Input type is defined as an object union type with the following alterations.

An Input Field redefines an object Field as follows:

- an optional documentation string,
- a Field name
- zero or more Field Aliases
- a type parameter or Input type references
- zero or more type Modifiers
- an optional Default value

A Default of `null` is only allowed on Optional fields. The Default must be compatible with the Modified Type of the field.

## Output type

```PEG
Output = 'output' output TypeParameters? Aliases? '{' Out_Definition '}'
Out_Definition = Out_Object? Out_Alternate*
Out_Object = ( ':' STRING? Out_Base )? ( STRING? field Out_EnumField )+
Out_EnumField = Out_Field | Out_Enum
Out_Field = InputParameters? fieldAlias* ':' STRING? Out_Reference Modifiers?
Out_Enum = fieldAlias* '=' STRING? EnumValue

Out_Alternate = '|' STRING? Out_Reference Modifiers?
Out_Reference = Internal | Simple | Out_Base
Out_Base = '$'typeParameter | output ( '<' ( STRING? Out_Reference |  STRING? EnumValue )+ '>' )?
```

Output types define the result values for Categories and Output fields.

An Output type is defined as an object union type with the following alterations.

An Output type reference may have Type Arguments of Output type references and/or Enum Values.
If there is a conflict between a bare Enum Value and a Type, the Type will have precedence.

An Output Field redefines an object Field as follows:

- an optional documentation string,
- a Field name
- optional Input Parameters
- zero or more Field Aliases
- a type parameter or an Output type reference
- zero or more type Modifiers

or:

- an optional documentation string,
- a Field name
- zero or more Field Aliases
- an Enum Value (which will imply the field Type)

## Complete Grammar

```PEG
Schema = Declaration+

Declaration = STRING? ( Category | Directive | Option | Type )
Type = Enum | Input | Output | Scalar

Aliases = '[' alias+ ']'

Category = 'category' category? Aliases? '{' ( '(' Cat_Option ')' )? output '}'
Cat_Option = 'parallel' | 'sequential' | 'single'

Directive = 'directive' '@'directive InputParameters? Aliases? '{' Dir_Repeatable? Dir_Location+ '}'
Dir_Repeatable = '(' 'repeatable' ')'
Dir_Location = 'Operation' | 'Variable' | 'Field' | 'Inline' | 'Spread' | 'Fragment'

Option = 'option' name Aliases? '{' Opt_Setting* '}'
Opt_Setting = Opt_Kind '=' Boolean
Opt_Kind = 'Strict' | 'GraphQl_Compatibility'

Internal = 'Null' | 'null' | 'Object' | '%' | 'Void'  # Redefined

Simple = Basic | scalar | enum  # Redefined

Enum = 'enum' enum Aliases? '{' ( ':' enum )? En_Value+ '}'
En_Value = STRING? value Aliases?

Scalar = 'scalar' scalar Aliases? '{' ScalarDefinition '}'
ScalarDefinition = Scal_Number | Scal_String | Scalar_Union

Scal_Number = 'Number' Scal_Range*
Scal_String = 'String' Scal_Regex*
Scal_Union = 'Union' Scal_Reference+

Scal_Range = ':' '<'? NUMBER | NUMBER '>'? ':' ( '<'? NUMBER )?
Scal_RegEx = REGEX '!'?
Scal_Reference = '|' Simple

# base definition
Object = 'object' object TypeParameters? Aliases? '{' Obj_Definition '}'
Obj_Definition = Obj_Object? Obj_Alternate*
Obj_Object = ( ':' STRING? Obj_Base )? Obj_Field+
Obj_Field = STRING? field fieldAlias* ':' STRING? Obj_Reference Modifiers?

Obj_Alternate = '|' STRING? Obj_Reference Modifiers?
Obj_Reference = Internal | Simple | Obj_Base
Obj_Base = '$'typeParameter | object ( '<' STRING? Obj_Reference+ '>' )?

TypeParameters = '<' ( STRING? '$'typeParameter )+ '>'

InputParameters = '(' InParam_Type+ ')'
InParam_Type = STRING? In_Reference Modifiers? Default?

Input = 'input' input TypeParameters? Aliases? '{' In_Definition '}'
In_Definition = In_Object? In_Alternate*
In_Object = ( ':' STRING? In_Base )? In_Field+
In_Field = STRING? field fieldAlias* ':' STRING? In_Reference Modifiers? Default?

In_Alternate = '|' STRING? In_Reference Modifiers?
In_Reference = Internal | Simple | In_Base
In_Base = '$'typeParameter | input ( '<' STRING? In_Reference+ '>' )?

Output = 'output' output TypeParameters? Aliases? '{' Out_Definition '}'
Out_Definition = Out_Object? Out_Alternate*
Out_Object = ( ':' STRING? Out_Base )? ( STRING? field Out_EnumField )+
Out_EnumField = Out_Field | Out_Enum
Out_Field = InputParameters? fieldAlias* ':' STRING? Out_Reference Modifiers?
Out_Enum = fieldAlias* '=' STRING? EnumValue

Out_Alternate = '|' STRING? Out_Reference Modifiers?
Out_Reference = Internal | Simple | Out_Base
Out_Base = '$'typeParameter | output ( '<' ( STRING? Out_Reference |  STRING? EnumValue )+ '>' )?

```
