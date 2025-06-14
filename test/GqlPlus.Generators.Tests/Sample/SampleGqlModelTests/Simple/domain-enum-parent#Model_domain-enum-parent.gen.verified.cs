//HintName: Model_domain-enum-parent.gen.cs
// Generated from domain-enum-parent.graphql+

/*
*/

namespace GqlTest.Model_domain_enum_parent;

public interface IDmnEnumPrnt
  : I( !Tr I@023/0001 PrntDmnEnumPrnt )
{
}
public class DomainDmnEnumPrnt
  : Domain( !Tr I@023/0001 PrntDmnEnumPrnt )
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
