//HintName: Model_domain-enum-parent-descr.gen.cs
// Generated from domain-enum-parent-descr.graphql+

/*
*/

namespace GqlTest.Model_domain_enum_parent_descr;

public interface IDmnEnumPrntDescr
  : I( 'Parent comment' !Tr I@044/0001 PrntDmnEnumPrntDescr )
{
}
public class DomainDmnEnumPrntDescr
  : Domain( 'Parent comment' !Tr I@044/0001 PrntDmnEnumPrntDescr )
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
