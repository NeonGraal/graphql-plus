using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Parser.Schema.Objects;

public class ParseInputTests(
  ICheckObject<IGqlpInputField> objectChecks
) : TestObject<IGqlpInputField>(objectChecks)
{ }

internal sealed class ParseInputChecks(
  Parser<IGqlpObject<IGqlpInputField>>.D parser
) : CheckObject<IGqlpInputField, InputFieldAst>(new InputFactories(), parser)
{ }
