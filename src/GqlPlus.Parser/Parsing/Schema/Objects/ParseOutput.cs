using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseOutput(
  ISimpleName name,
  Parser<IGqlpTypeParameter>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate>>.D definition
) : ObjectParser<OutputDeclAst, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate>(name, param, aliases, option, definition)
{
  protected override OutputDeclAst MakeResult(AstPartial<IGqlpTypeParameter, NullOption> partial, ObjectDefinition<IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate> value)
    => new(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParameters = partial.Parameters.ArrayOf<TypeParameterAst>(),
      Parent = value.Parent,
      ObjFields = value.Fields,
      ObjAlternates = value.Alternates,
    };

  protected override OutputDeclAst ToResult(AstPartial<IGqlpTypeParameter, NullOption> partial)
    => new(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParameters = partial.Parameters.ArrayOf<TypeParameterAst>(),
    };
}
