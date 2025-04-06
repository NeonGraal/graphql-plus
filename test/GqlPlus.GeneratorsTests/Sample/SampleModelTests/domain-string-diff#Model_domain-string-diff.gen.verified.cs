//HintName: Model_domain-string-diff.gen.cs
// Generated from domain-string-diff.graphql+

/*
*/

namespace GqlTest.Model_domain_string_diff;

public interface IDomainDmnStrDiff {
  string Value { get; set; }
}
public class DomainDmnStrDiff
  : IDomainDmnStrDiff
{
  string _value;
  string Value { get => _value; set => CheckAndSet(value); }
}
