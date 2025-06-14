//HintName: Model_domain-number-parent-descr.gen.cs
// Generated from domain-number-parent-descr.graphql+

/*
*/

namespace GqlTest.Model_domain_number_parent_descr;

public interface IDmnNmbrPrntDescr
  : I( 'Parent comment' !Tr I@044/0001 PrntDmnNmbrPrntDescr )
{
}
public class DomainDmnNmbrPrntDescr
  : Domain( 'Parent comment' !Tr I@044/0001 PrntDmnNmbrPrntDescr )
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
