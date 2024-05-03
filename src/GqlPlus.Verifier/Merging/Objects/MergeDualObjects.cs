using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Merging.Objects;

internal class MergeDualObjects(
  ILoggerFactory logger,
  IMerge<DualFieldAst> fields,
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AstAlternate<DualBaseAst>> alternates
) : AstObjectsMerger<DualDeclAst, DualFieldAst, DualBaseAst>(logger, fields, typeParameters, alternates)
{ }
