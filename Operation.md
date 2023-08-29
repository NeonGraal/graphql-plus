# Operation language definition

> See [Definition](Definition.md) on how to read the definition below

```
Operation =  Category? Variables? Result

Category = category name
Variables = '(' Variable* ')'
Result = Type Modifier?

Variable = '$'variable VariableType? VariableDefault?
VariableType = ':' type Modifier?
VariableDefault = '=' Constant

Type = Simple Arguments? | Object
Simple = Internal | Basic
Internal = 'Null' | 'Void' | 'Unit'

Modifier = '?' | '[]' Modifier? | '[' Basic '?'? ']' Modifier?

Basic = 'Boolean' | 'Number' | 'String'

Object = '{' ObjectField* '}'
ObjectField = ObjectKey Object | ObjectKey Modifier?
ObjectKey = field Arguments?

Arguments = '(' Argument ')'
Argument = Constant | Variable | ArgumentList | ArgumentObject
ArgumentList = '[' Argument* ']'
ArgumentObject = '{' ArgumentField* '}'
ArgumentField = FieldKey ':' Argument
FieldKey = field | NUMBER | STRING

Constant = ConstantValue | ConstantList | ConstantObject
ConstantValue = 'true' | 'false' | 'null' | NUMBER | STRING
ConstantList = '[' Constant* ']'
ConstantObject = '{' ConstantField* '}'
ConstantField = FieldKey ':' Constant
```

## Operation

If not specified, an Operation's category is "query" and it's name is blank. _(GraphQL compatibility)_

## Variables

A `Variable`'s Type should only be validated if a Default is also specified and only against it's Modifier as follows:
> | Modifier | Default | Comment |
> |---|---|---|
> | `?` | `null` | A default of `null` is only allowed on Optional types |
> | `[]` | object | **ERROR** A List type cannot have an Object default |
> | `[]` | value | A value is equivalent to a list containing just that value, ie. `[`value`]` |
> | `[`any`]` | list or value | **ERROR** An Object type can only have an object default |

A Variable with the Optional Modifier has an implied Default of `null` and a Variable with a Default of `null` has an implied Optional Modifier.

## Result

