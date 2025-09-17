using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class ParseDualBaseTests(
  ICheckObjectBase<IGqlpDualBase> objectBaseChecks
) : TestObjectBase<IGqlpDualBase>(objectBaseChecks)
{ }

internal sealed class ParseDualBaseChecks(
  Parser<IGqlpDualBase>.D parser
) : CheckObjectBase<IGqlpDualBase, DualBaseAst, DualArgAst>(new DualFactories(), parser)
{ }
