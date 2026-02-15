//HintName: test_generic-value+Input_Impl.gen.cs
// Generated from generic-value+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Input;

public class testGnrcValueInp
  : ItestGnrcValueInp
{
}

public class testRefGnrcValueInp<TType>
  : ItestRefGnrcValueInp<TType>
{
  public TType Field { get; set; }
}
