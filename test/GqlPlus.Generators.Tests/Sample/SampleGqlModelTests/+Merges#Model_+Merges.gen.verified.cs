//HintName: Model_+Merges.gen.cs
// Generated from +Merges.graphql+

/*
Category ctgr
Category ctgrAlias
Category ctgrDescr
Category ctgrMod
Directive Drct
Directive DrctAlias
Directive DrctParam
Option Schema
*/

namespace GqlTest.Model__Merges;

public interface ICtgr
{
}
public class OutputCtgr
  : ICtgr
{
}

public interface ICtgrAlias
{
}
public class OutputCtgrAlias
  : ICtgrAlias
{
}

public interface ICtgrDescr
{
}
public class OutputCtgrDescr
  : ICtgrDescr
{
}

public interface ICtgrMod
{
}
public class OutputCtgrMod
  : ICtgrMod
{
}

public interface IInDrctParam
{
}
public class InputInDrctParam
  : IInDrctParam
{
}

public interface IDmnAlias
{
}
public class DomainDmnAlias
  : IDmnAlias
{
}

public interface IDmnBool
{
}
public class DomainDmnBool
  : IDmnBool
{
}

public interface IDmnBoolDiff
{
}
public class DomainDmnBoolDiff
  : IDmnBoolDiff
{
}

public interface IDmnBoolSame
{
}
public class DomainDmnBoolSame
  : IDmnBoolSame
{
}

public interface IDmnEnumDiff
{
}
public class DomainDmnEnumDiff
  : IDmnEnumDiff
{
}

public interface IDmnEnumSame
{
}
public class DomainDmnEnumSame
  : IDmnEnumSame
{
}

public interface IDmnNmbr
{
}
public class DomainDmnNmbr
  : IDmnNmbr
{
}

public interface IDmnNmbrDiff
{
}
public class DomainDmnNmbrDiff
  : IDmnNmbrDiff
{
}

public interface IDmnNmbrSame
{
}
public class DomainDmnNmbrSame
  : IDmnNmbrSame
{
}

public interface IDmnStr
{
}
public class DomainDmnStr
  : IDmnStr
{
}

public interface IDmnStrDiff
{
}
public class DomainDmnStrDiff
  : IDmnStrDiff
{
}

public interface IDmnStrSame
{
}
public class DomainDmnStrSame
  : IDmnStrSame
{
}

public enum EnumAlias
{
  enumAlias,
}

public enum EnumDiff
{
  one,
  two,
}

public enum EnumSame
{
  enumSame,
}

public enum EnumSamePrnt
{
  prnt_enumSamePrnt = PrntEnumSamePrnt.prnt_enumSamePrnt,,
  enumSamePrnt,
}

public enum PrntEnumSamePrnt
{
  prnt_enumSamePrnt,
}

public enum EnumValueAlias
{
  enumValueAlias,
  val1 = enumValueAlias,
  val2 = enumValueAlias,
}

public interface IObjDual
{
}
public class DualObjDual
  : IObjDual
{
}

public interface IObjInp
{
}
public class InputObjInp
  : IObjInp
{
}

public interface IObjOutp
{
}
public class OutputObjOutp
  : IObjOutp
{
}

public interface IObjAliasDual
{
}
public class DualObjAliasDual
  : IObjAliasDual
{
}

public interface IObjAliasInp
{
}
public class InputObjAliasInp
  : IObjAliasInp
{
}

public interface IObjAliasOutp
{
}
public class OutputObjAliasOutp
  : IObjAliasOutp
{
}

public interface IObjAltDual
{
  ObjAltDualType AsObjAltDualType { get; }
}
public class DualObjAltDual
  : IObjAltDual
{
  public ObjAltDualType AsObjAltDualType { get; set; }
}

public interface IObjAltDualType
{
}
public class DualObjAltDualType
  : IObjAltDualType
{
}

public interface IObjAltInp
{
  ObjAltInpType AsObjAltInpType { get; }
}
public class InputObjAltInp
  : IObjAltInp
{
  public ObjAltInpType AsObjAltInpType { get; set; }
}

public interface IObjAltInpType
{
}
public class InputObjAltInpType
  : IObjAltInpType
{
}

public interface IObjAltOutp
{
  ObjAltOutpType AsObjAltOutpType { get; }
}
public class OutputObjAltOutp
  : IObjAltOutp
{
  public ObjAltOutpType AsObjAltOutpType { get; set; }
}

