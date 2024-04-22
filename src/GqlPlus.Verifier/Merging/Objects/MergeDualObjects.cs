using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Merging.Objects;

internal class MergeDualObjects(
  ILoggerFactory logger,
  IMerge<DualFieldAst> fields,
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AstAlternate<DualReferenceAst>> alternates
) : AstObjectsMerger<DualDeclAst, DualFieldAst, DualReferenceAst>(logger, fields, typeParameters, alternates)
{ }
