# Operation language

```
Operation =  Category? Variables? Result

Category = category name

Variables = "(" Variable* ")"
Variable = "$"variable

Result = Type Modifier?

Type = Simple Arguments? | Object

Modifier = "?" | "[]" Modifier? | "[" Simple "]" Modifier?

Simple = "Boolean" | "Number" | "String"

Object = "{" ObjectField* "}"
ObjectField = field Arguments? Object | field Arguments? Modifier?

Arguments = "(" Argument ")"
Argument = Constant | Variable | "[" Argument* "]" | "{" ArgumentField* "}"
ArgumentField = field ":" Argument

Constant = "true" | "false" | "_" | NUMBER | STRING | "[" Constant* "]" | "{" ConstantField* "}"
ConstantField = field ":" Constant
```
