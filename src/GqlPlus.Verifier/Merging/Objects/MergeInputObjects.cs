using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Merging.Objects;

internal class MergeInputObjects(
  ILoggerFactory logger,
  IMerge<InputFieldAst> fields,
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AstAlternate<InputReferenceAst>> alternates
) : AstObjectsMerger<InputDeclAst, InputFieldAst, InputReferenceAst>(logger, fields, typeParameters, alternates)
{ }
