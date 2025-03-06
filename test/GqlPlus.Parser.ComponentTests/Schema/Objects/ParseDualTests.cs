using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class ParseDualTests(
  ICheckObject<IGqlpDualObject> objectChecks
) : TestObject<IGqlpDualObject>(objectChecks)
{ }

internal sealed class ParseDualChecks(
  Parser<IGqlpDualObject>.D parser
) : CheckObject<IGqlpDualObject, DualDeclAst, IGqlpDualField, DualFieldAst, IGqlpDualAlternate, DualAlternateAst, IGqlpDualBase, DualBaseAst, IGqlpDualArg, DualArgAst>(new DualFactories(), parser)
{ }
