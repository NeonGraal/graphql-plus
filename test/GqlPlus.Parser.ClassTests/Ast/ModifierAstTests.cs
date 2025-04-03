namespace GqlPlus.Ast;

public class ModifierAstTests
{
  [Fact]
  public void HashCode()
    => _checks.HashCode(() => ModifierAst.Optional(AstNulls.At));

  [Theory, RepeatData]
  public void HashCode_WithDict(string key, bool optional)
    => _checks.HashCode(() => ModifierAst.Dict(AstNulls.At, key, optional));

  [Theory, RepeatData]
  public void HashCode_WithParam(string key, bool optional)
    => _checks.HashCode(() => ModifierAst.Param(AstNulls.At, key, optional));

  [Fact]
  public void Text()
  {
    _checks.Text(() => ModifierAst.Optional(AstNulls.At), "?");
    _checks.Text(() => ModifierAst.List(AstNulls.At), "[]");
  }

  [Theory, RepeatData]
  public void String_WithDict(string key, bool optional)
  {
    string optString = optional ? "?" : "";
    _checks.Text(() => ModifierAst.Dict(AstNulls.At, key, optional), $"[{key}{optString}]");
  }

  [Theory, RepeatData]
  public void String_WithParam(string key, bool optional)
  {
    string optString = optional ? "?" : "";
    _checks.Text(() => ModifierAst.Param(AstNulls.At, key, optional), $"[${key}{optString}]");
  }

  [Fact]
  public void Inequality()
    => _checks.Inequality(
      () => ModifierAst.Optional(AstNulls.At),
      () => ModifierAst.List(AstNulls.At));

  [Theory, RepeatData]
  public void Equality_WithDict(string key, bool optional)
    => _checks.Equality(() => ModifierAst.Dict(AstNulls.At, key, optional));

  [Theory, RepeatData]
  public void Equality_WithParam(string key, bool optional)
    => _checks.Equality(() => ModifierAst.Param(AstNulls.At, key, optional));

  [Theory, RepeatData]
  public void Inequality_WithDict(string key, bool optional)
    => _checks.Inequality(
      () => ModifierAst.Dict(AstNulls.At, key, optional),
      () => ModifierAst.List(AstNulls.At));

  [Theory, RepeatData]
  public void Inequality_WithParam(string key, bool optional)
    => _checks.Inequality(
      () => ModifierAst.Dict(AstNulls.At, key, optional),
      () => ModifierAst.Param(AstNulls.At, key, optional));

  [Theory, RepeatData]
  public void Inequality_BetweenKeys(string key1, string key2)
    => _checks.InequalityBetween(key1, key2,
      key => ModifierAst.Dict(AstNulls.At, key, false),
      key1 == key2);

  [Theory, RepeatData]
  public void Inequality_BetweenParams(string key1, string key2)
    => _checks.InequalityBetween(key1, key2,
      key => ModifierAst.Param(AstNulls.At, key, false),
      key1 == key2);

  internal BaseAstChecks<IGqlpModifier> _checks = new();
}
