using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema.Simple;

public class DomainItemBuilder
  : ErrorBuilder
{
  internal bool _excludes;

  public DomainItemBuilder()
    => Add<IGqlpDomainItem>();

  protected new T Build<T>()
    where T : class, IGqlpDomainItem
  {
    T result = base.Build<T>();
    result.Excludes.Returns(_excludes);
    return result;
  }
}

public static class DomainItemBuilderHelper
{
  public static TBuild WithExcludes<TBuild>(this TBuild builder, bool excludes = true)
    where TBuild : DomainItemBuilder
    => builder.FluentAction(b => b._excludes = excludes);
}
