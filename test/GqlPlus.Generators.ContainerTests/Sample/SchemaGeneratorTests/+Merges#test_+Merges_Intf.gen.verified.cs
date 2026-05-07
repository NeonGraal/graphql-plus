//HintName: test_+Merges_Intf.gen.cs
// Generated from {CurrentDirectory}+Merges.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Merges;

public interface ItestCtgr
  : IGqlpInterfaceBase
{
  ItestCtgrObject? As_Ctgr { get; }
}

public interface ItestCtgrObject
  : IGqlpInterfaceBase
{
}

public interface ItestCtgrAlias
  : IGqlpInterfaceBase
{
  ItestCtgrAliasObject? As_CtgrAlias { get; }
}

public interface ItestCtgrAliasObject
  : IGqlpInterfaceBase
{
}

public interface ItestCtgrDescr
  : IGqlpInterfaceBase
{
  ItestCtgrDescrObject? As_CtgrDescr { get; }
}

public interface ItestCtgrDescrObject
  : IGqlpInterfaceBase
{
}

public interface ItestCtgrMod
  : IGqlpInterfaceBase
{
  ItestCtgrModObject? As_CtgrMod { get; }
}

public interface ItestCtgrModObject
  : IGqlpInterfaceBase
{
}

public interface ItestInDrctParam
  : IGqlpInterfaceBase
{
  ItestInDrctParamObject? As_InDrctParam { get; }
}

public interface ItestInDrctParamObject
  : IGqlpInterfaceBase
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
  new bool? Value { get; }
}

public interface ItestDmnEnumSame
  : IGqlpDomainEnum
{
  new bool? Value { get; }
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
  : IGqlpInterfaceBase
{
  ItestObjDualObject? As_ObjDual { get; }
}

public interface ItestObjDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjInp
  : IGqlpInterfaceBase
{
  ItestObjInpObject? As_ObjInp { get; }
}

public interface ItestObjInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjOutp
  : IGqlpInterfaceBase
{
  ItestObjOutpObject? As_ObjOutp { get; }
}

public interface ItestObjOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjAliasDual
  : IGqlpInterfaceBase
{
  ItestObjAliasDualObject? As_ObjAliasDual { get; }
}

public interface ItestObjAliasDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjAliasInp
  : IGqlpInterfaceBase
{
  ItestObjAliasInpObject? As_ObjAliasInp { get; }
}

public interface ItestObjAliasInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjAliasOutp
  : IGqlpInterfaceBase
{
  ItestObjAliasOutpObject? As_ObjAliasOutp { get; }
}

public interface ItestObjAliasOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjAltDual
  : IGqlpInterfaceBase
{
  ItestObjAltDualType? AsObjAltDualType { get; }
  ItestObjAltDualObject? As_ObjAltDual { get; }
}

public interface ItestObjAltDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjAltDualType
  : IGqlpInterfaceBase
{
  ItestObjAltDualTypeObject? As_ObjAltDualType { get; }
}

public interface ItestObjAltDualTypeObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjAltInp
  : IGqlpInterfaceBase
{
  ItestObjAltInpType? AsObjAltInpType { get; }
  ItestObjAltInpObject? As_ObjAltInp { get; }
}

public interface ItestObjAltInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjAltInpType
  : IGqlpInterfaceBase
{
  ItestObjAltInpTypeObject? As_ObjAltInpType { get; }
}

public interface ItestObjAltInpTypeObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjAltOutp
  : IGqlpInterfaceBase
{
  ItestObjAltOutpType? AsObjAltOutpType { get; }
  ItestObjAltOutpObject? As_ObjAltOutp { get; }
}

public interface ItestObjAltOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjAltOutpType
  : IGqlpInterfaceBase
{
  ItestObjAltOutpTypeObject? As_ObjAltOutpType { get; }
}

public interface ItestObjAltOutpTypeObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjAltEnumDual
  : IGqlpInterfaceBase
{
  bool? AsBooleantrue { get; }
  bool? AsBooleanfalse { get; }
  ItestObjAltEnumDualObject? As_ObjAltEnumDual { get; }
}

public interface ItestObjAltEnumDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjAltEnumInp
  : IGqlpInterfaceBase
{
  bool? AsBooleantrue { get; }
  bool? AsBooleanfalse { get; }
  ItestObjAltEnumInpObject? As_ObjAltEnumInp { get; }
}

public interface ItestObjAltEnumInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjAltEnumOutp
  : IGqlpInterfaceBase
{
  bool? AsBooleantrue { get; }
  bool? AsBooleanfalse { get; }
  ItestObjAltEnumOutpObject? As_ObjAltEnumOutp { get; }
}

public interface ItestObjAltEnumOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjCnstDual<TType>
  : IGqlpInterfaceBase
{
  ItestObjCnstDualObject<TType>? As_ObjCnstDual { get; }
}

public interface ItestObjCnstDualObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
  TType Str { get; }
}

