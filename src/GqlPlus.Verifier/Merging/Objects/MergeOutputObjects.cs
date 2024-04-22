using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Merging.Objects;

internal class MergeOutputObjects(
  ILoggerFactory logger,
  IMerge<OutputFieldAst> fields,
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AstAlternate<OutputReferenceAst>> alternates
) : AstObjectsMerger<OutputDeclAst, OutputFieldAst, OutputReferenceAst>(logger, fields, typeParameters, alternates)
{ }
