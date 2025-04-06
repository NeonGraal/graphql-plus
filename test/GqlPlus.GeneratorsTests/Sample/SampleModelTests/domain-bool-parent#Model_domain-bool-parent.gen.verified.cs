//HintName: Model_domain-bool-parent.gen.cs
// Generated from domain-bool-parent.graphql+

/*
*/

namespace GqlTest.Model_domain_bool_parent;

public interface IDomainDmnBoolPrnt : IDomainPrntDmnBoolPrnt {
  bool Value { get; set; }
}
public class DomainDmnBoolPrnt
  : DomainPrntDmnBoolPrnt
  , IDomainDmnBoolPrnt
{
}

public interface IDomainPrntDmnBoolPrnt {
  bool Value { get; set; }
}
public class DomainPrntDmnBoolPrnt
  : IDomainPrntDmnBoolPrnt
{
}
