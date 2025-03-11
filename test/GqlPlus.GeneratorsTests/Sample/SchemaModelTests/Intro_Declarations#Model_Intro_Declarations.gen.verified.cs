//HintName: Model_Intro_Declarations.gen.cs
// Generated from Intro_Declarations.graphql+

/*
*/

namespace GqlTest.Model_Intro_Declarations;

public interface IOutput_Schema {}

public interface IDomain_Identifier {
  string Value { get; set; }
}
public class Domain_Identifier
  : IDomain_Identifier
{
  string _value;
  string Value { get => _value; set => CheckAndSet(value); }
}

public interface IInput_Filter {}

public interface IDomain_NameFilter {
  string Value { get; set; }
}
public class Domain_NameFilter
  : IDomain_NameFilter
{
  string _value;
  string Value { get => _value; set => CheckAndSet(value); }
}

public interface IInput_CategoryFilter {}

public interface IInput_TypeFilter {}
