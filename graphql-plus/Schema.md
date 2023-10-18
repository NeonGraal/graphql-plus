# Schema language definition

> See [Definition](Definition.md) on how to read the definitions below.
>
> Including PEG definitions for Common and Constant terms.

## Schema

```PEG
Schema = Declaration+

Declaration = STRING? ( Category | Directive | Type )
Type = Enum | Input | Output | Scalar
```

A Schema is one (or more) Declarations. Each declaration can be preceded by a documentation string.

The following declarations are implied but can be specified explicitly:

- `category Query` and thus `output Query = { }`
- `category Mutation (sequential)` and thus `output Mutation = { }`
- `category Subscription (single)` and thus `output Subscription = { }`
- `output _Schema` (see [Introspection](Introspection.md))

The names of all Types must be unique.
The aliases of all Types must be unique.
Explicit Type name declarations will override that name being used as Type alias.

## Category

```PEG
Category = 'category' output ( '(' Cat_Option ')' )? categoryAlias*
Cat_Option = 'sequential' | 'single'
```

A Category is a set of operations defined by an Output type.

A Category has a default alias of the Output type with the first character changed to lowercase. Other aliases may be specified.

By default an operation can specify multiple fields that are resolved in parallel but this can be changed with the following Options:

| Option       | Description                                                                                     |
| ------------ | ----------------------------------------------------------------------------------------------- |
| `single`     | One and only one field can be specified in an operation of this category.                       |
| `sequential` | Multiple fields specified in an operation of this category will be resolved in the order given. |

Duplicate Category declarations are not permitted.
An explicit Category declaration for an Output type will override that name being used as an alias for a different Category.

## Directive

```PEG
Directive = 'directive' '@'directive Parameter? directiveAlias* '=' Dir_Repeatable? Dir_Location+
Dir_Repeatable = '(' 'repeatable' ')'
Dir_Location = 'Operation' | 'Variable' | 'Field' | 'Inline' | 'Spread' | 'Fragment'
```

## Enum type

```PEG
Enum = 'enum' enum typeAlias* '=' ( enum ':' )? En_Labels
En_Labels = En_Label '|' En_Labels | En_Label
En_Label = STRING? label labelAlias*
```

An Enum is a type defined with one or more Labels.
Each Label can be preceded by a documentation string and may have one or more aliases.
Label names and Label aliases must be unique for that Enum.
Explicit Label names will override that name being used as a Label alias.

An Enum can extend another enum and thus implicitly includes the extended enum's labels.

Duplicate Enum declarations with different base Enums are not permitted.
Multiple Enum declarations with the same base, or no base, will have their labels and Type aliases merged and de-duplicated.

## Object Union types

Input and Output types are both Object Union types

```PEG
TypeParameters = '<' ( STRING? '$'typeParameter )+ '>'

Parameter = '(' In_Reference Modifiers? Default? ')'

Simple = Basic | scalar | enum  # Redefined
```

Type parameters can be defined on either Input or Output types. Each parameter can be preceded by a documentation string.

An Enum Label reference may drop the Enum portion if the Label is unique within the Schema.

### Modifiers

Note that Schema Modifiers include Scalar and Enum types as valid Dictionary keys.

<details>
<summary>Modifiers</summary>

<i>The following GraphQlPlus isn't strictly valid but ...</i>

Modifiers are equivalent to predefined generic Input and Output types as follows:

```gqlp
"$T?"
input|output _Opt<$T> Opt = $T | Null

"$T[]"
input|output _List<$T> List = $T[]

"$T[$K]"
input|output _Dict<$K $T> Dict = { $K: $T }
```

The following GraphQlPlus idioms have equivalent generic Input and Output types.

