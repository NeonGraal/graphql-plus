# Schema language definition

> See [Definition](Definition.md) on how to read the definition below

```
Schema = Declaration+

Declaration = Category | Enum | Input | Output | Scalar

Category = 'category' output

Enum = 'enum' enum '=' EnumLabels
Input = 'input' input InputTypeParameters '=' InputDefinitions
Output = 'output' output '=' OutputDefinitions
Scalar = 'scalar' scalar '=' ScalarDefinition


EnumLabels = label | label '|' EnumLabels


InputTypeParameters = '<' InputTypeParameter+ '>'
InputTypeParameter = '$'inputparam

InputDefinitions = InputDefinition | InputDefinition '|' InputDefinitions
InputDefinition = InputType Modifiers?
InputType = InputReference | InputObject
InputReference = Simple | input InputTypeArguments | '$'inputparam

InputObject = '{' InputFields+ '}'
InputFields = InputField Modifiers? ':' InputReference

InputTypeArguments = '<' InputReference+ '>'


OutputDefinitions = OutputDefinition | OutputDefinition '|' OutputDefinitions
OutputDefinition = ...


ScalarDefinition = ...


Modifier = '?' | '[]' Modifier? | '[' Simple ']' Modifier?

Simple = Basic | scalar | enum
Basic = 'Boolean' | 'Number' | 'String'

```