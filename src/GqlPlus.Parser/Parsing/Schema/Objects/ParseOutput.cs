using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseOutput(
  ISimpleName name,
  Parser<IGqlpTypeParameter>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<OutputFieldAst, OutputBaseAst>>.D definition
) : ObjectParser<OutputDeclAst, OutputFieldAst, OutputBaseAst>(name, param, aliases, option, definition)
{
  protected override OutputDeclAst MakeResult(AstPartial<IGqlpTypeParameter, NullOption> partial, ObjectDefinition<OutputFieldAst, OutputBaseAst> value)
    => new(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParameters = partial.Parameters.ArrayOf<TypeParameterAst>(),
      Parent = value.Parent,
      Fields = value.Fields,
      Alternates = value.Alternates,
    };

  protected override OutputDeclAst ToResult(AstPartial<IGqlpTypeParameter, NullOption> partial)
    => new(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParameters = partial.Parameters.ArrayOf<TypeParameterAst>(),
    };
}

internal class ParseOutputDefinition(
  Parser<OutputFieldAst>.D objField,
  ParserArray<IParserCollections, IGqlpModifier>.DA collections,
  Parser<OutputBaseAst>.D objBase
) : ParseObjectDefinition<OutputFieldAst, OutputBaseAst>(objField, collections, objBase)
{
  protected override string Label => "Output";
}
