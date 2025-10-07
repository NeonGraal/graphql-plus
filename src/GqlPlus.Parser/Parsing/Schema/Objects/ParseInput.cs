using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseInput(
  ISimpleName name,
  Parser<IGqlpTypeParam>.DA param,
  Parser<string>.DA aliases,
  Parser<IOptionParser<NullOption>, NullOption>.D option,
  Parser<ObjectDefinition<IGqlpInputField>>.D definition
) : ObjectParser<IGqlpInputObject, IGqlpInputField>(name, param, aliases, option, definition)
{
  protected override IGqlpInputObject MakeResult(AstPartial<IGqlpTypeParam, NullOption> partial, ObjectDefinition<IGqlpInputField> value)
    => new InputDeclAst(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParams = partial.Params.ArrayOf<TypeParamAst>(),
      Parent = value.Parent,
      ObjFields = value.Fields,
      Alternates = value.Alternates,
    };

  protected override IGqlpInputObject ToResult(AstPartial<IGqlpTypeParam, NullOption> partial)
    => new InputDeclAst(partial.At, partial.Name, partial.Description) {
      Aliases = partial.Aliases,
      TypeParams = partial.Params.ArrayOf<TypeParamAst>(),
    };
}
