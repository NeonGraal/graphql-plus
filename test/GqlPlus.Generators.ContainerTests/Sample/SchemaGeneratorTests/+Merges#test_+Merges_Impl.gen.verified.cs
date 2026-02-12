//HintName: test_+Merges_Impl.gen.cs
// Generated from +Merges.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Merges;

public class testCtgr
  : ItestCtgr
{
  public ItestCtgrObject AsCtgr { get; set; }
}

public class testCtgrAlias
  : ItestCtgrAlias
{
  public ItestCtgrAliasObject AsCtgrAlias { get; set; }
}

public class testCtgrDescr
  : ItestCtgrDescr
{
  public ItestCtgrDescrObject AsCtgrDescr { get; set; }
}

public class testCtgrMod
  : ItestCtgrMod
{
  public ItestCtgrModObject AsCtgrMod { get; set; }
}

public class testInDrctParam
  : ItestInDrctParam
{
  public ItestInDrctParamObject AsInDrctParam { get; set; }
}

public class testDmnAlias
  : DomainNumber
  , ItestDmnAlias
{
}

public class testDmnBool
  : DomainBoolean
  , ItestDmnBool
{
}

public class testDmnBoolDiff
  : DomainBoolean
  , ItestDmnBoolDiff
{
}

public class testDmnBoolSame
  : DomainBoolean
  , ItestDmnBoolSame
{
}

public class testDmnEnumDiff
  : DomainEnum
  , ItestDmnEnumDiff
{
}

public class testDmnEnumSame
  : DomainEnum
  , ItestDmnEnumSame
{
}

public class testDmnNmbr
  : DomainNumber
  , ItestDmnNmbr
{
}

public class testDmnNmbrDiff
  : DomainNumber
  , ItestDmnNmbrDiff
{
}

public class testDmnNmbrSame
  : DomainNumber
  , ItestDmnNmbrSame
{
}

public class testDmnStr
  : DomainString
  , ItestDmnStr
{
}

public class testDmnStrDiff
  : DomainString
  , ItestDmnStrDiff
{
}

public class testDmnStrSame
  : DomainString
  , ItestDmnStrSame
{
}

public class testObjDual
  : ItestObjDual
{
  public ItestObjDualObject AsObjDual { get; set; }
}

public class testObjInp
  : ItestObjInp
{
  public ItestObjInpObject AsObjInp { get; set; }
}

public class testObjOutp
  : ItestObjOutp
{
  public ItestObjOutpObject AsObjOutp { get; set; }
}

public class testObjAliasDual
  : ItestObjAliasDual
{
  public ItestObjAliasDualObject AsObjAliasDual { get; set; }
}

public class testObjAliasInp
  : ItestObjAliasInp
{
  public ItestObjAliasInpObject AsObjAliasInp { get; set; }
}

public class testObjAliasOutp
  : ItestObjAliasOutp
{
  public ItestObjAliasOutpObject AsObjAliasOutp { get; set; }
}

public class testObjAltDual
  : ItestObjAltDual
{
  public ItestObjAltDualType AsObjAltDualType { get; set; }
  public ItestObjAltDualObject AsObjAltDual { get; set; }
}

public class testObjAltDualType
  : ItestObjAltDualType
{
  public ItestObjAltDualTypeObject AsObjAltDualType { get; set; }
}

public class testObjAltInp
  : ItestObjAltInp
{
  public ItestObjAltInpType AsObjAltInpType { get; set; }
  public ItestObjAltInpObject AsObjAltInp { get; set; }
}

public class testObjAltInpType
  : ItestObjAltInpType
{
  public ItestObjAltInpTypeObject AsObjAltInpType { get; set; }
}

public class testObjAltOutp
  : ItestObjAltOutp
{
  public ItestObjAltOutpType AsObjAltOutpType { get; set; }
  public ItestObjAltOutpObject AsObjAltOutp { get; set; }
}

public class testObjAltOutpType
  : ItestObjAltOutpType
{
  public ItestObjAltOutpTypeObject AsObjAltOutpType { get; set; }
}

public class testObjAltEnumDual
  : ItestObjAltEnumDual
{
  public bool AsBooleantrue { get; set; }
  public bool AsBooleanfalse { get; set; }
  public ItestObjAltEnumDualObject AsObjAltEnumDual { get; set; }
}

public class testObjAltEnumInp
  : ItestObjAltEnumInp
{
  public bool AsBooleantrue { get; set; }
  public bool AsBooleanfalse { get; set; }
  public ItestObjAltEnumInpObject AsObjAltEnumInp { get; set; }
}

