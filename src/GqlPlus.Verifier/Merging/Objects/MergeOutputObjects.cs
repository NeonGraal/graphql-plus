using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Merging.Objects;

internal class MergeOutputObjects(
  ILoggerFactory logger,
  IMerge<OutputFieldAst> fields,
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AstAlternate<OutputBaseAst>> alternates
) : AstObjectsMerger<OutputDeclAst, OutputFieldAst, OutputBaseAst>(logger, fields, typeParameters, alternates)
{ }
