# Language Definitions

| Item | Example | Description |
|---|---|---|
| Term | `Operation` | A Term is defined elsewhere in the langage definition. Terms are capitalized. |
| Optional | item `?` | The previous item may ocurr zero or once. |
| Word | `category` | A Word is simple name defined by the regex [A-Za-z][A-Za-z0-9_.]+ |
| Literal | `'('` | A String surrounded by quotes that must appear exactly as written. |
| Some | item `*` | The previous item may appear zero or more times. |
| Alternate |  items `\|` items | If the previous item(s) don't match, try the following item(s) instead. |
| BuiltIn | `NUMBER` | An item that matches a specific regex as defined below. |
