using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging;

public interface IMerge<TItem>
  where TItem : IAstError
{
  IMessages CanMerge(IEnumerable<TItem> items);
  IEnumerable<TItem> Merge(IEnumerable<TItem> items);
}

public interface IMergeAll<TItem>
  : IMerge<TItem>
  where TItem : IAstType
{ }

public class MergerOne<T>(
  MergerOne<T>.D factory
) : DeferOne<IMerge<T>>(factory)
  , IMerge<T>
  where T : IAstError
{
  public IMessages CanMerge(IEnumerable<T> items)
    => Value.CanMerge(items);
  public IEnumerable<T> Merge(IEnumerable<T> items)
    => Value.Merge(items);

  public static implicit operator MergerOne<T>(D factory)
    => new(factory.ThrowIfNull());
}

public class MergerList<T>(
  MergerList<T>.D factory
) : DeferList<IMergeAll<T>>(factory)
  where T : IAstType
{
  public static implicit operator MergerList<T>(D factory)
    => new(factory.ThrowIfNull());
}
