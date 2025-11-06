using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema.Simple;

public class DomainBuilder<TItem>
  : SimpleBuilder
  where TItem : IGqlpDomainItem
{
  internal TItem[] _items = [];
  private readonly DomainKind _kind;

  public DomainBuilder(string name, DomainKind kind)
    : base(name)
  {
    Add<IGqlpDomain<TItem>>();
    Add<IGqlpDomain>();
    _typeKind = TypeKind.Domain;

    _kind = kind;
  }

  protected new T Build<T>()
    where T : class, IGqlpDomain<TItem>
  {
    T result = base.Build<T>();
    result.DomainKind.Returns(_kind);
    result.Items.Returns(_items);
    return result;
  }

  public IGqlpDomain<TItem> AsDomain
    => Build<IGqlpDomain<TItem>>();
}

public static class DomainBuilderHelper
{
  public static TBuild WithItems<TBuild, TItem>(this TBuild builder, params TItem[] items)
    where TBuild : DomainBuilder<TItem>
    where TItem : IGqlpDomainItem
    => builder.FluentAction(b => b._items = items);
}
