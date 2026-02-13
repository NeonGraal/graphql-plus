//HintName: test_+Merges_Intf.gen.cs
// Generated from +Merges.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Merges;

public interface ItestCtgr
{
  ItestCtgrObject AsCtgr { get; }
}

public interface ItestCtgrObject
{
}

public interface ItestCtgrAlias
{
  ItestCtgrAliasObject AsCtgrAlias { get; }
}

public interface ItestCtgrAliasObject
{
}

public interface ItestCtgrDescr
{
  ItestCtgrDescrObject AsCtgrDescr { get; }
}

public interface ItestCtgrDescrObject
{
}

public interface ItestCtgrMod
{
  ItestCtgrModObject AsCtgrMod { get; }
}

public interface ItestCtgrModObject
{
}

public interface ItestInDrctParam
{
  ItestInDrctParamObject AsInDrctParam { get; }
}

public interface ItestInDrctParamObject
{
}

public interface ItestDmnAlias
  : IGqlpDomainNumber
{
}

public interface ItestDmnBool
  : IGqlpDomainBoolean
{
}

public interface ItestDmnBoolDiff
  : IGqlpDomainBoolean
{
}

public interface ItestDmnBoolSame
  : IGqlpDomainBoolean
{
}

public interface ItestDmnEnumDiff
  : IGqlpDomainEnum
{
}

public interface ItestDmnEnumSame
  : IGqlpDomainEnum
{
}

public interface ItestDmnNmbr
  : IGqlpDomainNumber
{
}

public interface ItestDmnNmbrDiff
  : IGqlpDomainNumber
{
}

public interface ItestDmnNmbrSame
  : IGqlpDomainNumber
{
}

public interface ItestDmnStr
  : IGqlpDomainString
{
}

public interface ItestDmnStrDiff
  : IGqlpDomainString
{
}

public interface ItestDmnStrSame
  : IGqlpDomainString
{
}

public interface ItestObjDual
{
  ItestObjDualObject AsObjDual { get; }
}

public interface ItestObjDualObject
{
}

public interface ItestObjInp
{
  ItestObjInpObject AsObjInp { get; }
}

public interface ItestObjInpObject
{
}

public interface ItestObjOutp
{
  ItestObjOutpObject AsObjOutp { get; }
}

public interface ItestObjOutpObject
{
}

public interface ItestObjAliasDual
{
  ItestObjAliasDualObject AsObjAliasDual { get; }
}

public interface ItestObjAliasDualObject
{
}

public interface ItestObjAliasInp
{
  ItestObjAliasInpObject AsObjAliasInp { get; }
}

public interface ItestObjAliasInpObject
{
}

public interface ItestObjAliasOutp
{
  ItestObjAliasOutpObject AsObjAliasOutp { get; }
}

public interface ItestObjAliasOutpObject
{
}

public interface ItestObjAltDual
{
  ItestObjAltDualType AsObjAltDualType { get; }
  ItestObjAltDualObject AsObjAltDual { get; }
}

public interface ItestObjAltDualObject
{
}

public interface ItestObjAltDualType
{
  ItestObjAltDualTypeObject AsObjAltDualType { get; }
}

public interface ItestObjAltDualTypeObject
{
}

public interface ItestObjAltInp
{
  ItestObjAltInpType AsObjAltInpType { get; }
  ItestObjAltInpObject AsObjAltInp { get; }
}

public interface ItestObjAltInpObject
{
}

public interface ItestObjAltInpType
{
  ItestObjAltInpTypeObject AsObjAltInpType { get; }
}

public interface ItestObjAltInpTypeObject
{
}

public interface ItestObjAltOutp
{
  ItestObjAltOutpType AsObjAltOutpType { get; }
  ItestObjAltOutpObject AsObjAltOutp { get; }
}

public interface ItestObjAltOutpObject
{
}

public interface ItestObjAltOutpType
{
  ItestObjAltOutpTypeObject AsObjAltOutpType { get; }
}

public interface ItestObjAltOutpTypeObject
{
}

public interface ItestObjAltEnumDual
{
  bool AsBooleantrue { get; }
  bool AsBooleanfalse { get; }
  ItestObjAltEnumDualObject AsObjAltEnumDual { get; }
}

public interface ItestObjAltEnumDualObject
{
}

public interface ItestObjAltEnumInp
{
  bool AsBooleantrue { get; }
  bool AsBooleanfalse { get; }
  ItestObjAltEnumInpObject AsObjAltEnumInp { get; }
}

public interface ItestObjAltEnumInpObject
{
}

public interface ItestObjAltEnumOutp
{
  bool AsBooleantrue { get; }
  bool AsBooleanfalse { get; }
  ItestObjAltEnumOutpObject AsObjAltEnumOutp { get; }
}

public interface ItestObjAltEnumOutpObject
{
}

public interface ItestObjCnstDual<TType>
{
  ItestObjCnstDualObject<TType> AsObjCnstDual { get; }
}

