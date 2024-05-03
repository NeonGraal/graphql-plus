using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public class ParseInputTests(
  Parser<InputDeclAst>.D parser
) : TestObject
{
  internal override ICheckObject ObjectChecks => _checks;

  private readonly CheckObject<InputDeclAst, InputFieldAst, InputBaseAst> _checks = new(new InputFactories(), parser);
}
