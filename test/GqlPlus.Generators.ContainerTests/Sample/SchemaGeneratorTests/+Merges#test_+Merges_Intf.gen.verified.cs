//HintName: test_+Merges_Intf.gen.cs
// Generated from {CurrentDirectory}+Merges.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Merges;

public interface ItestCtgr
  : IGqlpModelImplementationBase
{
  ItestCtgrObject AsCtgr { get; }
}

public interface ItestCtgrObject
{
}

public interface ItestCtgrAlias
  : IGqlpModelImplementationBase
{
  ItestCtgrAliasObject AsCtgrAlias { get; }
}

public interface ItestCtgrAliasObject
{
}

public interface ItestCtgrDescr
  : IGqlpModelImplementationBase
{
  ItestCtgrDescrObject AsCtgrDescr { get; }
}

public interface ItestCtgrDescrObject
{
}

public interface ItestCtgrMod
  : IGqlpModelImplementationBase
{
  ItestCtgrModObject AsCtgrMod { get; }
}

public interface ItestCtgrModObject
{
}

public interface ItestInDrctParam
  : IGqlpModelImplementationBase
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
  : IGqlpModelImplementationBase
{
  ItestObjDualObject AsObjDual { get; }
}

public interface ItestObjDualObject
{
}

public interface ItestObjInp
  : IGqlpModelImplementationBase
{
  ItestObjInpObject AsObjInp { get; }
}

public interface ItestObjInpObject
{
}

public interface ItestObjOutp
  : IGqlpModelImplementationBase
{
  ItestObjOutpObject AsObjOutp { get; }
}

public interface ItestObjOutpObject
{
}

public interface ItestObjAliasDual
  : IGqlpModelImplementationBase
{
  ItestObjAliasDualObject AsObjAliasDual { get; }
}

public interface ItestObjAliasDualObject
{
}

public interface ItestObjAliasInp
  : IGqlpModelImplementationBase
{
  ItestObjAliasInpObject AsObjAliasInp { get; }
}

public interface ItestObjAliasInpObject
{
}

public interface ItestObjAliasOutp
  : IGqlpModelImplementationBase
{
  ItestObjAliasOutpObject AsObjAliasOutp { get; }
}

public interface ItestObjAliasOutpObject
{
}

public interface ItestObjAltDual
  : IGqlpModelImplementationBase
{
  ItestObjAltDualType AsObjAltDualType { get; }
  ItestObjAltDualObject AsObjAltDual { get; }
}

public interface ItestObjAltDualObject
{
}

public interface ItestObjAltDualType
  : IGqlpModelImplementationBase
{
  ItestObjAltDualTypeObject AsObjAltDualType { get; }
}

public interface ItestObjAltDualTypeObject
{
}

public interface ItestObjAltInp
  : IGqlpModelImplementationBase
{
  ItestObjAltInpType AsObjAltInpType { get; }
  ItestObjAltInpObject AsObjAltInp { get; }
}

public interface ItestObjAltInpObject
{
}

public interface ItestObjAltInpType
  : IGqlpModelImplementationBase
{
  ItestObjAltInpTypeObject AsObjAltInpType { get; }
}

public interface ItestObjAltInpTypeObject
{
}

public interface ItestObjAltOutp
  : IGqlpModelImplementationBase
{
  ItestObjAltOutpType AsObjAltOutpType { get; }
  ItestObjAltOutpObject AsObjAltOutp { get; }
}

public interface ItestObjAltOutpObject
{
}

public interface ItestObjAltOutpType
  : IGqlpModelImplementationBase
{
  ItestObjAltOutpTypeObject AsObjAltOutpType { get; }
}

public interface ItestObjAltOutpTypeObject
{
}

public interface ItestObjAltEnumDual
  : IGqlpModelImplementationBase
{
  bool AsBooleantrue { get; }
  bool AsBooleanfalse { get; }
  ItestObjAltEnumDualObject AsObjAltEnumDual { get; }
}

public interface ItestObjAltEnumDualObject
{
}

public interface ItestObjAltEnumInp
  : IGqlpModelImplementationBase
{
  bool AsBooleantrue { get; }
  bool AsBooleanfalse { get; }
  ItestObjAltEnumInpObject AsObjAltEnumInp { get; }
}

public interface ItestObjAltEnumInpObject
{
}

public interface ItestObjAltEnumOutp
  : IGqlpModelImplementationBase
{
  bool AsBooleantrue { get; }
  bool AsBooleanfalse { get; }
  ItestObjAltEnumOutpObject AsObjAltEnumOutp { get; }
}

public interface ItestObjAltEnumOutpObject
{
}

public interface ItestObjCnstDual<TType>
  : IGqlpModelImplementationBase
{
  ItestObjCnstDualObject<TType> AsObjCnstDual { get; }
}

