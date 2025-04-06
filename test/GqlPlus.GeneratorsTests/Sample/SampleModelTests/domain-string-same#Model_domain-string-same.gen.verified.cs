//HintName: Model_domain-string-same.gen.cs
// Generated from domain-string-same.graphql+

/*
*/

namespace GqlTest.Model_domain_string_same;

public interface IDomainDmnStrSame {
  string Value { get; set; }
}
public class DomainDmnStrSame
  : IDomainDmnStrSame
{
  string _value;
  string Value { get => _value; set => CheckAndSet(value); }
}