```gqlp
"$T[*]"
input|output _Map<$T> Map = _Dict<String $T>

"$T[0]"
input|output _Array<$T> Array = _Dict<Number $T>

"$T[~]"
input|output _IfElse<$T> IfElse = _Dict<Boolean $T>

"_[$K]"
input|output Set<$K> = _Dict<$K Unit>

"~[$K]"
input|output Mask<$K> = _Dict<$K Boolean>
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

<details>
<summary>Built-In types</summary>

<i>The following GraphQlPlus isn't strictly valid but ...</i>

Boolean, Null, Unit and Void are effectively enum types as follows:

```gqlp
enum Boolean ~ = true | false

enum Null null = null

enum Unit _ = _

enum Void =  # no valid value
```

Number and String are effectively scalar types as follows:

```gqlp
scalar Number 0 = Number

scalar String * = String
```

Object is a general Dictionary as follows:

```gqlp
"%"
input|output Object % = _Map<Any>

input|output _Any<$T> = $T | _Scalar | Object | _Any<$T>? | _Any<$T>[] | _Any<$T>[Simple] | _Any<$T>[Simple?]

input Any = _Any<_Input>
output Any =  _Any<_Output>
```

The internal types `_Scalar`, `_Output`, `_Input` and `_Enum` are automatically defined to be a union of all Scalar, Output, Input and Enum types respectively.

</details>

## Input type

```PEG
Input = 'input' input TypeParameters? typeAlias* '=' In_Definition
In_Definition = In_Object ( '|'? In_Alternates )? | In_Alternates
In_Object = In_Base? '{' InField+ '}'
In_Field = STRING? field fieldAlias* ':' In_Reference Modifiers? Default?

In_Alternates = In_Reference '|' In_Alternates | In_Reference
In_Reference = Internal | Simple | In_Base
In_Base = '$'typeParameter | input ( '<' In_Reference+ '>' )?
```

Input types define the type of Output field's Argument.

An Input type is defined as either:

- an Input object definition followed by zero or more Input type references, or
- one or more Input type references

An Input object may have a base Input type and has one or more Input fields.

An Input Field comprises:

- an optional documentation string,
- a Field name
- zero or more Field aliases
- a type parameter or Input type references
- zero or more type Modifiers
- an optional Default value

An Input type reference may be an Internal, Simple or Input type.
If an Input type is may have Type Arguments of Input type references.

A Default of `null` is only allowed on Optional fields. The Default must be compatible with the Modified Type of the field.

Input Field names and Field aliases must be unique within the Input object, including any base object.
Explicit Field names will override the same name being used as a Field alias.

An Operation's Argument value is mapped into a Field's Argument Input type as follows:

> ...

Duplicate Input declarations with different base Inputs are not permitted.
Multiple Input declarations with the same base, or no base, will have their fields and alternates merged and de-duplicated.

When merging, Fields with the same name must have the same Modified Type. Field aliases will be merged and de-duplicated.
Optional components (documentation string and default), if present, must be the same.
If only present on one Field before merging, optional components will be retained on the merged Field.

## Output type

```PEG
Output = 'output' output TypeParameters? typeAlias* '=' Out_Definition
Out_Definition = Out_Object ( '|'? Out_Alternates )? | Out_Alternates
Out_Object = Out_Base? '{' ( STRING? field Out_Field )+ '}'
Out_Field = Parameter? fieldAlias* ':' Out_Reference Modifiers? | fieldAlias* '=' EnumLabel

