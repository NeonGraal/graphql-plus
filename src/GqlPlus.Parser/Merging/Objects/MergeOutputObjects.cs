using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeOutputObjects(
  ILoggerFactory logger,
  IMerge<OutputFieldAst> fields,
  IMerge<IGqlpTypeParameter> typeParameters,
  IMerge<AstAlternate<IGqlpOutputBase>> alternates
) : AstObjectsMerger<OutputDeclAst, OutputFieldAst, IGqlpOutputBase>(logger, fields, typeParameters, alternates)
{ }
