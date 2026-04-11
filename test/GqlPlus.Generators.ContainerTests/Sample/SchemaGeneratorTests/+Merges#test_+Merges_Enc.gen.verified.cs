//HintName: test_+Merges_Enc.gen.cs
// Generated from {CurrentDirectory}+Merges.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Merges;

internal class testCtgrEncoder
{
}

internal class testCtgrAliasEncoder
{
}

internal class testCtgrDescrEncoder
{
}

internal class testCtgrModEncoder
{
}

internal class testInDrctParamEncoder
{
}

internal class testDmnAliasEncoder
{
}

internal class testDmnBoolEncoder
{
}

internal class testDmnBoolDiffEncoder
{
}

internal class testDmnBoolSameEncoder
{
}

internal class testDmnEnumDiffEncoder
{
}

internal class testDmnEnumSameEncoder
{
}

internal class testDmnNmbrEncoder
{
}

internal class testDmnNmbrDiffEncoder
{
}

internal class testDmnNmbrSameEncoder
{
}

internal class testDmnStrEncoder
{
}

internal class testDmnStrDiffEncoder
{
}

internal class testDmnStrSameEncoder
{
}

internal class testEnumAliasEncoder
{
  public string enumAlias { get; set; }
}

internal class testEnumDiffEncoder
{
  public string one { get; set; }
  public string two { get; set; }
}

internal class testEnumSameEncoder
{
  public string enumSame { get; set; }
}

internal class testEnumSamePrntEncoder
{
  public string prnt_enumSamePrnt { get; set; }
  public string enumSamePrnt { get; set; }
}

internal class testPrntEnumSamePrntEncoder
{
  public string prnt_enumSamePrnt { get; set; }
}

internal class testEnumValueAliasEncoder
{
  public string enumValueAlias { get; set; }
  public string val1 { get; set; }
  public string val2 { get; set; }
}

internal class testObjDualEncoder
{
}

internal class testObjInpEncoder
{
}

internal class testObjOutpEncoder
{
}

internal class testObjAliasDualEncoder
{
}

internal class testObjAliasInpEncoder
{
}

internal class testObjAliasOutpEncoder
{
}

internal class testObjAltDualEncoder
{
}

internal class testObjAltDualTypeEncoder
{
}

internal class testObjAltInpEncoder
{
}

internal class testObjAltInpTypeEncoder
{
}

internal class testObjAltOutpEncoder
{
}

internal class testObjAltOutpTypeEncoder
{
}

internal class testObjAltEnumDualEncoder
{
}

internal class testObjAltEnumInpEncoder
{
}

internal class testObjAltEnumOutpEncoder
{
}

internal class testObjCnstDualEncoder<TType>
{
  public TType Field { get; set; }
  public TType Str { get; set; }
}

internal class testObjCnstInpEncoder<TType>
{
  public TType Field { get; set; }
  public TType Str { get; set; }
}

internal class testObjCnstOutpEncoder<TType>
{
  public TType Field { get; set; }
  public TType Str { get; set; }
}

internal class testObjFieldDualEncoder
{
  public ItestFldObjFieldDual Field { get; set; }
}

internal class testFldObjFieldDualEncoder
{
}

internal class testObjFieldInpEncoder
{
  public ItestFldObjFieldInp Field { get; set; }
}

internal class testFldObjFieldInpEncoder
{
}

internal class testObjFieldOutpEncoder
{
  public ItestFldObjFieldOutp Field { get; set; }
}

internal class testFldObjFieldOutpEncoder
{
}

internal class testObjFieldAliasDualEncoder
{
  public ItestFldObjFieldAliasDual Field { get; set; }
}

internal class testFldObjFieldAliasDualEncoder
{
}

internal class testObjFieldAliasInpEncoder
{
  public ItestFldObjFieldAliasInp Field { get; set; }
}

internal class testFldObjFieldAliasInpEncoder
{
}

internal class testObjFieldAliasOutpEncoder
{
  public ItestFldObjFieldAliasOutp Field { get; set; }
}

internal class testFldObjFieldAliasOutpEncoder
{
}

internal class testObjFieldEnumAliasDualEncoder
{
  public bool Field { get; set; }
}

internal class testObjFieldEnumAliasInpEncoder
{
  public bool Field { get; set; }
}

internal class testObjFieldEnumAliasOutpEncoder
{
  public bool Field { get; set; }
}

internal class testObjFieldEnumValueDualEncoder
{
  public bool Field { get; set; }
}

internal class testObjFieldEnumValueInpEncoder
{
  public bool Field { get; set; }
}

internal class testObjFieldEnumValueOutpEncoder
{
  public bool Field { get; set; }
}

internal class testObjFieldTypeAliasDualEncoder
{
  public string Field { get; set; }
}

internal class testObjFieldTypeAliasInpEncoder
{
  public string Field { get; set; }
}

internal class testObjFieldTypeAliasOutpEncoder
{
  public string Field { get; set; }
}

internal class testObjParamDualEncoder<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }
}

internal class testObjParamInpEncoder<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }
}

internal class testObjParamOutpEncoder<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }
}

internal class testObjParamDupDualEncoder<TTest>
{
  public TTest Test { get; set; }
  public TTest Type { get; set; }
}

internal class testObjParamDupInpEncoder<TTest>
{
  public TTest Test { get; set; }
  public TTest Type { get; set; }
}

internal class testObjParamDupOutpEncoder<TTest>
{
  public TTest Test { get; set; }
  public TTest Type { get; set; }
}

internal class testObjPrntDualEncoder
{
}

internal class testRefObjPrntDualEncoder
{
}

internal class testObjPrntInpEncoder
{
}

internal class testRefObjPrntInpEncoder
{
}

internal class testObjPrntOutpEncoder
{
}

internal class testRefObjPrntOutpEncoder
{
}

internal class testOpEncoder
{
}

internal class testOutpFieldParamEncoder
{
  public ItestFldOutpFieldParam? Field(ItestOutpFieldParam1 parameter)
    => null;
}

internal class testOutpFieldParam1Encoder
{
}

internal class testOutpFieldParam2Encoder
{
}

internal class testFldOutpFieldParamEncoder
{
}

internal class testUnionAliasEncoder
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
}

internal class testUnionDiffEncoder
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
}

internal class testUnionSameEncoder
{
  public Boolean AsBoolean { get; set; }
}

internal class testUnionSamePrntEncoder
{
  public Boolean AsBoolean { get; set; }
}

internal class testPrntUnionSamePrntEncoder
{
  public String AsString { get; set; }
}