Out_Alternates = Out_Reference '|' Out_Alternates | Out_Reference
Out_Reference = Internal | Simple | Out_Base
Out_Base = '$'typeParameter | output ( '<' ( Out_Reference | EnumLabel )+ '>' )?
```

Output types define the result values for Categories and Output fields.

An Output type is defined as either:

- an Output object definition followed by zero or more Output type references, or
- one or more Output type references

An Output object may have a base Output type and has one or more Output fields.

An Output Field comprises:

- an optional documentation string,
- a Field name
- an optional Parameter
- zero or more Field aliases
- a type parameter or an Output type reference
- zero or more type Modifiers

or:

- an optional documentation string,
- a Field name
- zero or more Field aliases
- an Enum Label (which will imply the field Type)

An Output type reference may be an Internal, Simple or Output type.
If an Output type is may have Type Arguments of Output type references and/or Enum Labels.

A Parameter is a Input type reference, possibly with Modifiers and/or a Default.

Output Field names and Field aliases must be unique within the Output object, including any base object.
Explicit Field names will override the same name being used as a Field alias.

Duplicate Output declarations with different base Outputs are not permitted.
Multiple Output declarations with the same base, or no base, will have their fields and alternates merged and de-duplicated.

## Scalar type

```PEG
Scalar = 'scalar' scalar typeAlias* '=' ScalarDefinition
ScalarDefinition = Scal_Number | Scal_String

Scal_Number = 'Number' Scal_Range*
Scal_String = 'String' Scal_Regex*

Scal_Range = '..' '<'? NUMBER | NUMBER '>'? '..' ( '<'? NUMBER )?
Scal_RegEx = REGEX | '!' REGEX
```

Scalar types define specific domains of:

- Numbers, possibly only those in a given range. Ranges may be upper and/or lower bounded and each bound may be inclusive or exclusive.
- Strings, possibly only those that match (or don't match) one or more regular expressions.

Duplicate Scalar declarations with different bases are not permitted.
Multiple Scalar declarations with the same base will have their ranges or regexes merged and de-duplicated.

## Complete Grammar

```PEG
Schema = Declaration+

Declaration = STRING? ( Category | Directive | Type )
Type = Enum | Input | Output | Scalar

Category = 'category' output ( '(' Cat_Option ')' )? categoryAlias*
Cat_Option = 'sequential' | 'single'

Directive = 'directive' '@'directive Parameter? directiveAlias* '=' Dir_Repeatable? Dir_Location+
Dir_Repeatable = '(' 'repeatable' ')'
Dir_Location = 'Operation' | 'Variable' | 'Field' | 'Inline' | 'Spread' | 'Fragment'

Enum = 'enum' enum typeAlias* '=' ( enum ':' )? En_Labels
En_Labels = En_Label '|' En_Labels | En_Label
En_Label = STRING? label labelAlias*

TypeParameters = '<' ( STRING? '$'typeParameter )+ '>'

Parameter = '(' In_Reference Modifiers? Default? ')'

Simple = Basic | scalar | enum  # Redefined

Input = 'input' input TypeParameters? typeAlias* '=' In_Definition
In_Definition = In_Object ( '|'? In_Alternates )? | In_Alternates
In_Object = In_Base? '{' InField+ '}'
In_Field = STRING? field fieldAlias* ':' In_Reference Modifiers? Default?

In_Alternates = In_Reference '|' In_Alternates | In_Reference
In_Reference = Internal | Simple | In_Base
In_Base = '$'typeParameter | input ( '<' In_Reference+ '>' )?

Output = 'output' output TypeParameters? typeAlias* '=' Out_Definition
Out_Definition = Out_Object ( '|'? Out_Alternates )? | Out_Alternates
Out_Object = Out_Base? '{' ( STRING? field Out_Field )+ '}'
Out_Field = Parameter? fieldAlias* ':' Out_Reference Modifiers? | fieldAlias* '=' EnumLabel

Out_Alternates = Out_Reference '|' Out_Alternates | Out_Reference
Out_Reference = Internal | Simple | Out_Base
Out_Base = '$'typeParameter | output ( '<' ( Out_Reference | EnumLabel )+ '>' )?

Scalar = 'scalar' scalar typeAlias* '=' ScalarDefinition
ScalarDefinition = Scal_Number | Scal_String

Scal_Number = 'Number' Scal_Range*
Scal_String = 'String' Scal_Regex*

Scal_Range = '..' '<'? NUMBER | NUMBER '>'? '..' ( '<'? NUMBER )?
Scal_RegEx = REGEX | '!' REGEX

```
