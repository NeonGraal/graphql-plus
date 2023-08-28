# Schema language

```
Schema = Declaration+

Declaration = Category | Enum | Input | Output | Scalar

Category = "category" output

Enum = "enum" EnumLabel+
EnumLabel = enum ("=" EnumValue)?
EnumValue = NUMBER | STRING

Input = "input" input InputDefinition
InputDefinition = ...

Output = "output" output OutputDefinition
OutputDefinition = ...

Scalar = "scalar" scalar ScalarDefinition
ScalarDefinition = ...
```