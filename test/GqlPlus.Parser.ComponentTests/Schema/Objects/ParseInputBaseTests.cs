using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class ParseInputBaseTests(
  ICheckObjectBase<IGqlpInputBase> objectBaseChecks
) : TestObjectBase<IGqlpInputBase>(objectBaseChecks)
{ }

internal sealed class ParseInputBaseChecks(
  Parser<IGqlpInputBase>.D parser
) : CheckObjectBase<IGqlpInputBase, InputBaseAst, InputArgAst>(new InputFactories(), parser)
{ }
