namespace GqlPlus.Verifier.Merging;

internal abstract partial class DistinctMerger<TItem>(
  ILoggerFactory logger
) : GroupsMerger<TItem>
{
  [SuppressMessage("Performance", "CA1823:Avoid unused private fields", Justification = "Logging")]
  private readonly ILogger _logger = logger.CreateLogger(nameof(DistinctMerger<TItem>));

  protected override bool CanMergeGroup(IGrouping<string, TItem> group)
  {
    var distinct = group.Select(ItemMatchKey).Distinct();
    if (distinct.Count() == 1) {
      return true;
    }

    GroupNotSingular(typeof(TItem).ExpandTypeName(), group.Key);

    return false;
  }

  [LoggerMessage(LogLevel.Warning, Message = "Group of {Type} for {Key} is not singular")]
  private partial void GroupNotSingular(string type, string key);

  protected abstract string ItemMatchKey(TItem item);
}
