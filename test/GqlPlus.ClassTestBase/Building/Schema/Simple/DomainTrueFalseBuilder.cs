using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema.Simple;

public class DomainTrueFalseBuilder
  : DomainItemBuilder
{
  internal bool _isTrue;

  public DomainTrueFalseBuilder(bool isTrue)
  {
    Add<IGqlpDomainTrueFalse>();
    _isTrue = isTrue;
  }

  protected new T Build<T>()
    where T : class, IGqlpDomainTrueFalse
  {
    T result = base.Build<T>();
    result.IsTrue.Returns(_isTrue);
    return result;
  }

  public IGqlpDomainTrueFalse AsTrueFalse
    => Build<IGqlpDomainTrueFalse>();
}

public static class DomainTrueFalseBuilderHelper
{
  public static TBuild WithIsTrue<TBuild>(this TBuild builder, bool isTrue = true)
    where TBuild : DomainTrueFalseBuilder
    => builder.FluentAction(b => b._isTrue = isTrue);
}
