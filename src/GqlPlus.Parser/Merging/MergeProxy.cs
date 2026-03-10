namespace GqlPlus.Merging;

internal sealed class MergeProxy<T>(IMergerRepository mergers) : IMerge<T>
  where T : IGqlpError
{
  private readonly IMerge<T> _merge = mergers.MergerFor<T>();

  public IMessages CanMerge(IEnumerable<T> items) => _merge.CanMerge(items);
  public IEnumerable<T> Merge(IEnumerable<T> items) => _merge.Merge(items);
}
