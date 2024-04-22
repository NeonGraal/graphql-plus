using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

internal class ParseOutput(
  ISimpleName name,
  Parser<TypeParameterAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<OutputFieldAst, OutputReferenceAst>>.D definition
) : ObjectParser<OutputDeclAst, OutputFieldAst, OutputReferenceAst>(name, param, aliases, option, definition)
{
  protected override OutputDeclAst MakeResult(OutputDeclAst result, ObjectDefinition<OutputFieldAst, OutputReferenceAst> value)
  {
    result.Parent = value.Parent;
    result.Fields = value.Fields;
    result.Alternates = value.Alternates;

    return result;
  }

  protected override bool ApplyOption(OutputDeclAst result, IResult<NullOption> option) => true;

  [return: NotNull]
  protected override OutputDeclAst MakePartial(TokenAt at, string? name, string description)
    => new(at, name!, description);
}

internal class ParseOutputDefinition(
  Parser<OutputFieldAst>.D field,
  ParserArray<IParserCollections, ModifierAst>.DA collections,
  Parser<OutputReferenceAst>.D reference
) : ParseObjectDefinition<OutputFieldAst, OutputReferenceAst>(field, collections, reference)
{
  protected override string Label => "Output";
}
