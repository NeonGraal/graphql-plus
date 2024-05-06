namespace GqlPlus.Ast;

public class ModifierAstTests
{
  [Fact]
  public void HashCode()
    => _checks.HashCode(() => ModifierAst.Optional(AstNulls.At));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithKey(string key, bool optional)
    => _checks.HashCode(() => new ModifierAst(AstNulls.At, new(AstNulls.At, key), optional));

  [Fact]
  public void Text()
  {
    _checks.Text(() => ModifierAst.Optional(AstNulls.At), "?");
    _checks.Text(() => ModifierAst.List(AstNulls.At), "[]");
  }

  [Theory, RepeatData(Repeats)]
  public void String_WithKey(string key, bool optional)
  {
    string optString = optional ? "?" : "";
    _checks.Text(() => new ModifierAst(AstNulls.At, new(AstNulls.At, key), optional), $"[( !k '{key}' ){optString}]");
  }

  [Fact]
  public void Inequality()
    => _checks.Inequality(
      () => ModifierAst.Optional(AstNulls.At),
      () => ModifierAst.List(AstNulls.At));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithKey(string key, bool optional)
    => _checks.Equality(() => new ModifierAst(AstNulls.At, new(AstNulls.At, key), optional));

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithKey(string key, bool optional)
    => _checks.Inequality(
      () => new ModifierAst(AstNulls.At, new(AstNulls.At, key), optional),
      () => ModifierAst.List(AstNulls.At));

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenKeys(string key1, string key2)
    => _checks.InequalityBetween(key1, key2,
      key => new ModifierAst(AstNulls.At, new(AstNulls.At, key), false),
      key1 == key2);

  internal BaseAstChecks<ModifierAst> _checks = new();
}
