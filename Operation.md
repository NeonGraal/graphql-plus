<!-- markdownlint-disable MD041 -->
<div style="float:right; position:sticky; top:0; background-color: #eeec; z-index:9;">

## Table of Contents <!-- omit from toc -->

- [Operation language definition](#operation-language-definition)
  - [Operation](#operation)
  - [Variables](#variables)
  - [Result](#result)
  - [Modifier](#modifier)
  - [Simple](#simple)
  - [Object](#object)
  - [Argument](#argument)
  - [Constant](#constant)

</div>

# Operation language definition

<details>

> See [Definition](Definition.md) on how to read the definition below

``` BNF
Operation =  Category? Variables? Result
Category = category name

Variables = '(' Variable+ ')'
Variable = '$'variable Var_Type? Var_Default?
Var_Type = ':' type Modifier?  # GraphQL compatibility
Var_Default = '=' Constant

Result = Type Modifier?
Type = Simple Argument? | Object

Modifier = '?' | '[]' Modifier? | '[' Basic '?'? ']' Modifier?
Basic = 'Boolean' | 'Number' | 'String' | 'Unit'

Simple = Internal | Basic
Internal = 'Void' | 'Null'

Object = '{' Obj_Field+ '}'
Obj_Field = field Argument? Modifier? Object?

Argument = '(' Arg_Value ')'
Arg_Value = Constant | Variable | Arg_List | Arg_Object
Arg_List = '[' Arg_Value* ']'
Arg_Object = '{' Arg_Field* '}'
Arg_Field = FieldKey ':' Arg_Value

Constant = Const_Value | Const_List | Const_Object
Const_Value = 'true' | 'false' | 'null' | '_' | NUMBER | STRING
Const_List = '[' Constant* ']'
Const_Object = '{' Const_Field* '}'
Const_Field = FieldKey ':' Constant

FieldKey = field | NUMBER | STRING
```

</details>

## Operation

``` BNF
Operation =  Category? Variables? Result
Category = category name
```

If not specified, an Operation's category is "query" and it's name is blank. This is for GraphQL compatibility.

## Variables

``` BNF
Variables = '(' Variable+ ')'
Variable = '$'variable Var_Type? Modifier? Var_Default?
Var_Type = ':' type # GraphQL compatibility
Var_Default = '=' Constant
```

A Variable with the Optional Modifier has an implied Default of `null` and a Variable with a Default of `null` has an implied Optional Modifier.

A Variable's Type name (`type`) is only included for GraphQL compatibility and is otherwise ignored.

A `Variable`'s Modifier and Default are both specified they should be validated, recursively, as follows:

| Modifier | Default | Comment |
|---|---|---|
| `?` | `null` | A default of `null` is only allowed on Optional types.  |
| `[]` | object | **ERROR** A List type cannot have an Object default. |
| `[]` | value | A value is equivalent to a list containing just that value, ie. `[`value`]`. |
| `[`any`]` | list or value | **ERROR** An Object type can only have an object default. |

## Result

``` BNF
Result = Type Modifier?
Type = Simple Argument? | Object
```

An Operation's Result is either:

- a Simple type with an optional Argument and/or Modifier(s), or
- an Object type with optional Modifier(s).

## Modifier

``` BNF
Modifier = '?' | '[]' Modifier? | '[' Basic '?'? ']' Modifier?
Basic = 'Boolean' | 'Number' | 'String' | 'Unit'
```

| Modifier | Syntax | Notes | Description |
|---|---|---|---|
| Optional | `?` | An Optional Result may have the value of `null`. <br/> The Null type may not be Optional. | Optional _type_ |
| List | `[]` | A List Result will be an array with zero or more entries. | List of _type_ |
| Dictionary | `[`Basic`?`?`]` | A Dictionary Result will be an object with the given Basic type as the Key. <br/> The Key may be Optional. | Dictionary by _key_ of _type_ |

Multiple Modifiers from left to right are from outside to inside finishing with the initial type.

| Syntax | Description | Example |
|---|---|---|
| `String?`| Optional String | `""` |
| `String[]` | List of String | `[ "", "a" ]` |
| `String[]?` | List of Optional String | `[ "", null ]` |
| `String[Number?]` | Dictionary by Optional Number of String | `{ 1:"", null:"a", 2:"B" }` |
| `String[][Number][Unit?]?` | List of Dictionary by Number of <br/> Dictionary by Optional Unit of Optional String | _See Example 1 below_|

<details style="padding-left:2em">
<summary>Example 1</summary>

``` js
[
  {
    0: { _:null, null:"a" },
    1: { _:"" }
  },
  { 
    2: { null:"b" }
  }
]
```

</details>

## Simple

``` BNF
Simple = Internal | Basic
Internal = 'Void' | 'Null'
```

| Type | Value(s) | Description |
|---|---|---|
|| _Internal types_ |
| Void |  | The Void type has no values. |
| Null | `null` | The Null type only has one value, but can't be the type of a Dictionary Key |
|| _Basic types_ |
| Unit | `_` | The Unit type only has one value. |
| Boolean | `false` or `true` | The Boolean type only has two values. |
| Number | NUMBER | |
| String | STRING | |

## Object

``` BNF
Object = '{' Obj_Field+ '}'
Obj_Field = field Argument? Modifier? Object?
```

A Result Object is a selection of fields. Each field may have none, one, more or even all of the following, in this order:

- an Argument
- Modifiers
- a sub-selection of fields

| Example | Sample |
|---|---|
| `{ name }` | `{ name: "Andrew" }` |
| `{ name[] }` | `{ name: [ "Andrew", "Alan", "Barbera" ] }` |
| `{ id(12) }` | `{ id: 12 }` |
| `{ name("A*")[] }` | `{ name: ["Andrew", "Alan"] }` |
| `{ user(12) { id name } }` | `{ user:{ id:12, name:"Andrew" } }` |
| `{ user(12)[] { id name } }` | `{ user:[ { id:12, name:"Andrew" } ] }` |
| `{ user("A*") { id name } }` | `{ user:{ id:12, name:"Andrew" } }` |
| `{ user("A*")[] { id name } }` | `{ user:[ { id:12, name:"Andrew" }, { id:34, name:"Alan" } ] }` |

## Argument

``` BNF
Argument = '(' Arg_Value ')'
Arg_Value = Constant | Variable | Arg_List | Arg_Object | Arg_GraphQl
Arg_List = '[' Arg_Value* ']'
Arg_Object = '{' Arg_Field* '}'
Arg_Field = FieldKey ':' Arg_Value
Arg_GraphQL = Arg_Field*  # GraphQL compatibility
```

An Argument is usually a single value, but for GraphQL compatibility a set of argument fields can be provided.
These are treated as an Argument Object.

## Constant

``` BNF
Constant = Const_Value | Const_List | Const_Object
Const_Value = 'true' | 'false' | 'null' | '_' | NUMBER | STRING
Const_List = '[' Constant* ']'
Const_Object = '{' Const_Field* '}'
Const_Field = FieldKey ':' Constant
```
