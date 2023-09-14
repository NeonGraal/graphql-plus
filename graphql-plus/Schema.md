# Schema language definition

<details>

> See [Definition](Definition.md) on how to read the definition below

```BNF
Schema = Declaration+

Declaration = STRING? Dec_Definition
Dec_Definition = Category | Enum | Input | Output | Scalar


Category = 'category' output Cat_Option? alias*
Cat_Option = 'sequential' | 'single'


Enum = 'enum' enum '=' En_Labels
En_Labels = En_Label | En_Label '|' En_Labels
En_Label = STRING? label


TypeParameters = '<' TypeParameter+ '>'
TypeParameter = STRING? '$'typeParameter

Modifier = '?' | '[]' Modifier? | '[' Simple '?'? ']' Modifier?

Internal = 'Null' | 'Void' | 'Unit'
Simple = Basic | scalar | enum
Basic = 'Boolean' | 'Number' | 'String'


Input = 'input' input TypeParameters? '=' In_Definition
In_Definition = In_References | In_References '|' In_Object | In_Object
In_References = In_Reference | In_Reference  '|' In_References
In_Reference = Internal | Simple | In_Base

In_Object = In_Base? '{' In_Field+ '}'
In_Field = STRING? field ':' In_Reference Modifiers?
In_Base = input In_TypeArguments | '$'typeParameter
In_TypeArguments = '<' In_Reference+ '>'


Output = 'output' output TypeParameters? '=' Out_Definition
Out_Definition = Out_References | Out_References '|' Out_Object | Out_Object
Out_References = Out_Reference | Out_Reference '|' Out_References
Out_Reference = Internal | Simple | Out_Base

Out_Object = Out_Base? '{' Out_Fields+ '}'
Out_Fields = STRING? field Argument? ':' Out_Reference Modifiers?
Argument = '(' In_Reference Modifiers? ')'
Out_Base = output Out_TypeArguments | '$'typeParameter
Out_TypeArguments = '<' Out_Reference+ '>'


Scalar = 'scalar' scalar '=' ScalarDefinition
ScalarDefinition = Scal_Boolean | Scal_Number | Scal_String

Scal_Boolean = 'Boolean'
Scal_Number = 'Number' Scal_Range?
Scal_String = 'String' Scal_Regex?

Scal_Range = NUMBER '>'? '..' '<'? NUMBER | NUMBER '>'? '..' | '..' '<'? NUMBER
Scal_RegEx = '/' STRING '/'
```

</details>

## Schema

```BNF
Schema = Declaration+

Declaration = STRING? Dec_Definition
Dec_Definition = Category | Enum | Input | Output | Scalar
```

A Schema is one (or more) Declarations. Each declaration can be preceded by a documentation string.

The following declarations are implied but can be specified explicitly:

- `category Query` and thus `output Query = { }`
- `category Mutation sequential` and thus `output Mutation = { }`
- `category Subscription single` and thus `output Subscription = { }`
- `output _Schema` (see [Introspection](Introspection.md))

## Category

```BNF
Category = 'category' output Cat_Option? alias*
Cat_Option = 'sequential' | 'single'
```

A Category is a set of operations defined by an Output type.

A Category has a default alias of the Output type with the first character changed to lowercase. Other aliases may be specified.

By default an operation can specify multiple fields that are resolved in parallel but this can be changed with the following Options:

| Option       | Description                                                                                     |
| ------------ | ----------------------------------------------------------------------------------------------- |
| `single`     | One and only one field can be specified in an operation of this category.                       |
| `sequential` | Multiple fields specified in an operation of this category will be resolved in the order given. |

## Enum type

```BNF
Enum = 'enum' enum '=' En_Labels
En_Labels = En_Label | En_Label '|' En_Labels
En_Label = STRING? label
```

An Enum is a type defined by one or more labels. Each label can be preceded by a documentation string.

## Common

```BNF
TypeParameters = '<' TypeParameter+ '>'
TypeParameter = STRING? '$'typeParameter

Modifier = '?' | '[]' Modifier? | '[' Simple '?'? ']' Modifier?

Internal = 'Null' | 'Void'
Simple = Basic | scalar | enum
Basic = 'Boolean' | 'Number' | 'String' | 'Unit'
```

