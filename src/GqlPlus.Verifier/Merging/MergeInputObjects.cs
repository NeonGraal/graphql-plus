using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeInputObjects(
  IMerge<InputFieldAst> fields,
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AstAlternate<InputReferenceAst>> alternates
) : AstObjectsMerger<InputDeclAst, InputFieldAst, InputReferenceAst>(fields, typeParameters, alternates)
{ }
