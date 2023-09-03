# Schema language definition

<details>

> See [Definition](Definition.md) on how to read the definition below

``` BNF
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

Modifier = '?' | '[]' Modifier? | '[' Simple ']' Modifier?

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

``` BNF
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

``` BNF
Category = 'category' output Cat_Option? alias*
Cat_Option = 'sequential' | 'single'
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
Enum = 'enum' enum '=' En_Labels
En_Labels = En_Label | En_Label '|' En_Labels
En_Label = STRING? label
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
Input = 'input' input TypeParameters? '=' In_Definition
In_Definition = In_Object | In_Object '|' In_References | In_References
In_Object = In_Base? '{' In_Field+ '}'
In_Field = field ':' In_Reference Modifiers?

In_References = In_Reference | In_Reference  '|' In_References
In_Reference = Internal | Simple | In_Base
In_Base = input In_TypeArguments | '$'typeParameter
In_TypeArguments = '<' In_Reference+ '>'
```

## Output type

``` BNF
Output = 'output' output TypeParameters? '=' Out_Definition
Out_Definition = Out_Object | Out_Object  '|' Out_References | Out_References
Out_Object = Out_Base? '{' Out_Fields+ '}'
Out_Fields = field Argument? ':' Out_Reference Modifiers? | field '=' label
Argument = '(' In_Reference Modifiers? ')'

Out_References = Out_Reference | Out_Reference '|' Out_References
Out_Reference = Internal | Simple | Out_Base
Out_Base = output Out_TypeArguments | '$'typeParameter
Out_TypeArguments = '<' Out_Reference+ '>'
```

## Scalar type

``` BNF
Scalar = 'scalar' scalar '=' ScalarDefinition
ScalarDefinition = Scal_Boolean | Scal_Number | Scal_String

Scal_Boolean = 'Boolean'
Scal_Number = 'Number' Scal_Range?
Scal_String = 'String' Scal_Regex?

Scal_Range = NUMBER '>'? '..' '<'? NUMBER | NUMBER '>'? '..' | '..' '<'? NUMBER
Scal_RegEx = '/' STRING '/'
```
