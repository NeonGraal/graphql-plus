using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Parser.Schema.Objects;

public class ParseDualTests(
  ICheckObject<IAstDualField> objectChecks
) : TestObject<IAstDualField>(objectChecks)
{ }

internal sealed class ParseDualChecks(
  IParserRepository parsers
) : CheckObject<IAstDualField, DualFieldAst>(new DualFactories(), parsers)
{ }