public interface ItestObjCnstInp<TType>
  : IGqlpInterfaceBase
{
  ItestObjCnstInpObject<TType>? As_ObjCnstInp { get; }
}

public interface ItestObjCnstInpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
  TType Str { get; }
}

public interface ItestObjCnstOutp<TType>
  : IGqlpInterfaceBase
{
  ItestObjCnstOutpObject<TType>? As_ObjCnstOutp { get; }
}

public interface ItestObjCnstOutpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
  TType Str { get; }
}

public interface ItestObjFieldDual
  : IGqlpInterfaceBase
{
  ItestObjFieldDualObject? As_ObjFieldDual { get; }
}

public interface ItestObjFieldDualObject
  : IGqlpInterfaceBase
{
  ItestFldObjFieldDual Field { get; }
}

public interface ItestFldObjFieldDual
  : IGqlpInterfaceBase
{
  ItestFldObjFieldDualObject? As_FldObjFieldDual { get; }
}

public interface ItestFldObjFieldDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjFieldInp
  : IGqlpInterfaceBase
{
  ItestObjFieldInpObject? As_ObjFieldInp { get; }
}

public interface ItestObjFieldInpObject
  : IGqlpInterfaceBase
{
  ItestFldObjFieldInp Field { get; }
}

public interface ItestFldObjFieldInp
  : IGqlpInterfaceBase
{
  ItestFldObjFieldInpObject? As_FldObjFieldInp { get; }
}

public interface ItestFldObjFieldInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjFieldOutp
  : IGqlpInterfaceBase
{
  ItestObjFieldOutpObject? As_ObjFieldOutp { get; }
}

public interface ItestObjFieldOutpObject
  : IGqlpInterfaceBase
{
  ItestFldObjFieldOutp Field { get; }
}

public interface ItestFldObjFieldOutp
  : IGqlpInterfaceBase
{
  ItestFldObjFieldOutpObject? As_FldObjFieldOutp { get; }
}

public interface ItestFldObjFieldOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjFieldAliasDual
  : IGqlpInterfaceBase
{
  ItestObjFieldAliasDualObject? As_ObjFieldAliasDual { get; }
}

public interface ItestObjFieldAliasDualObject
  : IGqlpInterfaceBase
{
  ItestFldObjFieldAliasDual Field { get; }
}

public interface ItestFldObjFieldAliasDual
  : IGqlpInterfaceBase
{
  ItestFldObjFieldAliasDualObject? As_FldObjFieldAliasDual { get; }
}

public interface ItestFldObjFieldAliasDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjFieldAliasInp
  : IGqlpInterfaceBase
{
  ItestObjFieldAliasInpObject? As_ObjFieldAliasInp { get; }
}

public interface ItestObjFieldAliasInpObject
  : IGqlpInterfaceBase
{
  ItestFldObjFieldAliasInp Field { get; }
}

public interface ItestFldObjFieldAliasInp
  : IGqlpInterfaceBase
{
  ItestFldObjFieldAliasInpObject? As_FldObjFieldAliasInp { get; }
}

public interface ItestFldObjFieldAliasInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjFieldAliasOutp
  : IGqlpInterfaceBase
{
  ItestObjFieldAliasOutpObject? As_ObjFieldAliasOutp { get; }
}

