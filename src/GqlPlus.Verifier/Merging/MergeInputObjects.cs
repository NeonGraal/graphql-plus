using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeInputObjects(
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AlternateAst<InputReferenceAst>> alternates,
  IMerge<InputFieldAst> fields
) : ObjectsMerger<InputDeclAst, InputFieldAst, InputReferenceAst>(typeParameters, alternates, fields)
{ }
