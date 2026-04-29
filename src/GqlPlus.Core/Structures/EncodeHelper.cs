using GqlPlus.Ast;

namespace GqlPlus.Structures;

public static class EncodeHelper
{
  public static Structured? Encode(this bool? value, string? tag = null)
    => value is null ? null : new(new StructureValue(value, tag), tag.IfWhiteSpace());
  public static Structured? Encode(this decimal? value, string? tag = null)
    => value is null ? null : new(new StructureValue(value, tag), tag.IfWhiteSpace());
  public static Structured? Encode(this int? value, string? tag = null)
    => value is null ? null : new(new StructureValue(value, tag), tag.IfWhiteSpace());
  public static Structured? Encode(this StructureValue? value)
    => value is null ? null : new(value, value.Tag.IfWhiteSpace());
  public static Structured Encode(this string value, string? tag = null)
    => new(new StructureValue(value, tag), tag.IfWhiteSpace());
  public static Structured Encode(this bool value, string? tag = null)
    => new(new StructureValue(value, tag), tag.IfWhiteSpace());
  public static Structured Encode(this decimal value, string? tag = null)
    => new(new StructureValue(value, tag), tag.IfWhiteSpace());
  public static Structured Encode(this int value, string? tag = null)
    => new(new StructureValue(value, tag), tag.IfWhiteSpace());

  public static Structured Encode<T>(
    this IEnumerable<T> list,
    Func<T, Structured> mapper,
    string? tag = null,
    bool flow = false
  ) => new(list.Select(mapper), tag, flow);

  public static Structured Encode<T>(this IEnumerable<T> list, string? tag = null, bool flow = false)
    where T : Enum
    => new(list.Select(v => v.ToString().Encode(tag.IfWhiteSpace(typeof(T).TypeTag()))), flow: flow);

  public static Structured Encode(this IEnumerable<string> list, string? tag = null, bool flow = false)
    => list.Encode(i => i.Encode(), tag, flow);

  public static Structured Encode<T>(
    this IMap<T> groups,
    Func<T, Structured> mapper,
    string? mapTag = null,
    string? keyTag = null,
    bool flow = false
  ) => new(groups
        .OrderBy(p => p.Key)
        .ToDictionary(k => new StructureValue(k.Key, keyTag), v => mapper(v.Value)), mapTag, flow);

  public static Structured Encode(
    this IMap<Structured> groups,
    string? mapTag = null,
    string? keyTag = null,
    bool flow = false
  ) => groups.Encode(v => v, mapTag, keyTag, flow);

  public static Structured Encode(this IMessages errors)
    => new(errors.Select(Encode), "_Errors");

  private static Structured Encode(IMessage msg)
  {
    Structured result = new Map<Structured>() { ["_message"] = msg.Message.Encode() }.Encode($"_{msg.Level}");

    if (msg is ITokenMessage error) {
      result
        .AddIf(error.Kind is TokenKind.Start or TokenKind.End,
          onFalse: r => r.Add("_at", EncodeAt(error)))
        .AddEnum("_kind", error.Kind);
    }

    return result;
  }

  private static Structured EncodeAt(ITokenAt at)
    => new Map<Structured>() {
      ["_col"] = at.Column.Encode(),
      ["_line"] = at.Line.Encode(),
    }.Encode("_At", flow: true);

  public static string TypeTag(this Type type)
  {
    string result = "_" + type.ThrowIfNull().Name.Replace("Model", "");

    if (type.IsGenericType) {
      IEnumerable<string> typeParams = type.GetGenericArguments().Select(TypeTag);

      result = result.Split('`')[0] + "(" + string.Concat(typeParams) + ")";
    }

    return result;
  }

  public static Structured EncodeEnum<TEnum>(this TEnum value, string? tag = null)
    where TEnum : struct
    => value.ToString().Encode(tag ?? value.GetType().TypeTag());
}
