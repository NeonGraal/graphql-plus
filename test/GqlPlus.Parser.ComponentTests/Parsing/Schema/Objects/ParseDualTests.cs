using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualTests(
  ICheckObject<IGqlpDualObject> objectChecks
) : TestObject<IGqlpDualObject>(objectChecks)
{ }

internal sealed class ParseDualChecks(
  Parser<IGqlpDualObject>.D parser
) : CheckObject<IGqlpDualObject, DualDeclAst, IGqlpDualField, DualFieldAst, IGqlpDualAlternate, DualAlternateAst, IGqlpDualBase, DualBaseAst, IGqlpDualArgument, DualArgumentAst>(new DualFactories(), parser)
{ }