public interface ItestObjCnstDualObject<TType>
{
  TType Field { get; }
  TType Str { get; }
}

public interface ItestObjCnstInp<TType>
{
  ItestObjCnstInpObject<TType> AsObjCnstInp { get; }
}

public interface ItestObjCnstInpObject<TType>
{
  TType Field { get; }
  TType Str { get; }
}

public interface ItestObjCnstOutp<TType>
{
  ItestObjCnstOutpObject<TType> AsObjCnstOutp { get; }
}

public interface ItestObjCnstOutpObject<TType>
{
  TType Field { get; }
  TType Str { get; }
}

public interface ItestObjFieldDual
{
  ItestObjFieldDualObject AsObjFieldDual { get; }
}

public interface ItestObjFieldDualObject
{
  ItestFldObjFieldDual Field { get; }
}

public interface ItestFldObjFieldDual
{
  ItestFldObjFieldDualObject AsFldObjFieldDual { get; }
}

public interface ItestFldObjFieldDualObject
{
}

public interface ItestObjFieldInp
{
  ItestObjFieldInpObject AsObjFieldInp { get; }
}

public interface ItestObjFieldInpObject
{
  ItestFldObjFieldInp Field { get; }
}

public interface ItestFldObjFieldInp
{
  ItestFldObjFieldInpObject AsFldObjFieldInp { get; }
}

public interface ItestFldObjFieldInpObject
{
}

public interface ItestObjFieldOutp
{
  ItestObjFieldOutpObject AsObjFieldOutp { get; }
}

public interface ItestObjFieldOutpObject
{
  ItestFldObjFieldOutp Field { get; }
}

public interface ItestFldObjFieldOutp
{
  ItestFldObjFieldOutpObject AsFldObjFieldOutp { get; }
}

public interface ItestFldObjFieldOutpObject
{
}

public interface ItestObjFieldAliasDual
{
  ItestObjFieldAliasDualObject AsObjFieldAliasDual { get; }
}

public interface ItestObjFieldAliasDualObject
{
  ItestFldObjFieldAliasDual Field { get; }
}

public interface ItestFldObjFieldAliasDual
{
  ItestFldObjFieldAliasDualObject AsFldObjFieldAliasDual { get; }
}

public interface ItestFldObjFieldAliasDualObject
{
}

public interface ItestObjFieldAliasInp
{
  ItestObjFieldAliasInpObject AsObjFieldAliasInp { get; }
}

public interface ItestObjFieldAliasInpObject
{
  ItestFldObjFieldAliasInp Field { get; }
}

public interface ItestFldObjFieldAliasInp
{
  ItestFldObjFieldAliasInpObject AsFldObjFieldAliasInp { get; }
}

public interface ItestFldObjFieldAliasInpObject
{
}

public interface ItestObjFieldAliasOutp
{
  ItestObjFieldAliasOutpObject AsObjFieldAliasOutp { get; }
}

public interface ItestObjFieldAliasOutpObject
{
  ItestFldObjFieldAliasOutp Field { get; }
}

public interface ItestFldObjFieldAliasOutp
{
  ItestFldObjFieldAliasOutpObject AsFldObjFieldAliasOutp { get; }
}

public interface ItestFldObjFieldAliasOutpObject
{
}

public interface ItestObjFieldEnumAliasDual
{
  ItestObjFieldEnumAliasDualObject AsObjFieldEnumAliasDual { get; }
}

public interface ItestObjFieldEnumAliasDualObject
{
  bool Field { get; }
}

public interface ItestObjFieldEnumAliasInp
{
  ItestObjFieldEnumAliasInpObject AsObjFieldEnumAliasInp { get; }
}

public interface ItestObjFieldEnumAliasInpObject
{
  bool Field { get; }
}

public interface ItestObjFieldEnumAliasOutp
{
  ItestObjFieldEnumAliasOutpObject AsObjFieldEnumAliasOutp { get; }
}

public interface ItestObjFieldEnumAliasOutpObject
{
  bool Field { get; }
}

public interface ItestObjFieldEnumValueDual
{
  ItestObjFieldEnumValueDualObject AsObjFieldEnumValueDual { get; }
}

public interface ItestObjFieldEnumValueDualObject
{
  bool Field { get; }
}

public interface ItestObjFieldEnumValueInp
{
  ItestObjFieldEnumValueInpObject AsObjFieldEnumValueInp { get; }
}

public interface ItestObjFieldEnumValueInpObject
{
  bool Field { get; }
}

public interface ItestObjFieldEnumValueOutp
{
  ItestObjFieldEnumValueOutpObject AsObjFieldEnumValueOutp { get; }
}

public interface ItestObjFieldEnumValueOutpObject
{
  bool Field { get; }
}

public interface ItestObjFieldTypeAliasDual
{
  ItestObjFieldTypeAliasDualObject AsObjFieldTypeAliasDual { get; }
}

