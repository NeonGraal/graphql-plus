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
  Parser<ObjectDefinition<OutputFieldAst, OutputBaseAst>>.D definition
) : ObjectParser<OutputDeclAst, OutputFieldAst, OutputBaseAst>(name, param, aliases, option, definition)
{
  protected override OutputDeclAst MakeResult(OutputDeclAst result, ObjectDefinition<OutputFieldAst, OutputBaseAst> value)
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
  Parser<OutputFieldAst>.D objField,
  ParserArray<IParserCollections, ModifierAst>.DA collections,
  Parser<OutputBaseAst>.D objBase
) : ParseObjectDefinition<OutputFieldAst, OutputBaseAst>(objField, collections, objBase)
{
  protected override string Label => "Output";
}
