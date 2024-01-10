using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Model;

public class DirectiveModelTests : ModelAliasedTests
{
  [Theory, RepeatData(Repeats)]
  public void Model_Repeatable(string name, DirectiveOption option)
    => _checks.Directive_Expected(
      new(AstNulls.At, name) { Option = option },
      $@"!!_Directive
name: {name}
repeatable: {(option == DirectiveOption.Repeatable).TrueFalse()}
");

  protected override string ExpectedDescriptionAliases(string input, string description, string aliases)
    => $@"!!_Directive{aliases}{description}
name: {input}
repeatable: false
";

  internal override IModelAliasedChecks AliasedChecks => _checks;

  private readonly DirectiveModelChecks _checks = new();
}
