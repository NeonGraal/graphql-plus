//HintName: test_+Merges_Dec.gen.cs
// Generated from {CurrentDirectory}+Merges.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Merges;

internal class testInDrctParamDecoder
{

  internal static testInDrctParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnAliasDecoder
{

  internal static testDmnAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolDecoder
{

  internal static testDmnBoolDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolDiffDecoder
{

  internal static testDmnBoolDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolSameDecoder
{

  internal static testDmnBoolSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumDiffDecoder
{

  internal static testDmnEnumDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumSameDecoder
{

  internal static testDmnEnumSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrDecoder
{

  internal static testDmnNmbrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrDiffDecoder
{

  internal static testDmnNmbrDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrSameDecoder
{

  internal static testDmnNmbrSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrDecoder
{

  internal static testDmnStrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrDiffDecoder
{

  internal static testDmnStrDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrSameDecoder
{

  internal static testDmnStrSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumAliasDecoder
{
  public string enumAlias { get; set; }

  internal static testEnumAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDiffDecoder
{
  public string one { get; set; }
  public string two { get; set; }

  internal static testEnumDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumSameDecoder
{
  public string enumSame { get; set; }

  internal static testEnumSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumSamePrntDecoder
{
  public string prnt_enumSamePrnt { get; set; }
  public string enumSamePrnt { get; set; }

  internal static testEnumSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumSamePrntDecoder
{
  public string prnt_enumSamePrnt { get; set; }

  internal static testPrntEnumSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumValueAliasDecoder
{
  public string enumValueAlias { get; set; }
  public string val1 { get; set; }
  public string val2 { get; set; }

  internal static testEnumValueAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjDualDecoder
{

  internal static testObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjInpDecoder
{

  internal static testObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAliasDualDecoder
{

  internal static testObjAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAliasInpDecoder
{

  internal static testObjAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltDualDecoder
{

  internal static testObjAltDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltDualTypeDecoder
{

  internal static testObjAltDualTypeDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltInpDecoder
{

  internal static testObjAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltInpTypeDecoder
{

  internal static testObjAltInpTypeDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltEnumDualDecoder
{

  internal static testObjAltEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltEnumInpDecoder
{

  internal static testObjAltEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjCnstDualDecoder<TType>
{
  public TType Field { get; set; }
  public TType Str { get; set; }
}

internal class testObjCnstInpDecoder<TType>
{
  public TType Field { get; set; }
  public TType Str { get; set; }
}

internal class testObjFieldDualDecoder
{
  public ItestFldObjFieldDual Field { get; set; }

  internal static testObjFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldDualDecoder
{

  internal static testFldObjFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldInpDecoder
{
  public ItestFldObjFieldInp Field { get; set; }

  internal static testObjFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldInpDecoder
{

  internal static testFldObjFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldAliasDualDecoder
{
  public ItestFldObjFieldAliasDual Field { get; set; }

  internal static testObjFieldAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldAliasDualDecoder
{

  internal static testFldObjFieldAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldAliasInpDecoder
{
  public ItestFldObjFieldAliasInp Field { get; set; }

  internal static testObjFieldAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldAliasInpDecoder
{

  internal static testFldObjFieldAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumAliasDualDecoder
{
  public bool Field { get; set; }

  internal static testObjFieldEnumAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumAliasInpDecoder
{
  public bool Field { get; set; }

  internal static testObjFieldEnumAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumValueDualDecoder
{
  public bool Field { get; set; }

  internal static testObjFieldEnumValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumValueInpDecoder
{
  public bool Field { get; set; }

  internal static testObjFieldEnumValueInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldTypeAliasDualDecoder
{
  public string Field { get; set; }

  internal static testObjFieldTypeAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldTypeAliasInpDecoder
{
  public string Field { get; set; }

  internal static testObjFieldTypeAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjParamDualDecoder<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }
}

internal class testObjParamInpDecoder<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }
}

internal class testObjParamDupDualDecoder<TTest>
{
  public TTest Test { get; set; }
  public TTest Type { get; set; }
}

internal class testObjParamDupInpDecoder<TTest>
{
  public TTest Test { get; set; }
  public TTest Type { get; set; }
}

internal class testObjPrntDualDecoder
{

  internal static testObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefObjPrntDualDecoder
{

  internal static testRefObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjPrntInpDecoder
{

  internal static testObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefObjPrntInpDecoder
{

  internal static testRefObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testOutpFieldParam1Decoder
{

  internal static testOutpFieldParam1Decoder Factory(IDecoderRepository _) => new();
}

internal class testOutpFieldParam2Decoder
{

  internal static testOutpFieldParam2Decoder Factory(IDecoderRepository _) => new();
}

internal class testFldOutpFieldParamDecoder
{

  internal static testFldOutpFieldParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionAliasDecoder
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }

  internal static testUnionAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionDiffDecoder
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }

  internal static testUnionDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionSameDecoder
{
  public Boolean AsBoolean { get; set; }

  internal static testUnionSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionSamePrntDecoder
{
  public Boolean AsBoolean { get; set; }

  internal static testUnionSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionSamePrntDecoder
{
  public String AsString { get; set; }

  internal static testPrntUnionSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test__MergesDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__MergesDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInDrctParamObject>(testInDrctParamDecoder.Factory)
      .AddDecoder<ItestDmnAlias>(testDmnAliasDecoder.Factory)
      .AddDecoder<ItestDmnBool>(testDmnBoolDecoder.Factory)
      .AddDecoder<ItestDmnBoolDiff>(testDmnBoolDiffDecoder.Factory)
      .AddDecoder<ItestDmnBoolSame>(testDmnBoolSameDecoder.Factory)
      .AddDecoder<ItestDmnEnumDiff>(testDmnEnumDiffDecoder.Factory)
      .AddDecoder<ItestDmnEnumSame>(testDmnEnumSameDecoder.Factory)
      .AddDecoder<ItestDmnNmbr>(testDmnNmbrDecoder.Factory)
      .AddDecoder<ItestDmnNmbrDiff>(testDmnNmbrDiffDecoder.Factory)
      .AddDecoder<ItestDmnNmbrSame>(testDmnNmbrSameDecoder.Factory)
      .AddDecoder<ItestDmnStr>(testDmnStrDecoder.Factory)
      .AddDecoder<ItestDmnStrDiff>(testDmnStrDiffDecoder.Factory)
      .AddDecoder<ItestDmnStrSame>(testDmnStrSameDecoder.Factory)
      .AddDecoder<testEnumAlias>(testEnumAliasDecoder.Factory)
      .AddDecoder<testEnumDiff>(testEnumDiffDecoder.Factory)
      .AddDecoder<testEnumSame>(testEnumSameDecoder.Factory)
      .AddDecoder<testEnumSamePrnt>(testEnumSamePrntDecoder.Factory)
      .AddDecoder<testPrntEnumSamePrnt>(testPrntEnumSamePrntDecoder.Factory)
      .AddDecoder<testEnumValueAlias>(testEnumValueAliasDecoder.Factory)
      .AddDecoder<ItestObjDualObject>(testObjDualDecoder.Factory)
      .AddDecoder<ItestObjInpObject>(testObjInpDecoder.Factory)
      .AddDecoder<ItestObjAliasDualObject>(testObjAliasDualDecoder.Factory)
      .AddDecoder<ItestObjAliasInpObject>(testObjAliasInpDecoder.Factory)
      .AddDecoder<ItestObjAltDualObject>(testObjAltDualDecoder.Factory)
      .AddDecoder<ItestObjAltDualTypeObject>(testObjAltDualTypeDecoder.Factory)
      .AddDecoder<ItestObjAltInpObject>(testObjAltInpDecoder.Factory)
      .AddDecoder<ItestObjAltInpTypeObject>(testObjAltInpTypeDecoder.Factory)
      .AddDecoder<ItestObjAltEnumDualObject>(testObjAltEnumDualDecoder.Factory)
      .AddDecoder<ItestObjAltEnumInpObject>(testObjAltEnumInpDecoder.Factory)
      .AddDecoder<ItestObjFieldDualObject>(testObjFieldDualDecoder.Factory)
      .AddDecoder<ItestFldObjFieldDualObject>(testFldObjFieldDualDecoder.Factory)
      .AddDecoder<ItestObjFieldInpObject>(testObjFieldInpDecoder.Factory)
      .AddDecoder<ItestFldObjFieldInpObject>(testFldObjFieldInpDecoder.Factory)
      .AddDecoder<ItestObjFieldAliasDualObject>(testObjFieldAliasDualDecoder.Factory)
      .AddDecoder<ItestFldObjFieldAliasDualObject>(testFldObjFieldAliasDualDecoder.Factory)
      .AddDecoder<ItestObjFieldAliasInpObject>(testObjFieldAliasInpDecoder.Factory)
      .AddDecoder<ItestFldObjFieldAliasInpObject>(testFldObjFieldAliasInpDecoder.Factory)
      .AddDecoder<ItestObjFieldEnumAliasDualObject>(testObjFieldEnumAliasDualDecoder.Factory)
      .AddDecoder<ItestObjFieldEnumAliasInpObject>(testObjFieldEnumAliasInpDecoder.Factory)
      .AddDecoder<ItestObjFieldEnumValueDualObject>(testObjFieldEnumValueDualDecoder.Factory)
      .AddDecoder<ItestObjFieldEnumValueInpObject>(testObjFieldEnumValueInpDecoder.Factory)
      .AddDecoder<ItestObjFieldTypeAliasDualObject>(testObjFieldTypeAliasDualDecoder.Factory)
      .AddDecoder<ItestObjFieldTypeAliasInpObject>(testObjFieldTypeAliasInpDecoder.Factory)
      .AddDecoder<ItestObjPrntDualObject>(testObjPrntDualDecoder.Factory)
      .AddDecoder<ItestRefObjPrntDualObject>(testRefObjPrntDualDecoder.Factory)
      .AddDecoder<ItestObjPrntInpObject>(testObjPrntInpDecoder.Factory)
      .AddDecoder<ItestRefObjPrntInpObject>(testRefObjPrntInpDecoder.Factory)
      .AddDecoder<ItestOutpFieldParam1Object>(testOutpFieldParam1Decoder.Factory)
      .AddDecoder<ItestOutpFieldParam2Object>(testOutpFieldParam2Decoder.Factory)
      .AddDecoder<ItestFldOutpFieldParamObject>(testFldOutpFieldParamDecoder.Factory)
      .AddDecoder<ItestUnionAlias>(testUnionAliasDecoder.Factory)
      .AddDecoder<ItestUnionDiff>(testUnionDiffDecoder.Factory)
      .AddDecoder<ItestUnionSame>(testUnionSameDecoder.Factory)
      .AddDecoder<ItestUnionSamePrnt>(testUnionSamePrntDecoder.Factory)
      .AddDecoder<ItestPrntUnionSamePrnt>(testPrntUnionSamePrntDecoder.Factory);
}
