//HintName: Model_-Merges.gen.cs
// Generated from -Merges.graphql+

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
{
}

public interface ICtgrAlias
{
}
public class OutputCtgrAlias
{
}

public interface ICtgrDescr
{
}
public class OutputCtgrDescr
{
}

public interface ICtgrMod
{
}
public class OutputCtgrMod
{
}

public interface IInDrctParam
{
}
public class InputInDrctParam
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
{
}

public interface IInpObj
{
}
public class InputInpObj
{
}

public interface IOutpObj
{
}
public class OutputOutpObj
{
}

public interface IDualObjAlias
{
}
public class DualDualObjAlias
{
}

public interface IInpObjAlias
{
}
public class InputInpObjAlias
{
}

public interface IOutpObjAlias
{
}
public class OutputOutpObjAlias
{
}

public interface IDualObjAlt
{
  DualObjAltType AsDualObjAltType { get; }
}
public class DualDualObjAlt
{
  public DualObjAltType AsDualObjAltType { get; set; }
}

public interface IDualObjAltType
{
}
public class DualDualObjAltType
{
}

public interface IInpObjAlt
{
  InpObjAltType AsInpObjAltType { get; }
}
public class InputInpObjAlt
{
  public InpObjAltType AsInpObjAltType { get; set; }
}

public interface IInpObjAltType
{
}
public class InputInpObjAltType
{
}

public interface IOutpObjAlt
{
  OutpObjAltType AsOutpObjAltType { get; }
}
public class OutputOutpObjAlt
{
  public OutpObjAltType AsOutpObjAltType { get; set; }
}

public interface IOutpObjAltType
{
}
public class OutputOutpObjAltType
{
}

public interface IDualObjField
{
  FldDualObjField field { get; }
}
public class DualDualObjField
{
  public FldDualObjField field { get; set; }
}

public interface IFldDualObjField
{
}
public class DualFldDualObjField
{
}

public interface IInpObjField
{
  FldInpObjField field { get; }
}
public class InputInpObjField
{
  public FldInpObjField field { get; set; }
}

public interface IFldInpObjField
{
}
public class InputFldInpObjField
{
}

public interface IOutpObjField
{
  FldOutpObjField field { get; }
}
public class OutputOutpObjField
{
  public FldOutpObjField field { get; set; }
}

public interface IFldOutpObjField
{
}
public class OutputFldOutpObjField
{
}

public interface IDualObjFieldAlias
{
  FldDualObjFieldAlias field { get; }
}
public class DualDualObjFieldAlias
{
  public FldDualObjFieldAlias field { get; set; }
}

public interface IFldDualObjFieldAlias
{
}
public class DualFldDualObjFieldAlias
{
}

public interface IInpObjFieldAlias
{
  FldInpObjFieldAlias field { get; }
}
public class InputInpObjFieldAlias
{
  public FldInpObjFieldAlias field { get; set; }
}

public interface IFldInpObjFieldAlias
{
}
public class InputFldInpObjFieldAlias
{
}

public interface IOutpObjFieldAlias
{
  FldOutpObjFieldAlias field { get; }
}
public class OutputOutpObjFieldAlias
{
  public FldOutpObjFieldAlias field { get; set; }
}

public interface IFldOutpObjFieldAlias
{
}
public class OutputFldOutpObjFieldAlias
{
}

public interface IDualObjParam
{
  $test test { get; }
  $type type { get; }
}
public class DualDualObjParam
{
  public $test test { get; set; }
  public $type type { get; set; }
}

public interface IInpObjParam
{
  $test test { get; }
  $type type { get; }
}
public class InputInpObjParam
{
  public $test test { get; set; }
  public $type type { get; set; }
}

public interface IOutpObjParam
{
  $test test { get; }
  $type type { get; }
}
public class OutputOutpObjParam
{
  public $test test { get; set; }
  public $type type { get; set; }
}

public interface IDualObjPrnt
{
}
public class DualDualObjPrnt
{
}

public interface IRefDualObjPrnt
{
}
public class DualRefDualObjPrnt
{
}

public interface IInpObjPrnt
{
}
public class InputInpObjPrnt
{
}

public interface IRefInpObjPrnt
{
}
public class InputRefInpObjPrnt
{
}

public interface IOutpObjPrnt
{
}
public class OutputOutpObjPrnt
{
}

public interface IRefOutpObjPrnt
{
}
public class OutputRefOutpObjPrnt
{
}

public interface IOutpFieldEnumAlias
{
  Boolean field { get; }
   Boolean { get; }
}
public class OutputOutpFieldEnumAlias
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
{
  public Boolean field { get; set; }
  public  Boolean { get; set; }
}

public interface IOutpFieldParam
{
  FldOutpFieldParam field { get; }
}
public class OutputOutpFieldParam
{
  public FldOutpFieldParam field { get; set; }
}

public interface IOutpFieldParam1
{
}
public class InputOutpFieldParam1
{
}

public interface IOutpFieldParam2
{
}
public class InputOutpFieldParam2
{
}

public interface IFldOutpFieldParam
{
}
public class DualFldOutpFieldParam
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
  : IUnionSamePrnt
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
