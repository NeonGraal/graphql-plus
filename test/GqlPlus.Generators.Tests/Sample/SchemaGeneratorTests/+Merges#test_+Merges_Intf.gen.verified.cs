//HintName: test_+Merges_Intf.gen.cs
// Generated from +Merges.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp__Merges;

public interface ItestCtgr
{
}

public interface ItestCtgrAlias
{
}

public interface ItestCtgrDescr
{
}

public interface ItestCtgrMod
{
}

public interface ItestInDrctParam
{
}

public interface ItestDmnAlias
{
}

public interface ItestDmnBool
{
}

public interface ItestDmnBoolDiff
{
}

public interface ItestDmnBoolSame
{
}

public interface ItestDmnEnumDiff
{
}

public interface ItestDmnEnumSame
{
}

public interface ItestDmnNmbr
{
}

public interface ItestDmnNmbrDiff
{
}

public interface ItestDmnNmbrSame
{
}

public interface ItestDmnStr
{
}

public interface ItestDmnStrDiff
{
}

public interface ItestDmnStrSame
{
}

public interface ItestObjDual
{
}

public interface ItestObjInp
{
}

public interface ItestObjOutp
{
}

public interface ItestObjAliasDual
{
}

public interface ItestObjAliasInp
{
}

public interface ItestObjAliasOutp
{
}

public interface ItestObjAltDual
{
  ObjAltDualType AsObjAltDualType { get; }
}

public interface ItestObjAltDualType
{
}

public interface ItestObjAltInp
{
  ObjAltInpType AsObjAltInpType { get; }
}

public interface ItestObjAltInpType
{
}

public interface ItestObjAltOutp
{
  ObjAltOutpType AsObjAltOutpType { get; }
}

public interface ItestObjAltOutpType
{
}

public interface ItestObjAltEnumDual
{
  Boolean AsBoolean { get; }
  Boolean AsBoolean { get; }
}

public interface ItestObjAltEnumInp
{
  Boolean AsBoolean { get; }
  Boolean AsBoolean { get; }
}

public interface ItestObjAltEnumOutp
{
  Boolean AsBoolean { get; }
  Boolean AsBoolean { get; }
}

public interface ItestObjCnstDual<Ttype>
{
  Ttype field { get; }
  Ttype str { get; }
}

public interface ItestObjCnstInp<Ttype>
{
  Ttype field { get; }
  Ttype str { get; }
}

public interface ItestObjCnstOutp<Ttype>
{
  Ttype field { get; }
  Ttype str { get; }
}

public interface ItestObjFieldDual
{
  FldObjFieldDual field { get; }
}

public interface ItestFldObjFieldDual
{
}

public interface ItestObjFieldInp
{
  FldObjFieldInp field { get; }
}

public interface ItestFldObjFieldInp
{
}

public interface ItestObjFieldOutp
{
  FldObjFieldOutp field { get; }
}

public interface ItestFldObjFieldOutp
{
}

public interface ItestObjFieldAliasDual
{
  FldObjFieldAliasDual field { get; }
}

public interface ItestFldObjFieldAliasDual
{
}

public interface ItestObjFieldAliasInp
{
  FldObjFieldAliasInp field { get; }
}

public interface ItestFldObjFieldAliasInp
{
}

public interface ItestObjFieldAliasOutp
{
  FldObjFieldAliasOutp field { get; }
}

public interface ItestFldObjFieldAliasOutp
{
}

public interface ItestObjFieldEnumAliasDual
{
  Boolean field { get; }
}

public interface ItestObjFieldEnumAliasInp
{
  Boolean field { get; }
}

public interface ItestObjFieldEnumAliasOutp
{
  Boolean field { get; }
}

public interface ItestObjFieldEnumValueDual
{
  Boolean field { get; }
}

public interface ItestObjFieldEnumValueInp
{
  Boolean field { get; }
}

public interface ItestObjFieldEnumValueOutp
{
  Boolean field { get; }
}

public interface ItestObjFieldTypeAliasDual
{
  String field { get; }
}

public interface ItestObjFieldTypeAliasInp
{
  String field { get; }
}

public interface ItestObjFieldTypeAliasOutp
{
  String field { get; }
}

public interface ItestObjParamDual<Ttest,Ttype>
{
  Ttest test { get; }
  Ttype type { get; }
}

public interface ItestObjParamInp<Ttest,Ttype>
{
  Ttest test { get; }
  Ttype type { get; }
}

public interface ItestObjParamOutp<Ttest,Ttype>
{
  Ttest test { get; }
  Ttype type { get; }
}

public interface ItestObjParamDupDual<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}

public interface ItestObjParamDupInp<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}

public interface ItestObjParamDupOutp<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}

public interface ItestObjPrntDual
  : ItestRefObjPrntDual
{
}

public interface ItestRefObjPrntDual
{
}

public interface ItestObjPrntInp
  : ItestRefObjPrntInp
{
}

public interface ItestRefObjPrntInp
{
}

public interface ItestObjPrntOutp
  : ItestRefObjPrntOutp
{
}

public interface ItestRefObjPrntOutp
{
}

public interface ItestOutpFieldParam
{
  FldOutpFieldParam field { get; }
}

public interface ItestOutpFieldParam1
{
}

public interface ItestOutpFieldParam2
{
}

public interface ItestFldOutpFieldParam
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
