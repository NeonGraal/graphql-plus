using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseDualBaseTests(
  ICheckObjectBase<IGqlpDualBase> objectBaseChecks
) : TestObjectBase<IGqlpDualBase>(objectBaseChecks)
{ }

internal sealed class ParseDualBaseChecks(
  Parser<IGqlpDualBase>.D parser
) : CheckObjectBase<IGqlpDualBase, DualBaseAst, IGqlpDualArg, DualArgAst>(new DualFactories(), parser)
{ }
