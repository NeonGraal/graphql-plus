//HintName: Gqlp_+Merges_Intf.gen.cs
// Generated from +Merges.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp__Merges;

public interface ICtgr
{
}

public interface ICtgrAlias
{
}

public interface ICtgrDescr
{
}

public interface ICtgrMod
{
}

public interface IInDrctParam
{
}

public interface IDmnAlias
{
}

public interface IDmnBool
{
}

public interface IDmnBoolDiff
{
}

public interface IDmnBoolSame
{
}

public interface IDmnEnumDiff
{
}

public interface IDmnEnumSame
{
}

public interface IDmnNmbr
{
}

public interface IDmnNmbrDiff
{
}

public interface IDmnNmbrSame
{
}

public interface IDmnStr
{
}

public interface IDmnStrDiff
{
}

public interface IDmnStrSame
{
}

public interface IObjDual
{
}

public interface IObjInp
{
}

public interface IObjOutp
{
}

public interface IObjAliasDual
{
}

public interface IObjAliasInp
{
}

public interface IObjAliasOutp
{
}

public interface IObjAltDual
{
  ObjAltDualType AsObjAltDualType { get; }
}

public interface IObjAltDualType
{
}

public interface IObjAltInp
{
  ObjAltInpType AsObjAltInpType { get; }
}

public interface IObjAltInpType
{
}

public interface IObjAltOutp
{
  ObjAltOutpType AsObjAltOutpType { get; }
}

public interface IObjAltOutpType
{
}

public interface IObjCnstDual<Ttype>
{
  Ttype field { get; }
  Ttype str { get; }
}

public interface IObjCnstInp<Ttype>
{
  Ttype field { get; }
  Ttype str { get; }
}

public interface IObjCnstOutp<Ttype>
{
  Ttype field { get; }
  Ttype str { get; }
}

public interface IObjFieldDual
{
  FldObjFieldDual field { get; }
}

public interface IFldObjFieldDual
{
}

public interface IObjFieldInp
{
  FldObjFieldInp field { get; }
}

public interface IFldObjFieldInp
{
}

public interface IObjFieldOutp
{
  FldObjFieldOutp field { get; }
}

public interface IFldObjFieldOutp
{
}

public interface IObjFieldAliasDual
{
  FldObjFieldAliasDual field { get; }
}

public interface IFldObjFieldAliasDual
{
}

public interface IObjFieldAliasInp
{
  FldObjFieldAliasInp field { get; }
}

public interface IFldObjFieldAliasInp
{
}

public interface IObjFieldAliasOutp
{
  FldObjFieldAliasOutp field { get; }
}

public interface IFldObjFieldAliasOutp
{
}

public interface IObjFieldTypeAliasDual
{
  String field { get; }
}

public interface IObjFieldTypeAliasInp
{
  String field { get; }
}

public interface IObjFieldTypeAliasOutp
{
  String field { get; }
}

public interface IObjParamDual<Ttest,Ttype>
{
  Ttest test { get; }
  Ttype type { get; }
}

public interface IObjParamInp<Ttest,Ttype>
{
  Ttest test { get; }
  Ttype type { get; }
}

public interface IObjParamOutp<Ttest,Ttype>
{
  Ttest test { get; }
  Ttype type { get; }
}

public interface IObjParamCnstDual<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}

public interface IObjParamCnstInp<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}

public interface IObjParamCnstOutp<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}

public interface IObjParamDupDual<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}

public interface IObjParamDupInp<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}

public interface IObjParamDupOutp<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}

public interface IObjPrntDual
  : IRefObjPrntDual
{
}

public interface IRefObjPrntDual
{
}

public interface IObjPrntInp
  : IRefObjPrntInp
{
}

public interface IRefObjPrntInp
{
}

public interface IObjPrntOutp
  : IRefObjPrntOutp
{
}

public interface IRefObjPrntOutp
{
}

public interface IOutpFieldEnumAlias
{
  Boolean field { get; }
}

public interface IOutpFieldEnumValue
{
  Boolean field { get; }
}

public interface IOutpFieldParam
{
  FldOutpFieldParam field { get; }
}

public interface IOutpFieldParam1
{
}

public interface IOutpFieldParam2
{
}

public interface IFldOutpFieldParam
{
}

public interface IUnionAlias
{
  Boolean AsBoolean { get; }
  Number AsNumber { get; }
}

public interface IUnionDiff
{
  Boolean AsBoolean { get; }
  Number AsNumber { get; }
}

public interface IUnionSame
{
  Boolean AsBoolean { get; }
}

public interface IUnionSamePrnt
  : IPrntUnionSamePrnt
{
  Boolean AsBoolean { get; }
}

public interface IPrntUnionSamePrnt
{
  String AsString { get; }
}
