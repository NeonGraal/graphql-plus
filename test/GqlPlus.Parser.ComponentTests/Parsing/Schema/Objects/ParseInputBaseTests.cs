using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputBaseTests(
  ICheckObjectBase<IGqlpInputBase> objectBaseChecks
) : TestObjectBase<IGqlpInputBase>(objectBaseChecks)
{ }

internal sealed class ParseInputBaseChecks(
  Parser<IGqlpInputBase>.D parser
) : CheckObjectBase<IGqlpInputBase, InputBaseAst, IGqlpInputArgument, InputArgumentAst>(new InputFactories(), parser)
{ }
