//HintName: test_+Merges_Dec.gen.cs
// Generated from {CurrentDirectory}+Merges.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Merges;

internal class testCtgrDecoder
{
}

internal class testCtgrAliasDecoder
{
}

internal class testCtgrDescrDecoder
{
}

internal class testCtgrModDecoder
{
}

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

internal class testObjOutpDecoder
{
}

internal class testObjAliasDualDecoder
{
}

internal class testObjAliasInpDecoder
{
}

internal class testObjAliasOutpDecoder
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

internal class testObjAltOutpDecoder
{
}

internal class testObjAltOutpTypeDecoder
{
}

internal class testObjAltEnumDualDecoder
{
}

internal class testObjAltEnumInpDecoder
{
}

internal class testObjAltEnumOutpDecoder
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

internal class testObjCnstOutpDecoder<TType>
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

internal class testObjFieldOutpDecoder
{
  public ItestFldObjFieldOutp Field { get; set; }
}

internal class testFldObjFieldOutpDecoder
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

internal class testObjFieldAliasOutpDecoder
{
  public ItestFldObjFieldAliasOutp Field { get; set; }
}

internal class testFldObjFieldAliasOutpDecoder
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

internal class testObjFieldEnumAliasOutpDecoder
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

internal class testObjFieldEnumValueOutpDecoder
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

internal class testObjFieldTypeAliasOutpDecoder
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

internal class testObjParamOutpDecoder<TTest,TType>
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

internal class testObjParamDupOutpDecoder<TTest>
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

internal class testObjPrntOutpDecoder
{
}

internal class testRefObjPrntOutpDecoder
{
}

