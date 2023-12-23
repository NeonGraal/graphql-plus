using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeOutputObjects(
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AlternateAst<OutputReferenceAst>> alternates,
  IMerge<OutputFieldAst> fields
) : ObjectsMerger<OutputDeclAst, OutputFieldAst, OutputReferenceAst>(typeParameters, alternates, fields)
{ }
