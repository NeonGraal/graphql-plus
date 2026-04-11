using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Parser.Schema.Objects;

public class ParseDualFieldTests(
  ICheckObjectField<IAstDualField> checks
) : TestObjectField<IAstDualField>(checks)
{ }

internal sealed class ParseDualFieldChecks(
  IParserRepository parsers
) : CheckObjectField<IAstDualField, DualFieldAst>(new DualFactories(), parsers)
{ }
