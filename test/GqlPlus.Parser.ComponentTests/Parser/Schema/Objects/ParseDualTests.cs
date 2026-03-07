using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Parser.Schema.Objects;

public class ParseDualTests(
  ICheckObject<IGqlpDualField> objectChecks
) : TestObject<IGqlpDualField>(objectChecks)
{ }

internal sealed class ParseDualChecks(
  IParserRepository parsers
) : CheckObject<IGqlpDualField, DualFieldAst>(new DualFactories(), parsers)
{ }
