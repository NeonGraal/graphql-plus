//HintName: Model_domain-string.gen.cs
// Generated from domain-string.graphql+

/*
*/

namespace GqlTest.Model_domain_string;

public interface IDomainDmnStr {
  string Value { get; set; }
}
public class DomainDmnStr
  : IDomainDmnStr
{
  string _value;
  string Value { get => _value; set => CheckAndSet(value); }
}
