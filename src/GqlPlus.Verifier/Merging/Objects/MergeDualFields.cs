using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Merging.Objects;

internal class MergeDualFields(
  ILoggerFactory logger
) : FieldsMerger<DualFieldAst, DualReferenceAst>(logger)
{ }
