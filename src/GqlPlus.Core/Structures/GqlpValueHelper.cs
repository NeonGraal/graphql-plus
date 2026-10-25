using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using GqlPlus;

namespace GqlPlus.Structures;

public static class GqlpValueHelper
{
  public static IGqlpValue? Encode(this bool? value, string? tag = null)
    => value is null ? null : new GqlpScalar(value.Value, tag);
  public static IGqlpValue? Encode(this decimal? value, string? tag = null)
    => value is null ? null : new GqlpScalar(value.Value, tag);
  public static IGqlpValue? Encode(this int? value, string? tag = null)
    => value is null ? null : new GqlpScalar(value.Value, tag);
  public static IGqlpValue Encode(this string value, string? tag = null)
    => new GqlpScalar(value, tag, value.IsIdentifier());
  public static IGqlpValue Encode(this bool value, string? tag = null)
    => new GqlpScalar(value, tag);
  public static IGqlpValue Encode(this decimal value, string? tag = null)
    => new GqlpScalar(value, tag);
  public static IGqlpValue Encode(this int value, string? tag = null)
    => new GqlpScalar(value, tag);

  public static IGqlpValue Encode<T>(
    this IEnumerable<T> list,
    Func<T, IGqlpValue> mapper,
    string? tag = null,
    bool flow = false
  ) => new GqlpList(list.Select(mapper), tag, flow);

  public static IGqlpValue Encode<T>(this IEnumerable<T> list, string? tag = null, bool flow = false)
    where T : Enum
    => new GqlpList(list.Select(v => v.ToString().Encode(tag.IfWhiteSpace(typeof(T).TypeTag()))), flow: flow);

  public static IGqlpValue Encode(this IEnumerable<string> list, string? tag = null, bool flow = false)
    => list.Encode(i => i.Encode(), tag, flow);

  public static IGqlpValue Encode<T>(
    this IMap<T> groups,
    Func<T, IGqlpValue> mapper,
    string? mapTag = null,
    string? keyTag = null,
    bool flow = false
  ) => new GqlpMap(groups
        .OrderBy(p => p.Key)
        .Select(k => new KeyValuePair<IGqlpScalar, IGqlpValue>(
          new GqlpScalar(k.Key, keyTag, isIdentifier: k.Key.IsIdentifier()),
          mapper(k.Value))), mapTag, flow);

  public static IGqlpValue Encode(
    this IMap<IGqlpValue> groups,
    string? mapTag = null,
    string? keyTag = null,
    bool flow = false
  ) => groups.Encode(v => v, mapTag, keyTag, flow);

  public static IGqlpValue Encode(this IMessages errors)
    => errors.Encode(Encode, "_Errors");

  private static IGqlpValue Encode(IMessage msg)
  {
    if (msg is ITokenMessage error) {
      List<KeyValuePair<IGqlpScalar, IGqlpValue>> fields = [
        new(new GqlpScalar("_message", isIdentifier: true), msg.Message.Encode()),
      ];
      if (error.Kind is not (TokenKind.Start or TokenKind.End)) {
        fields.Add(new(new GqlpScalar("_at", isIdentifier: true), new GqlpMap([
          new(new GqlpScalar("_col", isIdentifier: true), error.Column.Encode()),
          new(new GqlpScalar("_line", isIdentifier: true), error.Line.Encode()),
        ], "_At", flow: true)));
      }
      fields.Add(new(new GqlpScalar("_kind", isIdentifier: true), error.Kind.EncodeEnum()));
      return new GqlpMap(fields, $"_{msg.Level}");
    }

    return new GqlpMap([
      new(new GqlpScalar("_message", isIdentifier: true), msg.Message.Encode()),
    ], $"_{msg.Level}");
  }

  public static IGqlpValue Add(this IGqlpValue value, string key, IGqlpValue? item)
  {
    value.ThrowIfNull();
    if (item is null || item.IsEmpty()) {
      return value;
    }

    List<KeyValuePair<IGqlpScalar, IGqlpValue>> fields = value is GqlpMap map
      ? [.. map.Entries]
      : [];
    fields.Add(new(new GqlpScalar(key, isIdentifier: key.IsIdentifier()), item));
    return new GqlpMap(fields, value.Tag, value is GqlpMap { Flow: true });
  }

  public static IGqlpValue AddBool(this IGqlpValue value, string key, bool item)
    => item ? value.Add(key, item.Encode()) : value;

  public static IGqlpValue IncludeEncoded<T>(this IGqlpValue value, T? item, IEncoder<T> encoder)
  {
    value.ThrowIfNull();
    encoder.ThrowIfNull();
    if (item is null || encoder.Encode(item) is not GqlpMap encoded) {
      return value;
    }

    List<KeyValuePair<IGqlpScalar, IGqlpValue>> fields = value is GqlpMap map ? [.. map.Entries] : [];
    fields.AddRange(encoded.Entries);
    return new GqlpMap(fields, value.Tag, value is GqlpMap { Flow: true });
  }

