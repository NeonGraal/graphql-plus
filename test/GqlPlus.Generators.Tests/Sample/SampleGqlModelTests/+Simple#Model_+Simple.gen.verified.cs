﻿//HintName: Model_+Simple.gen.cs
// Generated from +Simple.graphql+

/*
*/

namespace GqlTest.Model__Simple;

public interface IDmnBoolDescr
{
}
public class DomainDmnBoolDescr
  : IDmnBoolDescr
{
}

public interface IDmnBoolPrnt
  : I( !Tr I@023/0003 PrntDmnBoolPrnt )
{
}
public class DomainDmnBoolPrnt
  : Domain( !Tr I@023/0003 PrntDmnBoolPrnt )
  , IDmnBoolPrnt
{
}

public interface IPrntDmnBoolPrnt
{
}
public class DomainPrntDmnBoolPrnt
  : IPrntDmnBoolPrnt
{
}

public interface IDmnBoolPrntDescr
  : I( 'Parent comment' !Tr I@044/0006 PrntDmnBoolPrntDescr )
{
}
public class DomainDmnBoolPrntDescr
  : Domain( 'Parent comment' !Tr I@044/0006 PrntDmnBoolPrntDescr )
  , IDmnBoolPrntDescr
{
}

public interface IPrntDmnBoolPrntDescr
{
}
public class DomainPrntDmnBoolPrntDescr
  : IPrntDmnBoolPrntDescr
{
}

public interface IDmnEnumAll
{
}
public class DomainDmnEnumAll
  : IDmnEnumAll
{
}

public enum EnumDmnEnumAll
{
  dmnEnumAll,
  enum_dmnEnumAll,
}

public interface IDmnEnumAllDescr
{
}
public class DomainDmnEnumAllDescr
  : IDmnEnumAllDescr
{
}

public enum EnumDmnEnumAllDescr
{
  dmnEnumAllDescr,
  enum_dmnEnumAllDescr,
}

public interface IDmnEnumAllPrnt
{
}
public class DomainDmnEnumAllPrnt
  : IDmnEnumAllPrnt
{
}

public enum EnumDmnEnumAllPrnt
{
  prnt_dmnEnumAllPrnt = PrntDmnEnumAllPrnt.prnt_dmnEnumAllPrnt,,
  dmnEnumAllPrnt,
}

public enum PrntDmnEnumAllPrnt
{
  prnt_dmnEnumAllPrnt,
}

public interface IDmnEnumDescr
{
}
public class DomainDmnEnumDescr
  : IDmnEnumDescr
{
}

public enum EnumDmnEnumDescr
{
  dmnEnumDescr,
}

public interface IDmnEnumLabel
{
}
public class DomainDmnEnumLabel
  : IDmnEnumLabel
{
}

public enum EnumDmnEnumLabel
{
  dmnEnumLabel,
}

public interface IDmnEnumPrnt
  : I( !Tr I@023/0025 PrntDmnEnumPrnt )
{
}
public class DomainDmnEnumPrnt
  : Domain( !Tr I@023/0025 PrntDmnEnumPrnt )
  , IDmnEnumPrnt
{
}

public interface IPrntDmnEnumPrnt
{
}
public class DomainPrntDmnEnumPrnt
  : IPrntDmnEnumPrnt
{
}

public enum EnumDmnEnumPrnt
{
  enum_dmnEnumPrnt,
  prnt_dmnEnumPrnt,
}

public interface IDmnEnumPrntDescr
  : I( 'Parent comment' !Tr I@044/0029 PrntDmnEnumPrntDescr )
{
}
public class DomainDmnEnumPrntDescr
  : Domain( 'Parent comment' !Tr I@044/0029 PrntDmnEnumPrntDescr )
  , IDmnEnumPrntDescr
{
}

public interface IPrntDmnEnumPrntDescr
{
}
public class DomainPrntDmnEnumPrntDescr
  : IPrntDmnEnumPrntDescr
{
}

public enum EnumDmnEnumPrntDescr
{
  enum_dmnEnumPrntDescr,
  prnt_dmnEnumPrntDescr,
}

public enum EnumDmnEnumUnq
{
  enum_dmnEnumUnq,
  dmnEnumUnq,
}

public enum EnumDomDup
{
  dmnEnumUnq,
  dup_dmnEnumUnq,
}

public enum EnumDmnEnumUnqPrnt
{
  dmnEnumUnqPrnt = PrntDmnEnumUnqPrnt.dmnEnumUnqPrnt,,
  prnt_dmnEnumUnqPrnt = PrntDmnEnumUnqPrnt.prnt_dmnEnumUnqPrnt,,
  enum_dmnEnumUnqPrnt,
}

public enum PrntDmnEnumUnqPrnt
{
  dmnEnumUnqPrnt,
  prnt_dmnEnumUnqPrnt,
}

public enum DupDmnEnumUnqPrnt
{
  dmnEnumUnqPrnt,
  dup_dmnEnumUnqPrnt,
}

public interface IDmnEnumValue
{
}
public class DomainDmnEnumValue
  : IDmnEnumValue
{
}

public enum EnumDmnEnumValue
{
  dmnEnumValue,
}

public interface IDmnEnumValuePrnt
{
}
public class DomainDmnEnumValuePrnt
  : IDmnEnumValuePrnt
{
}

public enum EnumDmnEnumValuePrnt
{
  prnt_dmnEnumValuePrnt = PrntDmnEnumValuePrnt.prnt_dmnEnumValuePrnt,,
  dmnEnumValuePrnt,
}

