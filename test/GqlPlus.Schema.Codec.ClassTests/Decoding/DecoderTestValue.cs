using System.Diagnostics.CodeAnalysis;

namespace GqlPlus;

internal sealed class DecoderTestValue : IValue
{
  public string Tag => "";
  private readonly IReadOnlyList<IValue>? _list;
  private readonly IMap<IValue>? _map;

  private DecoderTestValue(IEnumerable<IValue> values)
    => _list = [.. values];
  private DecoderTestValue(IEnumerable<KeyValuePair<string, IValue>> fields)
  {
    Map<IValue> map = [];
    foreach (KeyValuePair<string, IValue> field in fields) {
      map.Add(field.Key, field.Value);
    }
    _map = map;
  }

  public static IValue FromList(IEnumerable<IValue> values) => new DecoderTestValue(values);
  public static IValue FromMap(IEnumerable<KeyValuePair<string, IValue>> fields) => new DecoderTestValue(fields);

  public bool TryGetBoolean([NotNullWhen(true)] out bool? value)
    => TryGet((bool?)null, out value);
  public bool TryGetNumber([NotNullWhen(true)] out decimal? value)
    => TryGet((decimal?)null, out value);
  public bool TryGetText([NotNullWhen(true)] out string? value)
    => TryGet((string?)null, out value);
  public bool TryGetList([NotNullWhen(true)] out IEnumerable<IValue>? list)
    => (list = _list) is not null;
  public bool TryGetMap([NotNullWhen(true)] out IMap<IValue>? map)
    => (map = _map) is not null;

  private static bool TryGet<T>(T? input, [NotNullWhen(true)] out T? value)
    where T : struct
  {
    value = input;
    return value is not null;
  }

  private static bool TryGet([NotNullWhen(true)] string? input, [NotNullWhen(true)] out string? value)
  {
    value = input;
    return !string.IsNullOrEmpty(value);
  }
}
