using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseOutput(
  ISimpleName name,
  Parser<TypeParameterAst>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<OutputFieldAst, OutputBaseAst>>.D definition
) : ObjectParser<OutputDeclAst, OutputFieldAst, OutputBaseAst>(name, param, aliases, option, definition)
{
  protected override OutputDeclAst MakeResult(AstPartial<TypeParameterAst, NullOption> partial, ObjectDefinition<OutputFieldAst, OutputBaseAst> value)
    => new(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParameters = partial.Parameters,
      Parent = value.Parent,
      Fields = value.Fields,
      Alternates = value.Alternates,
    };

  protected override OutputDeclAst ToResult(AstPartial<TypeParameterAst, NullOption> partial)
    => new(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParameters = partial.Parameters,
    };
}

internal class ParseOutputDefinition(
  Parser<OutputFieldAst>.D objField,
  ParserArray<IParserCollections, ModifierAst>.DA collections,
  Parser<OutputBaseAst>.D objBase
) : ParseObjectDefinition<OutputFieldAst, OutputBaseAst>(objField, collections, objBase)
{
  protected override string Label => "Output";
}
