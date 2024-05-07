using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeOutputObjects(
  ILoggerFactory logger,
  IMerge<OutputFieldAst> fields,
  IMerge<IGqlpTypeParameter> typeParameters,
  IMerge<AstAlternate<OutputBaseAst>> alternates
) : AstObjectsMerger<OutputDeclAst, OutputFieldAst, OutputBaseAst>(logger, fields, typeParameters, alternates)
{ }
