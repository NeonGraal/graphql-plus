using System.Globalization;
using System.Text.Encodings.Web;

using Fluid;
using Fluid.Values;

namespace GqlPlus.Convert;

internal sealed class TaggedValue : FluidValue
{
  internal readonly string Tag;
  private readonly FluidValue _value;

  public TaggedValue(string tag, FluidValue value)
  {
    ArgumentNullException.ThrowIfNull(value);

    Tag = tag;
    _value = value;
  }

  public override FluidValues Type => _value.Type;

  public override bool Equals(FluidValue other) => _value.Equals(other);

  public override bool Contains(FluidValue value) => _value.Contains(value);

  public override IEnumerable<FluidValue> Enumerate(TemplateContext context) => _value.Enumerate(context);

  public override bool Equals(object? obj) => _value.Equals(obj);

  public override int GetHashCode() => _value.GetHashCode();

  public override ValueTask<FluidValue> GetIndexAsync(FluidValue index, TemplateContext context) => _value.GetIndexAsync(index, context);

  public override ValueTask<FluidValue> GetValueAsync(string name, TemplateContext context) => _value.GetValueAsync(name, context);

  public override bool IsNil() => _value.IsNil();

  public override bool ToBooleanValue() => _value.ToBooleanValue();

  public override decimal ToNumberValue() => _value.ToNumberValue();

  public override object ToObjectValue() => _value.ToObjectValue();

  public override string? ToString() => _value.ToString();

  public override string ToStringValue() => _value.ToStringValue();

  public override void WriteTo(TextWriter writer, TextEncoder encoder, CultureInfo cultureInfo)
  {
    AssertWriteToParameters(writer, encoder, cultureInfo);
    _value.WriteTo(writer, encoder, cultureInfo);
  }
}
