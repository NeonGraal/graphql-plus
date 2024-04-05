using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeDualObjects(
  ILoggerFactory logger,
  IMerge<DualFieldAst> fields,
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AstAlternate<DualReferenceAst>> alternates
) : AstObjectsMerger<DualDeclAst, DualFieldAst, DualReferenceAst>(logger, fields, typeParameters, alternates)
{ }