public class testObjAltEnumOutp
  : ItestObjAltEnumOutp
{
  public bool AsBooleantrue { get; set; }
  public bool AsBooleanfalse { get; set; }
  public ItestObjAltEnumOutpObject AsObjAltEnumOutp { get; set; }
}

public class testObjCnstDual<TType>
  : ItestObjCnstDual<TType>
{
  public TType Field { get; set; }
  public TType Str { get; set; }
  public ItestObjCnstDualObject<TType> AsObjCnstDual { get; set; }
}

public class testObjCnstInp<TType>
  : ItestObjCnstInp<TType>
{
  public TType Field { get; set; }
  public TType Str { get; set; }
  public ItestObjCnstInpObject<TType> AsObjCnstInp { get; set; }
}

public class testObjCnstOutp<TType>
  : ItestObjCnstOutp<TType>
{
  public TType Field { get; set; }
  public TType Str { get; set; }
  public ItestObjCnstOutpObject<TType> AsObjCnstOutp { get; set; }
}

public class testObjFieldDual
  : ItestObjFieldDual
{
  public ItestFldObjFieldDual Field { get; set; }
  public ItestObjFieldDualObject AsObjFieldDual { get; set; }
}

public class testFldObjFieldDual
  : ItestFldObjFieldDual
{
  public ItestFldObjFieldDualObject AsFldObjFieldDual { get; set; }
}

public class testObjFieldInp
  : ItestObjFieldInp
{
  public ItestFldObjFieldInp Field { get; set; }
  public ItestObjFieldInpObject AsObjFieldInp { get; set; }
}

public class testFldObjFieldInp
  : ItestFldObjFieldInp
{
  public ItestFldObjFieldInpObject AsFldObjFieldInp { get; set; }
}

public class testObjFieldOutp
  : ItestObjFieldOutp
{
  public ItestFldObjFieldOutp Field { get; set; }
  public ItestObjFieldOutpObject AsObjFieldOutp { get; set; }
}

public class testFldObjFieldOutp
  : ItestFldObjFieldOutp
{
  public ItestFldObjFieldOutpObject AsFldObjFieldOutp { get; set; }
}

public class testObjFieldAliasDual
  : ItestObjFieldAliasDual
{
  public ItestFldObjFieldAliasDual Field { get; set; }
  public ItestObjFieldAliasDualObject AsObjFieldAliasDual { get; set; }
}

public class testFldObjFieldAliasDual
  : ItestFldObjFieldAliasDual
{
  public ItestFldObjFieldAliasDualObject AsFldObjFieldAliasDual { get; set; }
}

public class testObjFieldAliasInp
  : ItestObjFieldAliasInp
{
  public ItestFldObjFieldAliasInp Field { get; set; }
  public ItestObjFieldAliasInpObject AsObjFieldAliasInp { get; set; }
}

public class testFldObjFieldAliasInp
  : ItestFldObjFieldAliasInp
{
  public ItestFldObjFieldAliasInpObject AsFldObjFieldAliasInp { get; set; }
}

public class testObjFieldAliasOutp
  : ItestObjFieldAliasOutp
{
  public ItestFldObjFieldAliasOutp Field { get; set; }
  public ItestObjFieldAliasOutpObject AsObjFieldAliasOutp { get; set; }
}

public class testFldObjFieldAliasOutp
  : ItestFldObjFieldAliasOutp
{
  public ItestFldObjFieldAliasOutpObject AsFldObjFieldAliasOutp { get; set; }
}

public class testObjFieldEnumAliasDual
  : ItestObjFieldEnumAliasDual
{
  public bool Field { get; set; }
  public ItestObjFieldEnumAliasDualObject AsObjFieldEnumAliasDual { get; set; }
}

public class testObjFieldEnumAliasInp
  : ItestObjFieldEnumAliasInp
{
  public bool Field { get; set; }
  public ItestObjFieldEnumAliasInpObject AsObjFieldEnumAliasInp { get; set; }
}

public class testObjFieldEnumAliasOutp
  : ItestObjFieldEnumAliasOutp
{
  public bool Field { get; set; }
  public ItestObjFieldEnumAliasOutpObject AsObjFieldEnumAliasOutp { get; set; }
}

public class testObjFieldEnumValueDual
  : ItestObjFieldEnumValueDual
{
  public bool Field { get; set; }
  public ItestObjFieldEnumValueDualObject AsObjFieldEnumValueDual { get; set; }
}

public class testObjFieldEnumValueInp
  : ItestObjFieldEnumValueInp
{
  public bool Field { get; set; }
  public ItestObjFieldEnumValueInpObject AsObjFieldEnumValueInp { get; set; }
}

