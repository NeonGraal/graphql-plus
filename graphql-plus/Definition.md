# Language Definitions

All keywords and identifiers are case-sensitive.

Except where explicitly specified (in Constants), commas (`,`) are considered whitespace.

## Grammar

Language definitions are given in a modified PEG (Parsing Expression Grammar)

| Operator   | Example       | Description                                                                              |
| ---------- | ------------- | ---------------------------------------------------------------------------------------- |
| Grouping   | `(` exp `)`   | The expression is treated as a single term.                                              |
|            |
| Lookahead  |               | These two operators don't consume the input for the expression                           |
| Positive   | `&` exp       | The expression must match at this point.                                                 |
| Negative   | `!` exp       | The expression must NOT match at this point.                                             |
|            |
| Term       | `Operation`   | Defined elsewhere in the language definition. Terms are capitalized.                     |
| Word       | `category`    | A simple name defined by the regex `\[A-Za-z][A-Za-z0-9_.]+`                             |
| Prefix     | `'$'variable` | A String surrounded by quotes immediately followed by a Word.                            |
| Literal    | `'('`         | A String surrounded by quotes that must appear exactly as written.                       |
| Built-In   | `NUMBER`      | An expression that matches a specific regex as defined below. Built-Ins are in all-caps. |
|            |
| Repetition |
| Optional   | exp `?`       | The expression occurs zero or one times.                                                 |
| Some       | exp `*`       | The expression occurs zero or more times.                                                |
| Many       | exp `+`       | The expression occurs one or more times.                                                 |
|            |
| Sequence   | exp exp       | The expressions must occur in the given order.                                           |
|            |
| Alternate  | exp `\|` exp  | If the first expression doesn't match, try the second expression instead.                |

**Note:** The above are in descending order of precedence

## Built-Ins

| Built-In | RegEx                                | Description                                                                                                                                 | Examples                                              |
| -------- | ------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------- |
| NUMBER   | `[-+]?[0-9_]+(\.[0-9_]]+)?`          | A number, possibly signed and/or with a fractional portion. An underscore (`_`) can be used to separate digit groups                        | 1 2.3 45 67.89 0.10 -11 +12 -13.14 +15.16 17_18.19_20 |
| STRING   | `"([^"]\|\\")*"` or `'([^']\|\\')*'` | A string delimited by either single (`'`) or double (`"`) quotes and with any delimiter characters in the string escaped by backslash (`\`) | "" "a" "b\\"c" "d'e" <br/> '' 'f' 'g"h' 'i\\'j'       |
| REGEX    | `/.*/`                               | A regex delimited by slashes (`/`) conforming to POSIX ERE                                                                                  | /.\*/                                                 |

**Note:** Both STRING and REGEX built-ins can include end-of-line and other control characters.

## Common

```PEG
Default = '=' Constant

EnumValue = ( enum '.' )? value

FieldKey = EnumValue | NUMBER | STRING

Modifier = '?' | '[]' Modifier? | '[' Simple '?'? ']' Modifier?
Simple = Basic | enum
Basic = 'Boolean' | '~' | 'Number' | '0' | 'String' | '*' | 'Unit' |  '_'

Internal = 'Void' | 'Null' | 'null'
```

An Enum Value reference may drop the Enum portion if the Value is unique.

| Modifier   | Syntax           | Notes                                                                                                                        | Description                   |
| ---------- | ---------------- | ---------------------------------------------------------------------------------------------------------------------------- | ----------------------------- |
| Optional   | `?`              | An Optional Result may have the value of `null`. <br/> The `Null` type is effectively the same as `Void?` and so is `Null?`. | Optional _type_               |
| List       | `[]`             | A List Result will be an array with zero or more entries.                                                                    | List of _type_                |
| Dictionary | `[`Simple`?`?`]` | A Dictionary Result will be an object with the given Simple type as the Key. <br/> The Key may be Optional.                  | Dictionary by _key_ of _type_ |

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

## Constant

```PEG
Constant = Const_List | Const_Object | Const_Value
Const_Value = 'true' | 'false' | 'null' | '_' | NUMBER | STRING | EnumValue
Const_List = '[' Cons_Values* ']'
Const_Values = Constant ',' Const_Values | Constant

Const_Object = '{' Const_Fields* '}'
Const_Fields = Const_Field ',' Const_Fields | Const_Field
Const_Field = FieldKey ':' Const_Value
```

A Constant is a single value. Commas (`,`) can be used to separate list values and object fields.

If a Constant Object FieldKey appears more than once, all the values will be merged as follows:

> A merged with B results in:
>
> |                          |     B Value `b` | B List `[b1,b2]` |    B Object `{b1:b2,b3:b4}` |
> | -----------------------: | --------------: | ---------------: | --------------------------: |
> |              A Value `a` |             `b` |      `[a,b1,b2]` |             `{b1:b2,b3:b4}` |
> |         A List `[a1,a2]` |     `[a1,a2,b]` |  `[a1,a2,b1,b2]` |             `{b1:b2,b3:b4}` |
> | A Object `{a1:a2,a3:a4}` | `{a1:a2,a3:a4}` |  `{a1:a2,a3:a4}` | `{a1:a2,a3:a4,b1:b2,b3:b4}` |

## Complete Grammar

```PEG
Default = '=' Constant

EnumValue = ( enum '.' )? value

FieldKey = EnumValue | NUMBER | STRING

Modifier = '?' | '[]' Modifier? | '[' Simple '?'? ']' Modifier?
Simple = Basic | enum
Basic = 'Boolean' | '~' | 'Number' | '0' | 'String' | '*' | 'Unit' |  '_'

Internal = 'Void' | 'Null' | 'null'

Constant = Const_List | Const_Object | Const_Value
Const_Value = 'true' | 'false' | 'null' | '_' | NUMBER | STRING | EnumValue
Const_List = '[' Cons_Values* ']'
Const_Values = Constant ',' Const_Values | Constant

Const_Object = '{' Const_Fields* '}'
Const_Fields = Const_Field ',' Const_Fields | Const_Field
Const_Field = FieldKey ':' Const_Value

```
