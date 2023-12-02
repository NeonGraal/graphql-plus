# Schema language definition

> See [Definition](Definition.md) on how to read the definitions below.
>
> Including PEG definitions for Common and Constant terms.

## Schema

```PEG
Schema = Declaration+

Declaration = STRING? ( Category | Directive | Type )
Type = Enum | Input | Output | Scalar

Aliases = '[' alias+ ']'
```

A Schema is one (or more) Declarations. Each declaration can be preceded by a documentation string.

Declarations have the following general form:

> `label name Parameters? Aliases? '{' ( '(' Options ')' )? Definition '}'`

The following declarations are implied but can be specified explicitly:

- `category { Query }` and thus `output Query { }`
- `category { (sequential) Mutation }` and thus `output Mutation { }`
- `category { (single) Subscription }` and thus `output Subscription { }`
- `output _Schema { ... }` (see [Introspection](Introspection.md))

### Types

Most declarations define a Type.

The names of all Types must be unique.
The Aliases of all Types must be unique.
Explicit Type name declarations will override that name being used as Type Alias.

### Merging and De-duplicating

Where duplicate definitions are permitted, some item lists can be merged and de-duplicated.

Merging two (or more) lists will be done by some matching criteria.
List components of any matching items will be merged and de-duplicated.
Other (ie, not lists or part of the matching criteria) required components of any matching items must be the same.
Optional components, if present, must be the same.
If only present on one item before merging, optional components will be retained on the merged item.

De-duplicating two (or more) lists will be done by the merging matching criteria.
As order is significant in most lists, the first item of any duplicates will be kept, possibly updated by any merging.

## Category

```PEG
Category = 'category' category? Aliases? '{' ( '(' Cat_Option ')' )? output '}'
Cat_Option = 'parallel' | 'sequential' | 'single'
```

A Category is a set of fields defined by an Output type.

A Category has a default name of the Output type name with the first character changed to lowercase.

By default an operation over a Category can specify multiple fields that are resolved in parallel but this can be changed with the following Category Options:

| Option       | Description                                                                                     |
| ------------ | ----------------------------------------------------------------------------------------------- |
| `parallel`   | Multiple fields specified in an operation of this category will be resolved asynchronously.     |
| `sequential` | Multiple fields specified in an operation of this category will be resolved in the order given. |
| `single`     | One and only one field can be specified in an operation of this category.                       |

Duplicate Category declarations are not permitted.
An explicit Category declaration for a name (even if defaulted from Output type) will override that name being used as an Alias for a different Category.

## Directive

```PEG
Directive = 'directive' '@'directive Parameter? Aliases? '{' Dir_Repeatable? Dir_Location+ '}'
Dir_Repeatable = '(' 'repeatable' ')'
Dir_Location = 'Operation' | 'Variable' | 'Field' | 'Inline' | 'Spread' | 'Fragment'
```

A Directive is defined by name and may have a Parameter.

Multiple Directive declarations with the same name will have their Parameters merged and de-duplicated.

## Enum type

```PEG
Enum = 'enum' enum Aliases? '{' ( ':' enum )? En_Label+ '}'
En_Label = STRING? label Aliases?
```

An Enum is a Type defined with one or more Labels.
Each Label can be preceded by a documentation string and may have one or more Aliases.
Label names and Label Aliases must be unique for that Enum.
Explicit Label names will override that name being used as a Label Alias.

An Enum can extend another Enum, called it's base Enum, and thus it's Labels are merged and de-duplicated into the base Enum's Labels.

Multiple Enum declarations with the same name but different base Enums are not permitted.
Multiple Enum declarations with the same name and base Enum, will have their Labels and Aliases merged and de-duplicated.

## Object Union types

Input and Output types are both Object Union types

