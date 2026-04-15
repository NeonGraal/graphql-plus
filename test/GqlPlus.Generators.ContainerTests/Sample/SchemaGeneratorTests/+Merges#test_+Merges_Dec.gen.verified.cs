//HintName: test_+Merges_Dec.gen.cs
// Generated from {CurrentDirectory}+Merges.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Merges;

internal class testInDrctParamDecoder
{
}

internal class testDmnAliasDecoder
{
}

internal class testDmnBoolDecoder
{
}

internal class testDmnBoolDiffDecoder
{
}

internal class testDmnBoolSameDecoder
{
}

internal class testDmnEnumDiffDecoder
{
}

internal class testDmnEnumSameDecoder
{
}

internal class testDmnNmbrDecoder
{
}

internal class testDmnNmbrDiffDecoder
{
}

internal class testDmnNmbrSameDecoder
{
}

internal class testDmnStrDecoder
{
}

internal class testDmnStrDiffDecoder
{
}

internal class testDmnStrSameDecoder
{
}

internal class testEnumAliasDecoder
{
  public string enumAlias { get; set; }
}

internal class testEnumDiffDecoder
{
  public string one { get; set; }
  public string two { get; set; }
}

internal class testEnumSameDecoder
{
  public string enumSame { get; set; }
}

internal class testEnumSamePrntDecoder
{
  public string prnt_enumSamePrnt { get; set; }
  public string enumSamePrnt { get; set; }
}

internal class testPrntEnumSamePrntDecoder
{
  public string prnt_enumSamePrnt { get; set; }
}

internal class testEnumValueAliasDecoder
{
  public string enumValueAlias { get; set; }
  public string val1 { get; set; }
  public string val2 { get; set; }
}

internal class testObjDualDecoder
{
}

internal class testObjInpDecoder
{
}

internal class testObjAliasDualDecoder
{
}

internal class testObjAliasInpDecoder
{
}

internal class testObjAltDualDecoder
{
}

internal class testObjAltDualTypeDecoder
{
}

internal class testObjAltInpDecoder
{
}

internal class testObjAltInpTypeDecoder
{
}

internal class testObjAltEnumDualDecoder
{
}

internal class testObjAltEnumInpDecoder
{
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
}

internal class testFldObjFieldDualDecoder
{
}

internal class testObjFieldInpDecoder
{
  public ItestFldObjFieldInp Field { get; set; }
}

internal class testFldObjFieldInpDecoder
{
}

internal class testObjFieldAliasDualDecoder
{
  public ItestFldObjFieldAliasDual Field { get; set; }
}

internal class testFldObjFieldAliasDualDecoder
{
}

internal class testObjFieldAliasInpDecoder
{
  public ItestFldObjFieldAliasInp Field { get; set; }
}

internal class testFldObjFieldAliasInpDecoder
{
}

internal class testObjFieldEnumAliasDualDecoder
{
  public bool Field { get; set; }
}

internal class testObjFieldEnumAliasInpDecoder
{
  public bool Field { get; set; }
}

internal class testObjFieldEnumValueDualDecoder
{
  public bool Field { get; set; }
}

internal class testObjFieldEnumValueInpDecoder
{
  public bool Field { get; set; }
}

internal class testObjFieldTypeAliasDualDecoder
{
  public string Field { get; set; }
}

internal class testObjFieldTypeAliasInpDecoder
{
  public string Field { get; set; }
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
}

internal class testRefObjPrntDualDecoder
{
}

internal class testObjPrntInpDecoder
{
}

internal class testRefObjPrntInpDecoder
{
}

internal class testOutpFieldParam1Decoder
{
}

internal class testOutpFieldParam2Decoder
{
}

internal class testFldOutpFieldParamDecoder
{
}

internal class testUnionAliasDecoder
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
}

internal class testUnionDiffDecoder
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
}

internal class testUnionSameDecoder
{
  public Boolean AsBoolean { get; set; }
}

internal class testUnionSamePrntDecoder
{
  public Boolean AsBoolean { get; set; }
}

internal class testPrntUnionSamePrntDecoder
{
  public String AsString { get; set; }
}