public interface ItestObjCnstDualObject<TType>
{
  TType Field { get; }
  TType Str { get; }
}

public interface ItestObjCnstInp<TType>
  : IGqlpModelImplementationBase
{
  ItestObjCnstInpObject<TType> AsObjCnstInp { get; }
}

public interface ItestObjCnstInpObject<TType>
{
  TType Field { get; }
  TType Str { get; }
}

public interface ItestObjCnstOutp<TType>
  : IGqlpModelImplementationBase
{
  ItestObjCnstOutpObject<TType> AsObjCnstOutp { get; }
}

public interface ItestObjCnstOutpObject<TType>
{
  TType Field { get; }
  TType Str { get; }
}

public interface ItestObjFieldDual
  : IGqlpModelImplementationBase
{
  ItestObjFieldDualObject AsObjFieldDual { get; }
}

public interface ItestObjFieldDualObject
{
  ItestFldObjFieldDual Field { get; }
}

public interface ItestFldObjFieldDual
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldDualObject AsFldObjFieldDual { get; }
}

public interface ItestFldObjFieldDualObject
{
}

public interface ItestObjFieldInp
  : IGqlpModelImplementationBase
{
  ItestObjFieldInpObject AsObjFieldInp { get; }
}

public interface ItestObjFieldInpObject
{
  ItestFldObjFieldInp Field { get; }
}

public interface ItestFldObjFieldInp
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldInpObject AsFldObjFieldInp { get; }
}

public interface ItestFldObjFieldInpObject
{
}

public interface ItestObjFieldOutp
  : IGqlpModelImplementationBase
{
  ItestObjFieldOutpObject AsObjFieldOutp { get; }
}

public interface ItestObjFieldOutpObject
{
  ItestFldObjFieldOutp Field { get; }
}

public interface ItestFldObjFieldOutp
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldOutpObject AsFldObjFieldOutp { get; }
}

public interface ItestFldObjFieldOutpObject
{
}

public interface ItestObjFieldAliasDual
  : IGqlpModelImplementationBase
{
  ItestObjFieldAliasDualObject AsObjFieldAliasDual { get; }
}

public interface ItestObjFieldAliasDualObject
{
  ItestFldObjFieldAliasDual Field { get; }
}

public interface ItestFldObjFieldAliasDual
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldAliasDualObject AsFldObjFieldAliasDual { get; }
}

public interface ItestFldObjFieldAliasDualObject
{
}

public interface ItestObjFieldAliasInp
  : IGqlpModelImplementationBase
{
  ItestObjFieldAliasInpObject AsObjFieldAliasInp { get; }
}

public interface ItestObjFieldAliasInpObject
{
  ItestFldObjFieldAliasInp Field { get; }
}

public interface ItestFldObjFieldAliasInp
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldAliasInpObject AsFldObjFieldAliasInp { get; }
}

public interface ItestFldObjFieldAliasInpObject
{
}

public interface ItestObjFieldAliasOutp
  : IGqlpModelImplementationBase
{
  ItestObjFieldAliasOutpObject AsObjFieldAliasOutp { get; }
}

public interface ItestObjFieldAliasOutpObject
{
  ItestFldObjFieldAliasOutp Field { get; }
}

public interface ItestFldObjFieldAliasOutp
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldAliasOutpObject AsFldObjFieldAliasOutp { get; }
}

public interface ItestFldObjFieldAliasOutpObject
{
}

public interface ItestObjFieldEnumAliasDual
  : IGqlpModelImplementationBase
{
  ItestObjFieldEnumAliasDualObject AsObjFieldEnumAliasDual { get; }
}

public interface ItestObjFieldEnumAliasDualObject
{
  bool Field { get; }
}

public interface ItestObjFieldEnumAliasInp
  : IGqlpModelImplementationBase
{
  ItestObjFieldEnumAliasInpObject AsObjFieldEnumAliasInp { get; }
}

public interface ItestObjFieldEnumAliasInpObject
{
  bool Field { get; }
}

public interface ItestObjFieldEnumAliasOutp
  : IGqlpModelImplementationBase
{
  ItestObjFieldEnumAliasOutpObject AsObjFieldEnumAliasOutp { get; }
}

public interface ItestObjFieldEnumAliasOutpObject
{
  bool Field { get; }
}

public interface ItestObjFieldEnumValueDual
  : IGqlpModelImplementationBase
{
  ItestObjFieldEnumValueDualObject AsObjFieldEnumValueDual { get; }
}

public interface ItestObjFieldEnumValueDualObject
{
  bool Field { get; }
}

public interface ItestObjFieldEnumValueInp
  : IGqlpModelImplementationBase
{
  ItestObjFieldEnumValueInpObject AsObjFieldEnumValueInp { get; }
}

public interface ItestObjFieldEnumValueInpObject
{
  bool Field { get; }
}