```PEG
# base definition
Object = 'object' object TypeParameters? Aliases? '{' Obj_Definition '}'
Obj_Definition = Obj_Object? Obj_Alternate*
Obj_Object = ( ':' STRING? Obj_Base )? Obj_Field+
Obj_Field = STRING? field fieldAlias* ':' STRING? Obj_Reference Modifiers?

Obj_Alternate = '|' STRING? Obj_Reference Modifiers?
Obj_Reference = Internal | Simple | Obj_Base
Obj_Base = '$'typeParameter | input ( '<' STRING? Obj_Reference+ '>' )?

TypeParameters = '<' ( STRING? '$'typeParameter )+ '>'
```

Type parameters can be defined on Object union types. Each parameter can be preceded by a documentation string.

An Object Union type is defined as either:

- an object definition followed by zero or more Alternate object Type references, or
- one or more Alternate object Type references

The order of Alternates is significant.

An object Type reference may be an Internal, Simple or another object Type.
If an object Type it may have Type Arguments of object Type references.

An object is defined with an optional base Type and has one or more Fields.

A Field is defined with at least:

- an optional documentation string,
- a Field name
- zero or more Field Aliases
- a type parameter or object type references, the Field's base Type
- zero or more Modifiers

Field names and Field Aliases must be unique within the object, including any base object.
Explicit Field names will override the same name being used as a Field Alias.

Multiple object declarations with the same name but different base Type (including no base Type) are not permitted.
Multiple object declarations with the same name and base Type (or no base Type) will have their Fields merged and de-duplicated by name
and their Alternates merged and de-duplicated by Type.

When merging, Fields with the same name must have the same Modified Type.
Field Aliases will be merged and de-duplicated. Any Aliases matching Field names in the merged object will be discarded.

When merging, Alternates with the same Type must have the the same Modifiers (including none).

### Parameter

```PEG
Parameter = '(' Param_Type+ ')'
Param_Type = STRING? In_Reference Modifiers? Default?
```

A Parameter is one or more Alternate Input type references, possibly with a documentation string, Modifiers and/or a Default.

The order of Parameter Alternates is significant.
Parameter Alternates with the same Input Type but different Modifiers (including no Modifers) are not permitted.
Parameter Alternates are merged and de-duplicated by their Modified Input Type.

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
input|output Set<$K> { _Dict<$K Unit> }

"~[$K]"
input|output Mask<$K> { _Dict<$K Boolean> }
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
input|output Object [%] { _Map<Any> }

input|output _Any<$T> { $T | _Scalar | Object | _Enum | _Any<$T>? | _Any<$T>[] | _Any<$T>[Simple] | _Any<$T>[Simple?] }

input Any { _Any<_Input> }
output Any { _Any<_Output> }
```

The internal types `_Scalar`, `_Output`, `_Input` and `_Enum` are automatically defined to be a union of all Scalar, Output, Input and Enum types respectively.

</details>

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
Out_Object = ( ':' STRING? Out_Base )? ( STRING? field Out_Field )+
Out_Field = Parameter? fieldAlias* ':' STRING? Out_Reference Modifiers? | fieldAlias* '=' EnumLabel

Out_Alternate = '|' STRING? Out_Reference Modifiers?
Out_Reference = Internal | Simple | Out_Base
Out_Base = '$'typeParameter | output ( '<' ( STRING? Out_Reference | EnumLabel )+ '>' )?
```

Output types define the result values for Categories and Output fields.

An Output type is defined as an object union type with the following alterations.

An Output type reference may have Type Arguments of Output type references and/or Enum Labels.

An Output Field redefines an object Field as follows:

- an optional documentation string,
- a Field name
- an optional Parameter
- zero or more Field Aliases
- a type parameter or an Output type reference
- zero or more type Modifiers

or:

- an optional documentation string,
- a Field name
- zero or more Field Aliases
- an Enum Label (which will imply the field Type)

## Scalar type

