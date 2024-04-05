using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeInputObjects(
  ILoggerFactory logger,
  IMerge<InputFieldAst> fields,
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AstAlternate<InputReferenceAst>> alternates
) : AstObjectsMerger<InputDeclAst, InputFieldAst, InputReferenceAst>(logger, fields, typeParameters, alternates)
{ }