internal static class test__MergesDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__MergesDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInDrctParamObject>(_ => new testInDrctParamDecoder())
      .AddDecoder<ItestDmnAlias>(_ => new testDmnAliasDecoder())
      .AddDecoder<ItestDmnBool>(_ => new testDmnBoolDecoder())
      .AddDecoder<ItestDmnBoolDiff>(_ => new testDmnBoolDiffDecoder())
      .AddDecoder<ItestDmnBoolSame>(_ => new testDmnBoolSameDecoder())
      .AddDecoder<ItestDmnEnumDiff>(_ => new testDmnEnumDiffDecoder())
      .AddDecoder<ItestDmnEnumSame>(_ => new testDmnEnumSameDecoder())
      .AddDecoder<ItestDmnNmbr>(_ => new testDmnNmbrDecoder())
      .AddDecoder<ItestDmnNmbrDiff>(_ => new testDmnNmbrDiffDecoder())
      .AddDecoder<ItestDmnNmbrSame>(_ => new testDmnNmbrSameDecoder())
      .AddDecoder<ItestDmnStr>(_ => new testDmnStrDecoder())
      .AddDecoder<ItestDmnStrDiff>(_ => new testDmnStrDiffDecoder())
      .AddDecoder<ItestDmnStrSame>(_ => new testDmnStrSameDecoder())
      .AddDecoder<testEnumAlias>(_ => new testEnumAliasDecoder())
      .AddDecoder<testEnumDiff>(_ => new testEnumDiffDecoder())
      .AddDecoder<testEnumSame>(_ => new testEnumSameDecoder())
      .AddDecoder<testEnumSamePrnt>(_ => new testEnumSamePrntDecoder())
      .AddDecoder<testPrntEnumSamePrnt>(_ => new testPrntEnumSamePrntDecoder())
      .AddDecoder<testEnumValueAlias>(_ => new testEnumValueAliasDecoder())
      .AddDecoder<ItestObjDualObject>(_ => new testObjDualDecoder())
      .AddDecoder<ItestObjInpObject>(_ => new testObjInpDecoder())
      .AddDecoder<ItestObjAliasDualObject>(_ => new testObjAliasDualDecoder())
      .AddDecoder<ItestObjAliasInpObject>(_ => new testObjAliasInpDecoder())
      .AddDecoder<ItestObjAltDualObject>(_ => new testObjAltDualDecoder())
      .AddDecoder<ItestObjAltDualTypeObject>(_ => new testObjAltDualTypeDecoder())
      .AddDecoder<ItestObjAltInpObject>(_ => new testObjAltInpDecoder())
      .AddDecoder<ItestObjAltInpTypeObject>(_ => new testObjAltInpTypeDecoder())
      .AddDecoder<ItestObjAltEnumDualObject>(_ => new testObjAltEnumDualDecoder())
      .AddDecoder<ItestObjAltEnumInpObject>(_ => new testObjAltEnumInpDecoder())
      .AddDecoder<ItestObjFieldDualObject>(_ => new testObjFieldDualDecoder())
      .AddDecoder<ItestFldObjFieldDualObject>(_ => new testFldObjFieldDualDecoder())
      .AddDecoder<ItestObjFieldInpObject>(_ => new testObjFieldInpDecoder())
      .AddDecoder<ItestFldObjFieldInpObject>(_ => new testFldObjFieldInpDecoder())
      .AddDecoder<ItestObjFieldAliasDualObject>(_ => new testObjFieldAliasDualDecoder())
      .AddDecoder<ItestFldObjFieldAliasDualObject>(_ => new testFldObjFieldAliasDualDecoder())
      .AddDecoder<ItestObjFieldAliasInpObject>(_ => new testObjFieldAliasInpDecoder())
      .AddDecoder<ItestFldObjFieldAliasInpObject>(_ => new testFldObjFieldAliasInpDecoder())
      .AddDecoder<ItestObjFieldEnumAliasDualObject>(_ => new testObjFieldEnumAliasDualDecoder())
      .AddDecoder<ItestObjFieldEnumAliasInpObject>(_ => new testObjFieldEnumAliasInpDecoder())
      .AddDecoder<ItestObjFieldEnumValueDualObject>(_ => new testObjFieldEnumValueDualDecoder())
      .AddDecoder<ItestObjFieldEnumValueInpObject>(_ => new testObjFieldEnumValueInpDecoder())
      .AddDecoder<ItestObjFieldTypeAliasDualObject>(_ => new testObjFieldTypeAliasDualDecoder())
      .AddDecoder<ItestObjFieldTypeAliasInpObject>(_ => new testObjFieldTypeAliasInpDecoder())
      .AddDecoder<ItestObjPrntDualObject>(_ => new testObjPrntDualDecoder())
      .AddDecoder<ItestRefObjPrntDualObject>(_ => new testRefObjPrntDualDecoder())
      .AddDecoder<ItestObjPrntInpObject>(_ => new testObjPrntInpDecoder())
      .AddDecoder<ItestRefObjPrntInpObject>(_ => new testRefObjPrntInpDecoder())
      .AddDecoder<ItestOutpFieldParam1Object>(_ => new testOutpFieldParam1Decoder())
      .AddDecoder<ItestOutpFieldParam2Object>(_ => new testOutpFieldParam2Decoder())
      .AddDecoder<ItestFldOutpFieldParamObject>(_ => new testFldOutpFieldParamDecoder())
      .AddDecoder<ItestUnionAlias>(_ => new testUnionAliasDecoder())
      .AddDecoder<ItestUnionDiff>(_ => new testUnionDiffDecoder())
      .AddDecoder<ItestUnionSame>(_ => new testUnionSameDecoder())
      .AddDecoder<ItestUnionSamePrnt>(_ => new testUnionSamePrntDecoder())
      .AddDecoder<ItestPrntUnionSamePrnt>(_ => new testPrntUnionSamePrntDecoder());
}
