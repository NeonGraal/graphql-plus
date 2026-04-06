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
  ItestCtgrObject? As_Ctgr { get; }
}

public interface ItestCtgrObject
  : IGqlpModelImplementationBase
{
}

public interface ItestCtgrAlias
  : IGqlpModelImplementationBase
{
  ItestCtgrAliasObject? As_CtgrAlias { get; }
}

public interface ItestCtgrAliasObject
  : IGqlpModelImplementationBase
{
}

public interface ItestCtgrDescr
  : IGqlpModelImplementationBase
{
  ItestCtgrDescrObject? As_CtgrDescr { get; }
}

public interface ItestCtgrDescrObject
  : IGqlpModelImplementationBase
{
}

public interface ItestCtgrMod
  : IGqlpModelImplementationBase
{
  ItestCtgrModObject? As_CtgrMod { get; }
}

public interface ItestCtgrModObject
  : IGqlpModelImplementationBase
{
}

public interface ItestInDrctParam
  : IGqlpModelImplementationBase
{
  ItestInDrctParamObject? As_InDrctParam { get; }
}

public interface ItestInDrctParamObject
  : IGqlpModelImplementationBase
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

public enum testEnumAlias
{
  enumAlias,
}

public enum testEnumDiff
{
  one,
  two,
}

public enum testEnumSame
{
  enumSame,
}

public enum testEnumSamePrnt
{
  prnt_enumSamePrnt = testPrntEnumSamePrnt.prnt_enumSamePrnt,
  enumSamePrnt,
}

public enum testPrntEnumSamePrnt
{
  prnt_enumSamePrnt,
}

public enum testEnumValueAlias
{
  enumValueAlias,
  val1 = enumValueAlias,
  val2 = enumValueAlias,
}

public interface ItestObjDual
  : IGqlpModelImplementationBase
{
  ItestObjDualObject? As_ObjDual { get; }
}

public interface ItestObjDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjInp
  : IGqlpModelImplementationBase
{
  ItestObjInpObject? As_ObjInp { get; }
}

public interface ItestObjInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjOutp
  : IGqlpModelImplementationBase
{
  ItestObjOutpObject? As_ObjOutp { get; }
}

public interface ItestObjOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjAliasDual
  : IGqlpModelImplementationBase
{
  ItestObjAliasDualObject? As_ObjAliasDual { get; }
}

public interface ItestObjAliasDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjAliasInp
  : IGqlpModelImplementationBase
{
  ItestObjAliasInpObject? As_ObjAliasInp { get; }
}

public interface ItestObjAliasInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjAliasOutp
  : IGqlpModelImplementationBase
{
  ItestObjAliasOutpObject? As_ObjAliasOutp { get; }
}

public interface ItestObjAliasOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjAltDual
  : IGqlpModelImplementationBase
{
  ItestObjAltDualType? AsObjAltDualType { get; }
  ItestObjAltDualObject? As_ObjAltDual { get; }
}

public interface ItestObjAltDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjAltDualType
  : IGqlpModelImplementationBase
{
  ItestObjAltDualTypeObject? As_ObjAltDualType { get; }
}

public interface ItestObjAltDualTypeObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjAltInp
  : IGqlpModelImplementationBase
{
  ItestObjAltInpType? AsObjAltInpType { get; }
  ItestObjAltInpObject? As_ObjAltInp { get; }
}

public interface ItestObjAltInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjAltInpType
  : IGqlpModelImplementationBase
{
  ItestObjAltInpTypeObject? As_ObjAltInpType { get; }
}

public interface ItestObjAltInpTypeObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjAltOutp
  : IGqlpModelImplementationBase
{
  ItestObjAltOutpType? AsObjAltOutpType { get; }
  ItestObjAltOutpObject? As_ObjAltOutp { get; }
}

public interface ItestObjAltOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjAltOutpType
  : IGqlpModelImplementationBase
{
  ItestObjAltOutpTypeObject? As_ObjAltOutpType { get; }
}

public interface ItestObjAltOutpTypeObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjAltEnumDual
  : IGqlpModelImplementationBase
{
  bool? AsBooleantrue { get; }
  bool? AsBooleanfalse { get; }
  ItestObjAltEnumDualObject? As_ObjAltEnumDual { get; }
}

public interface ItestObjAltEnumDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjAltEnumInp
  : IGqlpModelImplementationBase
{
  bool? AsBooleantrue { get; }
  bool? AsBooleanfalse { get; }
  ItestObjAltEnumInpObject? As_ObjAltEnumInp { get; }
}

public interface ItestObjAltEnumInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjAltEnumOutp
  : IGqlpModelImplementationBase
{
  bool? AsBooleantrue { get; }
  bool? AsBooleanfalse { get; }
  ItestObjAltEnumOutpObject? As_ObjAltEnumOutp { get; }
}

public interface ItestObjAltEnumOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjCnstDual<TType>
  : IGqlpModelImplementationBase
{
  ItestObjCnstDualObject<TType>? As_ObjCnstDual { get; }
}

public interface ItestObjCnstDualObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
  TType Str { get; }
}

public interface ItestObjCnstInp<TType>
  : IGqlpModelImplementationBase
{
  ItestObjCnstInpObject<TType>? As_ObjCnstInp { get; }
}

public interface ItestObjCnstInpObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
  TType Str { get; }
}

public interface ItestObjCnstOutp<TType>
  : IGqlpModelImplementationBase
{
  ItestObjCnstOutpObject<TType>? As_ObjCnstOutp { get; }
}

public interface ItestObjCnstOutpObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
  TType Str { get; }
}

public interface ItestObjFieldDual
  : IGqlpModelImplementationBase
{
  ItestObjFieldDualObject? As_ObjFieldDual { get; }
}

public interface ItestObjFieldDualObject
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldDual Field { get; }
}

public interface ItestFldObjFieldDual
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldDualObject? As_FldObjFieldDual { get; }
}

public interface ItestFldObjFieldDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjFieldInp
  : IGqlpModelImplementationBase
{
  ItestObjFieldInpObject? As_ObjFieldInp { get; }
}

public interface ItestObjFieldInpObject
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldInp Field { get; }
}

public interface ItestFldObjFieldInp
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldInpObject? As_FldObjFieldInp { get; }
}

public interface ItestFldObjFieldInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjFieldOutp
  : IGqlpModelImplementationBase
{
  ItestObjFieldOutpObject? As_ObjFieldOutp { get; }
}

public interface ItestObjFieldOutpObject
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldOutp Field { get; }
}

public interface ItestFldObjFieldOutp
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldOutpObject? As_FldObjFieldOutp { get; }
}

public interface ItestFldObjFieldOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjFieldAliasDual
  : IGqlpModelImplementationBase
{
  ItestObjFieldAliasDualObject? As_ObjFieldAliasDual { get; }
}

public interface ItestObjFieldAliasDualObject
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldAliasDual Field { get; }
}

public interface ItestFldObjFieldAliasDual
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldAliasDualObject? As_FldObjFieldAliasDual { get; }
}

public interface ItestFldObjFieldAliasDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjFieldAliasInp
  : IGqlpModelImplementationBase
{
  ItestObjFieldAliasInpObject? As_ObjFieldAliasInp { get; }
}

public interface ItestObjFieldAliasInpObject
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldAliasInp Field { get; }
}

public interface ItestFldObjFieldAliasInp
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldAliasInpObject? As_FldObjFieldAliasInp { get; }
}

public interface ItestFldObjFieldAliasInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjFieldAliasOutp
  : IGqlpModelImplementationBase
{
  ItestObjFieldAliasOutpObject? As_ObjFieldAliasOutp { get; }
}

public interface ItestObjFieldAliasOutpObject
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldAliasOutp Field { get; }
}