public interface ItestObjFieldAliasOutpObject
  : IGqlpInterfaceBase
{
  ItestFldObjFieldAliasOutp Field { get; }
}

public interface ItestFldObjFieldAliasOutp
  : IGqlpInterfaceBase
{
  ItestFldObjFieldAliasOutpObject? As_FldObjFieldAliasOutp { get; }
}

public interface ItestFldObjFieldAliasOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjFieldEnumAliasDual
  : IGqlpInterfaceBase
{
  ItestObjFieldEnumAliasDualObject? As_ObjFieldEnumAliasDual { get; }
}

public interface ItestObjFieldEnumAliasDualObject
  : IGqlpInterfaceBase
{
  bool Field { get; }
}

public interface ItestObjFieldEnumAliasInp
  : IGqlpInterfaceBase
{
  ItestObjFieldEnumAliasInpObject? As_ObjFieldEnumAliasInp { get; }
}

public interface ItestObjFieldEnumAliasInpObject
  : IGqlpInterfaceBase
{
  bool Field { get; }
}

public interface ItestObjFieldEnumAliasOutp
  : IGqlpInterfaceBase
{
  ItestObjFieldEnumAliasOutpObject? As_ObjFieldEnumAliasOutp { get; }
}

public interface ItestObjFieldEnumAliasOutpObject
  : IGqlpInterfaceBase
{
  bool Field { get; }
}

public interface ItestObjFieldEnumValueDual
  : IGqlpInterfaceBase
{
  ItestObjFieldEnumValueDualObject? As_ObjFieldEnumValueDual { get; }
}

public interface ItestObjFieldEnumValueDualObject
  : IGqlpInterfaceBase
{
  bool Field { get; }
}

public interface ItestObjFieldEnumValueInp
  : IGqlpInterfaceBase
{
  ItestObjFieldEnumValueInpObject? As_ObjFieldEnumValueInp { get; }
}

public interface ItestObjFieldEnumValueInpObject
  : IGqlpInterfaceBase
{
  bool Field { get; }
}

public interface ItestObjFieldEnumValueOutp
  : IGqlpInterfaceBase
{
  ItestObjFieldEnumValueOutpObject? As_ObjFieldEnumValueOutp { get; }
}

public interface ItestObjFieldEnumValueOutpObject
  : IGqlpInterfaceBase
{
  bool Field { get; }
}

public interface ItestObjFieldTypeAliasDual
  : IGqlpInterfaceBase
{
  ItestObjFieldTypeAliasDualObject? As_ObjFieldTypeAliasDual { get; }
}

public interface ItestObjFieldTypeAliasDualObject
  : IGqlpInterfaceBase
{
  string Field { get; }
}

public interface ItestObjFieldTypeAliasInp
  : IGqlpInterfaceBase
{
  ItestObjFieldTypeAliasInpObject? As_ObjFieldTypeAliasInp { get; }
}

public interface ItestObjFieldTypeAliasInpObject
  : IGqlpInterfaceBase
{
  string Field { get; }
}

public interface ItestObjFieldTypeAliasOutp
  : IGqlpInterfaceBase
{
  ItestObjFieldTypeAliasOutpObject? As_ObjFieldTypeAliasOutp { get; }
}

public interface ItestObjFieldTypeAliasOutpObject
  : IGqlpInterfaceBase
{
  string Field { get; }
}

public interface ItestObjParamDual<TTest,TType>
  : IGqlpInterfaceBase
{
  ItestObjParamDualObject<TTest,TType>? As_ObjParamDual { get; }
}

public interface ItestObjParamDualObject<TTest,TType>
  : IGqlpInterfaceBase
{
  TTest Test { get; }
  TType Type { get; }
}

public interface ItestObjParamInp<TTest,TType>
  : IGqlpInterfaceBase
{
  ItestObjParamInpObject<TTest,TType>? As_ObjParamInp { get; }
}

