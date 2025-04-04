//HintName: Model_all.gen.cs
// Generated from all.graphql+

/*
Category all
Directive all
Option Schema
*/

namespace GqlTest.Model_all;

public interface IDomainGuid {
  string Value { get; set; }
}
public class DomainGuid
  : IDomainGuid
{
  string _value;
  string Value { get => _value; set => CheckAndSet(value); }
}

public enum One {
  Two,
  Three,
}

public interface IUnionMany {}

public interface IDualField {}

public interface IInputParam {}

public interface IOutputAll {}
