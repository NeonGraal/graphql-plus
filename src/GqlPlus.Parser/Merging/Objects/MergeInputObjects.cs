using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeInputObjects(
  ILoggerFactory logger,
  IMerge<InputFieldAst> fields,
  IMerge<IGqlpTypeParameter> typeParameters,
  IMerge<AstAlternate<IGqlpInputBase>> alternates
) : AstObjectsMerger<InputDeclAst, InputFieldAst, IGqlpInputBase>(logger, fields, typeParameters, alternates)
{ }
