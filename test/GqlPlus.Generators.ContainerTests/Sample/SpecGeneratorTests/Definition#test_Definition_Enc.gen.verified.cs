//HintName: test_Definition_Enc.gen.cs
// Generated from {CurrentDirectory}Definition.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Definition;

internal class boolEncoder : IEncoder<bool>
{
  public Structured Encode(bool input)
    => new(input.ToString(), "_Boolean");
}

internal class GqlpNullEncoder : IEncoder<GqlpNull>
{
  public Structured Encode(GqlpNull input)
    => new(input.ToString(), "_Null");
}

internal class GqlpUnitEncoder : IEncoder<GqlpUnit>
{
  public Structured Encode(GqlpUnit input)
    => new(input.ToString(), "_Unit");
}

internal class voidEncoder : IEncoder<void>
{
  public Structured Encode(void input)
    => new(input.ToString(), "_Void");
}

internal class decimalEncoder : IEncoder<decimal>
{
  public Structured Encode(decimal input)
    => new(input.Value);
}

internal class stringEncoder : IEncoder<string>
{
  public Structured Encode(string input)
    => new(input.Value);
}

internal class test_BasicEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_Basic>
{
  private readonly IEncoder<bool> _boolean = encoders.EncoderFor<bool>();
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  private readonly IEncoder<string> _string = encoders.EncoderFor<string>();
  private readonly IEncoder<GqlpUnit> _unit = encoders.EncoderFor<GqlpUnit>();
  public Structured Encode(Itest_Basic input)
    => input switch {
      { AsBoolean: { } m } => _boolean.Encode(m),
      { AsNumber: { } m } => _number.Encode(m),
      { AsString: { } m } => _string.Encode(m),
      { AsUnit: { } m } => _unit.Encode(m),
      _ => Structured.Empty()
    };
}

internal class test_InternalEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_Internal>
{
  private readonly IEncoder<GqlpNull> _null = encoders.EncoderFor<GqlpNull>();
  private readonly IEncoder<void> _void = encoders.EncoderFor<void>();
  public Structured Encode(Itest_Internal input)
    => input switch {
      { AsNull: { } m } => _null.Encode(m),
      { AsVoid: { } m } => _void.Encode(m),
      _ => Structured.Empty()
    };
}

internal class test_KeyEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_Key>
{
  private readonly IEncoder<Itest_Basic> __basic = encoders.EncoderFor<Itest_Basic>();
  private readonly IEncoder<Itest_Internal> __internal = encoders.EncoderFor<Itest_Internal>();
  private readonly IEncoder<Itest_Simple> __simple = encoders.EncoderFor<Itest_Simple>();
  public Structured Encode(Itest_Key input)
    => input switch {
      { As_Basic: { } m } => __basic.Encode(m),
      { As_Internal: { } m } => __internal.Encode(m),
      { As_Simple: { } m } => __simple.Encode(m),
      _ => Structured.Empty()
    };
}

internal class test_ObjectEncoder : IEncoder<Itest_ObjectObject>
{
  public Structured Encode(Itest_ObjectObject input)
    => Structured.Empty();
}

internal class test_DomainEncoder : IEncoder<Itest_Domain>
{
  public Structured Encode(Itest_Domain input)
    => Structured.Empty();
}

internal class test_DualEncoder : IEncoder<Itest_DualObject>
{
  public Structured Encode(Itest_DualObject input)
    => Structured.Empty();
}

internal class test_EnumEncoder : IEncoder<Itest_Enum>
{
  public Structured Encode(Itest_Enum input)
    => Structured.Empty();
}

internal class test_InputEncoder : IEncoder<Itest_InputObject>
{
  public Structured Encode(Itest_InputObject input)
    => Structured.Empty();
}

internal class test_OutputEncoder : IEncoder<Itest_OutputObject>
{
  public Structured Encode(Itest_OutputObject input)
    => Structured.Empty();
}

internal class test_UnionEncoder : IEncoder<Itest_Union>
{
  public Structured Encode(Itest_Union input)
    => Structured.Empty();
}

internal class test_SimpleEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_Simple>
{
  private readonly IEncoder<Itest_Enum> __enum = encoders.EncoderFor<Itest_Enum>();
  private readonly IEncoder<Itest_Domain> __domain = encoders.EncoderFor<Itest_Domain>();
  private readonly IEncoder<Itest_Union> __union = encoders.EncoderFor<Itest_Union>();
  public Structured Encode(Itest_Simple input)
    => input switch {
      { As_Enum: { } m } => __enum.Encode(m),
      { As_Domain: { } m } => __domain.Encode(m),
      { As_Union: { } m } => __union.Encode(m),
      _ => Structured.Empty()
    };
}
