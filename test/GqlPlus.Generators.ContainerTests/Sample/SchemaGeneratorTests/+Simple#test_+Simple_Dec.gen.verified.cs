//HintName: test_+Simple_Dec.gen.cs
// Generated from {CurrentDirectory}+Simple.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Simple;

internal class testDmnBoolDescrDecoder
{

  internal static testDmnBoolDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolPrntDecoder
{

  internal static testDmnBoolPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnBoolPrntDecoder
{

  internal static testPrntDmnBoolPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolPrntDescrDecoder
{

  internal static testDmnBoolPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnBoolPrntDescrDecoder
{

  internal static testPrntDmnBoolPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumAllDecoder
{

  internal static testDmnEnumAllDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumAllDecoder : IDecoder<testEnumDmnEnumAll?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumAll? output)
    => input.DecodeEnum("EnumDmnEnumAll", out output);

  internal static testEnumDmnEnumAllDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumAllDescrDecoder
{

  internal static testDmnEnumAllDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumAllDescrDecoder : IDecoder<testEnumDmnEnumAllDescr?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumAllDescr? output)
    => input.DecodeEnum("EnumDmnEnumAllDescr", out output);

  internal static testEnumDmnEnumAllDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumAllPrntDecoder
{

  internal static testDmnEnumAllPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumAllPrntDecoder : IDecoder<testEnumDmnEnumAllPrnt?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumAllPrnt? output)
    => input.DecodeEnum("EnumDmnEnumAllPrnt", out output);

  internal static testEnumDmnEnumAllPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumAllPrntDecoder : IDecoder<testPrntDmnEnumAllPrnt?>
{
  public IMessages Decoder(IValue input, out testPrntDmnEnumAllPrnt? output)
    => input.DecodeEnum("PrntDmnEnumAllPrnt", out output);

  internal static testPrntDmnEnumAllPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumDescrDecoder
{

  internal static testDmnEnumDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumDescrDecoder : IDecoder<testEnumDmnEnumDescr?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumDescr? output)
    => input.DecodeEnum("EnumDmnEnumDescr", out output);

  internal static testEnumDmnEnumDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumExclDecoder
{

  internal static testDmnEnumExclDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumExclDecoder : IDecoder<testEnumDmnEnumExcl?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumExcl? output)
    => input.DecodeEnum("EnumDmnEnumExcl", out output);

  internal static testEnumDmnEnumExclDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumExclPrntDecoder
{

  internal static testDmnEnumExclPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumExclPrntDecoder : IDecoder<testEnumDmnEnumExclPrnt?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumExclPrnt? output)
    => input.DecodeEnum("EnumDmnEnumExclPrnt", out output);

  internal static testEnumDmnEnumExclPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumExclPrntDecoder : IDecoder<testPrntDmnEnumExclPrnt?>
{
  public IMessages Decoder(IValue input, out testPrntDmnEnumExclPrnt? output)
    => input.DecodeEnum("PrntDmnEnumExclPrnt", out output);

  internal static testPrntDmnEnumExclPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumLabelDecoder
{

  internal static testDmnEnumLabelDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumLabelDecoder : IDecoder<testEnumDmnEnumLabel?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumLabel? output)
    => input.DecodeEnum("EnumDmnEnumLabel", out output);

  internal static testEnumDmnEnumLabelDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumPrntDecoder
{

  internal static testDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumPrntDecoder
{

  internal static testPrntDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumPrntDecoder : IDecoder<testEnumDmnEnumPrnt?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumPrnt? output)
    => input.DecodeEnum("EnumDmnEnumPrnt", out output);

  internal static testEnumDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumPrntDescrDecoder
{

  internal static testDmnEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumPrntDescrDecoder
{

  internal static testPrntDmnEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumPrntDescrDecoder : IDecoder<testEnumDmnEnumPrntDescr?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumPrntDescr? output)
    => input.DecodeEnum("EnumDmnEnumPrntDescr", out output);

  internal static testEnumDmnEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumUnqDecoder
{

  internal static testDmnEnumUnqDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumUnqDecoder : IDecoder<testEnumDmnEnumUnq?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumUnq? output)
    => input.DecodeEnum("EnumDmnEnumUnq", out output);

  internal static testEnumDmnEnumUnqDecoder Factory(IDecoderRepository _) => new();
}

internal class testDupDmnEnumUnqDecoder : IDecoder<testDupDmnEnumUnq?>
{
  public IMessages Decoder(IValue input, out testDupDmnEnumUnq? output)
    => input.DecodeEnum("DupDmnEnumUnq", out output);

  internal static testDupDmnEnumUnqDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumUnqPrntDecoder
{

  internal static testDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumUnqPrntDecoder : IDecoder<testEnumDmnEnumUnqPrnt?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumUnqPrnt? output)
    => input.DecodeEnum("EnumDmnEnumUnqPrnt", out output);

  internal static testEnumDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumUnqPrntDecoder : IDecoder<testPrntDmnEnumUnqPrnt?>
{
  public IMessages Decoder(IValue input, out testPrntDmnEnumUnqPrnt? output)
    => input.DecodeEnum("PrntDmnEnumUnqPrnt", out output);

  internal static testPrntDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDupDmnEnumUnqPrntDecoder : IDecoder<testDupDmnEnumUnqPrnt?>
{
  public IMessages Decoder(IValue input, out testDupDmnEnumUnqPrnt? output)
    => input.DecodeEnum("DupDmnEnumUnqPrnt", out output);

  internal static testDupDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumValueDecoder
{

  internal static testDmnEnumValueDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumValueDecoder : IDecoder<testEnumDmnEnumValue?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumValue? output)
    => input.DecodeEnum("EnumDmnEnumValue", out output);

  internal static testEnumDmnEnumValueDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumValuePrntDecoder
{

  internal static testDmnEnumValuePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumValuePrntDecoder : IDecoder<testEnumDmnEnumValuePrnt?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumValuePrnt? output)
    => input.DecodeEnum("EnumDmnEnumValuePrnt", out output);

  internal static testEnumDmnEnumValuePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumValuePrntDecoder : IDecoder<testPrntDmnEnumValuePrnt?>
{
  public IMessages Decoder(IValue input, out testPrntDmnEnumValuePrnt? output)
    => input.DecodeEnum("PrntDmnEnumValuePrnt", out output);

  internal static testPrntDmnEnumValuePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrDescrDecoder
{

  internal static testDmnNmbrDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrPrntDecoder
{

  internal static testDmnNmbrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnNmbrPrntDecoder
{

  internal static testPrntDmnNmbrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrPrntDescrDecoder
{

  internal static testDmnNmbrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnNmbrPrntDescrDecoder
{

  internal static testPrntDmnNmbrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrPstvDecoder
{

  internal static testDmnNmbrPstvDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrRangeDecoder
{

  internal static testDmnNmbrRangeDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrDescrDecoder
{

  internal static testDmnStrDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrNonEmptyDecoder
{

  internal static testDmnStrNonEmptyDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrPrntDecoder
{

  internal static testDmnStrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnStrPrntDecoder
{

  internal static testPrntDmnStrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrPrntDescrDecoder
{

  internal static testDmnStrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnStrPrntDescrDecoder
{

  internal static testPrntDmnStrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDescrDecoder : IDecoder<testEnumDescr?>
{
  public IMessages Decoder(IValue input, out testEnumDescr? output)
    => input.DecodeEnum("EnumDescr", out output);

  internal static testEnumDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumPrntDecoder : IDecoder<testEnumPrnt?>
{
  public IMessages Decoder(IValue input, out testEnumPrnt? output)
    => input.DecodeEnum("EnumPrnt", out output);

  internal static testEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntDecoder : IDecoder<testPrntEnumPrnt?>
{
  public IMessages Decoder(IValue input, out testPrntEnumPrnt? output)
    => input.DecodeEnum("PrntEnumPrnt", out output);

  internal static testPrntEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumPrntAliasDecoder : IDecoder<testEnumPrntAlias?>
{
  public IMessages Decoder(IValue input, out testEnumPrntAlias? output)
    => input.DecodeEnum("EnumPrntAlias", out output);

  internal static testEnumPrntAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntAliasDecoder : IDecoder<testPrntEnumPrntAlias?>
{
  public IMessages Decoder(IValue input, out testPrntEnumPrntAlias? output)
    => input.DecodeEnum("PrntEnumPrntAlias", out output);

  internal static testPrntEnumPrntAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumPrntDescrDecoder : IDecoder<testEnumPrntDescr?>
{
  public IMessages Decoder(IValue input, out testEnumPrntDescr? output)
    => input.DecodeEnum("EnumPrntDescr", out output);

  internal static testEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntDescrDecoder : IDecoder<testPrntEnumPrntDescr?>
{
  public IMessages Decoder(IValue input, out testPrntEnumPrntDescr? output)
    => input.DecodeEnum("PrntEnumPrntDescr", out output);

  internal static testPrntEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumPrntDupDecoder : IDecoder<testEnumPrntDup?>
{
  public IMessages Decoder(IValue input, out testEnumPrntDup? output)
    => input.DecodeEnum("EnumPrntDup", out output);

  internal static testEnumPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntDupDecoder : IDecoder<testPrntEnumPrntDup?>
{
  public IMessages Decoder(IValue input, out testPrntEnumPrntDup? output)
    => input.DecodeEnum("PrntEnumPrntDup", out output);

  internal static testPrntEnumPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionDescrDecoder
{
  public Number AsNumber { get; set; }

  internal static testUnionDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionPrntDecoder
{
  public String AsString { get; set; }

  internal static testUnionPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionPrntDecoder
{
  public Number AsNumber { get; set; }

  internal static testPrntUnionPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionPrntDescrDecoder
{
  public Number AsNumber { get; set; }

  internal static testUnionPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionPrntDescrDecoder
{
  public Number AsNumber { get; set; }

  internal static testPrntUnionPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionPrntDupDecoder
{
  public Number AsNumber { get; set; }

  internal static testUnionPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionPrntDupDecoder
{
  public Number AsNumber { get; set; }

  internal static testPrntUnionPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal static class test__SimpleDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__SimpleDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnBoolDescr>(testDmnBoolDescrDecoder.Factory)
      .AddDecoder<ItestDmnBoolPrnt>(testDmnBoolPrntDecoder.Factory)
      .AddDecoder<ItestPrntDmnBoolPrnt>(testPrntDmnBoolPrntDecoder.Factory)
      .AddDecoder<ItestDmnBoolPrntDescr>(testDmnBoolPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntDmnBoolPrntDescr>(testPrntDmnBoolPrntDescrDecoder.Factory)
      .AddDecoder<ItestDmnEnumAll>(testDmnEnumAllDecoder.Factory)
      .AddDecoder<testEnumDmnEnumAll?>(testEnumDmnEnumAllDecoder.Factory)
      .AddDecoder<ItestDmnEnumAllDescr>(testDmnEnumAllDescrDecoder.Factory)
      .AddDecoder<testEnumDmnEnumAllDescr?>(testEnumDmnEnumAllDescrDecoder.Factory)
      .AddDecoder<ItestDmnEnumAllPrnt>(testDmnEnumAllPrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumAllPrnt?>(testEnumDmnEnumAllPrntDecoder.Factory)
      .AddDecoder<testPrntDmnEnumAllPrnt?>(testPrntDmnEnumAllPrntDecoder.Factory)
      .AddDecoder<ItestDmnEnumDescr>(testDmnEnumDescrDecoder.Factory)
      .AddDecoder<testEnumDmnEnumDescr?>(testEnumDmnEnumDescrDecoder.Factory)
      .AddDecoder<ItestDmnEnumExcl>(testDmnEnumExclDecoder.Factory)
      .AddDecoder<testEnumDmnEnumExcl?>(testEnumDmnEnumExclDecoder.Factory)
      .AddDecoder<ItestDmnEnumExclPrnt>(testDmnEnumExclPrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumExclPrnt?>(testEnumDmnEnumExclPrntDecoder.Factory)
      .AddDecoder<testPrntDmnEnumExclPrnt?>(testPrntDmnEnumExclPrntDecoder.Factory)
      .AddDecoder<ItestDmnEnumLabel>(testDmnEnumLabelDecoder.Factory)
      .AddDecoder<testEnumDmnEnumLabel?>(testEnumDmnEnumLabelDecoder.Factory)
      .AddDecoder<ItestDmnEnumPrnt>(testDmnEnumPrntDecoder.Factory)
      .AddDecoder<ItestPrntDmnEnumPrnt>(testPrntDmnEnumPrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumPrnt?>(testEnumDmnEnumPrntDecoder.Factory)
      .AddDecoder<ItestDmnEnumPrntDescr>(testDmnEnumPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntDmnEnumPrntDescr>(testPrntDmnEnumPrntDescrDecoder.Factory)
      .AddDecoder<testEnumDmnEnumPrntDescr?>(testEnumDmnEnumPrntDescrDecoder.Factory)
      .AddDecoder<ItestDmnEnumUnq>(testDmnEnumUnqDecoder.Factory)
      .AddDecoder<testEnumDmnEnumUnq?>(testEnumDmnEnumUnqDecoder.Factory)
      .AddDecoder<testDupDmnEnumUnq?>(testDupDmnEnumUnqDecoder.Factory)
      .AddDecoder<ItestDmnEnumUnqPrnt>(testDmnEnumUnqPrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumUnqPrnt?>(testEnumDmnEnumUnqPrntDecoder.Factory)
      .AddDecoder<testPrntDmnEnumUnqPrnt?>(testPrntDmnEnumUnqPrntDecoder.Factory)
      .AddDecoder<testDupDmnEnumUnqPrnt?>(testDupDmnEnumUnqPrntDecoder.Factory)
      .AddDecoder<ItestDmnEnumValue>(testDmnEnumValueDecoder.Factory)
      .AddDecoder<testEnumDmnEnumValue?>(testEnumDmnEnumValueDecoder.Factory)
      .AddDecoder<ItestDmnEnumValuePrnt>(testDmnEnumValuePrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumValuePrnt?>(testEnumDmnEnumValuePrntDecoder.Factory)
      .AddDecoder<testPrntDmnEnumValuePrnt?>(testPrntDmnEnumValuePrntDecoder.Factory)
      .AddDecoder<ItestDmnNmbrDescr>(testDmnNmbrDescrDecoder.Factory)
      .AddDecoder<ItestDmnNmbrPrnt>(testDmnNmbrPrntDecoder.Factory)
      .AddDecoder<ItestPrntDmnNmbrPrnt>(testPrntDmnNmbrPrntDecoder.Factory)
      .AddDecoder<ItestDmnNmbrPrntDescr>(testDmnNmbrPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntDmnNmbrPrntDescr>(testPrntDmnNmbrPrntDescrDecoder.Factory)
      .AddDecoder<ItestDmnNmbrPstv>(testDmnNmbrPstvDecoder.Factory)
      .AddDecoder<ItestDmnNmbrRange>(testDmnNmbrRangeDecoder.Factory)
      .AddDecoder<ItestDmnStrDescr>(testDmnStrDescrDecoder.Factory)
      .AddDecoder<ItestDmnStrNonEmpty>(testDmnStrNonEmptyDecoder.Factory)
      .AddDecoder<ItestDmnStrPrnt>(testDmnStrPrntDecoder.Factory)
      .AddDecoder<ItestPrntDmnStrPrnt>(testPrntDmnStrPrntDecoder.Factory)
      .AddDecoder<ItestDmnStrPrntDescr>(testDmnStrPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntDmnStrPrntDescr>(testPrntDmnStrPrntDescrDecoder.Factory)
      .AddDecoder<testEnumDescr?>(testEnumDescrDecoder.Factory)
      .AddDecoder<testEnumPrnt?>(testEnumPrntDecoder.Factory)
      .AddDecoder<testPrntEnumPrnt?>(testPrntEnumPrntDecoder.Factory)
      .AddDecoder<testEnumPrntAlias?>(testEnumPrntAliasDecoder.Factory)
      .AddDecoder<testPrntEnumPrntAlias?>(testPrntEnumPrntAliasDecoder.Factory)
      .AddDecoder<testEnumPrntDescr?>(testEnumPrntDescrDecoder.Factory)
      .AddDecoder<testPrntEnumPrntDescr?>(testPrntEnumPrntDescrDecoder.Factory)
      .AddDecoder<testEnumPrntDup?>(testEnumPrntDupDecoder.Factory)
      .AddDecoder<testPrntEnumPrntDup?>(testPrntEnumPrntDupDecoder.Factory)
      .AddDecoder<ItestUnionDescr>(testUnionDescrDecoder.Factory)
      .AddDecoder<ItestUnionPrnt>(testUnionPrntDecoder.Factory)
      .AddDecoder<ItestPrntUnionPrnt>(testPrntUnionPrntDecoder.Factory)
      .AddDecoder<ItestUnionPrntDescr>(testUnionPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntUnionPrntDescr>(testPrntUnionPrntDescrDecoder.Factory)
      .AddDecoder<ItestUnionPrntDup>(testUnionPrntDupDecoder.Factory)
      .AddDecoder<ItestPrntUnionPrntDup>(testPrntUnionPrntDupDecoder.Factory);
}
