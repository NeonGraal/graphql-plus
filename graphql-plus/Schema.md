# Schema language definition

> All keywords and identifiers are case-sensitive. See [Definition](Definition.md) on how to read the definitions below.

## Schema

```PEG
Schema = Declaration+

Declaration = STRING? ( Category | Enum | Input | Output | Scalar )
```

A Schema is one (or more) Declarations. Each declaration can be preceded by a documentation string.

The following declarations are implied but can be specified explicitly:

- `category Query` and thus `output Query = { }`
- `category Mutation sequential` and thus `output Mutation = { }`
- `category Subscription single` and thus `output Subscription = { }`
- `output _Schema` (see [Introspection](Introspection.md))

The names of all Types (All Declarations except Category) must be unique.
The aliases of all Types (All Declarations except Category) must be unique.
Explicit Type name declarations will override that name being used as Type alias.

## Category

```PEG
Category = 'category' output ( 'sequential' | 'single' )? categoryAlias*
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

## Common

```PEG
TypeParameters = '<' ( STRING? '$'typeParameter )+ '>'

EnumLabel = ( enum '.' )? label

Modifier = '?' | '[]' Modifier? | '[' Simple '?'? ']' Modifier?

Internal = 'Null' | 'Void' | 'null' | 'Object' | '%'
Simple = Basic | scalar | enum
Basic = 'Boolean' | '!' | 'Number' | '0' | 'String' | '*' | 'Unit' |  '_'
```

Type parameters can be defined on either Input or Output types. Each parameter can be preceded by a documentation string.

An Enum Label reference may drop the Enum portion if the Label is unique within the Schema.

### Modifiers

Multiple Modifiers from left to right are from outside to inside finishing with the initial type.

> Note that Schema Modifiers include Scalar and Enum types as valid Dictionary keys.

<details>
<summary>Modifiers</summary>

<i>The following GraphQlPlus isn't strictly valid but ...</i>

Modifiers are equivalent to predefined generic Input and Output types as follows:

```gqlp
"$T?"
input|output _Optional<$T> = $T | Null

"$T[]"
input|output _List<$T> = $T[]

"$T[$K]"
input|output _Dictionary<$K $T> = { $K : $T }
```

The following GraphQlPlus idioms have equivalent generic Input and Output types.

```gqlp
"$T[*]"
input|output _Map<$T> = _Dictionary<String $T>

"$T[0]"
input|output _Array<$T> = _Dictionary<Number $T>

"$T[!]"
input|output _IfElse<$T> = _Dictionary<Boolean $T>

"_[$K]"
input|output Set<$K> = Dictionary<$K Unit>

"![$K]"
input|output Mask<$K> = Dictionary<$K Boolean>
```

These Generic types are the Input types if `$T` is an Input type and Output types if `$T` is an Output type.

`Set`, `Object` and `Mask` are both Input and Output types.

</details>

| Syntax                     | Generic type      | Description                                                                          | Example                     |
| -------------------------- | ----------------- | ------------------------------------------------------------------------------------ | --------------------------- |
| `String?`                  | Optional<$T>      | Optional String                                                                      | `""`                        |
| `String[]`                 | List<$T>          | List of String                                                                       | `[ "", "a" ]`               |
| `String[]?`                |                   | List of Optional String                                                              | `[ "", null ]`              |
| `String[Number?]`          | Dictionary<$K $T> | Dictionary by Optional Number of String                                              | `{ 1:"", null:"a", 2:"B" }` |
| `String[][Number][Unit?]?` |                   | List of Dictionary by Number of <br/> Dictionary by Optional Unit of Optional String | _See Example 1 below_       |

<details>
<summary>Example 1</summary>

```js
[
  {
    0: { _: null, null: "a" },
    1: { _: "" },
  },
  {
    2: { null: "b" },
  },
];
```

</details>

### Built In types

<details>
<summary>Built-In types</summary>

<i>The following GraphQlPlus isn't strictly valid but ...</i>

Boolean, Null, Unit and Void are effectively enum types as follows:

```gqlp
enum Boolean ! = true | false

enum Null null = null

enum Unit _ = _

enum Void =  # Yes
```

Number and String are effectively scalar types as follows:

```gqlp
scalar Number 0 = Number

scalar String * = String
```

Object is a general Dictionary as follows:

```gqlp
"%"
input|output Object % = Map<Any>

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
In_Object = In_Base? '{' ( field fieldAlias* ':' In_Reference Modifiers? )+ '}'

