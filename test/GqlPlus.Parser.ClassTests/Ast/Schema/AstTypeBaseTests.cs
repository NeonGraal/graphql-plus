using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema;

public abstract class AstTypeBaseTests
  : AstAliasedBaseTests
{
  [Theory, RepeatData]
  public void HashCode_WithParent(string name, string parent)
      => TypeChecks
      .HashCode_WithParent(name, parent);

  [Theory, RepeatData]
  public void Text_WithParent(string name, string parent)
    => TypeChecks
      .Text_WithParent(name, parent);

  [Theory, RepeatData]
  public void Equality_WithParent(string name, string parent)
    => TypeChecks
      .Equality_WithParent(name, parent);

  [Theory, RepeatData]
  public void Inequality_WithParent(string name, string parent)
    => TypeChecks
      .Inequality_WithParent(name, parent);

  [Theory, RepeatData]
  public void Inequality_BetweenParents(string name, string parent1, string parent2)
    => TypeChecks.Inequality_ByParents(name, parent1, parent2);

  protected virtual string ParentString(string name, string parent)
    => $"( !{AliasedChecks.Abbr} {name} :( !Tr {parent} ) )";

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
  where TParent : IGqlpDescribed, IEquatable<TParent>
{
  internal readonly ParentCreator CreateParent = createParent;

  internal delegate TParent ParentCreator(string parent);

  public void Equality_WithParent(string name, string parent)
    => Equality(() => CreateType(name, parent));

  public void HashCode_WithParent(string name, string parent)
    => HashCode(() => CreateType(name, parent));

  public void Inequality_WithParent(string name, string parent)
    => Inequality(() => CreateInput(name), () => CreateType(name, parent), CreateExpression);

  public void Inequality_ByParents(string name, string parent1, string parent2)
    => this.SkipEqual(parent1, parent2)
    .InequalityBetween(parent1, parent2, parent => CreateType(name, parent));

  public void Text_WithParent(string name, string parent)
    => Text(() => CreateType(name, parent), ParentString(name, parent));

  private TType CreateType(string name, string parent)
    => CreateInput(name) with { Parent = CreateParent(parent) };

  protected virtual string ParentString(string name, string parent)
    => $"( !{Abbr} {name} :( !Tr {parent} ) )";
}

internal class AstTypeChecks<TType>(
  BaseAstChecks<TType>.CreateBy<string> createInput,
  [CallerArgumentExpression(nameof(createInput))] string createExpression = ""
) : AstTypeChecks<TType, IGqlpTypeRef>(createInput, MakeParent, createExpression)
  , IAstTypeChecks
  where TType : AstType<IGqlpTypeRef>
{
  internal static IGqlpTypeRef MakeParent(string parent)
    => new TypeRefAst(AstNulls.At, parent);
}

internal interface IAstTypeChecks
  : IAstAliasedChecks
{
  void HashCode_WithParent(string name, string parent);
  void Text_WithParent(string name, string parent);
  void Equality_WithParent(string name, string parent);
  void Inequality_WithParent(string name, string parent);
  void Inequality_ByParents(string name, string parent1, string parent2);
}