public enum PrntDmnEnumValuePrnt
{
  prnt_dmnEnumValuePrnt,
}

public interface IDmnNmbrDescr
{
}
public class DomainDmnNmbrDescr
  : IDmnNmbrDescr
{
}

public interface IDmnNmbrPrnt
  : I( !Tr I@023/0051 PrntDmnNmbrPrnt )
{
}
public class DomainDmnNmbrPrnt
  : Domain( !Tr I@023/0051 PrntDmnNmbrPrnt )
  , IDmnNmbrPrnt
{
}

public interface IPrntDmnNmbrPrnt
{
}
public class DomainPrntDmnNmbrPrnt
  : IPrntDmnNmbrPrnt
{
}

public interface IDmnNmbrPrntDescr
  : I( 'Parent comment' !Tr I@044/0054 PrntDmnNmbrPrntDescr )
{
}
public class DomainDmnNmbrPrntDescr
  : Domain( 'Parent comment' !Tr I@044/0054 PrntDmnNmbrPrntDescr )
  , IDmnNmbrPrntDescr
{
}

public interface IPrntDmnNmbrPrntDescr
{
}
public class DomainPrntDmnNmbrPrntDescr
  : IPrntDmnNmbrPrntDescr
{
}

public interface IDmnStrDescr
{
}
public class DomainDmnStrDescr
  : IDmnStrDescr
{
}

public interface IDmnStrPrnt
  : I( !Tr I@022/0059 PrntDmnStrPrnt )
{
}
public class DomainDmnStrPrnt
  : Domain( !Tr I@022/0059 PrntDmnStrPrnt )
  , IDmnStrPrnt
{
}

public interface IPrntDmnStrPrnt
{
}
public class DomainPrntDmnStrPrnt
  : IPrntDmnStrPrnt
{
}

public interface IDmnStrPrntDescr
  : I( 'Parent comment' !Tr I@043/0062 PrntDmnStrPrntDescr )
{
}
public class DomainDmnStrPrntDescr
  : Domain( 'Parent comment' !Tr I@043/0062 PrntDmnStrPrntDescr )
  , IDmnStrPrntDescr
{
}

public interface IPrntDmnStrPrntDescr
{
}
public class DomainPrntDmnStrPrntDescr
  : IPrntDmnStrPrntDescr
{
}

public enum EnumDescr
{
  enumDescr,
}

public enum EnumPrnt
{
  prnt_enumPrnt = PrntEnumPrnt.prnt_enumPrnt,,
  enumPrnt,
}

public enum PrntEnumPrnt
{
  prnt_enumPrnt,
}

public enum EnumPrntAlias
{
  prnt_enumPrntAlias = PrntEnumPrntAlias.prnt_enumPrntAlias,,
  val_enumPrntAlias,
  prnt_enumPrntAlias,
  enumPrntAlias = prnt_enumPrntAlias,
}

public enum PrntEnumPrntAlias
{
  prnt_enumPrntAlias,
}

public enum EnumPrntDescr
{
  prnt_enumPrntDescr = PrntEnumPrntDescr.prnt_enumPrntDescr,,
  enumPrntDescr,
}

public enum PrntEnumPrntDescr
{
  prnt_enumPrntDescr,
}

public enum EnumPrntDup
{
  prnt_enumPrntDup = PrntEnumPrntDup.prnt_enumPrntDup,,
  enumPrntDup = PrntEnumPrntDup.prnt_enumPrntDup,,
  enumPrntDup,
}

public enum PrntEnumPrntDup
{
  prnt_enumPrntDup,
  enumPrntDup = prnt_enumPrntDup,
}

public interface IUnionDescr
{
  Number AsNumber { get; }
}
public class UnionUnionDescr
  : IUnionDescr
{
  public Number AsNumber { get; set; }
}

public interface IUnionPrnt
  : I( !Tr I@020/0081 PrntUnionPrnt )
{
  String AsString { get; }
}
public class UnionUnionPrnt
  : Union( !Tr I@020/0081 PrntUnionPrnt )
  , IUnionPrnt
{
  public String AsString { get; set; }
}

public interface IPrntUnionPrnt
{
  Number AsNumber { get; }
}
public class UnionPrntUnionPrnt
  : IPrntUnionPrnt
{
  public Number AsNumber { get; set; }
}

public interface IUnionPrntDescr
  : I( 'Parent comment' !Tr I@041/0084 PrntUnionPrntDescr )
{
  Number AsNumber { get; }
}
public class UnionUnionPrntDescr
  : Union( 'Parent comment' !Tr I@041/0084 PrntUnionPrntDescr )
  , IUnionPrntDescr
{
  public Number AsNumber { get; set; }
}

public interface IPrntUnionPrntDescr
{
  Number AsNumber { get; }
}
public class UnionPrntUnionPrntDescr
  : IPrntUnionPrntDescr
{
  public Number AsNumber { get; set; }
}

public interface IUnionPrntDup
  : I( !Tr I@023/0087 PrntUnionPrntDup )
{
  Number AsNumber { get; }
}
public class UnionUnionPrntDup
  : Union( !Tr I@023/0087 PrntUnionPrntDup )
  , IUnionPrntDup
{
  public Number AsNumber { get; set; }
}

public interface IPrntUnionPrntDup
{
  Number AsNumber { get; }
}
public class UnionPrntUnionPrntDup
  : IPrntUnionPrntDup
{
  public Number AsNumber { get; set; }
}
