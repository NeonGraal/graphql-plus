# Schema language definition

<details>

> See [Definition](Definition.md) on how to read the definition below

``` BNF
Schema = Declaration+

Declaration = Category | Enum | Input | Output | Scalar

Category = 'category' output Aliases? Option*
Enum = 'enum' enum '=' EnumLabels
Input = 'input' input TypeParameters? '=' InputDefinitions
Output = 'output' output TypeParameters? '=' OutputDefinitions
Scalar = 'scalar' scalar '=' ScalarDefinition

Aliases = '=' STRING+
Option = 'sequential' | 'single'

EnumLabels = label | label '|' EnumLabels


TypeParameters = '<' TypeParameter+ '>'
TypeParameter = '$'typeParameter

Modifier = '?' | '[]' Modifier? | '[' Simple ']' Modifier?

Internal = 'Null' | 'Void' | 'Unit'
Simple = Basic | scalar | enum
Basic = 'Boolean' | 'Number' | 'String'


InputDefinitions = In_Definition | In_Definition '|' InputDefinitions
In_Definition = In_Type Modifiers?
In_Type = In_Reference | In_Object
In_Reference = Internal | Simple | In_Base

In_Base = input In_TypeArguments | '$'typeParameter
In_Object = In_Base? '{' In_Fields+ '}'
In_Fields = field ':' In_Reference Modifiers?

In_TypeArguments = '<' In_Reference+ '>'


OutputDefinitions = Out_Definition | Out_Definition '|' OutputDefinitions
Out_Definition = Out_Type Modifiers?
Out_Type = Out_Reference | Out_Object
Out_Reference = Internal | Simple | Out_Base

Out_Base = output Out_TypeArguments | '$'typeParameter
Out_Object = Out_Base? '{' Out_Fields+ '}'
Out_Fields = field Argument? ':' Out_Reference Modifiers? | field '=' label
Argument = '(' In_Reference ')'

Out_TypeArguments = '<' Out_Reference+ '>'


ScalarDefinition = ...
```

</details>

## Schema

``` BNF
Schema = Declaration+

Declaration = Category | Enum | Input | Output | Scalar
```

A Schema is one (or more) Declarations. The following declarations are implied but can be specified explicitly:

- `category Query` and thus `output Query`
- `category Mutation sequential` and thus `output Mutation`
- `category Subscription single` and thus `output Subscription`
- `output _Schema` (see [Introspection](Introspection.md))

## Category

``` BNF
Category = 'category' output Aliases? Option*

Aliases = '=' STRING+
Option = 'sequential' | 'single'
```

A category is a set of operations defined by an Output type.

A category has a default alias of the Output type with the first character changed to lowercase. Other aliases may be specified.

By default an operation can specify multiple fields that are resolved in parallel but this can be changed with the following Options:

| Option | Description |
|---|---|
| `single` | One and only one field can be specified in an operation of this category. |
| `sequential` | Multiple fields  specified in an operation of this category will be resolved in the order given. |

## Enum type

``` BNF
Enum = 'enum' enum '=' EnumLabels

EnumLabels = label | label '|' EnumLabels
```

## Common

``` BNF
TypeParameters = '<' TypeParameter+ '>'
TypeParameter = '$'typeParameter

Modifier = '?' | '[]' Modifier? | '[' Simple ']' Modifier?

Internal = 'Null' | 'Void' | 'Unit'
Simple = Basic | scalar | enum
Basic = 'Boolean' | 'Number' | 'String'
```

## Input type

``` BNF
Input = 'input' input TypeParameters? '=' InputDefinitions

InputDefinitions = In_Definition | In_Definition '|' InputDefinitions
In_Definition = In_Type Modifiers?
In_Type = In_Reference | In_Object
In_Reference = Internal | Simple | input In_TypeArguments | '$'typeParameter

In_Object = '{' In_Fields+ '}'
In_Fields = In_Field ':' In_Reference Modifiers?

In_TypeArguments = '<' In_Reference+ '>'
```

## Output type

``` BNF
Output = 'output' output TypeParameters? '=' OutputDefinitions

OutputDefinitions = Out_Definition | Out_Definition '|' OutputDefinitions
Out_Definition = Out_Type Modifiers?
Out_Type = Out_Reference | Out_Object
Out_Reference = Internal | Simple | output Out_TypeArguments | '$'typeParameter

Out_Object = '{' Out_Fields+ '}'
Out_Fields = Out_Field Argument? ':' Out_Reference Modifiers?
Argument = '(' In_Reference ')'

Out_TypeArguments = '<' Out_Reference+ '>'
```

## Scalar type

``` BNF
Scalar = 'scalar' scalar '=' ScalarDefinition

ScalarDefinition = ...
```
