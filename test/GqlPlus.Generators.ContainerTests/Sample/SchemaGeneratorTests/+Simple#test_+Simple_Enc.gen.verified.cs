//HintName: test_+Simple_Enc.gen.cs
// Generated from {CurrentDirectory}+Simple.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Simple;

internal class testDmnBoolDescrEncoder : IEncoder<ItestDmnBoolDescr>
{
  public Structured Encode(ItestDmnBoolDescr input)
    => new(input.Value);
}

internal class testDmnBoolPrntEncoder : IEncoder<ItestDmnBoolPrnt>
{
  public Structured Encode(ItestDmnBoolPrnt input)
    => new(input.Value);
}

internal class testPrntDmnBoolPrntEncoder : IEncoder<ItestPrntDmnBoolPrnt>
{
  public Structured Encode(ItestPrntDmnBoolPrnt input)
    => new(input.Value);
}

internal class testDmnBoolPrntDescrEncoder : IEncoder<ItestDmnBoolPrntDescr>
{
  public Structured Encode(ItestDmnBoolPrntDescr input)
    => new(input.Value);
}

internal class testPrntDmnBoolPrntDescrEncoder : IEncoder<ItestPrntDmnBoolPrntDescr>
{
  public Structured Encode(ItestPrntDmnBoolPrntDescr input)
    => new(input.Value);
}