public interface IObjAltOutpType
{
}
public class OutputObjAltOutpType
  : IObjAltOutpType
{
}

public interface IObjCnstDual<Ttype>
{
  Ttype field { get; }
  Ttype str { get; }
}
public class DualObjCnstDual<Ttype>
  : IObjCnstDual<Ttype>
{
  public Ttype field { get; set; }
  public Ttype str { get; set; }
}

public interface IObjCnstInp<Ttype>
{
  Ttype field { get; }
  Ttype str { get; }
}
public class InputObjCnstInp<Ttype>
  : IObjCnstInp<Ttype>
{
  public Ttype field { get; set; }
  public Ttype str { get; set; }
}

public interface IObjCnstOutp<Ttype>
{
  Ttype field { get; }
  Ttype str { get; }
}
public class OutputObjCnstOutp<Ttype>
  : IObjCnstOutp<Ttype>
{
  public Ttype field { get; set; }
  public Ttype str { get; set; }
}

public interface IObjFieldDual
{
  FldObjFieldDual field { get; }
}
public class DualObjFieldDual
  : IObjFieldDual
{
  public FldObjFieldDual field { get; set; }
}

public interface IFldObjFieldDual
{
}
public class DualFldObjFieldDual
  : IFldObjFieldDual
{
}

public interface IObjFieldInp
{
  FldObjFieldInp field { get; }
}
public class InputObjFieldInp
  : IObjFieldInp
{
  public FldObjFieldInp field { get; set; }
}

public interface IFldObjFieldInp
{
}
public class InputFldObjFieldInp
  : IFldObjFieldInp
{
}

public interface IObjFieldOutp
{
  FldObjFieldOutp field { get; }
}
public class OutputObjFieldOutp
  : IObjFieldOutp
{
  public FldObjFieldOutp field { get; set; }
}

public interface IFldObjFieldOutp
{
}
public class OutputFldObjFieldOutp
  : IFldObjFieldOutp
{
}

public interface IObjFieldAliasDual
{
  FldObjFieldAliasDual field { get; }
}
public class DualObjFieldAliasDual
  : IObjFieldAliasDual
{
  public FldObjFieldAliasDual field { get; set; }
}

public interface IFldObjFieldAliasDual
{
}
public class DualFldObjFieldAliasDual
  : IFldObjFieldAliasDual
{
}

public interface IObjFieldAliasInp
{
  FldObjFieldAliasInp field { get; }
}
public class InputObjFieldAliasInp
  : IObjFieldAliasInp
{
  public FldObjFieldAliasInp field { get; set; }
}

public interface IFldObjFieldAliasInp
{
}
public class InputFldObjFieldAliasInp
  : IFldObjFieldAliasInp
{
}

public interface IObjFieldAliasOutp
{
  FldObjFieldAliasOutp field { get; }
}
public class OutputObjFieldAliasOutp
  : IObjFieldAliasOutp
{
  public FldObjFieldAliasOutp field { get; set; }
}

public interface IFldObjFieldAliasOutp
{
}
public class OutputFldObjFieldAliasOutp
  : IFldObjFieldAliasOutp
{
}

public interface IObjFieldTypeAliasDual
{
  String field { get; }
}
public class DualObjFieldTypeAliasDual
  : IObjFieldTypeAliasDual
{
  public String field { get; set; }
}

public interface IObjFieldTypeAliasInp
{
  String field { get; }
}
public class InputObjFieldTypeAliasInp
  : IObjFieldTypeAliasInp
{
  public String field { get; set; }
}

public interface IObjFieldTypeAliasOutp
{
  String field { get; }
}
public class OutputObjFieldTypeAliasOutp
  : IObjFieldTypeAliasOutp
{
  public String field { get; set; }
}

public interface IObjParamDual<Ttest,Ttype>
{
  Ttest test { get; }
  Ttype type { get; }
}
public class DualObjParamDual<Ttest,Ttype>
  : IObjParamDual<Ttest,Ttype>
{
  public Ttest test { get; set; }
  public Ttype type { get; set; }
}

public interface IObjParamInp<Ttest,Ttype>
{
  Ttest test { get; }
  Ttype type { get; }
}
public class InputObjParamInp<Ttest,Ttype>
  : IObjParamInp<Ttest,Ttype>
{
  public Ttest test { get; set; }
  public Ttype type { get; set; }
}

