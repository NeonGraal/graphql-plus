using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parse.Schema.Objects;

public class ParseInputBaseTests(
  Parser<InputBaseAst>.D parser
) : TestObjectBase
{
  internal override ICheckObjectBase ObjectBaseChecks => _checks;

  private readonly CheckObjectBase<InputBaseAst> _checks = new(new InputFactories(), parser);
}
