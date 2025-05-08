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

public interface IDualObj
{
}
public class DualDualObj
  : IDualObj
{
}

public interface IInpObj
{
}
public class InputInpObj
  : IInpObj
{
}

public interface IOutpObj
{
}
public class OutputOutpObj
  : IOutpObj
{
}

public interface IDualObjAlias
{
}
public class DualDualObjAlias
  : IDualObjAlias
{
}

public interface IInpObjAlias
{
}
public class InputInpObjAlias
  : IInpObjAlias
{
}

public interface IOutpObjAlias
{
}
public class OutputOutpObjAlias
  : IOutpObjAlias
{
}

public interface IDualObjAlt
{
  DualObjAltType AsDualObjAltType { get; }
}
public class DualDualObjAlt
  : IDualObjAlt
{
  public DualObjAltType AsDualObjAltType { get; set; }
}

public interface IDualObjAltType
{
}
public class DualDualObjAltType
  : IDualObjAltType
{
}

public interface IInpObjAlt
{
  InpObjAltType AsInpObjAltType { get; }
}
public class InputInpObjAlt
  : IInpObjAlt
{
  public InpObjAltType AsInpObjAltType { get; set; }
}

public interface IInpObjAltType
{
}
public class InputInpObjAltType
  : IInpObjAltType
{
}

public interface IOutpObjAlt
{
  OutpObjAltType AsOutpObjAltType { get; }
}
public class OutputOutpObjAlt
  : IOutpObjAlt
{
  public OutpObjAltType AsOutpObjAltType { get; set; }
}

public interface IOutpObjAltType
{
}
public class OutputOutpObjAltType
  : IOutpObjAltType
{
}

public interface IDualObjField
{
  FldDualObjField field { get; }
}
public class DualDualObjField
  : IDualObjField
{
  public FldDualObjField field { get; set; }
}

public interface IFldDualObjField
{
}
public class DualFldDualObjField
  : IFldDualObjField
{
}

public interface IInpObjField
{
  FldInpObjField field { get; }
}
public class InputInpObjField
  : IInpObjField
{
  public FldInpObjField field { get; set; }
}

public interface IFldInpObjField
{
}
public class InputFldInpObjField
  : IFldInpObjField
{
}

public interface IOutpObjField
{
  FldOutpObjField field { get; }
}
public class OutputOutpObjField
  : IOutpObjField
{
  public FldOutpObjField field { get; set; }
}

public interface IFldOutpObjField
{
}
public class OutputFldOutpObjField
  : IFldOutpObjField
{
}

public interface IDualObjFieldAlias
{
  FldDualObjFieldAlias field { get; }
}
public class DualDualObjFieldAlias
  : IDualObjFieldAlias
{
  public FldDualObjFieldAlias field { get; set; }
}

public interface IFldDualObjFieldAlias
{
}
public class DualFldDualObjFieldAlias
  : IFldDualObjFieldAlias
{
}

public interface IInpObjFieldAlias
{
  FldInpObjFieldAlias field { get; }
}
public class InputInpObjFieldAlias
  : IInpObjFieldAlias
{
  public FldInpObjFieldAlias field { get; set; }
}

public interface IFldInpObjFieldAlias
{
}
public class InputFldInpObjFieldAlias
  : IFldInpObjFieldAlias
{
}

public interface IOutpObjFieldAlias
{
  FldOutpObjFieldAlias field { get; }
}
public class OutputOutpObjFieldAlias
  : IOutpObjFieldAlias
{
  public FldOutpObjFieldAlias field { get; set; }
}

public interface IFldOutpObjFieldAlias
{
}
public class OutputFldOutpObjFieldAlias
  : IFldOutpObjFieldAlias
{
}

public interface IDualObjParam<Ttest,Ttype>
{
  Ttest test { get; }
  Ttype type { get; }
}
public class DualDualObjParam<Ttest,Ttype>
  : IDualObjParam<Ttest,Ttype>
{
  public Ttest test { get; set; }
  public Ttype type { get; set; }
}

public interface IInpObjParam<Ttest,Ttype>
{
  Ttest test { get; }
  Ttype type { get; }
}
public class InputInpObjParam<Ttest,Ttype>
  : IInpObjParam<Ttest,Ttype>
{
  public Ttest test { get; set; }
  public Ttype type { get; set; }
}

public interface IOutpObjParam<Ttest,Ttype>
{
  Ttest test { get; }
  Ttype type { get; }
}
public class OutputOutpObjParam<Ttest,Ttype>
  : IOutpObjParam<Ttest,Ttype>
{
  public Ttest test { get; set; }
  public Ttype type { get; set; }
}

public interface IDualObjPrnt
  : IRefDualObjPrnt
{
}
public class DualDualObjPrnt
  : DualRefDualObjPrnt
  , IDualObjPrnt
{
}

public interface IRefDualObjPrnt
{
}
public class DualRefDualObjPrnt
  : IRefDualObjPrnt
{
}

public interface IInpObjPrnt
  : IRefInpObjPrnt
{
}
public class InputInpObjPrnt
  : InputRefInpObjPrnt
  , IInpObjPrnt
{
}

public interface IRefInpObjPrnt
{
}
public class InputRefInpObjPrnt
  : IRefInpObjPrnt
{
}

public interface IOutpObjPrnt
  : IRefOutpObjPrnt
{
}
public class OutputOutpObjPrnt
  : OutputRefOutpObjPrnt
  , IOutpObjPrnt
{
}

public interface IRefOutpObjPrnt
{
}
public class OutputRefOutpObjPrnt
  : IRefOutpObjPrnt
{
}

public interface IOutpFieldEnumAlias
{
  Boolean field { get; }
   Boolean { get; }
}
public class OutputOutpFieldEnumAlias
  : IOutpFieldEnumAlias
{
  public Boolean field { get; set; }
  public  Boolean { get; set; }
}

public interface IOutpFieldEnumValue
{
  Boolean field { get; }
   Boolean { get; }
}
public class OutputOutpFieldEnumValue
  : IOutpFieldEnumValue
{
  public Boolean field { get; set; }
  public  Boolean { get; set; }
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
