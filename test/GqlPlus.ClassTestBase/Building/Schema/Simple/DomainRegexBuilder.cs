using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema.Simple;

public class DomainRegexBuilder
  : DomainItemBuilder
{
  internal string? _pattern;

  public DomainRegexBuilder(string? pattern = null)
  {
    Add<IAstDomainRegex>();
    _pattern = pattern;
  }

  protected new T Build<T>()
    where T : class, IAstDomainRegex
  {
    T result = base.Build<T>();
    result.Pattern.Returns(_pattern);
    return result;
  }

  public IAstDomainRegex AsRegex
    => Build<IAstDomainRegex>();
}

public static class DomainRegexBuilderHelper
{
  public static TBuild WithPattern<TBuild>(this TBuild builder, string? pattern)
    where TBuild : DomainRegexBuilder
    => builder.FluentAction(b => b._pattern = pattern);
}
