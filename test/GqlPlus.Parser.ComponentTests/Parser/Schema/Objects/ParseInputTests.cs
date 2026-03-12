using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Parser.Schema.Objects;

public class ParseInputTests(
  ICheckObject<IGqlpInputField> objectChecks
) : TestObject<IGqlpInputField>(objectChecks)
{ }

internal sealed class ParseInputChecks(
  IParserRepository parsers
) : CheckObject<IGqlpInputField, InputFieldAst>(new InputFactories(), parsers)
{ }
