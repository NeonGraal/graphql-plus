# Language Definitions

All keywords and identifiers are case-sensitive.

Except where explicitly specified (in Constants), commas (`,`) and semi-colons (`;`) are considered whitespace.

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
| Term       | `Operation`   | A Term is defined elsewhere in the language definition. Terms are capitalized.           |
| Word       | `category`    | A Word is a simple name defined by the regex `\[A-Za-z][A-Za-z0-9_.]+`                   |
| Prefix     | `'$'variable` | A String surrounded by quotes immediately followed by a Word.                            |
| Literal    | `'('`         | A String surrounded by quotes that must appear exactly as written.                       |
| Built-In   | `NUMBER`      | An expression that matches a specific regex as defined below. Built-Ins are in all-caps. |
|            |
| Repetition |
| Optional   | exp `?`       | The expression occurs zero or once.                                                      |
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
