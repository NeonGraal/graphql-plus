# Language Definitions

| Item | Example | Description |
|---|---|---|
| Term | `Operation` | A Term is defined elsewhere in the language definition. Terms are capitalized. |
| Word | `category` | A Word is simple name defined by the regex `\[A-Za-z][A-Za-z0-9_.]+` |
| Literal | `'('` | A String surrounded by quotes that must appear exactly as written. |
| BuiltIn | `NUMBER` | An item that matches a specific regex as defined below. |
| |
| Optional | item `?` | The item may occur zero or once. |
| Some | item `*` | The item may appear zero or more times. |
| Many | item `+` | The item may appear one or more times. |
| |
| Sequence | item item | The items must match in the given order. |
| |
| Alternate |  item+ `\|` item+ | If the previous item(s) don't match, try the following item(s) instead. |

**Note:** The above are in descending order of precedence

## BuiltIns

| BuiltIn | RegEx | Description | Examples |
|---|---|---|---|
| NUMBER | `[-+]?[0-9_]+(\.[0-9_]]+)?` | A number, possibly signed and/or with a fractional portion. An underscore (`_`) can be used to separate digit groups | 1 2.3 45 67.89 0.10 -11 +12 -13.14 +15.16 17_18.19_20 |
| STRING | `"([^"]\|\\")*"` or `'([^']\|\\')*'` | A string delimited by either single (`'`) or double (`"`) quotes and with any delimiter characters in the string escaped by backslash (`\`) | "" "a" "b\\"c" "d'e" <br/> '' 'f' 'g"h' 'i\\'j' |
| REGEX | `/.*/` | A regex delimited by slashes (`/`) conforming to POSIX ERE | /.*/ |
