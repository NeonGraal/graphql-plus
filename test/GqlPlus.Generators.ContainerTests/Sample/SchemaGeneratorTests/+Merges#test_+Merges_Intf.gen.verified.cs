//HintName: test_+Merges_Intf.gen.cs
// Generated from +Merges.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Merges;

public interface ItestCtgr
{
  public ItestCtgrObject AsCtgr { get; set; }
}

public interface ItestCtgrObject
{
}

public interface ItestCtgrAlias
{
  public ItestCtgrAliasObject AsCtgrAlias { get; set; }
}

public interface ItestCtgrAliasObject
{
}

public interface ItestCtgrDescr
{
  public ItestCtgrDescrObject AsCtgrDescr { get; set; }
}

public interface ItestCtgrDescrObject
{
}

public interface ItestCtgrMod
{
  public ItestCtgrModObject AsCtgrMod { get; set; }
}

public interface ItestCtgrModObject
{
}

public interface ItestInDrctParam
{
  public ItestInDrctParamObject AsInDrctParam { get; set; }
}

public interface ItestInDrctParamObject
{
}

public interface ItestDmnAlias
  : IDomainNumber
{
}

public interface ItestDmnBool
  : IDomainBoolean
{
}

public interface ItestDmnBoolDiff
  : IDomainBoolean
{
}

public interface ItestDmnBoolSame
  : IDomainBoolean
{
}

public interface ItestDmnEnumDiff
  : IDomainEnum
{
}

public interface ItestDmnEnumSame
  : IDomainEnum
{
}

public interface ItestDmnNmbr
  : IDomainNumber
{
}

public interface ItestDmnNmbrDiff
  : IDomainNumber
{
}

public interface ItestDmnNmbrSame
  : IDomainNumber
{
}

public interface ItestDmnStr
  : IDomainString
{
}

public interface ItestDmnStrDiff
  : IDomainString
{
}

public interface ItestDmnStrSame
  : IDomainString
{
}

public interface ItestObjDual
{
  public ItestObjDualObject AsObjDual { get; set; }
}

public interface ItestObjDualObject
{
}

public interface ItestObjInp
{
  public ItestObjInpObject AsObjInp { get; set; }
}

public interface ItestObjInpObject
{
}

public interface ItestObjOutp
{
  public ItestObjOutpObject AsObjOutp { get; set; }
}

public interface ItestObjOutpObject
{
}

public interface ItestObjAliasDual
{
  public ItestObjAliasDualObject AsObjAliasDual { get; set; }
}

public interface ItestObjAliasDualObject
{
}

public interface ItestObjAliasInp
{
  public ItestObjAliasInpObject AsObjAliasInp { get; set; }
}

public interface ItestObjAliasInpObject
{
}

public interface ItestObjAliasOutp
{
  public ItestObjAliasOutpObject AsObjAliasOutp { get; set; }
}

public interface ItestObjAliasOutpObject
{
}

public interface ItestObjAltDual
{
  public ItestObjAltDualType AsObjAltDualType { get; set; }
  public ItestObjAltDualObject AsObjAltDual { get; set; }
}

public interface ItestObjAltDualObject
{
}

public interface ItestObjAltDualType
{
  public ItestObjAltDualTypeObject AsObjAltDualType { get; set; }
}

public interface ItestObjAltDualTypeObject
{
}

public interface ItestObjAltInp
{
  public ItestObjAltInpType AsObjAltInpType { get; set; }
  public ItestObjAltInpObject AsObjAltInp { get; set; }
}

public interface ItestObjAltInpObject
{
}

public interface ItestObjAltInpType
{
  public ItestObjAltInpTypeObject AsObjAltInpType { get; set; }
}

public interface ItestObjAltInpTypeObject
{
}

public interface ItestObjAltOutp
{
  public ItestObjAltOutpType AsObjAltOutpType { get; set; }
  public ItestObjAltOutpObject AsObjAltOutp { get; set; }
}

public interface ItestObjAltOutpObject
{
}

public interface ItestObjAltOutpType
{
  public ItestObjAltOutpTypeObject AsObjAltOutpType { get; set; }
}

public interface ItestObjAltOutpTypeObject
{
}

public interface ItestObjAltEnumDual
{
  public bool AsBooleantrue { get; set; }
  public bool AsBooleanfalse { get; set; }
  public ItestObjAltEnumDualObject AsObjAltEnumDual { get; set; }
}

public interface ItestObjAltEnumDualObject
{
}

public interface ItestObjAltEnumInp
{
  public bool AsBooleantrue { get; set; }
  public bool AsBooleanfalse { get; set; }
  public ItestObjAltEnumInpObject AsObjAltEnumInp { get; set; }
}

public interface ItestObjAltEnumInpObject
{
}

public interface ItestObjAltEnumOutp
{
  public bool AsBooleantrue { get; set; }
  public bool AsBooleanfalse { get; set; }
  public ItestObjAltEnumOutpObject AsObjAltEnumOutp { get; set; }
}

