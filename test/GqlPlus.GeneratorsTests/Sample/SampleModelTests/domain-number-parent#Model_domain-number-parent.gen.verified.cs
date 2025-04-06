//HintName: Model_domain-number-parent.gen.cs
// Generated from domain-number-parent.graphql+

/*
*/

namespace GqlTest.Model_domain_number_parent;

public interface IDomainDmnNmbrPrnt : IDomainPrntDmnNmbrPrnt {
  decimal Value { get; set; }
}
public class DomainDmnNmbrPrnt
  : DomainPrntDmnNmbrPrnt
  , IDomainDmnNmbrPrnt
{
}

public interface IDomainPrntDmnNmbrPrnt {
  decimal Value { get; set; }
}
public class DomainPrntDmnNmbrPrnt
  : IDomainPrntDmnNmbrPrnt
{
}
