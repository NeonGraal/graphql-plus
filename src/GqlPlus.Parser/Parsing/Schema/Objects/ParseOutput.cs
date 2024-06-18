using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseOutput(
  ISimpleName name,
  Parser<IGqlpTypeParameter>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<IGqlpOutputField, IGqlpOutputAlternate, IGqlpOutputBase>>.D definition
) : ObjectParser<OutputDeclAst, IGqlpOutputField, IGqlpOutputAlternate, IGqlpOutputBase>(name, param, aliases, option, definition)
{
  protected override OutputDeclAst MakeResult(AstPartial<IGqlpTypeParameter, NullOption> partial, ObjectDefinition<IGqlpOutputField, IGqlpOutputAlternate, IGqlpOutputBase> value)
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
