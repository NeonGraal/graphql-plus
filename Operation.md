# Operation language definition

> See [Definition](Definition.md) on how to read the definition below

```
Operation =  Category? Variables? Result

Category = category name

Variables = '(' Variable* ')'
Variable = '$'variable

Result = Type Modifier?

Type = Simple Arguments? | Object

Modifier = '?' | '[]' Modifier? | '[' Basic '?'? ']' Modifier?

Basic = 'Boolean' | 'Number' | 'String'

Object = '{' ObjectField* '}'
ObjectField = ObjectKey Object | ObjectKey Modifier?
ObjectKey = field Arguments?

Arguments = '(' Argument ')'
Argument = Constant | Variable | '[' Argument* ']' | '{' ArgumentField* '}'
ArgumentField = FieldKey ':' Argument
FieldKey = field | NUMBER | STRING

Constant = 'true' | 'false' | 'null' | NUMBER | STRING | '[' Constant* ']' | '{' ConstantField* '}'
ConstantField = FieldKey ':' Constant
```
