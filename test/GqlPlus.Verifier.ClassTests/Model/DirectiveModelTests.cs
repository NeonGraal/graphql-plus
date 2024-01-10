using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Model;

public class DirectiveModelTests
{
  [Theory, RepeatData(Repeats)]
  public void Model_Default(string name)
    => _checks.Directive_Expected(
      new(AstNulls.At, name),
      $@"!!_Directive
name: {name}
repeatable: false
");

  [Theory, RepeatData(Repeats)]
  public void Model_Description(string name, string contents)
    => _checks.Directive_Expected(
      new(AstNulls.At, name) { Description = contents },
      $@"!!_Directive
description: {_checks.YamlQuoted(contents)}
name: {name}
repeatable: false
");

  [Theory, RepeatData(Repeats)]
  public void Model_Aliases(string name, string[] aliases)
    => _checks.Directive_Expected(
      new(AstNulls.At, name) { Aliases = aliases },
      $@"!!_Directive
aliases: [{string.Join(", ", aliases)}]
name: {name}
repeatable: false
");

  private readonly DirectiveModelChecks _checks = new();
}
