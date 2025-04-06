//HintName: Model_domain-string-descr.gen.cs
// Generated from domain-string-descr.graphql+

/*
*/

namespace GqlTest.Model_domain_string_descr;

public interface IDomainDmnStrDescr {
  string Value { get; set; }
}
public class DomainDmnStrDescr
  : IDomainDmnStrDescr
{
  string _value;
  string Value { get => _value; set => CheckAndSet(value); }
}
