using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Building.Schema.Simple;

public class DomainBuilder<TItem>
  : SimpleBuilder<IAstDomain<TItem>>
  where TItem : IAstDomainItem
{
  internal TItem[] _items = [];
  private readonly DomainKind _kind;

  public DomainBuilder(string name, DomainKind kind)
    : base(name)
  {
    Add<IAstDomain<TItem>>();
    Add<IAstDomain>();
    _typeKind = TypeKind.Domain;

    _kind = kind;
  }

  protected new T Build<T>()
    where T : class, IAstDomain<TItem>
  {
    T result = base.Build<T>();
    result.DomainKind.Returns(_kind);
    result.Items.Returns(_items);
    return result;
  }

  public IAstDomain<TItem> AsDomain
    => Build<IAstDomain<TItem>>();

  public override IAstDomain<TItem> AsSimple => AsDomain;
}

public static class DomainBuilderHelper
{
  public static TBuild WithItems<TBuild, TItem>(this TBuild builder, params TItem[] items)
    where TBuild : DomainBuilder<TItem>
    where TItem : IAstDomainItem
    => builder.FluentAction(b => b._items = items);
}