public interface ItestObjAltEnumOutpObject
{
}

public interface ItestObjCnstDual<Ttype>
{
  public ItestObjCnstDualObject AsObjCnstDual { get; set; }
}

public interface ItestObjCnstDualObject<Ttype>
{
  public Ttype Field { get; set; }
  public Ttype Str { get; set; }
}

public interface ItestObjCnstInp<Ttype>
{
  public ItestObjCnstInpObject AsObjCnstInp { get; set; }
}

public interface ItestObjCnstInpObject<Ttype>
{
  public Ttype Field { get; set; }
  public Ttype Str { get; set; }
}

public interface ItestObjCnstOutp<Ttype>
{
  public ItestObjCnstOutpObject AsObjCnstOutp { get; set; }
}

public interface ItestObjCnstOutpObject<Ttype>
{
  public Ttype Field { get; set; }
  public Ttype Str { get; set; }
}

public interface ItestObjFieldDual
{
  public ItestObjFieldDualObject AsObjFieldDual { get; set; }
}

public interface ItestObjFieldDualObject
{
  public ItestFldObjFieldDual Field { get; set; }
}

public interface ItestFldObjFieldDual
{
  public ItestFldObjFieldDualObject AsFldObjFieldDual { get; set; }
}

public interface ItestFldObjFieldDualObject
{
}

public interface ItestObjFieldInp
{
  public ItestObjFieldInpObject AsObjFieldInp { get; set; }
}

public interface ItestObjFieldInpObject
{
  public ItestFldObjFieldInp Field { get; set; }
}

public interface ItestFldObjFieldInp
{
  public ItestFldObjFieldInpObject AsFldObjFieldInp { get; set; }
}

public interface ItestFldObjFieldInpObject
{
}

public interface ItestObjFieldOutp
{
  public ItestObjFieldOutpObject AsObjFieldOutp { get; set; }
}

public interface ItestObjFieldOutpObject
{
  public ItestFldObjFieldOutp Field { get; set; }
}

public interface ItestFldObjFieldOutp
{
  public ItestFldObjFieldOutpObject AsFldObjFieldOutp { get; set; }
}

public interface ItestFldObjFieldOutpObject
{
}

public interface ItestObjFieldAliasDual
{
  public ItestObjFieldAliasDualObject AsObjFieldAliasDual { get; set; }
}

public interface ItestObjFieldAliasDualObject
{
  public ItestFldObjFieldAliasDual Field { get; set; }
}

public interface ItestFldObjFieldAliasDual
{
  public ItestFldObjFieldAliasDualObject AsFldObjFieldAliasDual { get; set; }
}

public interface ItestFldObjFieldAliasDualObject
{
}

public interface ItestObjFieldAliasInp
{
  public ItestObjFieldAliasInpObject AsObjFieldAliasInp { get; set; }
}

public interface ItestObjFieldAliasInpObject
{
  public ItestFldObjFieldAliasInp Field { get; set; }
}

public interface ItestFldObjFieldAliasInp
{
  public ItestFldObjFieldAliasInpObject AsFldObjFieldAliasInp { get; set; }
}

public interface ItestFldObjFieldAliasInpObject
{
}

public interface ItestObjFieldAliasOutp
{
  public ItestObjFieldAliasOutpObject AsObjFieldAliasOutp { get; set; }
}

public interface ItestObjFieldAliasOutpObject
{
  public ItestFldObjFieldAliasOutp Field { get; set; }
}

public interface ItestFldObjFieldAliasOutp
{
  public ItestFldObjFieldAliasOutpObject AsFldObjFieldAliasOutp { get; set; }
}

public interface ItestFldObjFieldAliasOutpObject
{
}

public interface ItestObjFieldEnumAliasDual
{
  public ItestObjFieldEnumAliasDualObject AsObjFieldEnumAliasDual { get; set; }
}

public interface ItestObjFieldEnumAliasDualObject
{
  public bool Field { get; set; }
}

public interface ItestObjFieldEnumAliasInp
{
  public ItestObjFieldEnumAliasInpObject AsObjFieldEnumAliasInp { get; set; }
}

public interface ItestObjFieldEnumAliasInpObject
{
  public bool Field { get; set; }
}

public interface ItestObjFieldEnumAliasOutp
{
  public ItestObjFieldEnumAliasOutpObject AsObjFieldEnumAliasOutp { get; set; }
}

public interface ItestObjFieldEnumAliasOutpObject
{
  public bool Field { get; set; }
}

public interface ItestObjFieldEnumValueDual
{
  public ItestObjFieldEnumValueDualObject AsObjFieldEnumValueDual { get; set; }
}

public interface ItestObjFieldEnumValueDualObject
{
  public bool Field { get; set; }
}

public interface ItestObjFieldEnumValueInp
{
  public ItestObjFieldEnumValueInpObject AsObjFieldEnumValueInp { get; set; }
}

public interface ItestObjFieldEnumValueInpObject
{
  public bool Field { get; set; }
}

