# Schema language definition

> See [Definition](Definition.md) on how to read the definition below

``` BNF
Schema = Declaration+

Declaration = Category | Enum | Input | Output | Scalar

Category = 'category' output

Enum = 'enum' enum '=' EnumLabels
Input = 'input' input InputTypeParameters '=' InputDefinitions
Output = 'output' output '=' OutputDefinitions
Scalar = 'scalar' scalar '=' ScalarDefinition


EnumLabels = label | label '|' EnumLabels


InputTypeParameters = '<' InputTypeParameter+ '>'
InputTypeParameter = '$'inputTypeParam

InputDefinitions = InputDefinition | InputDefinition '|' InputDefinitions
InputDefinition = InputType Modifiers?
InputType = InputReference | InputObject
InputReference = Internal | Simple | input InputTypeArguments | '$'inputTypeParam

InputObject = '{' InputFields+ '}'
InputFields = InputField Modifiers? ':' InputReference

InputTypeArguments = '<' InputReference+ '>'


OutputDefinitions = OutputDefinition | OutputDefinition '|' OutputDefinitions
OutputDefinition = ...


ScalarDefinition = ...


Modifier = '?' | '[]' Modifier? | '[' Simple ']' Modifier?

Internal = 'Null' | 'Void' | 'Unit'
Simple = Basic | scalar | enum
Basic = 'Boolean' | 'Number' | 'String'

```
