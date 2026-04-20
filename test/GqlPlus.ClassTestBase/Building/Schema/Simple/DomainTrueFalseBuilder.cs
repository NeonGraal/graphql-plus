using GqlPlus.Ast.Schema;

namespace GqlPlus.Building.Schema.Simple;

public class DomainTrueFalseBuilder
  : DomainItemBuilder
{
  internal bool _isTrue;

  public DomainTrueFalseBuilder(bool isTrue)
  {
    Add<IAstDomainTrueFalse>();
    _isTrue = isTrue;
  }

  protected new T Build<T>()
    where T : class, IAstDomainTrueFalse
  {
    T result = base.Build<T>();
    result.IsTrue.Returns(_isTrue);
    return result;
  }

  public IAstDomainTrueFalse AsTrueFalse
    => Build<IAstDomainTrueFalse>();
}

public static class DomainTrueFalseBuilderHelper
{
  public static TBuild WithIsTrue<TBuild>(this TBuild builder, bool isTrue = true)
    where TBuild : DomainTrueFalseBuilder
    => builder.FluentAction(b => b._isTrue = isTrue);
}
