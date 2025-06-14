//HintName: Model_domain-string-parent-descr.gen.cs
// Generated from domain-string-parent-descr.graphql+

/*
*/

namespace GqlTest.Model_domain_string_parent_descr;

public interface IDmnStrPrntDescr
  : I( 'Parent comment' !Tr I@043/0001 PrntDmnStrPrntDescr )
{
}
public class DomainDmnStrPrntDescr
  : Domain( 'Parent comment' !Tr I@043/0001 PrntDmnStrPrntDescr )
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
