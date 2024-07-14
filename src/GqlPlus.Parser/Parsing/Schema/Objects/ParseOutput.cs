using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseOutput(
  ISimpleName name,
  Parser<IGqlpTypeParam>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate>>.D definition
) : ObjectParser<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate>(name, param, aliases, option, definition)
{
  protected override IGqlpOutputObject MakeResult(AstPartial<IGqlpTypeParam, NullOption> partial, ObjectDefinition<IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate> value)
    => new OutputDeclAst(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParams = partial.Params.ArrayOf<TypeParamAst>(),
      Parent = value.Parent,
      ObjFields = value.Fields,
      ObjAlternates = value.Alternates,
    };

  protected override IGqlpOutputObject ToResult(AstPartial<IGqlpTypeParam, NullOption> partial)
    => new OutputDeclAst(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParams = partial.Params.ArrayOf<TypeParamAst>(),
    };
}