public class testObjFieldEnumValueOutp
  : ItestObjFieldEnumValueOutp
{
  public bool Field { get; set; }
  public ItestObjFieldEnumValueOutpObject AsObjFieldEnumValueOutp { get; set; }
}

public class testObjFieldTypeAliasDual
  : ItestObjFieldTypeAliasDual
{
  public string Field { get; set; }
  public ItestObjFieldTypeAliasDualObject AsObjFieldTypeAliasDual { get; set; }
}

public class testObjFieldTypeAliasInp
  : ItestObjFieldTypeAliasInp
{
  public string Field { get; set; }
  public ItestObjFieldTypeAliasInpObject AsObjFieldTypeAliasInp { get; set; }
}

public class testObjFieldTypeAliasOutp
  : ItestObjFieldTypeAliasOutp
{
  public string Field { get; set; }
  public ItestObjFieldTypeAliasOutpObject AsObjFieldTypeAliasOutp { get; set; }
}

public class testObjParamDual<TTest,TType>
  : ItestObjParamDual<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }
  public ItestObjParamDualObject<TTest,TType> AsObjParamDual { get; set; }
}

public class testObjParamInp<TTest,TType>
  : ItestObjParamInp<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }
  public ItestObjParamInpObject<TTest,TType> AsObjParamInp { get; set; }
}

public class testObjParamOutp<TTest,TType>
  : ItestObjParamOutp<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }
  public ItestObjParamOutpObject<TTest,TType> AsObjParamOutp { get; set; }
}

public class testObjParamDupDual<TTest>
  : ItestObjParamDupDual<TTest>
{
  public TTest Test { get; set; }
  public TTest Type { get; set; }
  public ItestObjParamDupDualObject<TTest> AsObjParamDupDual { get; set; }
}

public class testObjParamDupInp<TTest>
  : ItestObjParamDupInp<TTest>
{
  public TTest Test { get; set; }
  public TTest Type { get; set; }
  public ItestObjParamDupInpObject<TTest> AsObjParamDupInp { get; set; }
}

public class testObjParamDupOutp<TTest>
  : ItestObjParamDupOutp<TTest>
{
  public TTest Test { get; set; }
  public TTest Type { get; set; }
  public ItestObjParamDupOutpObject<TTest> AsObjParamDupOutp { get; set; }
}

public class testObjPrntDual
  : testRefObjPrntDual
  , ItestObjPrntDual
{
  public ItestObjPrntDualObject AsObjPrntDual { get; set; }
}

public class testRefObjPrntDual
  : ItestRefObjPrntDual
{
  public ItestRefObjPrntDualObject AsRefObjPrntDual { get; set; }
}

public class testObjPrntInp
  : testRefObjPrntInp
  , ItestObjPrntInp
{
  public ItestObjPrntInpObject AsObjPrntInp { get; set; }
}

public class testRefObjPrntInp
  : ItestRefObjPrntInp
{
  public ItestRefObjPrntInpObject AsRefObjPrntInp { get; set; }
}

public class testObjPrntOutp
  : testRefObjPrntOutp
  , ItestObjPrntOutp
{
  public ItestObjPrntOutpObject AsObjPrntOutp { get; set; }
}

public class testRefObjPrntOutp
  : ItestRefObjPrntOutp
{
  public ItestRefObjPrntOutpObject AsRefObjPrntOutp { get; set; }
}

public class testOutpFieldParam
  : ItestOutpFieldParam
{
  public ItestFldOutpFieldParam Field { get; set; }
  public ItestOutpFieldParamObject AsOutpFieldParam { get; set; }
}

public class testOutpFieldParam1
  : ItestOutpFieldParam1
{
  public ItestOutpFieldParam1Object AsOutpFieldParam1 { get; set; }
}

public class testOutpFieldParam2
  : ItestOutpFieldParam2
{
  public ItestOutpFieldParam2Object AsOutpFieldParam2 { get; set; }
}

public class testFldOutpFieldParam
  : ItestFldOutpFieldParam
{
  public ItestFldOutpFieldParamObject AsFldOutpFieldParam { get; set; }
}

public class testUnionAlias
  : ItestUnionAlias
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
}

public class testUnionDiff
  : ItestUnionDiff
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
}

public class testUnionSame
  : ItestUnionSame
{
  public Boolean AsBoolean { get; set; }
}

public class testUnionSamePrnt
  : testPrntUnionSamePrnt
  , ItestUnionSamePrnt
{
  public Boolean AsBoolean { get; set; }
}

public class testPrntUnionSamePrnt
  : ItestPrntUnionSamePrnt
{
  public String AsString { get; set; }
}
