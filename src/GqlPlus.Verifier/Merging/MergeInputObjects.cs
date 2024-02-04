using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeInputObjects(
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AstAlternate<InputReferenceAst>> alternates,
  IMerge<InputFieldAst> fields
) : AstObjectsMerger<InputDeclAst, InputFieldAst, InputReferenceAst>(typeParameters, alternates, fields)
{ }