internal class testDmnEnumAllEncoder : IEncoder<ItestDmnEnumAll>
{
  public Structured Encode(ItestDmnEnumAll input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumAllEncoder : IEncoder<testEnumDmnEnumAll>
{
  public Structured Encode(testEnumDmnEnumAll input)
    => new(input.ToString(), "_EnumDmnEnumAll");
}

internal class testDmnEnumAllDescrEncoder : IEncoder<ItestDmnEnumAllDescr>
{
  public Structured Encode(ItestDmnEnumAllDescr input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumAllDescrEncoder : IEncoder<testEnumDmnEnumAllDescr>
{
  public Structured Encode(testEnumDmnEnumAllDescr input)
    => new(input.ToString(), "_EnumDmnEnumAllDescr");
}

internal class testDmnEnumAllPrntEncoder : IEncoder<ItestDmnEnumAllPrnt>
{
  public Structured Encode(ItestDmnEnumAllPrnt input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumAllPrntEncoder : IEncoder<testEnumDmnEnumAllPrnt>
{
  public Structured Encode(testEnumDmnEnumAllPrnt input)
    => new(input.ToString(), "_EnumDmnEnumAllPrnt");
}

internal class testPrntDmnEnumAllPrntEncoder : IEncoder<testPrntDmnEnumAllPrnt>
{
  public Structured Encode(testPrntDmnEnumAllPrnt input)
    => new(input.ToString(), "_PrntDmnEnumAllPrnt");
}

internal class testDmnEnumDescrEncoder : IEncoder<ItestDmnEnumDescr>
{
  public Structured Encode(ItestDmnEnumDescr input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumDescrEncoder : IEncoder<testEnumDmnEnumDescr>
{
  public Structured Encode(testEnumDmnEnumDescr input)
    => new(input.ToString(), "_EnumDmnEnumDescr");
}

internal class testDmnEnumExclEncoder : IEncoder<ItestDmnEnumExcl>
{
  public Structured Encode(ItestDmnEnumExcl input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumExclEncoder : IEncoder<testEnumDmnEnumExcl>
{
  public Structured Encode(testEnumDmnEnumExcl input)
    => new(input.ToString(), "_EnumDmnEnumExcl");
}

internal class testDmnEnumExclPrntEncoder : IEncoder<ItestDmnEnumExclPrnt>
{
  public Structured Encode(ItestDmnEnumExclPrnt input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumExclPrntEncoder : IEncoder<testEnumDmnEnumExclPrnt>
{
  public Structured Encode(testEnumDmnEnumExclPrnt input)
    => new(input.ToString(), "_EnumDmnEnumExclPrnt");
}

internal class testPrntDmnEnumExclPrntEncoder : IEncoder<testPrntDmnEnumExclPrnt>
{
  public Structured Encode(testPrntDmnEnumExclPrnt input)
    => new(input.ToString(), "_PrntDmnEnumExclPrnt");
}

internal class testDmnEnumLabelEncoder : IEncoder<ItestDmnEnumLabel>
{
  public Structured Encode(ItestDmnEnumLabel input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumLabelEncoder : IEncoder<testEnumDmnEnumLabel>
{
  public Structured Encode(testEnumDmnEnumLabel input)
    => new(input.ToString(), "_EnumDmnEnumLabel");
}

internal class testDmnEnumPrntEncoder : IEncoder<ItestDmnEnumPrnt>
{
  public Structured Encode(ItestDmnEnumPrnt input)
    => new((decimal?)input.Value);
}

internal class testPrntDmnEnumPrntEncoder : IEncoder<ItestPrntDmnEnumPrnt>
{
  public Structured Encode(ItestPrntDmnEnumPrnt input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumPrntEncoder : IEncoder<testEnumDmnEnumPrnt>
{
  public Structured Encode(testEnumDmnEnumPrnt input)
    => new(input.ToString(), "_EnumDmnEnumPrnt");
}

internal class testDmnEnumPrntDescrEncoder : IEncoder<ItestDmnEnumPrntDescr>
{
  public Structured Encode(ItestDmnEnumPrntDescr input)
    => new((decimal?)input.Value);
}

internal class testPrntDmnEnumPrntDescrEncoder : IEncoder<ItestPrntDmnEnumPrntDescr>
{
  public Structured Encode(ItestPrntDmnEnumPrntDescr input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumPrntDescrEncoder : IEncoder<testEnumDmnEnumPrntDescr>
{
  public Structured Encode(testEnumDmnEnumPrntDescr input)
    => new(input.ToString(), "_EnumDmnEnumPrntDescr");
}

internal class testDmnEnumUnqEncoder : IEncoder<ItestDmnEnumUnq>
{
  public Structured Encode(ItestDmnEnumUnq input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumUnqEncoder : IEncoder<testEnumDmnEnumUnq>
{
  public Structured Encode(testEnumDmnEnumUnq input)
    => new(input.ToString(), "_EnumDmnEnumUnq");
}

internal class testDupDmnEnumUnqEncoder : IEncoder<testDupDmnEnumUnq>
{
  public Structured Encode(testDupDmnEnumUnq input)
    => new(input.ToString(), "_DupDmnEnumUnq");
}

internal class testDmnEnumUnqPrntEncoder : IEncoder<ItestDmnEnumUnqPrnt>
{
  public Structured Encode(ItestDmnEnumUnqPrnt input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumUnqPrntEncoder : IEncoder<testEnumDmnEnumUnqPrnt>
{
  public Structured Encode(testEnumDmnEnumUnqPrnt input)
    => new(input.ToString(), "_EnumDmnEnumUnqPrnt");
}

internal class testPrntDmnEnumUnqPrntEncoder : IEncoder<testPrntDmnEnumUnqPrnt>
{
  public Structured Encode(testPrntDmnEnumUnqPrnt input)
    => new(input.ToString(), "_PrntDmnEnumUnqPrnt");
}

internal class testDupDmnEnumUnqPrntEncoder : IEncoder<testDupDmnEnumUnqPrnt>
{
  public Structured Encode(testDupDmnEnumUnqPrnt input)
    => new(input.ToString(), "_DupDmnEnumUnqPrnt");
}

internal class testDmnEnumValueEncoder : IEncoder<ItestDmnEnumValue>
{
  public Structured Encode(ItestDmnEnumValue input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumValueEncoder : IEncoder<testEnumDmnEnumValue>
{
  public Structured Encode(testEnumDmnEnumValue input)
    => new(input.ToString(), "_EnumDmnEnumValue");
}

internal class testDmnEnumValuePrntEncoder : IEncoder<ItestDmnEnumValuePrnt>
{
  public Structured Encode(ItestDmnEnumValuePrnt input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumValuePrntEncoder : IEncoder<testEnumDmnEnumValuePrnt>
{
  public Structured Encode(testEnumDmnEnumValuePrnt input)
    => new(input.ToString(), "_EnumDmnEnumValuePrnt");
}

internal class testPrntDmnEnumValuePrntEncoder : IEncoder<testPrntDmnEnumValuePrnt>
{
  public Structured Encode(testPrntDmnEnumValuePrnt input)
    => new(input.ToString(), "_PrntDmnEnumValuePrnt");
}

internal class testDmnNmbrDescrEncoder : IEncoder<ItestDmnNmbrDescr>
{
  public Structured Encode(ItestDmnNmbrDescr input)
    => new(input.Value);
}

internal class testDmnNmbrPrntEncoder : IEncoder<ItestDmnNmbrPrnt>
{
  public Structured Encode(ItestDmnNmbrPrnt input)
    => new(input.Value);
}

internal class testPrntDmnNmbrPrntEncoder : IEncoder<ItestPrntDmnNmbrPrnt>
{
  public Structured Encode(ItestPrntDmnNmbrPrnt input)
    => new(input.Value);
}

internal class testDmnNmbrPrntDescrEncoder : IEncoder<ItestDmnNmbrPrntDescr>
{
  public Structured Encode(ItestDmnNmbrPrntDescr input)
    => new(input.Value);
}

internal class testPrntDmnNmbrPrntDescrEncoder : IEncoder<ItestPrntDmnNmbrPrntDescr>
{
  public Structured Encode(ItestPrntDmnNmbrPrntDescr input)
    => new(input.Value);
}

internal class testDmnNmbrPstvEncoder : IEncoder<ItestDmnNmbrPstv>
{
  public Structured Encode(ItestDmnNmbrPstv input)
    => new(input.Value);
}

internal class testDmnNmbrRangeEncoder : IEncoder<ItestDmnNmbrRange>
{
  public Structured Encode(ItestDmnNmbrRange input)
    => new(input.Value);
}

internal class testDmnStrDescrEncoder : IEncoder<ItestDmnStrDescr>
{
  public Structured Encode(ItestDmnStrDescr input)
    => new(input.Value);
}

internal class testDmnStrNonEmptyEncoder : IEncoder<ItestDmnStrNonEmpty>
{
  public Structured Encode(ItestDmnStrNonEmpty input)
    => new(input.Value);
}

internal class testDmnStrPrntEncoder : IEncoder<ItestDmnStrPrnt>
{
  public Structured Encode(ItestDmnStrPrnt input)
    => new(input.Value);
}

internal class testPrntDmnStrPrntEncoder : IEncoder<ItestPrntDmnStrPrnt>
{
  public Structured Encode(ItestPrntDmnStrPrnt input)
    => new(input.Value);
}

internal class testDmnStrPrntDescrEncoder : IEncoder<ItestDmnStrPrntDescr>
{
  public Structured Encode(ItestDmnStrPrntDescr input)
    => new(input.Value);
}

internal class testPrntDmnStrPrntDescrEncoder : IEncoder<ItestPrntDmnStrPrntDescr>
{
  public Structured Encode(ItestPrntDmnStrPrntDescr input)
    => new(input.Value);
}

internal class testEnumDescrEncoder : IEncoder<testEnumDescr>
{
  public Structured Encode(testEnumDescr input)
    => new(input.ToString(), "_EnumDescr");
}

internal class testEnumPrntEncoder : IEncoder<testEnumPrnt>
{
  public Structured Encode(testEnumPrnt input)
    => new(input.ToString(), "_EnumPrnt");
}

internal class testPrntEnumPrntEncoder : IEncoder<testPrntEnumPrnt>
{
  public Structured Encode(testPrntEnumPrnt input)
    => new(input.ToString(), "_PrntEnumPrnt");
}

internal class testEnumPrntAliasEncoder : IEncoder<testEnumPrntAlias>
{
  public Structured Encode(testEnumPrntAlias input)
    => new(input.ToString(), "_EnumPrntAlias");
}

internal class testPrntEnumPrntAliasEncoder : IEncoder<testPrntEnumPrntAlias>
{
  public Structured Encode(testPrntEnumPrntAlias input)
    => new(input.ToString(), "_PrntEnumPrntAlias");
}

internal class testEnumPrntDescrEncoder : IEncoder<testEnumPrntDescr>
{
  public Structured Encode(testEnumPrntDescr input)
    => new(input.ToString(), "_EnumPrntDescr");
}

internal class testPrntEnumPrntDescrEncoder : IEncoder<testPrntEnumPrntDescr>
{
  public Structured Encode(testPrntEnumPrntDescr input)
    => new(input.ToString(), "_PrntEnumPrntDescr");
}

internal class testEnumPrntDupEncoder : IEncoder<testEnumPrntDup>
{
  public Structured Encode(testEnumPrntDup input)
    => new(input.ToString(), "_EnumPrntDup");
}

internal class testPrntEnumPrntDupEncoder : IEncoder<testPrntEnumPrntDup>
{
  public Structured Encode(testPrntEnumPrntDup input)
    => new(input.ToString(), "_PrntEnumPrntDup");
}

internal class testUnionDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionDescr>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionDescr input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();
}

internal class testUnionPrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionPrnt>
{
  private readonly IEncoder<string> _string = encoders.EncoderFor<string>();
  public Structured Encode(ItestUnionPrnt input)
    => input.HasA<string>() ? _string.Encode(input.AsA<string>())
     : Structured.Empty();
}

internal class testPrntUnionPrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionPrnt>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestPrntUnionPrnt input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();
}

internal class testUnionPrntDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionPrntDescr>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionPrntDescr input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();
}

internal class testPrntUnionPrntDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionPrntDescr>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestPrntUnionPrntDescr input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();
}

internal class testUnionPrntDupEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionPrntDup>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionPrntDup input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();
}

internal class testPrntUnionPrntDupEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionPrntDup>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestPrntUnionPrntDup input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();
}

internal static class test__SimpleEncoders
{
  internal static IEncoderRepositoryBuilder Addtest__SimpleEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnBoolDescr>(_ => new testDmnBoolDescrEncoder())
      .AddEncoder<ItestDmnBoolPrnt>(_ => new testDmnBoolPrntEncoder())
      .AddEncoder<ItestPrntDmnBoolPrnt>(_ => new testPrntDmnBoolPrntEncoder())
      .AddEncoder<ItestDmnBoolPrntDescr>(_ => new testDmnBoolPrntDescrEncoder())
      .AddEncoder<ItestPrntDmnBoolPrntDescr>(_ => new testPrntDmnBoolPrntDescrEncoder())
      .AddEncoder<ItestDmnEnumAll>(_ => new testDmnEnumAllEncoder())
      .AddEncoder<testEnumDmnEnumAll>(_ => new testEnumDmnEnumAllEncoder())
      .AddEncoder<ItestDmnEnumAllDescr>(_ => new testDmnEnumAllDescrEncoder())
      .AddEncoder<testEnumDmnEnumAllDescr>(_ => new testEnumDmnEnumAllDescrEncoder())
      .AddEncoder<ItestDmnEnumAllPrnt>(_ => new testDmnEnumAllPrntEncoder())
      .AddEncoder<testEnumDmnEnumAllPrnt>(_ => new testEnumDmnEnumAllPrntEncoder())
      .AddEncoder<testPrntDmnEnumAllPrnt>(_ => new testPrntDmnEnumAllPrntEncoder())
      .AddEncoder<ItestDmnEnumDescr>(_ => new testDmnEnumDescrEncoder())
      .AddEncoder<testEnumDmnEnumDescr>(_ => new testEnumDmnEnumDescrEncoder())
      .AddEncoder<ItestDmnEnumExcl>(_ => new testDmnEnumExclEncoder())
      .AddEncoder<testEnumDmnEnumExcl>(_ => new testEnumDmnEnumExclEncoder())
      .AddEncoder<ItestDmnEnumExclPrnt>(_ => new testDmnEnumExclPrntEncoder())
      .AddEncoder<testEnumDmnEnumExclPrnt>(_ => new testEnumDmnEnumExclPrntEncoder())
      .AddEncoder<testPrntDmnEnumExclPrnt>(_ => new testPrntDmnEnumExclPrntEncoder())
      .AddEncoder<ItestDmnEnumLabel>(_ => new testDmnEnumLabelEncoder())
      .AddEncoder<testEnumDmnEnumLabel>(_ => new testEnumDmnEnumLabelEncoder())
      .AddEncoder<ItestDmnEnumPrnt>(_ => new testDmnEnumPrntEncoder())
      .AddEncoder<ItestPrntDmnEnumPrnt>(_ => new testPrntDmnEnumPrntEncoder())
      .AddEncoder<testEnumDmnEnumPrnt>(_ => new testEnumDmnEnumPrntEncoder())
      .AddEncoder<ItestDmnEnumPrntDescr>(_ => new testDmnEnumPrntDescrEncoder())
      .AddEncoder<ItestPrntDmnEnumPrntDescr>(_ => new testPrntDmnEnumPrntDescrEncoder())
      .AddEncoder<testEnumDmnEnumPrntDescr>(_ => new testEnumDmnEnumPrntDescrEncoder())
      .AddEncoder<ItestDmnEnumUnq>(_ => new testDmnEnumUnqEncoder())
      .AddEncoder<testEnumDmnEnumUnq>(_ => new testEnumDmnEnumUnqEncoder())
      .AddEncoder<testDupDmnEnumUnq>(_ => new testDupDmnEnumUnqEncoder())
      .AddEncoder<ItestDmnEnumUnqPrnt>(_ => new testDmnEnumUnqPrntEncoder())
      .AddEncoder<testEnumDmnEnumUnqPrnt>(_ => new testEnumDmnEnumUnqPrntEncoder())
      .AddEncoder<testPrntDmnEnumUnqPrnt>(_ => new testPrntDmnEnumUnqPrntEncoder())
      .AddEncoder<testDupDmnEnumUnqPrnt>(_ => new testDupDmnEnumUnqPrntEncoder())
      .AddEncoder<ItestDmnEnumValue>(_ => new testDmnEnumValueEncoder())
      .AddEncoder<testEnumDmnEnumValue>(_ => new testEnumDmnEnumValueEncoder())
      .AddEncoder<ItestDmnEnumValuePrnt>(_ => new testDmnEnumValuePrntEncoder())
      .AddEncoder<testEnumDmnEnumValuePrnt>(_ => new testEnumDmnEnumValuePrntEncoder())
      .AddEncoder<testPrntDmnEnumValuePrnt>(_ => new testPrntDmnEnumValuePrntEncoder())
      .AddEncoder<ItestDmnNmbrDescr>(_ => new testDmnNmbrDescrEncoder())
      .AddEncoder<ItestDmnNmbrPrnt>(_ => new testDmnNmbrPrntEncoder())
      .AddEncoder<ItestPrntDmnNmbrPrnt>(_ => new testPrntDmnNmbrPrntEncoder())
      .AddEncoder<ItestDmnNmbrPrntDescr>(_ => new testDmnNmbrPrntDescrEncoder())
      .AddEncoder<ItestPrntDmnNmbrPrntDescr>(_ => new testPrntDmnNmbrPrntDescrEncoder())
      .AddEncoder<ItestDmnNmbrPstv>(_ => new testDmnNmbrPstvEncoder())
      .AddEncoder<ItestDmnNmbrRange>(_ => new testDmnNmbrRangeEncoder())
      .AddEncoder<ItestDmnStrDescr>(_ => new testDmnStrDescrEncoder())
      .AddEncoder<ItestDmnStrNonEmpty>(_ => new testDmnStrNonEmptyEncoder())
      .AddEncoder<ItestDmnStrPrnt>(_ => new testDmnStrPrntEncoder())
      .AddEncoder<ItestPrntDmnStrPrnt>(_ => new testPrntDmnStrPrntEncoder())
      .AddEncoder<ItestDmnStrPrntDescr>(_ => new testDmnStrPrntDescrEncoder())
      .AddEncoder<ItestPrntDmnStrPrntDescr>(_ => new testPrntDmnStrPrntDescrEncoder())
      .AddEncoder<testEnumDescr>(_ => new testEnumDescrEncoder())
      .AddEncoder<testEnumPrnt>(_ => new testEnumPrntEncoder())
      .AddEncoder<testPrntEnumPrnt>(_ => new testPrntEnumPrntEncoder())
      .AddEncoder<testEnumPrntAlias>(_ => new testEnumPrntAliasEncoder())
      .AddEncoder<testPrntEnumPrntAlias>(_ => new testPrntEnumPrntAliasEncoder())
      .AddEncoder<testEnumPrntDescr>(_ => new testEnumPrntDescrEncoder())
      .AddEncoder<testPrntEnumPrntDescr>(_ => new testPrntEnumPrntDescrEncoder())
      .AddEncoder<testEnumPrntDup>(_ => new testEnumPrntDupEncoder())
      .AddEncoder<testPrntEnumPrntDup>(_ => new testPrntEnumPrntDupEncoder())
      .AddEncoder<ItestUnionDescr>(r => new testUnionDescrEncoder(r))
      .AddEncoder<ItestUnionPrnt>(r => new testUnionPrntEncoder(r))
      .AddEncoder<ItestPrntUnionPrnt>(r => new testPrntUnionPrntEncoder(r))
      .AddEncoder<ItestUnionPrntDescr>(r => new testUnionPrntDescrEncoder(r))
      .AddEncoder<ItestPrntUnionPrntDescr>(r => new testPrntUnionPrntDescrEncoder(r))
      .AddEncoder<ItestUnionPrntDup>(r => new testUnionPrntDupEncoder(r))
      .AddEncoder<ItestPrntUnionPrntDup>(r => new testPrntUnionPrntDupEncoder(r));
}