public interface ItestFldObjFieldAliasOutp
  : IGqlpModelImplementationBase
{
  ItestFldObjFieldAliasOutpObject? As_FldObjFieldAliasOutp { get; }
}

public interface ItestFldObjFieldAliasOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjFieldEnumAliasDual
  : IGqlpModelImplementationBase
{
  ItestObjFieldEnumAliasDualObject? As_ObjFieldEnumAliasDual { get; }
}

public interface ItestObjFieldEnumAliasDualObject
  : IGqlpModelImplementationBase
{
  bool Field { get; }
}

public interface ItestObjFieldEnumAliasInp
  : IGqlpModelImplementationBase
{
  ItestObjFieldEnumAliasInpObject? As_ObjFieldEnumAliasInp { get; }
}

public interface ItestObjFieldEnumAliasInpObject
  : IGqlpModelImplementationBase
{
  bool Field { get; }
}

public interface ItestObjFieldEnumAliasOutp
  : IGqlpModelImplementationBase
{
  ItestObjFieldEnumAliasOutpObject? As_ObjFieldEnumAliasOutp { get; }
}

public interface ItestObjFieldEnumAliasOutpObject
  : IGqlpModelImplementationBase
{
  bool Field { get; }
}

public interface ItestObjFieldEnumValueDual
  : IGqlpModelImplementationBase
{
  ItestObjFieldEnumValueDualObject? As_ObjFieldEnumValueDual { get; }
}

public interface ItestObjFieldEnumValueDualObject
  : IGqlpModelImplementationBase
{
  bool Field { get; }
}

public interface ItestObjFieldEnumValueInp
  : IGqlpModelImplementationBase
{
  ItestObjFieldEnumValueInpObject? As_ObjFieldEnumValueInp { get; }
}

public interface ItestObjFieldEnumValueInpObject
  : IGqlpModelImplementationBase
{
  bool Field { get; }
}

public interface ItestObjFieldEnumValueOutp
  : IGqlpModelImplementationBase
{
  ItestObjFieldEnumValueOutpObject? As_ObjFieldEnumValueOutp { get; }
}

public interface ItestObjFieldEnumValueOutpObject
  : IGqlpModelImplementationBase
{
  bool Field { get; }
}

public interface ItestObjFieldTypeAliasDual
  : IGqlpModelImplementationBase
{
  ItestObjFieldTypeAliasDualObject? As_ObjFieldTypeAliasDual { get; }
}

public interface ItestObjFieldTypeAliasDualObject
  : IGqlpModelImplementationBase
{
  string Field { get; }
}

public interface ItestObjFieldTypeAliasInp
  : IGqlpModelImplementationBase
{
  ItestObjFieldTypeAliasInpObject? As_ObjFieldTypeAliasInp { get; }
}

public interface ItestObjFieldTypeAliasInpObject
  : IGqlpModelImplementationBase
{
  string Field { get; }
}

public interface ItestObjFieldTypeAliasOutp
  : IGqlpModelImplementationBase
{
  ItestObjFieldTypeAliasOutpObject? As_ObjFieldTypeAliasOutp { get; }
}

public interface ItestObjFieldTypeAliasOutpObject
  : IGqlpModelImplementationBase
{
  string Field { get; }
}

public interface ItestObjParamDual<TTest,TType>
  : IGqlpModelImplementationBase
{
  ItestObjParamDualObject<TTest,TType>? As_ObjParamDual { get; }
}

public interface ItestObjParamDualObject<TTest,TType>
  : IGqlpModelImplementationBase
{
  TTest Test { get; }
  TType Type { get; }
}

public interface ItestObjParamInp<TTest,TType>
  : IGqlpModelImplementationBase
{
  ItestObjParamInpObject<TTest,TType>? As_ObjParamInp { get; }
}

public interface ItestObjParamInpObject<TTest,TType>
  : IGqlpModelImplementationBase
{
  TTest Test { get; }
  TType Type { get; }
}

