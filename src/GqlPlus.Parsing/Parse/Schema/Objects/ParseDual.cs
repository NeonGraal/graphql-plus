using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parse.Schema.Objects;

internal class ParseDual(
  ISimpleName name,
  Parser<TypeParameterAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<DualFieldAst, DualBaseAst>>.D definition
) : ObjectParser<DualDeclAst, DualFieldAst, DualBaseAst>(name, param, aliases, option, definition)
{
  protected override DualDeclAst MakeResult(AstPartial<TypeParameterAst, NullOption> partial, ObjectDefinition<DualFieldAst, DualBaseAst> value)
    => new(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParameters = partial.Parameters,
      Parent = value.Parent,
      Fields = value.Fields,
      Alternates = value.Alternates,
    };

  protected override DualDeclAst ToResult(AstPartial<TypeParameterAst, NullOption> partial)
    => new(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParameters = partial.Parameters,
    };
}

internal class ParseDualDefinition(
  Parser<DualFieldAst>.D field,
  ParserArray<IParserCollections, ModifierAst>.DA collections,
  Parser<DualBaseAst>.D objBase
) : ParseObjectDefinition<DualFieldAst, DualBaseAst>(field, collections, objBase)
{
  protected override string Label => "Dual";
}
