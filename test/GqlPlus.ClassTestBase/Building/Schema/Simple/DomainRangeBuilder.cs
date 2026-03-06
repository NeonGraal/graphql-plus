using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema.Simple;

public class DomainRangeBuilder
  : DomainItemBuilder
{
  internal decimal? _lower;
  internal decimal? _upper;

  public DomainRangeBuilder(decimal? value = null)
  {
    Add<IGqlpDomainRange>();
    _lower = value;
    _upper = value;
  }

  protected new T Build<T>()
    where T : class, IGqlpDomainRange
  {
    T result = base.Build<T>();
    result.Lower.Returns(_lower);
    result.Upper.Returns(_upper);
    return result;
  }

  public IGqlpDomainRange AsRange
    => Build<IGqlpDomainRange>();
}

public static class DomainRangeBuilderHelper
{
  public static TBuild WithLower<TBuild>(this TBuild builder, decimal? lower)
    where TBuild : DomainRangeBuilder
    => builder.FluentAction(b => b._lower = lower);
  public static TBuild WithUpper<TBuild>(this TBuild builder, decimal? upper)
    where TBuild : DomainRangeBuilder
    => builder.FluentAction(b => b._upper = upper);
}
