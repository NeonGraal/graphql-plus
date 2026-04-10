using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Parser.Schema.Objects;

public class ParseInputTests(
  ICheckObject<IAstInputField> objectChecks
) : TestObject<IAstInputField>(objectChecks)
{ }

internal sealed class ParseInputChecks(
  IParserRepository parsers
) : CheckObject<IAstInputField, InputFieldAst>(new InputFactories(), parsers)
{ }
