using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

internal class ParseInput(
  ISimpleName name,
  Parser<TypeParameterAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<InputFieldAst, InputBaseAst>>.D definition
) : ObjectParser<InputDeclAst, InputFieldAst, InputBaseAst>(name, param, aliases, option, definition)
{
  protected override InputDeclAst MakeResult(InputDeclAst result, ObjectDefinition<InputFieldAst, InputBaseAst> value)
  {
    result.Parent = value.Parent;
    result.Fields = value.Fields;
    result.Alternates = value.Alternates;

    return result;
  }

  protected override bool ApplyOption(InputDeclAst result, IResult<NullOption> option) => true;

  [return: NotNull]
  protected override InputDeclAst MakePartial(TokenAt at, string? name, string description)
    => new(at, name!, description);
}

internal class ParseInputDefinition(
  Parser<InputFieldAst>.D field,
  ParserArray<IParserCollections, ModifierAst>.DA collections,
  Parser<InputBaseAst>.D objBase
) : ParseObjectDefinition<InputFieldAst, InputBaseAst>(field, collections, objBase)
{
  protected override string Label => "Input";
}