public interface ItestObjFieldTypeAliasDualObject
{
  string Field { get; }
}

public interface ItestObjFieldTypeAliasInp
{
  ItestObjFieldTypeAliasInpObject AsObjFieldTypeAliasInp { get; }
}

public interface ItestObjFieldTypeAliasInpObject
{
  string Field { get; }
}

public interface ItestObjFieldTypeAliasOutp
{
  ItestObjFieldTypeAliasOutpObject AsObjFieldTypeAliasOutp { get; }
}

public interface ItestObjFieldTypeAliasOutpObject
{
  string Field { get; }
}

public interface ItestObjParamDual<TTest,TType>
{
  ItestObjParamDualObject<TTest,TType> AsObjParamDual { get; }
}

public interface ItestObjParamDualObject<TTest,TType>
{
  TTest Test { get; }
  TType Type { get; }
}

public interface ItestObjParamInp<TTest,TType>
{
  ItestObjParamInpObject<TTest,TType> AsObjParamInp { get; }
}

public interface ItestObjParamInpObject<TTest,TType>
{
  TTest Test { get; }
  TType Type { get; }
}

public interface ItestObjParamOutp<TTest,TType>
{
  ItestObjParamOutpObject<TTest,TType> AsObjParamOutp { get; }
}

public interface ItestObjParamOutpObject<TTest,TType>
{
  TTest Test { get; }
  TType Type { get; }
}

public interface ItestObjParamDupDual<TTest>
{
  ItestObjParamDupDualObject<TTest> AsObjParamDupDual { get; }
}

public interface ItestObjParamDupDualObject<TTest>
{
  TTest Test { get; }
  TTest Type { get; }
}

public interface ItestObjParamDupInp<TTest>
{
  ItestObjParamDupInpObject<TTest> AsObjParamDupInp { get; }
}

public interface ItestObjParamDupInpObject<TTest>
{
  TTest Test { get; }
  TTest Type { get; }
}

public interface ItestObjParamDupOutp<TTest>
{
  ItestObjParamDupOutpObject<TTest> AsObjParamDupOutp { get; }
}

public interface ItestObjParamDupOutpObject<TTest>
{
  TTest Test { get; }
  TTest Type { get; }
}

public interface ItestObjPrntDual
  : ItestRefObjPrntDual
{
  ItestObjPrntDualObject AsObjPrntDual { get; }
}

public interface ItestObjPrntDualObject
  : ItestRefObjPrntDualObject
{
}

public interface ItestRefObjPrntDual
{
  ItestRefObjPrntDualObject AsRefObjPrntDual { get; }
}

public interface ItestRefObjPrntDualObject
{
}

public interface ItestObjPrntInp
  : ItestRefObjPrntInp
{
  ItestObjPrntInpObject AsObjPrntInp { get; }
}

public interface ItestObjPrntInpObject
  : ItestRefObjPrntInpObject
{
}

public interface ItestRefObjPrntInp
{
  ItestRefObjPrntInpObject AsRefObjPrntInp { get; }
}

public interface ItestRefObjPrntInpObject
{
}

public interface ItestObjPrntOutp
  : ItestRefObjPrntOutp
{
  ItestObjPrntOutpObject AsObjPrntOutp { get; }
}

public interface ItestObjPrntOutpObject
  : ItestRefObjPrntOutpObject
{
}

public interface ItestRefObjPrntOutp
{
  ItestRefObjPrntOutpObject AsRefObjPrntOutp { get; }
}

public interface ItestRefObjPrntOutpObject
{
}

public interface ItestOutpFieldParam
{
  ItestOutpFieldParamObject AsOutpFieldParam { get; }
}

public interface ItestOutpFieldParamObject
{
  ItestFldOutpFieldParam Field { get; }
}

public interface ItestOutpFieldParam1
{
  ItestOutpFieldParam1Object AsOutpFieldParam1 { get; }
}

public interface ItestOutpFieldParam1Object
{
}

public interface ItestOutpFieldParam2
{
  ItestOutpFieldParam2Object AsOutpFieldParam2 { get; }
}

public interface ItestOutpFieldParam2Object
{
}

public interface ItestFldOutpFieldParam
{
  ItestFldOutpFieldParamObject AsFldOutpFieldParam { get; }
}

public interface ItestFldOutpFieldParamObject
{
}

public interface ItestUnionAlias
{
  Boolean AsBoolean { get; }
  Number AsNumber { get; }
}

public interface ItestUnionDiff
{
  Boolean AsBoolean { get; }
  Number AsNumber { get; }
}

public interface ItestUnionSame
{
  Boolean AsBoolean { get; }
}

public interface ItestUnionSamePrnt
  : ItestPrntUnionSamePrnt
{
  Boolean AsBoolean { get; }
}

public interface ItestPrntUnionSamePrnt
{
  String AsString { get; }
}
