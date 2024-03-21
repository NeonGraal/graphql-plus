using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeDualObjects(
  IMerge<DualFieldAst> fields,
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AstAlternate<DualReferenceAst>> alternates
) : AstObjectsMerger<DualDeclAst, DualFieldAst, DualReferenceAst>(fields, typeParameters, alternates)
{ }
