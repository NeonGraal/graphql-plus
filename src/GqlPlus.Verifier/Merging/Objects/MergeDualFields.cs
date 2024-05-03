using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Merging.Objects;

internal class MergeDualFields(
  ILoggerFactory logger
) : AstObjectFieldsMerger<DualFieldAst, DualBaseAst>(logger)
{ }
