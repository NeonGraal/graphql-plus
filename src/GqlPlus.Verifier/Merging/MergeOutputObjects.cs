using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeOutputObjects(
  IMerge<OutputFieldAst> fields,
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AstAlternate<OutputReferenceAst>> alternates
) : AstObjectsMerger<OutputDeclAst, OutputFieldAst, OutputReferenceAst>(fields, typeParameters, alternates)
{ }
