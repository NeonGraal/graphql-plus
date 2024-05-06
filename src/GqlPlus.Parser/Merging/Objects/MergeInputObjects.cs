using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeInputObjects(
  ILoggerFactory logger,
  IMerge<InputFieldAst> fields,
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AstAlternate<InputBaseAst>> alternates
) : AstObjectsMerger<InputDeclAst, InputFieldAst, InputBaseAst>(logger, fields, typeParameters, alternates)
{ }
