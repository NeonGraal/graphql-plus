using System.Runtime.CompilerServices;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Result;

namespace GqlPlus.Merging;

public static class MergeExtensions
{
  [SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code")]
  public static ITokenMessages CanMerge<TItem, TObjField>(
      this IEnumerable<TItem> items,
      Func<TItem, TObjField?> field,
      [CallerArgumentExpression(nameof(field))] string? fieldExpr = null)
    where TItem : AstBase
  {
    ArgumentNullException.ThrowIfNull(items);
    ArgumentNullException.ThrowIfNull(field);

    TObjField? result = default;

    foreach (TItem item in items) {
      TObjField? value = field(item);
      if (value is null || value.Equals(default)) {
        continue;
      }

      if (result is null || result.Equals(default)) {
        result = value;
        continue;
      }

      if (!result.Equals(value)) {
        return new TokenMessages(item.Error($"Different values merging {fieldExpr}: {result} != {value}"));
      }
    }

    return new TokenMessages();
  }

  public static ITokenMessages CanMerge<TItem, TObjField>(
      this IEnumerable<TItem> items,
      Func<TItem, TObjField?> field,
      IMerge<TObjField> merger)
    where TObjField : AstBase
  {
    ArgumentNullException.ThrowIfNull(merger);

    TObjField[] fields = items.Select(field).Where(f => f is not null).Cast<TObjField>().ToArray();

    return fields.Length > 0 ? merger.CanMerge(fields) : TokenMessages.New;
  }

  public static ITokenMessages CanMerge<TItem>(
      this IEnumerable<TItem> items,
      Func<TItem, string?> field,
      [CallerArgumentExpression(nameof(field))] string? fieldExpr = null)
    where TItem : AstBase
  {
    ArgumentNullException.ThrowIfNull(items);
    ArgumentNullException.ThrowIfNull(field);

    string result = "";

    foreach (TItem item in items) {
      string? value = field(item);
      if (string.IsNullOrEmpty(value)) {
        continue;
      }

      if (string.IsNullOrEmpty(result)) {
        result = value;
        continue;
      }

      if (result != value) {
        return new TokenMessages(item.Error($"Different values merging {fieldExpr}: {result} != {value}"));
      }
    }

    return new TokenMessages();
  }

  public static ITokenMessages ManyCanMerge<TItem, TGroup>(
      this IEnumerable<TItem> items,
      Func<TItem, IEnumerable<TGroup>> many,
      IMerge<TGroup> merger)
    where TGroup : AstBase
  {
    ArgumentNullException.ThrowIfNull(merger);

    TGroup[] groups = [.. items.SelectMany(many)];
    return groups.Length < 2 ? new TokenMessages()
      : merger.CanMerge(groups);
  }

  public static IEnumerable<TObjField> Merge<TItem, TObjField>(
      this IEnumerable<TItem> items,
      Func<TItem, TObjField?> field,
      IMerge<TObjField> merger)
    where TObjField : AstBase
  {
    ArgumentNullException.ThrowIfNull(merger);

    TObjField[] fields = items.Select(field).Where(f => f is not null).Cast<TObjField>().ToArray();

    return merger.Merge(fields);
  }

  public static IEnumerable<TGroup> ManyMerge<TItem, TGroup>(
      this IEnumerable<TItem> items,
      Func<TItem, IEnumerable<TGroup>> many,
      IMerge<TGroup> merger)
    where TGroup : AstBase
  {
    ArgumentNullException.ThrowIfNull(merger);

    return merger.Merge(items.SelectMany(many));
  }

  public static ITokenMessages ManyGroupCanMerge<TItem, TGroup>(
      this IEnumerable<TItem> items,
      Func<TItem, IEnumerable<TGroup>> many,
      Func<TGroup, string> key,
      IMerge<TGroup> merger)
    where TGroup : AstBase
    => TokenMessages.New
      .Add(items
        .SelectMany(many).GroupBy(key)
        .SelectMany(p => merger.CanMerge([.. p])));

  public static IEnumerable<TGroup> ManyGroupMerger<TItem, TGroup>(
      this IEnumerable<TItem> items,
      Func<TItem, IEnumerable<TGroup>> many,
      Func<TGroup, string> key,
      IMerge<TGroup> merger)
    where TGroup : AstBase
  {
    List<Indexed<TGroup>> result = [];
    IEnumerable<IGrouping<string, Indexed<TGroup>>> groups = items.SelectMany(many).Select(Indexed<TGroup>.To).GroupBy(i => key(i.Item));

    foreach (IGrouping<string, Indexed<TGroup>> group in groups) {
      TGroup item = group.Combine(i => i.Item, merger);
      result.Add(new(item, group.Min(i => i.Index)));
    }

    return result.OrderBy(i => i.Index).Select(i => i.Item);
  }

  public static IEnumerable<TItem> GroupMerger<TItem>(this IEnumerable<TItem> items, Func<TItem, string> key, Func<TItem[], TItem> merger)
  {
    ArgumentNullException.ThrowIfNull(merger);

    List<Indexed<TItem>> result = [];
    IEnumerable<IGrouping<string, Indexed<TItem>>> groups = items.Select(Indexed<TItem>.To).GroupBy(i => key(i.Item));

    foreach (IGrouping<string, Indexed<TItem>> group in groups) {
      TItem? item = merger([.. group.Select(i => i.Item)]);
      result.Add(new(item, group.Min(i => i.Index)));
    }

    return result.OrderBy(i => i.Index).Select(i => i.Item);
  }

  public static string MergeDescriptions<TItem>(this IEnumerable<TItem> items)
    where TItem : AstBase, IGqlpDescribed
    => items
      .Select(item => item.Description)
      .FirstOrDefault(descr => !string.IsNullOrWhiteSpace(descr))
      ?? "";

  public static TObjField Combine<TItem, TObjField>(this IEnumerable<TItem> items, Func<TItem, TObjField> field, IMerge<TObjField> merger)
    where TObjField : AstBase
  {
    ArgumentNullException.ThrowIfNull(merger);

    return merger.Merge(items.Select(field)).First();
  }

  private record struct Indexed<TItem>(TItem Item, int Index)
  {
    public static Indexed<TItem> To(TItem item, int n)
      => new(item, n);
  }
}