public interface ItestObjParamInpObject<TTest,TType>
  : IGqlpInterfaceBase
{
  TTest Test { get; }
  TType Type { get; }
}

public interface ItestObjParamOutp<TTest,TType>
  : IGqlpInterfaceBase
{
  ItestObjParamOutpObject<TTest,TType>? As_ObjParamOutp { get; }
}

public interface ItestObjParamOutpObject<TTest,TType>
  : IGqlpInterfaceBase
{
  TTest Test { get; }
  TType Type { get; }
}

public interface ItestObjParamDupDual<TTest>
  : IGqlpInterfaceBase
{
  ItestObjParamDupDualObject<TTest>? As_ObjParamDupDual { get; }
}

public interface ItestObjParamDupDualObject<TTest>
  : IGqlpInterfaceBase
{
  TTest Test { get; }
  TTest Type { get; }
}

public interface ItestObjParamDupInp<TTest>
  : IGqlpInterfaceBase
{
  ItestObjParamDupInpObject<TTest>? As_ObjParamDupInp { get; }
}

public interface ItestObjParamDupInpObject<TTest>
  : IGqlpInterfaceBase
{
  TTest Test { get; }
  TTest Type { get; }
}

public interface ItestObjParamDupOutp<TTest>
  : IGqlpInterfaceBase
{
  ItestObjParamDupOutpObject<TTest>? As_ObjParamDupOutp { get; }
}

public interface ItestObjParamDupOutpObject<TTest>
  : IGqlpInterfaceBase
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
  : IGqlpInterfaceBase
{
  ItestRefObjPrntDualObject? As_RefObjPrntDual { get; }
}

public interface ItestRefObjPrntDualObject
  : IGqlpInterfaceBase
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
  : IGqlpInterfaceBase
{
  ItestRefObjPrntInpObject? As_RefObjPrntInp { get; }
}

public interface ItestRefObjPrntInpObject
  : IGqlpInterfaceBase
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
  : IGqlpInterfaceBase
{
  ItestRefObjPrntOutpObject? As_RefObjPrntOutp { get; }
}

public interface ItestRefObjPrntOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestOp
  : IGqlpInterfaceBase
{
  ItestOpObject? As_Op { get; }
}

public interface ItestOpObject
  : IGqlpInterfaceBase
{
}

public interface ItestOutpFieldParam
  : IGqlpInterfaceBase
{
  ItestOutpFieldParamObject? As_OutpFieldParam { get; }
}

public interface ItestOutpFieldParamObject
  : IGqlpInterfaceBase
{
  ItestFldOutpFieldParam? Field(ItestOutpFieldParam1 parameter);
  ItestFldOutpFieldParam? Field();
}

public interface ItestOutpFieldParam1
  : IGqlpInterfaceBase
{
  ItestOutpFieldParam1Object? As_OutpFieldParam1 { get; }
}

public interface ItestOutpFieldParam1Object
  : IGqlpInterfaceBase
{
}

public interface ItestOutpFieldParam2
  : IGqlpInterfaceBase
{
  ItestOutpFieldParam2Object? As_OutpFieldParam2 { get; }
}

public interface ItestOutpFieldParam2Object
  : IGqlpInterfaceBase
{
}

public interface ItestFldOutpFieldParam
  : IGqlpInterfaceBase
{
  ItestFldOutpFieldParamObject? As_FldOutpFieldParam { get; }
}

public interface ItestFldOutpFieldParamObject
  : IGqlpInterfaceBase
{
}

public interface ItestUnionAlias
  : IGqlpInterfaceBase
{
  bool HasA<T>();
  T AsA<T>();
}

public interface ItestUnionDiff
  : IGqlpInterfaceBase
{
  bool HasA<T>();
  T AsA<T>();
}

public interface ItestUnionSame
  : IGqlpInterfaceBase
{
  bool HasA<T>();
  T AsA<T>();
}

public interface ItestUnionSamePrnt
  : ItestPrntUnionSamePrnt
{
}

public interface ItestPrntUnionSamePrnt
  : IGqlpInterfaceBase
{
  bool HasA<T>();
  T AsA<T>();
}