```PEG
Scalar = 'scalar' scalar Aliases? '{' ScalarDefinition '}'
ScalarDefinition = Scal_Number | Scal_String

Scal_Number = 'Number' Scal_Range*
Scal_String = 'String' Scal_Regex*

Scal_Range = '..' '<'? NUMBER | NUMBER '>'? '..' ( '<'? NUMBER )?
Scal_RegEx = REGEX '!'?
```

Scalar types define specific domains of:

- Numbers, possibly only those in a given range. Ranges may be upper and/or lower bounded and each bound may be inclusive or exclusive.
- Strings, possibly only those that match (or don't match) one or more regular expressions.

Duplicate Scalar declarations for a name with different bases are not permitted.
Multiple Scalar declarations with the same name and base will have their Ranges or Regexes merged and de-duplicated.

## Complete Grammar

```PEG
Schema = Declaration+

Declaration = STRING? ( Category | Directive | Type )
Type = Enum | Input | Output | Scalar

Aliases = '[' alias+ ']'

Category = 'category' category? Aliases? '{' ( '(' Cat_Option ')' )? output '}'
Cat_Option = 'parallel' | 'sequential' | 'single'

Directive = 'directive' '@'directive Parameter? Aliases? '{' Dir_Repeatable? Dir_Location+ '}'
Dir_Repeatable = '(' 'repeatable' ')'
Dir_Location = 'Operation' | 'Variable' | 'Field' | 'Inline' | 'Spread' | 'Fragment'

Enum = 'enum' enum Aliases? '{' ( ':' enum )? En_Label+ '}'
En_Label = STRING? label Aliases?

# base definition
Object = 'object' object TypeParameters? Aliases? '{' Obj_Definition '}'
Obj_Definition = Obj_Object? Obj_Alternate*
Obj_Object = ( ':' STRING? Obj_Base )? Obj_Field+
Obj_Field = STRING? field fieldAlias* ':' STRING? Obj_Reference Modifiers?

Obj_Alternate = '|' STRING? Obj_Reference Modifiers?
Obj_Reference = Internal | Simple | Obj_Base
Obj_Base = '$'typeParameter | input ( '<' STRING? Obj_Reference+ '>' )?

TypeParameters = '<' ( STRING? '$'typeParameter )+ '>'

Parameter = '(' Param_Type+ ')'
Param_Type = STRING? In_Reference Modifiers? Default?

Internal = 'Null' | 'null' | 'Object' | '%' | 'Void'  # Redefined

Simple = Basic | scalar | enum  # Redefined

Input = 'input' input TypeParameters? Aliases? '{' In_Definition '}'
In_Definition = In_Object? In_Alternate*
In_Object = ( ':' STRING? In_Base )? In_Field+
In_Field = STRING? field fieldAlias* ':' STRING? In_Reference Modifiers? Default?

In_Alternate = '|' STRING? In_Reference Modifiers?
In_Reference = Internal | Simple | In_Base
In_Base = '$'typeParameter | input ( '<' STRING? In_Reference+ '>' )?

Output = 'output' output TypeParameters? Aliases? '{' Out_Definition '}'
Out_Definition = Out_Object? Out_Alternate*
Out_Object = ( ':' STRING? Out_Base )? ( STRING? field Out_Field )+
Out_Field = Parameter? fieldAlias* ':' STRING? Out_Reference Modifiers? | fieldAlias* '=' EnumLabel

Out_Alternate = '|' STRING? Out_Reference Modifiers?
Out_Reference = Internal | Simple | Out_Base
Out_Base = '$'typeParameter | output ( '<' ( STRING? Out_Reference | EnumLabel )+ '>' )?

Scalar = 'scalar' scalar Aliases? '{' ScalarDefinition '}'
ScalarDefinition = Scal_Number | Scal_String

Scal_Number = 'Number' Scal_Range*
Scal_String = 'String' Scal_Regex*

Scal_Range = '..' '<'? NUMBER | NUMBER '>'? '..' ( '<'? NUMBER )?
Scal_RegEx = REGEX '!'?

```
