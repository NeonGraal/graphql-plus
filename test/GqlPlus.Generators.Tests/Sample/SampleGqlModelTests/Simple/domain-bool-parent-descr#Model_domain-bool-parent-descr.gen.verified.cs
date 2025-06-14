//HintName: Model_domain-bool-parent-descr.gen.cs
// Generated from domain-bool-parent-descr.graphql+

/*
*/

namespace GqlTest.Model_domain_bool_parent_descr;

public interface IDmnBoolPrntDescr
  : I( 'Parent comment' !Tr I@044/0001 PrntDmnBoolPrntDescr )
{
}
public class DomainDmnBoolPrntDescr
  : Domain( 'Parent comment' !Tr I@044/0001 PrntDmnBoolPrntDescr )
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