public interface IObjParamOutp<Ttest,Ttype>
{
  Ttest test { get; }
  Ttype type { get; }
}
public class OutputObjParamOutp<Ttest,Ttype>
  : IObjParamOutp<Ttest,Ttype>
{
  public Ttest test { get; set; }
  public Ttype type { get; set; }
}

public interface IObjParamCnstDual<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}
public class DualObjParamCnstDual<Ttest>
  : IObjParamCnstDual<Ttest>
{
  public Ttest test { get; set; }
  public Ttest type { get; set; }
}

public interface IObjParamCnstInp<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}
public class InputObjParamCnstInp<Ttest>
  : IObjParamCnstInp<Ttest>
{
  public Ttest test { get; set; }
  public Ttest type { get; set; }
}

public interface IObjParamCnstOutp<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}
public class OutputObjParamCnstOutp<Ttest>
  : IObjParamCnstOutp<Ttest>
{
  public Ttest test { get; set; }
  public Ttest type { get; set; }
}

public interface IObjParamDupDual<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}
public class DualObjParamDupDual<Ttest>
  : IObjParamDupDual<Ttest>
{
  public Ttest test { get; set; }
  public Ttest type { get; set; }
}

public interface IObjParamDupInp<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}
public class InputObjParamDupInp<Ttest>
  : IObjParamDupInp<Ttest>
{
  public Ttest test { get; set; }
  public Ttest type { get; set; }
}

public interface IObjParamDupOutp<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}
public class OutputObjParamDupOutp<Ttest>
  : IObjParamDupOutp<Ttest>
{
  public Ttest test { get; set; }
  public Ttest type { get; set; }
}

public interface IObjPrntDual
  : IRefObjPrntDual
{
}
public class DualObjPrntDual
  : DualRefObjPrntDual
  , IObjPrntDual
{
}

public interface IRefObjPrntDual
{
}
public class DualRefObjPrntDual
  : IRefObjPrntDual
{
}

public interface IObjPrntInp
  : IRefObjPrntInp
{
}
public class InputObjPrntInp
  : InputRefObjPrntInp
  , IObjPrntInp
{
}

public interface IRefObjPrntInp
{
}
public class InputRefObjPrntInp
  : IRefObjPrntInp
{
}

public interface IObjPrntOutp
  : IRefObjPrntOutp
{
}
public class OutputObjPrntOutp
  : OutputRefObjPrntOutp
  , IObjPrntOutp
{
}

public interface IRefObjPrntOutp
{
}
public class OutputRefObjPrntOutp
  : IRefObjPrntOutp
{
}

public interface IOutpFieldEnumAlias
{
  Boolean field { get; }
}
public class OutputOutpFieldEnumAlias
  : IOutpFieldEnumAlias
{
  public Boolean field { get; set; }
}

public interface IOutpFieldEnumValue
{
  Boolean field { get; }
}
public class OutputOutpFieldEnumValue
  : IOutpFieldEnumValue
{
  public Boolean field { get; set; }
}

public interface IOutpFieldParam
{
  FldOutpFieldParam field { get; }
}
public class OutputOutpFieldParam
  : IOutpFieldParam
{
  public FldOutpFieldParam field { get; set; }
}

public interface IOutpFieldParam1
{
}
public class InputOutpFieldParam1
  : IOutpFieldParam1
{
}

public interface IOutpFieldParam2
{
}
public class InputOutpFieldParam2
  : IOutpFieldParam2
{
}

public interface IFldOutpFieldParam
{
}
public class DualFldOutpFieldParam
  : IFldOutpFieldParam
{
}

public interface IUnionAlias
{
  Boolean AsBoolean { get; }
  Number AsNumber { get; }
}
public class UnionUnionAlias
  : IUnionAlias
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
}

public interface IUnionDiff
{
  Boolean AsBoolean { get; }
  Number AsNumber { get; }
}
public class UnionUnionDiff
  : IUnionDiff
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }
}

public interface IUnionSame
{
  Boolean AsBoolean { get; }
}
public class UnionUnionSame
  : IUnionSame
{
  public Boolean AsBoolean { get; set; }
}

public interface IUnionSamePrnt
  : IPrntUnionSamePrnt
{
  Boolean AsBoolean { get; }
}
public class UnionUnionSamePrnt
  : UnionPrntUnionSamePrnt
  , IUnionSamePrnt
{
  public Boolean AsBoolean { get; set; }
}

public interface IPrntUnionSamePrnt
{
  String AsString { get; }
}
public class UnionPrntUnionSamePrnt
  : IPrntUnionSamePrnt
{
  public String AsString { get; set; }
}
