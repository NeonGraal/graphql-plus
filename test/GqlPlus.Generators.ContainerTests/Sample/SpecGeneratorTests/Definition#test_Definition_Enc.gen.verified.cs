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
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : input.HasA<string>() ? _string.Encode(input.AsA<string>())
     : input.HasA<GqlpUnit>() ? _unit.Encode(input.AsA<GqlpUnit>())
     : Structured.Empty();
}

internal class test_InternalEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_Internal>
{
  private readonly IEncoder<GqlpNull> _null = encoders.EncoderFor<GqlpNull>();
  private readonly IEncoder<void> _void = encoders.EncoderFor<void>();
  public Structured Encode(Itest_Internal input)
    => input.HasA<GqlpNull>() ? _null.Encode(input.AsA<GqlpNull>())
     : input.HasA<void>() ? _void.Encode(input.AsA<void>())
     : Structured.Empty();
}

internal class test_KeyEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_Key>
{
  private readonly IEncoder<Itest_Basic> __basic = encoders.EncoderFor<Itest_Basic>();
  private readonly IEncoder<Itest_Internal> __internal = encoders.EncoderFor<Itest_Internal>();
  private readonly IEncoder<Itest_Simple> __simple = encoders.EncoderFor<Itest_Simple>();
  public Structured Encode(Itest_Key input)
    => input.HasA<Itest_Basic>() ? __basic.Encode(input.AsA<Itest_Basic>())
     : input.HasA<Itest_Internal>() ? __internal.Encode(input.AsA<Itest_Internal>())
     : input.HasA<Itest_Simple>() ? __simple.Encode(input.AsA<Itest_Simple>())
     : Structured.Empty();
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
    => input.HasA<Itest_Enum>() ? __enum.Encode(input.AsA<Itest_Enum>())
     : input.HasA<Itest_Domain>() ? __domain.Encode(input.AsA<Itest_Domain>())
     : input.HasA<Itest_Union>() ? __union.Encode(input.AsA<Itest_Union>())
     : Structured.Empty();
}

internal static class test_DefinitionEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_DefinitionEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<bool>(_ => new boolEncoder())
      .AddEncoder<GqlpNull>(_ => new GqlpNullEncoder())
      .AddEncoder<GqlpUnit>(_ => new GqlpUnitEncoder())
      .AddEncoder<void>(_ => new voidEncoder())
      .AddEncoder<decimal>(_ => new decimalEncoder())
      .AddEncoder<string>(_ => new stringEncoder())
      .AddEncoder<Itest_Basic>(r => new test_BasicEncoder(r))
      .AddEncoder<Itest_Internal>(r => new test_InternalEncoder(r))
      .AddEncoder<Itest_Key>(r => new test_KeyEncoder(r))
      .AddEncoder<Itest_ObjectObject>(_ => new test_ObjectEncoder())
      .AddEncoder<Itest_Domain>(_ => new test_DomainEncoder())
      .AddEncoder<Itest_DualObject>(_ => new test_DualEncoder())
      .AddEncoder<Itest_Enum>(_ => new test_EnumEncoder())
      .AddEncoder<Itest_OutputObject>(_ => new test_OutputEncoder())
      .AddEncoder<Itest_Union>(_ => new test_UnionEncoder())
      .AddEncoder<Itest_Simple>(r => new test_SimpleEncoder(r));
}
