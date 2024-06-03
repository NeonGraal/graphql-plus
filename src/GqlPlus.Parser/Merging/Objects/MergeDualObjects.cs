using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeDualObjects(
  ILoggerFactory logger,
  IMerge<DualFieldAst> fields,
  IMerge<IGqlpTypeParameter> typeParameters,
  IMerge<AstAlternate<IGqlpDualBase>> alternates
) : AstObjectsMerger<DualDeclAst, DualFieldAst, IGqlpDualBase>(logger, fields, typeParameters, alternates)
{ }
