using GqlPlus.Ast;
using GqlPlus.Token;

namespace GqlPlus.Merging;

#pragma warning disable CA1823 // Avoid unused private fields -- DO NOT DELETE
internal abstract partial class DistinctMerger<TItem>(
  ILoggerFactory logger
) : GroupsMerger<TItem>
  where TItem : AstBase
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(DistinctMerger<TItem>));

  protected override ITokenMessages CanMergeGroup(IGrouping<string, TItem> group)
  {
    IEnumerable<string> distinct = group.Select(ItemMatchKey).Distinct();
    if (distinct.Count() == 1) {
      return new TokenMessages();
    }

    string typeName = typeof(TItem).ExpandTypeName();
    string values = distinct.Debug();
    GroupNotSingular(typeName, group.Key, ItemMatchName, values);

    return new TokenMessages(group.Last()
        .Error($"Group of {typeName} for {group.Key} is not singular {ItemMatchName}[{values}]"));
  }

  [LoggerMessage(LogLevel.Warning, Message = "Group of {Type} for {Key} is not singular {ItemMatchName}[{Values}]")]
  private partial void GroupNotSingular(string type, string key, string itemMatchName, string values);

  protected abstract string ItemMatchKey(TItem item);
  protected abstract string ItemMatchName { get; }
}
