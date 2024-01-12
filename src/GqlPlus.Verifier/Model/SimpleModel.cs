using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Model;

internal record class SimpleModel
  : IRendering
{
  internal bool? Boolean { get; }
  internal decimal? Number { get; }
  internal string? String { get; }
  internal string? EnumType { get; }
  internal string? Value { get; }

  internal string EnumValue => $"{EnumType}.{Value}";

  internal SimpleModel(bool value)
    => Boolean = value;
  internal SimpleModel(decimal value)
    => Number = value;
  internal SimpleModel(string value)
    => String = value;
  internal SimpleModel(string type, string value)
    => (EnumType, Value) = (type, value);
  internal SimpleModel() { }

  public RenderStructure Render()
    => Boolean is not null ? new("", Boolean)
      : Number is not null ? new("", Number)
      : String is not null ? new("", String)
      : EnumType is not null ? new(EnumType, Value)
      : new("Basic", "null");
}

internal static class SimpleHelper
{
  internal static SimpleModel ToModel(this FieldKeyAst fieldKey)
    => fieldKey.Number.HasValue ? new(fieldKey.Number.Value)
    : fieldKey.String is not null ? new(fieldKey.String)
    : "Boolean".Equals(fieldKey.Type, StringComparison.OrdinalIgnoreCase) ? new("true".Equals(fieldKey.Value, StringComparison.OrdinalIgnoreCase))
    : fieldKey.Type is not null ? new(fieldKey.Type, fieldKey.Value ?? "")
    : new();
}
