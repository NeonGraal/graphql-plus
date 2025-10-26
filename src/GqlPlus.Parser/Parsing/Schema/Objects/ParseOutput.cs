using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseOutput(
  ISimpleName name,
  Parser<IGqlpTypeParam>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<IGqlpOutputField>>.D definition
) : ObjectParser<IGqlpOutputObject, IGqlpOutputField>(name, param, aliases, option, definition)
{
  protected override IGqlpOutputObject MakeResult(AstPartial<IGqlpTypeParam, NullOption> partial, ObjectDefinition<IGqlpOutputField> value)
    => new OutputDeclAst(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParams = partial.Params,
      Parent = value.Parent,
      ObjFields = value.Fields,
      Alternates = value.Alternates,
    };

  protected override IGqlpOutputObject ToResult(AstPartial<IGqlpTypeParam, NullOption> partial)
    => new OutputDeclAst(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParams = partial.Params,
    };
}