public interface ItestObjFieldEnumValueOutp
  : IGqlpModelImplementationBase
{
  ItestObjFieldEnumValueOutpObject AsObjFieldEnumValueOutp { get; }
}

public interface ItestObjFieldEnumValueOutpObject
{
  bool Field { get; }
}

public interface ItestObjFieldTypeAliasDual
  : IGqlpModelImplementationBase
{
  ItestObjFieldTypeAliasDualObject AsObjFieldTypeAliasDual { get; }
}

public interface ItestObjFieldTypeAliasDualObject
{
  string Field { get; }
}

public interface ItestObjFieldTypeAliasInp
  : IGqlpModelImplementationBase
{
  ItestObjFieldTypeAliasInpObject AsObjFieldTypeAliasInp { get; }
}

public interface ItestObjFieldTypeAliasInpObject
{
  string Field { get; }
}

public interface ItestObjFieldTypeAliasOutp
  : IGqlpModelImplementationBase
{
  ItestObjFieldTypeAliasOutpObject AsObjFieldTypeAliasOutp { get; }
}

public interface ItestObjFieldTypeAliasOutpObject
{
  string Field { get; }
}

public interface ItestObjParamDual<TTest,TType>
  : IGqlpModelImplementationBase
{
  ItestObjParamDualObject<TTest,TType> AsObjParamDual { get; }
}

public interface ItestObjParamDualObject<TTest,TType>
{
  TTest Test { get; }
  TType Type { get; }
}

public interface ItestObjParamInp<TTest,TType>
  : IGqlpModelImplementationBase
{
  ItestObjParamInpObject<TTest,TType> AsObjParamInp { get; }
}

public interface ItestObjParamInpObject<TTest,TType>
{
  TTest Test { get; }
  TType Type { get; }
}

public interface ItestObjParamOutp<TTest,TType>
  : IGqlpModelImplementationBase
{
  ItestObjParamOutpObject<TTest,TType> AsObjParamOutp { get; }
}

public interface ItestObjParamOutpObject<TTest,TType>
{
  TTest Test { get; }
  TType Type { get; }
}

public interface ItestObjParamDupDual<TTest>
  : IGqlpModelImplementationBase
{
  ItestObjParamDupDualObject<TTest> AsObjParamDupDual { get; }
}

public interface ItestObjParamDupDualObject<TTest>
{
  TTest Test { get; }
  TTest Type { get; }
}

public interface ItestObjParamDupInp<TTest>
  : IGqlpModelImplementationBase
{
  ItestObjParamDupInpObject<TTest> AsObjParamDupInp { get; }
}

public interface ItestObjParamDupInpObject<TTest>
{
  TTest Test { get; }
  TTest Type { get; }
}

public interface ItestObjParamDupOutp<TTest>
  : IGqlpModelImplementationBase
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
  : IGqlpModelImplementationBase
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
  : IGqlpModelImplementationBase
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
  : IGqlpModelImplementationBase
{
  ItestRefObjPrntOutpObject AsRefObjPrntOutp { get; }
}

public interface ItestRefObjPrntOutpObject
{
}

public interface ItestOutpFieldParam
  : IGqlpModelImplementationBase
{
  ItestOutpFieldParamObject AsOutpFieldParam { get; }
}

public interface ItestOutpFieldParamObject
{
  ItestFldOutpFieldParam Field (ItestOutpFieldParam1 parameter);
}

public interface ItestOutpFieldParam1
  : IGqlpModelImplementationBase
{
  ItestOutpFieldParam1Object AsOutpFieldParam1 { get; }
}

public interface ItestOutpFieldParam1Object
{
}

public interface ItestOutpFieldParam2
  : IGqlpModelImplementationBase
{
  ItestOutpFieldParam2Object AsOutpFieldParam2 { get; }
}

public interface ItestOutpFieldParam2Object
{
}

public interface ItestFldOutpFieldParam
  : IGqlpModelImplementationBase
{
  ItestFldOutpFieldParamObject AsFldOutpFieldParam { get; }
}

public interface ItestFldOutpFieldParamObject
{
}

public interface ItestUnionAlias
  : IGqlpModelImplementationBase
{
  Boolean AsBoolean { get; }
  Number AsNumber { get; }
}

public interface ItestUnionDiff
  : IGqlpModelImplementationBase
{
  Boolean AsBoolean { get; }
  Number AsNumber { get; }
}

public interface ItestUnionSame
  : IGqlpModelImplementationBase
{
  Boolean AsBoolean { get; }
}

public interface ItestUnionSamePrnt
  : ItestPrntUnionSamePrnt
{
  Boolean AsBoolean { get; }
}

public interface ItestPrntUnionSamePrnt
  : IGqlpModelImplementationBase
{
  String AsString { get; }
}
