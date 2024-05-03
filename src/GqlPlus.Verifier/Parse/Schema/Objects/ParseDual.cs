using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

internal class ParseDual(
  ISimpleName name,
  Parser<TypeParameterAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<DualFieldAst, DualBaseAst>>.D definition
) : ObjectParser<DualDeclAst, DualFieldAst, DualBaseAst>(name, param, aliases, option, definition)
{
  protected override DualDeclAst MakeResult(DualDeclAst result, ObjectDefinition<DualFieldAst, DualBaseAst> value)
    => result with {
      Parent = value.Parent,
      Fields = value.Fields,
      Alternates = value.Alternates,
    };

  protected override bool ApplyOption(DualDeclAst result, IResult<NullOption> option) => true;

  [return: NotNull]
  protected override DualDeclAst MakePartial(TokenAt at, string? name, string description)
    => new(at, name!, description);
}

internal class ParseDualDefinition(
  Parser<DualFieldAst>.D field,
  ParserArray<IParserCollections, ModifierAst>.DA collections,
  Parser<DualBaseAst>.D objBase
) : ParseObjectDefinition<DualFieldAst, DualBaseAst>(field, collections, objBase)
{
  protected override string Label => "Dual";
}
