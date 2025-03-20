using GqlPlus.Ast;
using GqlPlus.Token;

namespace GqlPlus.Merging;

internal abstract class DistinctMerger<TItem>(
  ILoggerFactory logger
) : GroupsMerger<TItem>
  where TItem : IGqlpError
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(DistinctMerger<TItem>));

  protected override ITokenMessages CanMergeGroup(IGrouping<string, TItem> group)
  {
    IEnumerable<string> distinct = group.Select(ItemMatchKey).Distinct();
    if (distinct.Count() == 1) {
      return TokenMessages.New;
    }

    string typeName = typeof(TItem).TidyTypeName();
    string values = distinct.Debug();
    _logger.GroupNotSingular(typeName, group.Key, ItemMatchName, values);

    return group.Last()
        .MakeError($"Group of {typeName} for '{group.Key}' is not singular {ItemMatchName}[{values}]");
  }

  protected abstract string ItemMatchKey(TItem item);
  protected abstract string ItemMatchName { get; }
}

internal static partial class DistinctMergerLogging
{

  [LoggerMessage(LogLevel.Warning, Message = "Group of {Type} for '{Key}' is not singular {ItemMatchName}[{Values}]")]
  internal static partial void GroupNotSingular(this ILogger logger, string type, string key, string itemMatchName, string values);

  [LoggerMessage(LogLevel.Warning, Message = "Aliases of {Type} for '{Key}' is not singular {ItemMatchName}[{Values}]")]
  internal static partial void AliasesNotSingular(this ILogger logger, string type, string key, string itemMatchName, string values);
}
