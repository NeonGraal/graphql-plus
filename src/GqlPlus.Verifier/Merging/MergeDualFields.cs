using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeDualFields(
  ILoggerFactory logger
) : FieldsMerger<DualFieldAst, DualReferenceAst>(logger)
{ }
