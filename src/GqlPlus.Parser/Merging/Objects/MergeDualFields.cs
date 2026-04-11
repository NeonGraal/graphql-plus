using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging.Objects;

internal class MergeDualFields(
  IMergerRepository mergers
) : AstObjectFieldsMerger<IAstDualField>(mergers)
{ }
