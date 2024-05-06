using System.Runtime.CompilerServices;

namespace GqlPlus.Ast.Schema;

public abstract class AstTypeTests
  : AstAliasedTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithParent(string name, string parent)
      => TypeChecks
      .HashCode_WithParent(name, parent);

  [Theory, RepeatData(Repeats)]
  public void String_WithParent(string name, string parent)
    => TypeChecks
      .String_WithParent(name, parent, ParentString(name, parent));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithParent(string name, string parent)
    => TypeChecks
      .Equality_WithParent(name, parent);

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithParent(string name, string parent)
    => TypeChecks
      .Inequality_WithParent(name, parent);

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenParents(string name, string parent1, string parent2)
    => TypeChecks
      .SkipIf(parent1 == parent2)
      .Inequality_ByParents(name, parent1, parent2);

  protected virtual string ParentString(string name, string parent)
    => $"( !{AliasedChecks.Abbr} {name} :{parent} )";

  internal sealed override IAstAliasedChecks<string> AliasedChecks => TypeChecks;

  internal abstract IAstTypeChecks TypeChecks { get; }
}

internal class AstTypeChecks<TType, TParent>(
  BaseAstChecks<TType>.CreateBy<string> createInput,
  AstTypeChecks<TType, TParent>.ParentCreator createParent,
  [CallerArgumentExpression(nameof(createInput))] string createExpression = ""
) : AstAliasedChecks<TType>(createInput, createExpression)
  , IAstTypeChecks
  where TType : AstType<TParent>
  where TParent : IEquatable<TParent>
{
  protected readonly ParentCreator CreateParent = createParent;

  internal delegate TParent ParentCreator(string parent);

  public void Equality_WithParent(string name, string parent)
    => Equality(() => CreateType(name, parent));

  public void HashCode_WithParent(string name, string parent)
    => HashCode(() => CreateType(name, parent));

  public void Inequality_WithParent(string name, string parent)
    => Inequality(() => CreateInput(name), () => CreateType(name, parent), CreateExpression);

  public void Inequality_ByParents(string name, string parent1, string parent2)
    => InequalityBetween(parent1, parent2, parent => CreateType(name, parent));

  public void String_WithParent(string name, string parent, string expected)
    => Text(() => CreateType(name, parent), expected);

  private TType CreateType(string name, string parent)
    => CreateInput(name) with { Parent = CreateParent(parent) };
}

internal sealed class AstTypeChecks<TType>(
  BaseAstChecks<TType>.CreateBy<string> createInput,
  [CallerArgumentExpression(nameof(createInput))] string createExpression = ""
) : AstTypeChecks<TType, string>(createInput, parent => parent, createExpression)
  , IAstTypeChecks
  where TType : AstType<string>
{ }

internal interface IAstTypeChecks
  : IAstAliasedChecks
{
  void HashCode_WithParent(string name, string parent);
  void String_WithParent(string name, string parent, string expected);
  void Equality_WithParent(string name, string parent);
  void Inequality_WithParent(string name, string parent);
  void Inequality_ByParents(string name, string parent1, string parent2);
}
