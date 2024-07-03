using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseInputTests(
  Parser<IGqlpInputObject>.D parser
) : TestObject
{
  internal override ICheckObject ObjectChecks => _checks;

  private readonly CheckObject<IGqlpInputObject, InputDeclAst, IGqlpInputField, InputFieldAst, IGqlpInputAlternate, InputAlternateAst, IGqlpInputBase, InputBaseAst, IGqlpInputArgument, InputArgumentAst> _checks = new(new InputFactories(), parser);
}