In_Alternates = In_Reference '|' In_Alternates | In_Reference
In_Reference = Internal | Simple | In_Base
In_Base = '$'typeParameter | input ( '<' In_Reference+ '>' )?
```

Input types define the type of Output field's Argument.

An Input type is defined as either:

- an Input object definition followed by zero or more Input type references, or
- one or more Input type references

An Input object may have a base Input type and has one or more Input fields.

Input Field names and Field aliases must be unique within the Input object, including any base object.
Explicit Field names will override the same name being used as a Field alias.

An Operation's Argument value is mapped into a Field's Argument Input type as follows:

> ...

Duplicate Input declarations with different base Inputs are not permitted.
Multiple Input declarations with the same base, or no base, will have their fields and alternates merged and de-duplicated.

## Output type

```PEG
Output = 'output' output TypeParameters? typeAlias* '=' Out_Definition
Out_Definition = Out_Object ( '|'? Out_Alternates )? | Out_Alternates
Out_Object = Out_Base? '{' Out_Fields+ '}'
Out_Fields = field Parameter? fieldAlias* ':' Out_Reference Modifiers? | field fieldAlias* '=' EnumLabel
Parameter = '(' In_Reference Modifiers? ( '=' Constant )? ')'

Out_Alternates = Out_Reference '|' Out_Alternates | Out_Reference
Out_Reference = Internal | Simple | Out_Base
Out_Base = '$'typeParameter | output ( '<' ( Out_Reference | EnumLabel )+ '>' )?
```

Output types define the result values for Categories and Output fields.

An Output type is defined as either:

- an Output object definition followed by zero or more Output type references, or
- one or more Output type references

An Output object may have a base Output type and has one or more Output fields.

Output Field names and Field aliases must be unique within the Output object, including any base object.
Explicit Field names will override the same name being used as a Field alias.

Duplicate Output declarations with different base Outputs are not permitted.
Multiple Output declarations with the same base, or no base, will have their fields and alternates merged and de-duplicated.

## Constant

```PEG
Constant = Const_List | Const_Object | Const_Value
Const_Value = EnumLabel | 'true' | 'false' | 'null' | '_' | NUMBER | STRING
Const_List = '[' Cons_Values ']' | '[' Constant* ']'
Const_Values = Constant ',' Const_Values | Constant

Const_Object = '{' Const_Fields '}' | '{' ( FieldKey ':' Constant )* '}'
Const_Fields = Const_Field ';' Const_Fields | Const_Field
Const_Field = FieldKey ':' Const_Values
FieldKey = field | NUMBER | STRING
```

A Constant is a single value. Commas (`,`) can be used to separate list values and semi-colons (`;`) can be used to separate object fields.

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

Declaration = STRING? ( Category | Enum | Input | Output | Scalar )

Category = 'category' output ( 'sequential' | 'single' )? categoryAlias*

Enum = 'enum' enum typeAlias* '=' ( enum ':' )? En_Labels
En_Labels = En_Label '|' En_Labels | En_Label
En_Label = STRING? label labelAlias*

TypeParameters = '<' ( STRING? '$'typeParameter )+ '>'

EnumLabel = ( enum '.' )? label

Modifier = '?' | '[]' Modifier? | '[' Simple '?'? ']' Modifier?

Internal = 'Null' | 'Void' | 'null' | 'Object' | '%'
Simple = Basic | scalar | enum
Basic = 'Boolean' | '!' | 'Number' | '0' | 'String' | '*' | 'Unit' |  '_'

Input = 'input' input TypeParameters? typeAlias* '=' In_Definition
In_Definition = In_Object ( '|'? In_Alternates )? | In_Alternates
In_Object = In_Base? '{' ( field fieldAlias* ':' In_Reference Modifiers? )+ '}'

In_Alternates = In_Reference '|' In_Alternates | In_Reference
In_Reference = Internal | Simple | In_Base
In_Base = '$'typeParameter | input ( '<' In_Reference+ '>' )?

Output = 'output' output TypeParameters? typeAlias* '=' Out_Definition
Out_Definition = Out_Object ( '|'? Out_Alternates )? | Out_Alternates
Out_Object = Out_Base? '{' Out_Fields+ '}'
Out_Fields = field Argument? fieldAlias* ':' Out_Reference Modifiers? | field fieldAlias* '=' EnumLabel
Argument = '(' In_Reference Modifiers? ( '=' Constant )? ')'

Out_Alternates = Out_Reference '|' Out_Alternates | Out_Reference
Out_Reference = Internal | Simple | Out_Base
Out_Base = '$'typeParameter | output ( '<' ( Out_Reference | EnumLabel )+ '>' )?

Constant = Const_List | Const_Object | Const_Value
Const_Value = EnumLabel | 'true' | 'false' | 'null' | '_' | NUMBER | STRING
Const_List = '[' Cons_Values ']' | '[' Constant* ']'
Const_Values = Constant ',' Const_Values | Constant

Const_Object = '{' Const_Fields '}' | '{' ( FieldKey ':' Constant )* '}'
Const_Fields = Const_Field ';' Const_Fields | Const_Field
Const_Field = FieldKey ':' Const_Values
FieldKey = field | NUMBER | STRING

Scalar = 'scalar' scalar typeAlias* '=' ScalarDefinition
ScalarDefinition = Scal_Number | Scal_String

Scal_Number = 'Number' Scal_Range*
Scal_String = 'String' Scal_Regex*

Scal_Range = '..' '<'? NUMBER | NUMBER '>'? '..' ( '<'? NUMBER )?
Scal_RegEx = REGEX | '!' REGEX
```
