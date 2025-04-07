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

public interface IOutputCtgr {}

public interface IOutputCtgrAlias {}

public interface IOutputCtgrDescr {}

public interface IOutputCtgrMod {}

public interface IInputInDrctParam {}

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

public interface IDualDualObj {}

public interface IInputInpObj {}

public interface IOutputOutpObj {}

public interface IDualDualObjAlias {}

public interface IInputInpObjAlias {}

public interface IOutputOutpObjAlias {}

public interface IDualDualObjAlt {}

public interface IDualDualObjAltType {}

public interface IInputInpObjAlt {}

public interface IInputInpObjAltType {}

public interface IOutputOutpObjAlt {}

public interface IOutputOutpObjAltType {}

public interface IDualDualObjField {}

public interface IDualFldDualObjField {}

public interface IInputInpObjField {}

public interface IInputFldInpObjField {}

public interface IOutputOutpObjField {}

public interface IOutputFldOutpObjField {}

public interface IDualDualObjFieldAlias {}

public interface IDualFldDualObjFieldAlias {}

public interface IInputInpObjFieldAlias {}

public interface IInputFldInpObjFieldAlias {}

public interface IOutputOutpObjFieldAlias {}

public interface IOutputFldOutpObjFieldAlias {}

public interface IDualDualObjParam {}

public interface IInputInpObjParam {}

public interface IOutputOutpObjParam {}

public interface IDualDualObjPrnt {}

public interface IDualRefDualObjPrnt {}

public interface IInputInpObjPrnt {}

public interface IInputRefInpObjPrnt {}

public interface IOutputOutpObjPrnt {}

public interface IOutputRefOutpObjPrnt {}

public interface IOutputOutpFieldEnumAlias {}

public interface IOutputOutpFieldEnumValue {}

public interface IOutputOutpFieldParam {}

public interface IInputOutpFieldParam1 {}

public interface IInputOutpFieldParam2 {}

public interface IDualFldOutpFieldParam {}

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