  public static IGqlpValue AddEnum<T>(this IGqlpValue value, string key, T item, string? tag = null)
    where T : Enum
    => value.Add(key, item.ToString().Encode(tag.IfWhiteSpace(typeof(T).TypeTag())));

  public static IGqlpValue AddEncoded<T>(this IGqlpValue value, string key, T? item, IEncoder<T> encoder)
    => item is null ? value : value.Add(key, encoder.ThrowIfNull().Encode(item));

  public static IGqlpValue AddList<T>(
    this IGqlpValue value,
    string key,
    IEnumerable<T>? items,
    IEncoder<T> encoder,
    string? tag = null,
    bool flow = false
  ) => items is null ? value : value.Add(key, items.Encode(encoder.ThrowIfNull().Encode, tag, flow));

  public static IGqlpValue AddMap<T>(
    this IGqlpValue value,
    string key,
    IMap<T> items,
    IEncoder<T> encoder,
    string dictTag,
    bool flow = false,
    string keyTag = "_Name"
  ) => value.Add(key, items
      .OrderBy(p => p.Key)
      .Select(p => new KeyValuePair<IGqlpScalar, IGqlpValue>(
        new GqlpScalar(p.Key, keyTag, p.Key.IsIdentifier()),
        encoder.Encode(p.Value)))
      .ToGqlpMap(dictTag.Surrounded("_Map(", ")"), flow));

  public static IGqlpValue AddMapList<T>(
    this IGqlpValue value,
    string key,
    IMap<T[]> items,
    IEncoder<T> encoder,
    string listTag,
    bool flow = false,
    string keyTag = "_Name"
  ) => value.Add(key, items
      .OrderBy(p => p.Key)
      .Select(p => new KeyValuePair<IGqlpScalar, IGqlpValue>(
        new GqlpScalar(p.Key, keyTag, p.Key.IsIdentifier()),
        p.Value.Encode(encoder.Encode, listTag, flow)))
      .ToGqlpMap(listTag.Surrounded("_Map(", ")"), flow));

  public static IGqlpValue AddIf(
    this IGqlpValue value,
    bool condition,
    Func<IGqlpValue, IGqlpValue>? onTrue = null,
    Func<IGqlpValue, IGqlpValue>? onFalse = null
  ) => condition ? onTrue?.Invoke(value) ?? value : onFalse?.Invoke(value) ?? value;

  public static IGqlpValue AddNull<T>(
    this IGqlpValue value,
    T? item,
    Func<IGqlpValue, IGqlpValue>? onValue = null,
    Func<IGqlpValue, IGqlpValue>? onNull = null
  ) => item is null ? onNull?.Invoke(value) ?? value : onValue?.Invoke(value) ?? value;

  public static IGqlpValue AddSet<TEnum>(this IGqlpValue value, string key, TEnum set, string? tag = null, bool flow = true)
    where TEnum : Enum
  {
    string[]? flags = set.FlagNames();
    return flags is null ? value : value.Add(key, new GqlpMap(
      flags.Select(flag => new KeyValuePair<IGqlpScalar, IGqlpValue>(
        new GqlpScalar(flag, isIdentifier: true),
        "_".Encode())),
      $"_Set({tag.IfWhiteSpace(typeof(TEnum).TypeTag())})",
      flow));
  }

  public static IGqlpValue ToGqlpMap(this IEnumerable<KeyValuePair<IGqlpScalar, IGqlpValue>> entries, string? tag = null, bool flow = false)
    => new GqlpMap(entries, tag, flow);

  public static string TypeTag(this Type type)
  {
    string result = "_" + type.ThrowIfNull().Name.Replace("Model", "");

    if (type.IsGenericType) {
      IEnumerable<string> typeParams = type.GetGenericArguments().Select(TypeTag);

      result = result.Split('`')[0] + "(" + string.Concat(typeParams) + ")";
    }

    return result;
  }

  public static IGqlpValue EncodeEnum<TEnum>(this TEnum value, string? tag = null)
    where TEnum : struct
    => value.ToString().Encode(tag ?? value.GetType().TypeTag());

  public static readonly Regex IdentifierRegex = new(@"^[\w_][\w\d_]*$");

  public static bool IsIdentifier(this string? text)
  {
    if (string.IsNullOrEmpty(text)) {
      return false;
    }

    return IdentifierRegex.IsMatch(text);
  }
  public static bool IsSingleFlag(this int flag)
  {
    while (flag > 0) {
      bool rem = (flag & 1) > 0;
      flag >>= 1;
      if (rem) {
        return flag == 0;
      }
    }

    return false;
  }
}
