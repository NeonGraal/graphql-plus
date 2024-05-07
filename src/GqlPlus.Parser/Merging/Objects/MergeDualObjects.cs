using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeDualObjects(
  ILoggerFactory logger,
  IMerge<DualFieldAst> fields,
  IMerge<IGqlpTypeParameter> typeParameters,
  IMerge<AstAlternate<DualBaseAst>> alternates
) : AstObjectsMerger<DualDeclAst, DualFieldAst, DualBaseAst>(logger, fields, typeParameters, alternates)
{ }
