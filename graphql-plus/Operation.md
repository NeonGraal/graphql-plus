# Operation language definition

> See [Definition](Definition.md) on how to read the definitions below.

## Operation

```PEG
Operation = ( category name? )? Variables? Directive* Result Fragment*
```

If not specified, an Operation's category is "query". This is for GraphQL compatibility.

## Variables

```PEG
Variables = '(' Variable+ ')'
Variable = '$'variable ( ':' Var_Type )? Modifier? ( '=' Constant )? Directive*
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
Result = ( ':' Simple Argument? | Object ) Modifier?
```

An Operation's Result is either:

- a Simple type with an optional Argument and/or Modifier(s), or
- an Object type with optional Modifier(s).

## Modifier

```PEG
Modifier = '?' | '[]' Modifier? | '[' Basic '?'? ']' Modifier?
Basic = 'Boolean' | '~' | 'Number' | '0' | 'String' | '*' | 'Unit' |  '_' | enum
```

| Modifier   | Syntax          | Notes                                                                                                                        | Description                   |
| ---------- | --------------- | ---------------------------------------------------------------------------------------------------------------------------- | ----------------------------- |
| Optional   | `?`             | An Optional Result may have the value of `null`. <br/> The `Null` type is effectively the same as `Void?` and so is `Null?`. | Optional _type_               |
| List       | `[]`            | A List Result will be an array with zero or more entries.                                                                    | List of _type_                |
| Dictionary | `[`Basic`?`?`]` | A Dictionary Result will be an object with the given Basic type as the Key. <br/> The Key may be Optional.                   | Dictionary by _key_ of _type_ |

Multiple Modifiers from left to right are from outside to inside finishing with the initial type.

| Syntax                     | Description                                                                          | Example                     |
| -------------------------- | ------------------------------------------------------------------------------------ | --------------------------- |
| `String?`                  | Optional String                                                                      | `""`                        |
| `String[]`                 | List of String                                                                       | `[ "", "a" ]`               |
| `String[]?`                | List of Optional String                                                              | `[ "", null ]`              |
| `String[Number?]`          | Dictionary by Optional Number of String                                              | `{ 1:"", null:"a", 2:"B" }` |
| `String[][Number][Unit?]?` | List of Dictionary by Number of <br/> Dictionary by Optional Unit of Optional String | _See Example 1 below_       |

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

## Simple

```PEG
Simple = Internal | Basic
Internal = 'Void' | 'Null' | 'null'
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
Object = '{' Selection+ '}'
Selection = Field | ( '...' | '|' ) ( Inline | Spread )
Field = ( alias ':' )? field Argument? Modifier? Directive* Object?
Inline = TypeCondition? Directive* Object
Spread = fragment Directive*
TypeCondition = ( 'on' | ':' ) type
```

A Result Object is a selection of fields or fragments.

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
| `{ user(12) { id name } }`            | `{ user:{ id:12; name:"Andrew" } }`                              |
| `{ user(12)[] { id name } }`          | `{ user:[ { id:12; name:"Andrew" } ] }`                          |
| `{ user("A*") { id name } }`          | `{ user:{ id:12; name:"Andrew" } }`                              |
| `{ All_A: user("A*")[] { id name } }` | `{ All_A:[ { id:12; name:"Andrew" }, { id:34; name:"Alan" } ] }` |

## Fragment

```PEG
Fragment = ( 'fragment' | '&' ) fragment TypeCondition Directive* Object
```

## Argument

```PEG
Argument = '(' Arg_Value ',' Arg_Values ')' | '(' Arg_Fields ')' | '(' Arg_Value* ')'
Arg_Value = '$'variable | Arg_List | Arg_Object | Constant
Arg_List = '[' Arg_Values ']' | '[' Arg_Value* ']'
Arg_Values = Arg_Value ',' Arg_Values | Arg_Value

Arg_Object = '{' Arg_Fields '}' | '{' ( FieldKey ':' Arg_Value )* '}' | Arg_Fields
Arg_Fields = Arg_Field ';' Arg_Fields | Arg_Field
Arg_Field = FieldKey ':' ArgValues

FieldKey = ( enum '.' )? field | NUMBER | STRING
```

An Argument is usually a single value. If multiple values are provided they are treated as a list. If one or more fields are provided they are treated as an object.

Commas (`,`) can be used to separate list values and semi-colons (`;`) can be used to separate object fields.

## Constant

```PEG
Constant = Const_List | Const_Object | Const_Value
Const_Value = 'true' | 'false' | 'null' | '_' | NUMBER | STRING | ( enum '.' )? label
Const_List = '[' Cons_Values ']' | '[' Constant* ']'
Const_Values = Constant ',' Const_Values | Constant

Const_Object = '{' Const_Fields '}' | '{' ( FieldKey ':' Constant )* '}'
Const_Fields = Const_Field ';' Const_Fields | Const_Field
Const_Field = FieldKey ':' Const_Values
```

A Constant is a single value. Commas (`,`) can be used to separate list values and semi-colons (`;`) can be used to separate object fields.

## Complete Grammar

```PEG
Operation = ( category name? )? Variables? Directive* Result Fragment*

Variables = '(' Variable+ ')'
Variable = '$'variable ( ':' Var_Type )? Modifier? ( '=' Constant )? Directive*
Var_Type = Var_Null '!'?
Var_Null = '[' Var_Type ']' | type

Directive = '@'directive Argument?

Result = ( ':' Simple Argument? | Object ) Modifier?

Modifier = '?' | '[]' Modifier? | '[' Basic '?'? ']' Modifier?
Basic = 'Boolean' | '~' | 'Number' | '0' | 'String' | '*' | 'Unit' |  '_' | enum

Simple = Internal | Basic
Internal = 'Void' | 'Null' | 'null'

Object = '{' Selection+ '}'
Selection = Field | ( '...' | '|' ) ( Inline | Spread )
Field = ( alias ':' )? field Argument? Modifier? Directive* Object?
Inline = TypeCondition? Directive* Object
Spread = fragment Directive*
TypeCondition = ( 'on' | ':' ) type

Fragment = ( 'fragment' | '&' ) fragment TypeCondition Directive* Object

Argument = '(' Arg_Value ',' Arg_Values ')' | '(' Arg_Fields ')' | '(' Arg_Value* ')'
Arg_Value = '$'variable | Arg_List | Arg_Object | Constant
Arg_List = '[' Arg_Values ']' | '[' Arg_Value* ']'
Arg_Values = Arg_Value ',' Arg_Values | Arg_Value

Arg_Object = '{' Arg_Fields '}' | '{' ( FieldKey ':' Arg_Value )* '}' | Arg_Fields
Arg_Fields = Arg_Field ';' Arg_Fields | Arg_Field
Arg_Field = FieldKey ':' ArgValues

FieldKey = ( enum '.' )? field | NUMBER | STRING

Constant = Const_List | Const_Object | Const_Value
Const_Value = 'true' | 'false' | 'null' | '_' | NUMBER | STRING | ( enum '.' )? label
Const_List = '[' Cons_Values ']' | '[' Constant* ']'
Const_Values = Constant ',' Const_Values | Constant

Const_Object = '{' Const_Fields '}' | '{' ( FieldKey ':' Constant )* '}'
Const_Fields = Const_Field ';' Const_Fields | Const_Field
Const_Field = FieldKey ':' Const_Values

```