internal class testOutpFieldParamDecoder
{
  public ItestFldOutpFieldParam? Field(ItestOutpFieldParam1 parameter)
    => null;
  public ItestFldOutpFieldParam? Field()
    => null;
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
      .AddDecoder<ItestCtgrObject>(_ => new testCtgrDecoder())
      .AddDecoder<ItestCtgrAliasObject>(_ => new testCtgrAliasDecoder())
      .AddDecoder<ItestCtgrDescrObject>(_ => new testCtgrDescrDecoder())
      .AddDecoder<ItestCtgrModObject>(_ => new testCtgrModDecoder())
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
      .AddDecoder<ItestObjOutpObject>(_ => new testObjOutpDecoder())
      .AddDecoder<ItestObjAliasDualObject>(_ => new testObjAliasDualDecoder())
      .AddDecoder<ItestObjAliasInpObject>(_ => new testObjAliasInpDecoder())
      .AddDecoder<ItestObjAliasOutpObject>(_ => new testObjAliasOutpDecoder())
      .AddDecoder<ItestObjAltDualObject>(_ => new testObjAltDualDecoder())
      .AddDecoder<ItestObjAltDualTypeObject>(_ => new testObjAltDualTypeDecoder())
      .AddDecoder<ItestObjAltInpObject>(_ => new testObjAltInpDecoder())
      .AddDecoder<ItestObjAltInpTypeObject>(_ => new testObjAltInpTypeDecoder())
      .AddDecoder<ItestObjAltOutpObject>(_ => new testObjAltOutpDecoder())
      .AddDecoder<ItestObjAltOutpTypeObject>(_ => new testObjAltOutpTypeDecoder())
      .AddDecoder<ItestObjAltEnumDualObject>(_ => new testObjAltEnumDualDecoder())
      .AddDecoder<ItestObjAltEnumInpObject>(_ => new testObjAltEnumInpDecoder())
      .AddDecoder<ItestObjAltEnumOutpObject>(_ => new testObjAltEnumOutpDecoder())
      .AddDecoder<ItestObjFieldDualObject>(r => new testObjFieldDualDecoder(r))
      .AddDecoder<ItestFldObjFieldDualObject>(_ => new testFldObjFieldDualDecoder())
      .AddDecoder<ItestObjFieldInpObject>(r => new testObjFieldInpDecoder(r))
      .AddDecoder<ItestFldObjFieldInpObject>(_ => new testFldObjFieldInpDecoder())
      .AddDecoder<ItestObjFieldOutpObject>(r => new testObjFieldOutpDecoder(r))
      .AddDecoder<ItestFldObjFieldOutpObject>(_ => new testFldObjFieldOutpDecoder())
      .AddDecoder<ItestObjFieldAliasDualObject>(r => new testObjFieldAliasDualDecoder(r))
      .AddDecoder<ItestFldObjFieldAliasDualObject>(_ => new testFldObjFieldAliasDualDecoder())
      .AddDecoder<ItestObjFieldAliasInpObject>(r => new testObjFieldAliasInpDecoder(r))
      .AddDecoder<ItestFldObjFieldAliasInpObject>(_ => new testFldObjFieldAliasInpDecoder())
      .AddDecoder<ItestObjFieldAliasOutpObject>(r => new testObjFieldAliasOutpDecoder(r))
      .AddDecoder<ItestFldObjFieldAliasOutpObject>(_ => new testFldObjFieldAliasOutpDecoder())
      .AddDecoder<ItestObjFieldEnumAliasDualObject>(r => new testObjFieldEnumAliasDualDecoder(r))
      .AddDecoder<ItestObjFieldEnumAliasInpObject>(r => new testObjFieldEnumAliasInpDecoder(r))
      .AddDecoder<ItestObjFieldEnumAliasOutpObject>(r => new testObjFieldEnumAliasOutpDecoder(r))
      .AddDecoder<ItestObjFieldEnumValueDualObject>(r => new testObjFieldEnumValueDualDecoder(r))
      .AddDecoder<ItestObjFieldEnumValueInpObject>(r => new testObjFieldEnumValueInpDecoder(r))
      .AddDecoder<ItestObjFieldEnumValueOutpObject>(r => new testObjFieldEnumValueOutpDecoder(r))
      .AddDecoder<ItestObjFieldTypeAliasDualObject>(r => new testObjFieldTypeAliasDualDecoder(r))
      .AddDecoder<ItestObjFieldTypeAliasInpObject>(r => new testObjFieldTypeAliasInpDecoder(r))
      .AddDecoder<ItestObjFieldTypeAliasOutpObject>(r => new testObjFieldTypeAliasOutpDecoder(r))
      .AddDecoder<ItestObjPrntDualObject>(_ => new testObjPrntDualDecoder())
      .AddDecoder<ItestRefObjPrntDualObject>(_ => new testRefObjPrntDualDecoder())
      .AddDecoder<ItestObjPrntInpObject>(_ => new testObjPrntInpDecoder())
      .AddDecoder<ItestRefObjPrntInpObject>(_ => new testRefObjPrntInpDecoder())
      .AddDecoder<ItestObjPrntOutpObject>(_ => new testObjPrntOutpDecoder())
      .AddDecoder<ItestRefObjPrntOutpObject>(_ => new testRefObjPrntOutpDecoder())
      .AddDecoder<ItestOutpFieldParamObject>(r => new testOutpFieldParamDecoder(r))
      .AddDecoder<ItestOutpFieldParam1Object>(_ => new testOutpFieldParam1Decoder())
      .AddDecoder<ItestOutpFieldParam2Object>(_ => new testOutpFieldParam2Decoder())
      .AddDecoder<ItestFldOutpFieldParamObject>(_ => new testFldOutpFieldParamDecoder())
      .AddDecoder<ItestUnionAlias>(r => new testUnionAliasDecoder(r))
      .AddDecoder<ItestUnionDiff>(r => new testUnionDiffDecoder(r))
      .AddDecoder<ItestUnionSame>(r => new testUnionSameDecoder(r))
      .AddDecoder<ItestUnionSamePrnt>(r => new testUnionSamePrntDecoder(r))
      .AddDecoder<ItestPrntUnionSamePrnt>(r => new testPrntUnionSamePrntDecoder(r));
}
