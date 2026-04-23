//HintName: test_+Simple_Enc.gen.cs
// Generated from {CurrentDirectory}+Simple.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Simple;

internal class testDmnBoolDescrEncoder : IEncoder<ItestDmnBoolDescr>
{
  public Structured Encode(ItestDmnBoolDescr input)
    => input.Value!.Encode();

  internal static testDmnBoolDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnBoolPrntEncoder : IEncoder<ItestDmnBoolPrnt>
{
  public Structured Encode(ItestDmnBoolPrnt input)
    => input.Value!.Encode();

  internal static testDmnBoolPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnBoolPrntEncoder : IEncoder<ItestPrntDmnBoolPrnt>
{
  public Structured Encode(ItestPrntDmnBoolPrnt input)
    => input.Value!.Encode();

  internal static testPrntDmnBoolPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnBoolPrntDescrEncoder : IEncoder<ItestDmnBoolPrntDescr>
{
  public Structured Encode(ItestDmnBoolPrntDescr input)
    => input.Value!.Encode();

  internal static testDmnBoolPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnBoolPrntDescrEncoder : IEncoder<ItestPrntDmnBoolPrntDescr>
{
  public Structured Encode(ItestPrntDmnBoolPrntDescr input)
    => input.Value!.Encode();

  internal static testPrntDmnBoolPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumAllEncoder : IEncoder<ItestDmnEnumAll>
{
  public Structured Encode(ItestDmnEnumAll input)
    => input.Value?.EncodeEnum("testEnumDmnEnumAll")!;

  internal static testDmnEnumAllEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumAllEncoder : IEncoder<testEnumDmnEnumAll>
{
  public Structured Encode(testEnumDmnEnumAll input)
    => input.EncodeEnum("EnumDmnEnumAll");

  internal static testEnumDmnEnumAllEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumAllDescrEncoder : IEncoder<ItestDmnEnumAllDescr>
{
  public Structured Encode(ItestDmnEnumAllDescr input)
    => input.Value?.EncodeEnum("testEnumDmnEnumAllDescr")!;

  internal static testDmnEnumAllDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumAllDescrEncoder : IEncoder<testEnumDmnEnumAllDescr>
{
  public Structured Encode(testEnumDmnEnumAllDescr input)
    => input.EncodeEnum("EnumDmnEnumAllDescr");

  internal static testEnumDmnEnumAllDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumAllPrntEncoder : IEncoder<ItestDmnEnumAllPrnt>
{
  public Structured Encode(ItestDmnEnumAllPrnt input)
    => input.Value?.EncodeEnum("testEnumDmnEnumAllPrnt")!;

  internal static testDmnEnumAllPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumAllPrntEncoder : IEncoder<testEnumDmnEnumAllPrnt>
{
  public Structured Encode(testEnumDmnEnumAllPrnt input)
    => input.EncodeEnum("EnumDmnEnumAllPrnt");

  internal static testEnumDmnEnumAllPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumAllPrntEncoder : IEncoder<testPrntDmnEnumAllPrnt>
{
  public Structured Encode(testPrntDmnEnumAllPrnt input)
    => input.EncodeEnum("PrntDmnEnumAllPrnt");

  internal static testPrntDmnEnumAllPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumDescrEncoder : IEncoder<ItestDmnEnumDescr>
{
  public Structured Encode(ItestDmnEnumDescr input)
    => input.Value?.EncodeEnum("testEnumDmnEnumDescr")!;

  internal static testDmnEnumDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumDescrEncoder : IEncoder<testEnumDmnEnumDescr>
{
  public Structured Encode(testEnumDmnEnumDescr input)
    => input.EncodeEnum("EnumDmnEnumDescr");

  internal static testEnumDmnEnumDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumExclEncoder : IEncoder<ItestDmnEnumExcl>
{
  public Structured Encode(ItestDmnEnumExcl input)
    => input.Value?.EncodeEnum("testEnumDmnEnumExcl")!;

  internal static testDmnEnumExclEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumExclEncoder : IEncoder<testEnumDmnEnumExcl>
{
  public Structured Encode(testEnumDmnEnumExcl input)
    => input.EncodeEnum("EnumDmnEnumExcl");

  internal static testEnumDmnEnumExclEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumExclPrntEncoder : IEncoder<testEnumDmnEnumExclPrnt>
{
  public Structured Encode(testEnumDmnEnumExclPrnt input)
    => input.EncodeEnum("EnumDmnEnumExclPrnt");

  internal static testEnumDmnEnumExclPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumExclPrntEncoder : IEncoder<testPrntDmnEnumExclPrnt>
{
  public Structured Encode(testPrntDmnEnumExclPrnt input)
    => input.EncodeEnum("PrntDmnEnumExclPrnt");

  internal static testPrntDmnEnumExclPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumLabelEncoder : IEncoder<ItestDmnEnumLabel>
{
  public Structured Encode(ItestDmnEnumLabel input)
    => input.Value?.EncodeEnum("testEnumDmnEnumLabel")!;

  internal static testDmnEnumLabelEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumLabelEncoder : IEncoder<testEnumDmnEnumLabel>
{
  public Structured Encode(testEnumDmnEnumLabel input)
    => input.EncodeEnum("EnumDmnEnumLabel");

  internal static testEnumDmnEnumLabelEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumPrntEncoder : IEncoder<ItestDmnEnumPrnt>
{
  public Structured Encode(ItestDmnEnumPrnt input)
    => input.Value?.EncodeEnum("testEnumDmnEnumPrnt")!;

  internal static testDmnEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumPrntEncoder : IEncoder<ItestPrntDmnEnumPrnt>
{
  public Structured Encode(ItestPrntDmnEnumPrnt input)
    => input.Value?.EncodeEnum("testEnumDmnEnumPrnt")!;

  internal static testPrntDmnEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumPrntEncoder : IEncoder<testEnumDmnEnumPrnt>
{
  public Structured Encode(testEnumDmnEnumPrnt input)
    => input.EncodeEnum("EnumDmnEnumPrnt");

  internal static testEnumDmnEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumPrntDescrEncoder : IEncoder<ItestDmnEnumPrntDescr>
{
  public Structured Encode(ItestDmnEnumPrntDescr input)
    => input.Value?.EncodeEnum("testEnumDmnEnumPrntDescr")!;

  internal static testDmnEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumPrntDescrEncoder : IEncoder<ItestPrntDmnEnumPrntDescr>
{
  public Structured Encode(ItestPrntDmnEnumPrntDescr input)
    => input.Value?.EncodeEnum("testEnumDmnEnumPrntDescr")!;

  internal static testPrntDmnEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumPrntDescrEncoder : IEncoder<testEnumDmnEnumPrntDescr>
{
  public Structured Encode(testEnumDmnEnumPrntDescr input)
    => input.EncodeEnum("EnumDmnEnumPrntDescr");

  internal static testEnumDmnEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumUnqEncoder : IEncoder<testEnumDmnEnumUnq>
{
  public Structured Encode(testEnumDmnEnumUnq input)
    => input.EncodeEnum("EnumDmnEnumUnq");

  internal static testEnumDmnEnumUnqEncoder Factory(IEncoderRepository _) => new();
}

internal class testDupDmnEnumUnqEncoder : IEncoder<testDupDmnEnumUnq>
{
  public Structured Encode(testDupDmnEnumUnq input)
    => input.EncodeEnum("DupDmnEnumUnq");

  internal static testDupDmnEnumUnqEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumUnqPrntEncoder : IEncoder<testEnumDmnEnumUnqPrnt>
{
  public Structured Encode(testEnumDmnEnumUnqPrnt input)
    => input.EncodeEnum("EnumDmnEnumUnqPrnt");

  internal static testEnumDmnEnumUnqPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumUnqPrntEncoder : IEncoder<testPrntDmnEnumUnqPrnt>
{
  public Structured Encode(testPrntDmnEnumUnqPrnt input)
    => input.EncodeEnum("PrntDmnEnumUnqPrnt");

  internal static testPrntDmnEnumUnqPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDupDmnEnumUnqPrntEncoder : IEncoder<testDupDmnEnumUnqPrnt>
{
  public Structured Encode(testDupDmnEnumUnqPrnt input)
    => input.EncodeEnum("DupDmnEnumUnqPrnt");

  internal static testDupDmnEnumUnqPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumValueEncoder : IEncoder<ItestDmnEnumValue>
{
  public Structured Encode(ItestDmnEnumValue input)
    => input.Value?.EncodeEnum("testEnumDmnEnumValue")!;

  internal static testDmnEnumValueEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumValueEncoder : IEncoder<testEnumDmnEnumValue>
{
  public Structured Encode(testEnumDmnEnumValue input)
    => input.EncodeEnum("EnumDmnEnumValue");

  internal static testEnumDmnEnumValueEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumValuePrntEncoder : IEncoder<ItestDmnEnumValuePrnt>
{
  public Structured Encode(ItestDmnEnumValuePrnt input)
    => input.Value?.EncodeEnum("testEnumDmnEnumValuePrnt")!;

  internal static testDmnEnumValuePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumValuePrntEncoder : IEncoder<testEnumDmnEnumValuePrnt>
{
  public Structured Encode(testEnumDmnEnumValuePrnt input)
    => input.EncodeEnum("EnumDmnEnumValuePrnt");

  internal static testEnumDmnEnumValuePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumValuePrntEncoder : IEncoder<testPrntDmnEnumValuePrnt>
{
  public Structured Encode(testPrntDmnEnumValuePrnt input)
    => input.EncodeEnum("PrntDmnEnumValuePrnt");

  internal static testPrntDmnEnumValuePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrDescrEncoder : IEncoder<ItestDmnNmbrDescr>
{
  public Structured Encode(ItestDmnNmbrDescr input)
    => input.Value!.Encode();

  internal static testDmnNmbrDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrPrntEncoder : IEncoder<ItestDmnNmbrPrnt>
{
  public Structured Encode(ItestDmnNmbrPrnt input)
    => input.Value!.Encode();

  internal static testDmnNmbrPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnNmbrPrntEncoder : IEncoder<ItestPrntDmnNmbrPrnt>
{
  public Structured Encode(ItestPrntDmnNmbrPrnt input)
    => input.Value!.Encode();

  internal static testPrntDmnNmbrPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrPrntDescrEncoder : IEncoder<ItestDmnNmbrPrntDescr>
{
  public Structured Encode(ItestDmnNmbrPrntDescr input)
    => input.Value!.Encode();

  internal static testDmnNmbrPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnNmbrPrntDescrEncoder : IEncoder<ItestPrntDmnNmbrPrntDescr>
{
  public Structured Encode(ItestPrntDmnNmbrPrntDescr input)
    => input.Value!.Encode();

  internal static testPrntDmnNmbrPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrPstvEncoder : IEncoder<ItestDmnNmbrPstv>
{
  public Structured Encode(ItestDmnNmbrPstv input)
    => input.Value!.Encode();

  internal static testDmnNmbrPstvEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrRangeEncoder : IEncoder<ItestDmnNmbrRange>
{
  public Structured Encode(ItestDmnNmbrRange input)
    => input.Value!.Encode();

  internal static testDmnNmbrRangeEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrDescrEncoder : IEncoder<ItestDmnStrDescr>
{
  public Structured Encode(ItestDmnStrDescr input)
    => input.Value!.Encode();

  internal static testDmnStrDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrNonEmptyEncoder : IEncoder<ItestDmnStrNonEmpty>
{
  public Structured Encode(ItestDmnStrNonEmpty input)
    => input.Value!.Encode();

  internal static testDmnStrNonEmptyEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrPrntEncoder : IEncoder<ItestDmnStrPrnt>
{
  public Structured Encode(ItestDmnStrPrnt input)
    => input.Value!.Encode();

  internal static testDmnStrPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnStrPrntEncoder : IEncoder<ItestPrntDmnStrPrnt>
{
  public Structured Encode(ItestPrntDmnStrPrnt input)
    => input.Value!.Encode();

  internal static testPrntDmnStrPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrPrntDescrEncoder : IEncoder<ItestDmnStrPrntDescr>
{
  public Structured Encode(ItestDmnStrPrntDescr input)
    => input.Value!.Encode();

  internal static testDmnStrPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnStrPrntDescrEncoder : IEncoder<ItestPrntDmnStrPrntDescr>
{
  public Structured Encode(ItestPrntDmnStrPrntDescr input)
    => input.Value!.Encode();

  internal static testPrntDmnStrPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDescrEncoder : IEncoder<testEnumDescr>
{
  public Structured Encode(testEnumDescr input)
    => input.EncodeEnum("EnumDescr");

  internal static testEnumDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumPrntEncoder : IEncoder<testEnumPrnt>
{
  public Structured Encode(testEnumPrnt input)
    => input.EncodeEnum("EnumPrnt");

  internal static testEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumPrntEncoder : IEncoder<testPrntEnumPrnt>
{
  public Structured Encode(testPrntEnumPrnt input)
    => input.EncodeEnum("PrntEnumPrnt");

  internal static testPrntEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumPrntAliasEncoder : IEncoder<testEnumPrntAlias>
{
  public Structured Encode(testEnumPrntAlias input)
    => input.EncodeEnum("EnumPrntAlias");

  internal static testEnumPrntAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumPrntAliasEncoder : IEncoder<testPrntEnumPrntAlias>
{
  public Structured Encode(testPrntEnumPrntAlias input)
    => input.EncodeEnum("PrntEnumPrntAlias");

  internal static testPrntEnumPrntAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumPrntDescrEncoder : IEncoder<testEnumPrntDescr>
{
  public Structured Encode(testEnumPrntDescr input)
    => input.EncodeEnum("EnumPrntDescr");

  internal static testEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumPrntDescrEncoder : IEncoder<testPrntEnumPrntDescr>
{
  public Structured Encode(testPrntEnumPrntDescr input)
    => input.EncodeEnum("PrntEnumPrntDescr");

  internal static testPrntEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumPrntDupEncoder : IEncoder<testEnumPrntDup>
{
  public Structured Encode(testEnumPrntDup input)
    => input.EncodeEnum("EnumPrntDup");

  internal static testEnumPrntDupEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumPrntDupEncoder : IEncoder<testPrntEnumPrntDup>
{
  public Structured Encode(testPrntEnumPrntDup input)
    => input.EncodeEnum("PrntEnumPrntDup");

  internal static testPrntEnumPrntDupEncoder Factory(IEncoderRepository _) => new();
}

internal class testUnionDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionDescr>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionDescr input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();

  internal static testUnionDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUnionPrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionPrnt>
{
  private readonly IEncoder<string> _string = encoders.EncoderFor<string>();
  public Structured Encode(ItestUnionPrnt input)
    => input.HasA<string>() ? _string.Encode(input.AsA<string>())
     : Structured.Empty();

  internal static testUnionPrntEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntUnionPrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionPrnt>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestPrntUnionPrnt input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();

  internal static testPrntUnionPrntEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUnionPrntDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionPrntDescr>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionPrntDescr input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();

  internal static testUnionPrntDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntUnionPrntDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionPrntDescr>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestPrntUnionPrntDescr input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();

  internal static testPrntUnionPrntDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUnionPrntDupEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionPrntDup>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionPrntDup input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();

  internal static testUnionPrntDupEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntUnionPrntDupEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionPrntDup>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestPrntUnionPrntDup input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();

  internal static testPrntUnionPrntDupEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test__SimpleEncoders
{
  internal static IEncoderRepositoryBuilder Addtest__SimpleEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnBoolDescr>(testDmnBoolDescrEncoder.Factory)
      .AddEncoder<ItestDmnBoolPrnt>(testDmnBoolPrntEncoder.Factory)
      .AddEncoder<ItestPrntDmnBoolPrnt>(testPrntDmnBoolPrntEncoder.Factory)
      .AddEncoder<ItestDmnBoolPrntDescr>(testDmnBoolPrntDescrEncoder.Factory)
      .AddEncoder<ItestPrntDmnBoolPrntDescr>(testPrntDmnBoolPrntDescrEncoder.Factory)
      .AddEncoder<ItestDmnEnumAll>(testDmnEnumAllEncoder.Factory)
      .AddEncoder<testEnumDmnEnumAll>(testEnumDmnEnumAllEncoder.Factory)
      .AddEncoder<ItestDmnEnumAllDescr>(testDmnEnumAllDescrEncoder.Factory)
      .AddEncoder<testEnumDmnEnumAllDescr>(testEnumDmnEnumAllDescrEncoder.Factory)
      .AddEncoder<ItestDmnEnumAllPrnt>(testDmnEnumAllPrntEncoder.Factory)
      .AddEncoder<testEnumDmnEnumAllPrnt>(testEnumDmnEnumAllPrntEncoder.Factory)
      .AddEncoder<testPrntDmnEnumAllPrnt>(testPrntDmnEnumAllPrntEncoder.Factory)
      .AddEncoder<ItestDmnEnumDescr>(testDmnEnumDescrEncoder.Factory)
      .AddEncoder<testEnumDmnEnumDescr>(testEnumDmnEnumDescrEncoder.Factory)
      .AddEncoder<ItestDmnEnumExcl>(testDmnEnumExclEncoder.Factory)
      .AddEncoder<testEnumDmnEnumExcl>(testEnumDmnEnumExclEncoder.Factory)
      .AddEncoder<testEnumDmnEnumExclPrnt>(testEnumDmnEnumExclPrntEncoder.Factory)
      .AddEncoder<testPrntDmnEnumExclPrnt>(testPrntDmnEnumExclPrntEncoder.Factory)
      .AddEncoder<ItestDmnEnumLabel>(testDmnEnumLabelEncoder.Factory)
      .AddEncoder<testEnumDmnEnumLabel>(testEnumDmnEnumLabelEncoder.Factory)
      .AddEncoder<ItestDmnEnumPrnt>(testDmnEnumPrntEncoder.Factory)
      .AddEncoder<ItestPrntDmnEnumPrnt>(testPrntDmnEnumPrntEncoder.Factory)
      .AddEncoder<testEnumDmnEnumPrnt>(testEnumDmnEnumPrntEncoder.Factory)
      .AddEncoder<ItestDmnEnumPrntDescr>(testDmnEnumPrntDescrEncoder.Factory)
      .AddEncoder<ItestPrntDmnEnumPrntDescr>(testPrntDmnEnumPrntDescrEncoder.Factory)
      .AddEncoder<testEnumDmnEnumPrntDescr>(testEnumDmnEnumPrntDescrEncoder.Factory)
      .AddEncoder<testEnumDmnEnumUnq>(testEnumDmnEnumUnqEncoder.Factory)
      .AddEncoder<testDupDmnEnumUnq>(testDupDmnEnumUnqEncoder.Factory)
      .AddEncoder<testEnumDmnEnumUnqPrnt>(testEnumDmnEnumUnqPrntEncoder.Factory)
      .AddEncoder<testPrntDmnEnumUnqPrnt>(testPrntDmnEnumUnqPrntEncoder.Factory)
      .AddEncoder<testDupDmnEnumUnqPrnt>(testDupDmnEnumUnqPrntEncoder.Factory)
      .AddEncoder<ItestDmnEnumValue>(testDmnEnumValueEncoder.Factory)
      .AddEncoder<testEnumDmnEnumValue>(testEnumDmnEnumValueEncoder.Factory)
      .AddEncoder<ItestDmnEnumValuePrnt>(testDmnEnumValuePrntEncoder.Factory)
      .AddEncoder<testEnumDmnEnumValuePrnt>(testEnumDmnEnumValuePrntEncoder.Factory)
      .AddEncoder<testPrntDmnEnumValuePrnt>(testPrntDmnEnumValuePrntEncoder.Factory)
      .AddEncoder<ItestDmnNmbrDescr>(testDmnNmbrDescrEncoder.Factory)
      .AddEncoder<ItestDmnNmbrPrnt>(testDmnNmbrPrntEncoder.Factory)
      .AddEncoder<ItestPrntDmnNmbrPrnt>(testPrntDmnNmbrPrntEncoder.Factory)
      .AddEncoder<ItestDmnNmbrPrntDescr>(testDmnNmbrPrntDescrEncoder.Factory)
      .AddEncoder<ItestPrntDmnNmbrPrntDescr>(testPrntDmnNmbrPrntDescrEncoder.Factory)
      .AddEncoder<ItestDmnNmbrPstv>(testDmnNmbrPstvEncoder.Factory)
      .AddEncoder<ItestDmnNmbrRange>(testDmnNmbrRangeEncoder.Factory)
      .AddEncoder<ItestDmnStrDescr>(testDmnStrDescrEncoder.Factory)
      .AddEncoder<ItestDmnStrNonEmpty>(testDmnStrNonEmptyEncoder.Factory)
      .AddEncoder<ItestDmnStrPrnt>(testDmnStrPrntEncoder.Factory)
      .AddEncoder<ItestPrntDmnStrPrnt>(testPrntDmnStrPrntEncoder.Factory)
      .AddEncoder<ItestDmnStrPrntDescr>(testDmnStrPrntDescrEncoder.Factory)
      .AddEncoder<ItestPrntDmnStrPrntDescr>(testPrntDmnStrPrntDescrEncoder.Factory)
      .AddEncoder<testEnumDescr>(testEnumDescrEncoder.Factory)
      .AddEncoder<testEnumPrnt>(testEnumPrntEncoder.Factory)
      .AddEncoder<testPrntEnumPrnt>(testPrntEnumPrntEncoder.Factory)
      .AddEncoder<testEnumPrntAlias>(testEnumPrntAliasEncoder.Factory)
      .AddEncoder<testPrntEnumPrntAlias>(testPrntEnumPrntAliasEncoder.Factory)
      .AddEncoder<testEnumPrntDescr>(testEnumPrntDescrEncoder.Factory)
      .AddEncoder<testPrntEnumPrntDescr>(testPrntEnumPrntDescrEncoder.Factory)
      .AddEncoder<testEnumPrntDup>(testEnumPrntDupEncoder.Factory)
      .AddEncoder<testPrntEnumPrntDup>(testPrntEnumPrntDupEncoder.Factory)
      .AddEncoder<ItestUnionDescr>(testUnionDescrEncoder.Factory)
      .AddEncoder<ItestUnionPrnt>(testUnionPrntEncoder.Factory)
      .AddEncoder<ItestPrntUnionPrnt>(testPrntUnionPrntEncoder.Factory)
      .AddEncoder<ItestUnionPrntDescr>(testUnionPrntDescrEncoder.Factory)
      .AddEncoder<ItestPrntUnionPrntDescr>(testPrntUnionPrntDescrEncoder.Factory)
      .AddEncoder<ItestUnionPrntDup>(testUnionPrntDupEncoder.Factory)
      .AddEncoder<ItestPrntUnionPrntDup>(testPrntUnionPrntDupEncoder.Factory);
}