Type parameters can be defined on either Input or Output types. Each parameter can be preceded by a documentation string.

### Modifiers

Multiple Modifiers from left to right are from outside to inside finishing with the initial type.

> Note that Schema Modifiers include Scalar and Enum types as valid Dictionary keys.

<details>
<summary>Built-In Generic types</summary>

Modifiers are equivalent to predefined generic Input and Output types as follows:

```gql
"$T?"
generic Optional<$T> = $T | Null

"$T[]"
generic List<$T> = $T[]  # Yes, I know this is recursive

"$T[$K]"
generic Dictionary<$K $T> = { $K : $T }  # Yes, I know this isn't strictly legal GraphQL-plus

generic Map<$T> = Dictionary<String $T>

generic Array<$T> = Dictionary<Number $T>

generic IfElse<$T> = Dictionary<Boolean $T>

generic Object = Map<Object>

generic Set<$K> = Dictionary<$K Unit>

generic Mask<$K> = Dictionary<$K Boolean>
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

### Common types

| Type    | Value(s)          | Description                                                                 |
| ------- | ----------------- | --------------------------------------------------------------------------- |
|         | _Internal types_  |
| Void    |                   | The Void type has no values.                                                |
| Null    | `null`            | The Null type only has one value, but can't be the type of a Dictionary Key |
|         | _Basic types_     |
| Unit    | `_`               | The Unit type only has one value.                                           |
| Boolean | `false` or `true` | The Boolean type only has two values.                                       |
| Number  | NUMBER            |                                                                             |
| String  | STRING            |                                                                             |

## Input type

```BNF
Input = 'input' input TypeParameters? '=' In_Definition
In_Definition = In_Object | In_Object '|' In_References | In_References
In_Object = In_Base? '{' In_Field+ '}'
In_Field = field ':' In_Reference Modifiers?

In_References = In_Reference | In_Reference  '|' In_References
In_Reference = Internal | Simple | In_Base
In_Base = input In_TypeArguments | '$'typeParameter
In_TypeArguments = '<' In_Reference+ '>'
```

Input types define the type of Output field's Argument.

An Input type is defined as either:

- an Input object definition, or
- an Input object definition followed by one or more Input type references, or
- one or more Input type references

An Operation's Argument value is mapped into a Field's Argument Input type as follows:

...

## Output type

```BNF
Output = 'output' output TypeParameters? '=' Out_Definition
Out_Definition = Out_Object | Out_Object  '|' Out_References | Out_References
Out_Object = Out_Base? '{' Out_Fields+ '}'
Out_Fields = field Argument? ':' Out_Reference Modifiers? | field '=' label
Argument = '(' In_Reference Modifiers? ')'

Out_References = Out_Reference | Out_Reference '|' Out_References
Out_Reference = Internal | Simple | Out_Base
Out_Base = output Out_TypeArguments | '$'typeParameter
Out_TypeArguments = '<' Out_TypeArgument+ '>'
Out_TypeArgument = Out_Reference | enum '.' label
```

Output types define the result values for Categories and Output fields.

An Output type is defined as either:

- an Output object definition, or
- an Output object definition followed by one or more Output type references, or
- one or more Output type references

## Scalar type

```BNF
Scalar = 'scalar' scalar '=' ScalarDefinition
ScalarDefinition = Scal_Boolean | Scal_Number | Scal_String

Scal_Boolean = 'Boolean'
Scal_Number = 'Number' Scal_Range?
Scal_String = 'String' Scal_Regexes?

Scal_Range = NUMBER '>'? '..' '<'? NUMBER | NUMBER '>'? '..' | '..' '<'? NUMBER
Scal_RegExes = Scal_Regex | Scal_Regex Scal_RegExes
Scal_RegEx = REGEX | '!' REGEX
```

Scalar types define specific domains of:

- Booleans
- Numbers, possibly only those in a given range. Ranges may be upper and/or lower bounded and each bound may be inclusive or exclusive.
- Strings, possibly only those that match (or don't match) one or more regular expressions.
