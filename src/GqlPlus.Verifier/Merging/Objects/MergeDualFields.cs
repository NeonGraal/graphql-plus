using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeDualFields(
  ILoggerFactory logger
) : AstObjectFieldsMerger<DualFieldAst, DualBaseAst>(logger)
{ }