public interface ItestObjFieldEnumValueOutp
{
  public ItestObjFieldEnumValueOutpObject AsObjFieldEnumValueOutp { get; set; }
}

public interface ItestObjFieldEnumValueOutpObject
{
  public bool Field { get; set; }
}

public interface ItestObjFieldTypeAliasDual
{
  public ItestObjFieldTypeAliasDualObject AsObjFieldTypeAliasDual { get; set; }
}

public interface ItestObjFieldTypeAliasDualObject
{
  public string Field { get; set; }
}

public interface ItestObjFieldTypeAliasInp
{
  public ItestObjFieldTypeAliasInpObject AsObjFieldTypeAliasInp { get; set; }
}

public interface ItestObjFieldTypeAliasInpObject
{
  public string Field { get; set; }
}

public interface ItestObjFieldTypeAliasOutp
{
  public ItestObjFieldTypeAliasOutpObject AsObjFieldTypeAliasOutp { get; set; }
}

public interface ItestObjFieldTypeAliasOutpObject
{
  public string Field { get; set; }
}

public interface ItestObjParamDual<Ttest,Ttype>
{
  public ItestObjParamDualObject AsObjParamDual { get; set; }
}

public interface ItestObjParamDualObject<Ttest,Ttype>
{
  public Ttest Test { get; set; }
  public Ttype Type { get; set; }
}

public interface ItestObjParamInp<Ttest,Ttype>
{
  public ItestObjParamInpObject AsObjParamInp { get; set; }
}

public interface ItestObjParamInpObject<Ttest,Ttype>
{
  public Ttest Test { get; set; }
  public Ttype Type { get; set; }
}

public interface ItestObjParamOutp<Ttest,Ttype>
{
  public ItestObjParamOutpObject AsObjParamOutp { get; set; }
}

public interface ItestObjParamOutpObject<Ttest,Ttype>
{
  public Ttest Test { get; set; }
  public Ttype Type { get; set; }
}

public interface ItestObjParamDupDual<Ttest>
{
  public ItestObjParamDupDualObject AsObjParamDupDual { get; set; }
}

public interface ItestObjParamDupDualObject<Ttest>
{
  public Ttest Test { get; set; }
  public Ttest Type { get; set; }
}

public interface ItestObjParamDupInp<Ttest>
{
  public ItestObjParamDupInpObject AsObjParamDupInp { get; set; }
}

public interface ItestObjParamDupInpObject<Ttest>
{
  public Ttest Test { get; set; }
  public Ttest Type { get; set; }
}

public interface ItestObjParamDupOutp<Ttest>
{
  public ItestObjParamDupOutpObject AsObjParamDupOutp { get; set; }
}

public interface ItestObjParamDupOutpObject<Ttest>
{
  public Ttest Test { get; set; }
  public Ttest Type { get; set; }
}

public interface ItestObjPrntDual
  : ItestRefObjPrntDual
{
  public ItestObjPrntDualObject AsObjPrntDual { get; set; }
}

public interface ItestObjPrntDualObject
  : ItestRefObjPrntDualObject
{
}

public interface ItestRefObjPrntDual
{
  public ItestRefObjPrntDualObject AsRefObjPrntDual { get; set; }
}

public interface ItestRefObjPrntDualObject
{
}

public interface ItestObjPrntInp
  : ItestRefObjPrntInp
{
  public ItestObjPrntInpObject AsObjPrntInp { get; set; }
}

public interface ItestObjPrntInpObject
  : ItestRefObjPrntInpObject
{
}

public interface ItestRefObjPrntInp
{
  public ItestRefObjPrntInpObject AsRefObjPrntInp { get; set; }
}

public interface ItestRefObjPrntInpObject
{
}

public interface ItestObjPrntOutp
  : ItestRefObjPrntOutp
{
  public ItestObjPrntOutpObject AsObjPrntOutp { get; set; }
}

public interface ItestObjPrntOutpObject
  : ItestRefObjPrntOutpObject
{
}

public interface ItestRefObjPrntOutp
{
  public ItestRefObjPrntOutpObject AsRefObjPrntOutp { get; set; }
}

public interface ItestRefObjPrntOutpObject
{
}

public interface ItestOutpFieldParam
{
  public ItestOutpFieldParamObject AsOutpFieldParam { get; set; }
}

public interface ItestOutpFieldParamObject
{
  public ItestFldOutpFieldParam Field { get; set; }
}

public interface ItestOutpFieldParam1
{
  public ItestOutpFieldParam1Object AsOutpFieldParam1 { get; set; }
}

public interface ItestOutpFieldParam1Object
{
}

public interface ItestOutpFieldParam2
{
  public ItestOutpFieldParam2Object AsOutpFieldParam2 { get; set; }
}

public interface ItestOutpFieldParam2Object
{
}

public interface ItestFldOutpFieldParam
{
  public ItestFldOutpFieldParamObject AsFldOutpFieldParam { get; set; }
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