public interface ItestObjParamOutp<TTest,TType>
  : IGqlpModelImplementationBase
{
  ItestObjParamOutpObject<TTest,TType>? As_ObjParamOutp { get; }
}

public interface ItestObjParamOutpObject<TTest,TType>
  : IGqlpModelImplementationBase
{
  TTest Test { get; }
  TType Type { get; }
}

public interface ItestObjParamDupDual<TTest>
  : IGqlpModelImplementationBase
{
  ItestObjParamDupDualObject<TTest>? As_ObjParamDupDual { get; }
}

public interface ItestObjParamDupDualObject<TTest>
  : IGqlpModelImplementationBase
{
  TTest Test { get; }
  TTest Type { get; }
}

public interface ItestObjParamDupInp<TTest>
  : IGqlpModelImplementationBase
{
  ItestObjParamDupInpObject<TTest>? As_ObjParamDupInp { get; }
}

public interface ItestObjParamDupInpObject<TTest>
  : IGqlpModelImplementationBase
{
  TTest Test { get; }
  TTest Type { get; }
}

public interface ItestObjParamDupOutp<TTest>
  : IGqlpModelImplementationBase
{
  ItestObjParamDupOutpObject<TTest>? As_ObjParamDupOutp { get; }
}

public interface ItestObjParamDupOutpObject<TTest>
  : IGqlpModelImplementationBase
{
  TTest Test { get; }
  TTest Type { get; }
}

public interface ItestObjPrntDual
  : ItestRefObjPrntDual
{
  ItestObjPrntDualObject? As_ObjPrntDual { get; }
}

public interface ItestObjPrntDualObject
  : ItestRefObjPrntDualObject
{
}

public interface ItestRefObjPrntDual
  : IGqlpModelImplementationBase
{
  ItestRefObjPrntDualObject? As_RefObjPrntDual { get; }
}

public interface ItestRefObjPrntDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjPrntInp
  : ItestRefObjPrntInp
{
  ItestObjPrntInpObject? As_ObjPrntInp { get; }
}

public interface ItestObjPrntInpObject
  : ItestRefObjPrntInpObject
{
}

public interface ItestRefObjPrntInp
  : IGqlpModelImplementationBase
{
  ItestRefObjPrntInpObject? As_RefObjPrntInp { get; }
}

public interface ItestRefObjPrntInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestObjPrntOutp
  : ItestRefObjPrntOutp
{
  ItestObjPrntOutpObject? As_ObjPrntOutp { get; }
}

public interface ItestObjPrntOutpObject
  : ItestRefObjPrntOutpObject
{
}

public interface ItestRefObjPrntOutp
  : IGqlpModelImplementationBase
{
  ItestRefObjPrntOutpObject? As_RefObjPrntOutp { get; }
}

public interface ItestRefObjPrntOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestOutpFieldParam
  : IGqlpModelImplementationBase
{
  ItestOutpFieldParamObject? As_OutpFieldParam { get; }
}

public interface ItestOutpFieldParamObject
  : IGqlpModelImplementationBase
{
  ItestFldOutpFieldParam? Field(ItestOutpFieldParam1 parameter);
}

public interface ItestOutpFieldParam1
  : IGqlpModelImplementationBase
{
  ItestOutpFieldParam1Object? As_OutpFieldParam1 { get; }
}

public interface ItestOutpFieldParam1Object
  : IGqlpModelImplementationBase
{
}

public interface ItestOutpFieldParam2
  : IGqlpModelImplementationBase
{
  ItestOutpFieldParam2Object? As_OutpFieldParam2 { get; }
}

public interface ItestOutpFieldParam2Object
  : IGqlpModelImplementationBase
{
}

public interface ItestFldOutpFieldParam
  : IGqlpModelImplementationBase
{
  ItestFldOutpFieldParamObject? As_FldOutpFieldParam { get; }
}

public interface ItestFldOutpFieldParamObject
  : IGqlpModelImplementationBase
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
