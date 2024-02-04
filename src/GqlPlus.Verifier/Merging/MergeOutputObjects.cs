using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeOutputObjects(
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AstAlternate<OutputReferenceAst>> alternates,
  IMerge<OutputFieldAst> fields
) : AstObjectsMerger<OutputDeclAst, OutputFieldAst, OutputReferenceAst>(typeParameters, alternates, fields)
{ }
