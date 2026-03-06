using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema.Simple;

public class DomainRegexBuilder
  : DomainItemBuilder
{
  internal string? _pattern;

  public DomainRegexBuilder(string? pattern = null)
  {
    Add<IGqlpDomainRegex>();
    _pattern = pattern;
  }

  protected new T Build<T>()
    where T : class, IGqlpDomainRegex
  {
    T result = base.Build<T>();
    result.Pattern.Returns(_pattern);
    return result;
  }

  public IGqlpDomainRegex AsRegex
    => Build<IGqlpDomainRegex>();
}

public static class DomainRegexBuilderHelper
{
  public static TBuild WithPattern<TBuild>(this TBuild builder, string? pattern)
    where TBuild : DomainRegexBuilder
    => builder.FluentAction(b => b._pattern = pattern);
}
