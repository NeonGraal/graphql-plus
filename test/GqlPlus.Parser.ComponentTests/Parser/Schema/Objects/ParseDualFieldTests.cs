using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Parser.Schema.Objects;

public class ParseDualFieldTests(
  ICheckObjectField<IGqlpDualField> checks
) : TestObjectField<IGqlpDualField>(checks)
{ }

internal sealed class ParseDualFieldChecks(
  IParserRepository parsers
) : CheckObjectField<IGqlpDualField, DualFieldAst>(new DualFactories(), parsers)
{ }
