using System.Diagnostics.CodeAnalysis;

using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema;

public class EnumContext(
  IMap<IGqlpDescribed> types,
  ITokenMessages errors,
  IMap<string> enumValues
) : UsageContext(types, errors)
{
  internal bool GetEnumValue(string value, [NotNullWhen(true)] out string? type)
    => enumValues.TryGetValue(value, out type);

  internal bool GetEnumType(string? name, [NotNullWhen(true)] out IGqlpEnum? enumType)
  {
    enumType = null;
    if (GetType(name, out IGqlpDescribed? theType)) {
      enumType = theType as IGqlpEnum;
    }

    return enumType is not null;
  }

  internal bool GetEnumValueType(IGqlpEnum enumType, string value, [NotNullWhen(true)] out IGqlpEnum? valueType)
  {
    valueType = enumType;
    while (!valueType.HasValue(value)) {
      if (!GetEnumType(valueType.Parent, out valueType)) {
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
    IEnumerable<IGrouping<string, string>> enums = aliased
        .OfType<IGqlpEnum>()
        .SelectMany(e => e.Items.Select(v => (Label: v.Name, Type: e.Name)))
        .GroupBy(e => e.Label, e => e.Type);

    HashSet<string> enumNames = [.. enums.Select(e => e.Key)];

    return aliased
        .OfType<IGqlpEnum>()
        .SelectMany(e => e.Items.SelectMany(
          v => v.Aliases
            .Where(a => !enumNames.Contains(a))
            .Select(a => (Label: a, Type: e.Name))))
        .GroupBy(e => e.Label, e => e.Type)
        .Concat(enums)
        .Where(g => g.Count() == 1)
        .ToMap(e => e.Key, e => e.First());
  }
}
