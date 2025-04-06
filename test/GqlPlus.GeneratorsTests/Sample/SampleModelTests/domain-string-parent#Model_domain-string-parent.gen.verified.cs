//HintName: Model_domain-string-parent.gen.cs
// Generated from domain-string-parent.graphql+

/*
*/

namespace GqlTest.Model_domain_string_parent;

public interface IDomainDmnStrPrnt : IDomainPrntDmnStrPrnt {
  string Value { get; set; }
}
public class DomainDmnStrPrnt
  : DomainPrntDmnStrPrnt
  , IDomainDmnStrPrnt
{
  string _value;
  string Value { get => _value; set => CheckAndSet(value); }
}

public interface IDomainPrntDmnStrPrnt {
  string Value { get; set; }
}
public class DomainPrntDmnStrPrnt
  : IDomainPrntDmnStrPrnt
{
  string _value;
  string Value { get => _value; set => CheckAndSet(value); }
}
