# Operation language definition

> See [Definition](Definition.md) on how to read the definitions below.
>
> Including PEG definitions for Common and Constant terms.

## Operation

```PEG
Operation = ( category name? )? Variables? Directive* Fragment* Result Frag_End*
```

If not specified, an Operation's category is "query". This is for GraphQL compatibility.

## Variables

```PEG
Variables = '(' Variable+ ')'
Variable = '$'variable ( ':' Var_Type )? Modifier? Default? Directive*
Var_Type = Var_Null '!'?
Var_Null = '[' Var_Type ']' | type
```

Note that there cannot be any other characters between the dollar sign (`$`) and the variable name.

A Variable with the Optional Modifier has an implied Default of `null` and a Variable with a Default of `null` has an implied Optional Modifier.

A Variable's Type name (`type`) is only included for GraphQL compatibility and is otherwise ignored.

If a Variable's Modifier and Default are both specified they should be validated, recursively, as follows:

| Modifier  | Default       | Comment                                                                      |
| --------- | ------------- | ---------------------------------------------------------------------------- |
| `?`       | `null`        | A default of `null` is only allowed on Optional types.                       |
| `[]`      | object        | **ERROR** A List type cannot have an Object default.                         |
| `[]`      | value         | A value is equivalent to a list containing just that value, ie. `[`value`]`. |
| `[`any`]` | list or value | **ERROR** An Object type can only have an object default.                    |

## Directives

```PEG
Directive = '@'directive Argument?
```

Note that there cannot be any other characters between the at sign (`@`) and the directive name.

The order of directives may be significant.

## Result

```PEG
Result = ( ':' Scalar Argument? | Object ) Modifier?
```

An Operation's Result is either:

- a Scalar type with an optional Argument and/or Modifier(s), or
- an Object type with optional Modifier(s).

## Scalar

```PEG
Scalar = Internal | Simple
```

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

Any unknown identifier used as a Dictionary key Type will be treated as an Enum Type name.

## Object

```PEG
Object = '{' ( Selection | Field )+ '}'
Field = ( alias ':' )? field Argument? Modifier? Directive* Object?
Selection = ( '...' | '|' ) ( Inline | Spread )
Inline = TypeCondition? Directive* Object
Spread = fragment Directive*
TypeCondition = ( 'on' | ':' ) type
```

A Result Object is a set of fields or selections.

A Field may have none, one, more or even all of the following, in this order:

- an Alias, before the field name
- an Argument
- Modifiers
- Directives
- a sub-selection of fields

| Example                               | Sample                                                           |
| ------------------------------------- | ---------------------------------------------------------------- |
| `{ name }`                            | `{ name: "Andrew" }`                                             |
| `{ name[] }`                          | `{ name: [ "Andrew", "Alan", "Barbera" ] }`                      |
| `{ id(12) }`                          | `{ id: 12 }`                                                     |
| `{ name("A*")[] }`                    | `{ name: ["Andrew", "Alan"] }`                                   |
| `{ user(12) { id name } }`            | `{ user:{ id:12, name:"Andrew" } }`                              |
| `{ user(12)[] { id name } }`          | `{ user:[ { id:12, name:"Andrew" } ] }`                          |
| `{ user("A*") { id name } }`          | `{ user:{ id:12, name:"Andrew" } }`                              |
| `{ All_A: user("A*")[] { id name } }` | `{ All_A:[ { id:12, name:"Andrew" }, { id:34, name:"Alan" } ] }` |

## Fragment

```PEG
Fragment = '&' fragment ':' type Frag_Body
Frag_End = ( 'fragment' | '&' ) fragment TypeCondition Frag_Body
Frag_Body = Directive* Object
```

## Argument

```PEG
Argument = '(' Arg_Fields+ | Arg_Values+ ')'
Arg_Value = '$'variable | Arg_List | Arg_Object | Constant
Arg_List = '[' Arg_Values* ']'
Arg_Values = Arg_Value ',' Arg_Values | Arg_Value

Arg_Object = '{' Arg_Fields* '}'
Arg_Fields = Arg_Field ',' Arg_Fields | Arg_Field
Arg_Field = FieldKey ':' Arg_Value
```

An Argument is usually a single value. If multiple values are provided they are treated as a list. If one or more fields are provided they are treated as an object.

Commas (`,`) can be used to separate list values and object fields.

If a Argument Object FieldKey appears more than once, all the values will be merged in the similar way as for Constant Object Field values, with Variables being treated as a Value, List or Object depending on their Modifiers.

## Complete Grammar

```PEG
Operation = ( category name? )? Variables? Directive* Fragment* Result Frag_End*

Variables = '(' Variable+ ')'
Variable = '$'variable ( ':' Var_Type )? Modifier? Default? Directive*
Var_Type = Var_Null '!'?
Var_Null = '[' Var_Type ']' | type

Directive = '@'directive Argument?

Result = ( ':' Scalar Argument? | Object ) Modifier?

Scalar = Internal | Simple

Object = '{' ( Selection | Field )+ '}'
Field = ( alias ':' )? field Argument? Modifier? Directive* Object?
Selection = ( '...' | '|' ) ( Inline | Spread )
Inline = TypeCondition? Directive* Object
Spread = fragment Directive*
TypeCondition = ( 'on' | ':' ) type

Fragment = '&' fragment ':' type Frag_Body
Frag_End = ( 'fragment' | '&' ) fragment TypeCondition Frag_Body
Frag_Body = Directive* Object

Argument = '(' Arg_Fields+ | Arg_Values+ ')'
Arg_Value = '$'variable | Arg_List | Arg_Object | Constant
Arg_List = '[' Arg_Values* ']'
Arg_Values = Arg_Value ',' Arg_Values | Arg_Value

Arg_Object = '{' Arg_Fields* '}'
Arg_Fields = Arg_Field ',' Arg_Fields | Arg_Field
Arg_Field = FieldKey ':' Arg_Value

```
