using System.Diagnostics.CodeAnalysis;

using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema;

public class EnumContext(
  IMap<IGqlpDescribed> types,
  IMessages errors,
  IMap<string> enumValues
) : UsageContext(types, errors)
{
  internal bool GetEnumValue(string value, [NotNullWhen(true)] out string? type)
    => enumValues.TryGetValue(value, out type);

  internal bool GetEnumValueType(IGqlpEnum enumType, string value, [NotNullWhen(true)] out IGqlpEnum? valueType)
  {
    valueType = enumType;
    while (!valueType.HasValue(value)) {
      if (!GetTyped(valueType.Parent?.Name, out valueType)) {
        valueType = null;
        return false;
      }
    }

    return true;
  }
}

public static class EnumContextHelper
{
  public static IMap<string> MakeEnumValues(this IGqlpType[] aliased)
  {
    IGqlpEnum[] enumTypes = aliased.ArrayOf<IGqlpEnum>();
    IEnumerable<IGrouping<string, string>> enums = GroupLabels(EnumLabels);

    HashSet<string> enumNames = [.. enums.Select(GKey)];

    return GroupLabels(EnumAliases)
        .Concat(enums)
        .Where(IsUniqueGroup)
        .ToMap(GKey, e => e.First());

    IEnumerable<IGrouping<string, string>> GroupLabels(Func<IGqlpEnum, IEnumerable<(string, string)>> mapper)
      => enumTypes.SelectMany(mapper).GroupBy(e => e.Item1, e => e.Item2);

    static IEnumerable<(string, string)> EnumLabels(IGqlpEnum e)
      => e.Items.Select(v => (v.Name, e.Name));

    static string GKey(IGrouping<string, string> e) => e.Key;

    IEnumerable<(string, string)> EnumAliases(IGqlpEnum e)
      => e.Items
          .SelectMany(v => v.Aliases
            .Where(a => !enumNames.Contains(a))
            .Select(a => (a, e.Name)));

    static bool IsUniqueGroup(IGrouping<string, string> g)
      => g.Count() == 1;
  }
}
