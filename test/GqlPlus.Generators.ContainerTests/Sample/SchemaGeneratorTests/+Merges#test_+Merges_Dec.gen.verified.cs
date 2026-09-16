//HintName: test_+Merges_Dec.gen.cs
// Generated from {CurrentDirectory}+Merges.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Merges;

internal class testInDrctParamDecoder : NullDecoder<ItestInDrctParamObject>
{

  internal static testInDrctParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnAliasDecoder : NullDecoder<ItestDmnAlias>
{

  internal static testDmnAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolDecoder : NullDecoder<ItestDmnBool>
{

  internal static testDmnBoolDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolDiffDecoder : NullDecoder<ItestDmnBoolDiff>
{

  internal static testDmnBoolDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolSameDecoder : NullDecoder<ItestDmnBoolSame>
{

  internal static testDmnBoolSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumDiffDecoder : NullDecoder<ItestDmnEnumDiff>
{

  internal static testDmnEnumDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumSameDecoder : NullDecoder<ItestDmnEnumSame>
{

  internal static testDmnEnumSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrDecoder : NullDecoder<ItestDmnNmbr>
{

  internal static testDmnNmbrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrDiffDecoder : NullDecoder<ItestDmnNmbrDiff>
{

  internal static testDmnNmbrDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrSameDecoder : NullDecoder<ItestDmnNmbrSame>
{

  internal static testDmnNmbrSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrDecoder : NullDecoder<ItestDmnStr>
{

  internal static testDmnStrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrDiffDecoder : NullDecoder<ItestDmnStrDiff>
{

  internal static testDmnStrDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrSameDecoder : NullDecoder<ItestDmnStrSame>
{

  internal static testDmnStrSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumAliasDecoder : NullDecoder<testEnumAlias>
{
  public string enumAlias { get; set; } = default!;

  internal static testEnumAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDiffDecoder : NullDecoder<testEnumDiff>
{
  public string one { get; set; } = default!;
  public string two { get; set; } = default!;

  internal static testEnumDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumSameDecoder : NullDecoder<testEnumSame>
{
  public string enumSame { get; set; } = default!;

  internal static testEnumSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumSamePrntDecoder : NullDecoder<testEnumSamePrnt>
{
  public string prnt_enumSamePrnt { get; set; } = default!;
  public string enumSamePrnt { get; set; } = default!;

  internal static testEnumSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumSamePrntDecoder : NullDecoder<testPrntEnumSamePrnt>
{
  public string prnt_enumSamePrnt { get; set; } = default!;

  internal static testPrntEnumSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumValueAliasDecoder : NullDecoder<testEnumValueAlias>
{
  public string enumValueAlias { get; set; } = default!;
  public string val1 { get; set; } = default!;
  public string val2 { get; set; } = default!;

  internal static testEnumValueAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjDualDecoder : NullDecoder<ItestObjDualObject>
{

  internal static testObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjInpDecoder : NullDecoder<ItestObjInpObject>
{

  internal static testObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAliasDualDecoder : NullDecoder<ItestObjAliasDualObject>
{

  internal static testObjAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAliasInpDecoder : NullDecoder<ItestObjAliasInpObject>
{

  internal static testObjAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltDualDecoder : NullDecoder<ItestObjAltDualObject>
{

  internal static testObjAltDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltDualTypeDecoder : NullDecoder<ItestObjAltDualTypeObject>
{

  internal static testObjAltDualTypeDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltInpDecoder : NullDecoder<ItestObjAltInpObject>
{

  internal static testObjAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltInpTypeDecoder : NullDecoder<ItestObjAltInpTypeObject>
{

  internal static testObjAltInpTypeDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltEnumDualDecoder : NullDecoder<ItestObjAltEnumDualObject>
{

  internal static testObjAltEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltEnumInpDecoder : NullDecoder<ItestObjAltEnumInpObject>
{

  internal static testObjAltEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjCnstDualDecoder<TType>
{
  public TType Field { get; set; } = default!;
  public TType Str { get; set; } = default!;
}

internal class testObjCnstInpDecoder<TType>
{
  public TType Field { get; set; } = default!;
  public TType Str { get; set; } = default!;
}

internal class testObjFieldDualDecoder : NullDecoder<ItestObjFieldDualObject>
{
  public ItestFldObjFieldDual Field { get; set; } = default!;

  internal static testObjFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldDualDecoder : NullDecoder<ItestFldObjFieldDualObject>
{

  internal static testFldObjFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldInpDecoder : NullDecoder<ItestObjFieldInpObject>
{
  public ItestFldObjFieldInp Field { get; set; } = default!;

  internal static testObjFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldInpDecoder : NullDecoder<ItestFldObjFieldInpObject>
{

  internal static testFldObjFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldAliasDualDecoder : NullDecoder<ItestObjFieldAliasDualObject>
{
  public ItestFldObjFieldAliasDual Field { get; set; } = default!;

  internal static testObjFieldAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldAliasDualDecoder : NullDecoder<ItestFldObjFieldAliasDualObject>
{

  internal static testFldObjFieldAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldAliasInpDecoder : NullDecoder<ItestObjFieldAliasInpObject>
{
  public ItestFldObjFieldAliasInp Field { get; set; } = default!;

  internal static testObjFieldAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldAliasInpDecoder : NullDecoder<ItestFldObjFieldAliasInpObject>
{

  internal static testFldObjFieldAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumAliasDualDecoder : NullDecoder<ItestObjFieldEnumAliasDualObject>
{
  public bool Field { get; set; } = default!;

  internal static testObjFieldEnumAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumAliasInpDecoder : NullDecoder<ItestObjFieldEnumAliasInpObject>
{
  public bool Field { get; set; } = default!;

  internal static testObjFieldEnumAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumValueDualDecoder : NullDecoder<ItestObjFieldEnumValueDualObject>
{
  public bool Field { get; set; } = default!;

  internal static testObjFieldEnumValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumValueInpDecoder : NullDecoder<ItestObjFieldEnumValueInpObject>
{
  public bool Field { get; set; } = default!;

  internal static testObjFieldEnumValueInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldTypeAliasDualDecoder : NullDecoder<ItestObjFieldTypeAliasDualObject>
{
  public string Field { get; set; } = default!;

  internal static testObjFieldTypeAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldTypeAliasInpDecoder : NullDecoder<ItestObjFieldTypeAliasInpObject>
{
  public string Field { get; set; } = default!;

  internal static testObjFieldTypeAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjParamDualDecoder<TTest,TType>
{
  public TTest Test { get; set; } = default!;
  public TType Type { get; set; } = default!;
}

internal class testObjParamInpDecoder<TTest,TType>
{
  public TTest Test { get; set; } = default!;
  public TType Type { get; set; } = default!;
}

internal class testObjParamDupDualDecoder<TTest>
{
  public TTest Test { get; set; } = default!;
  public TTest Type { get; set; } = default!;
}

internal class testObjParamDupInpDecoder<TTest>
{
  public TTest Test { get; set; } = default!;
  public TTest Type { get; set; } = default!;
}

internal class testObjPrntDualDecoder : NullDecoder<ItestObjPrntDualObject>
{

  internal static testObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefObjPrntDualDecoder : NullDecoder<ItestRefObjPrntDualObject>
{

  internal static testRefObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjPrntInpDecoder : NullDecoder<ItestObjPrntInpObject>
{

  internal static testObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefObjPrntInpDecoder : NullDecoder<ItestRefObjPrntInpObject>
{

  internal static testRefObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testOutpFieldParam1Decoder : NullDecoder<ItestOutpFieldParam1Object>
{

  internal static testOutpFieldParam1Decoder Factory(IDecoderRepository _) => new();
}

internal class testOutpFieldParam2Decoder : NullDecoder<ItestOutpFieldParam2Object>
{

  internal static testOutpFieldParam2Decoder Factory(IDecoderRepository _) => new();
}

internal class testFldOutpFieldParamDecoder : NullDecoder<ItestFldOutpFieldParamObject>
{

  internal static testFldOutpFieldParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionAliasDecoder : NullDecoder<ItestUnionAlias>
{
  public Boolean AsBoolean { get; set; } = default!;
  public Number AsNumber { get; set; } = default!;

  internal static testUnionAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionDiffDecoder : NullDecoder<ItestUnionDiff>
{
  public Boolean AsBoolean { get; set; } = default!;
  public Number AsNumber { get; set; } = default!;

  internal static testUnionDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionSameDecoder : NullDecoder<ItestUnionSame>
{
  public Boolean AsBoolean { get; set; } = default!;

  internal static testUnionSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionSamePrntDecoder : NullDecoder<ItestUnionSamePrnt>
{
  public Boolean AsBoolean { get; set; } = default!;

  internal static testUnionSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionSamePrntDecoder : NullDecoder<ItestPrntUnionSamePrnt>
{
  public String AsString { get; set; } = default!;

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
