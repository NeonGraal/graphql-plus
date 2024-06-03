using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeDualFields(
  ILoggerFactory logger
) : AstObjectFieldsMerger<DualFieldAst, IGqlpDualBase>(logger)
{ }
