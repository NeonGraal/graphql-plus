//HintName: test_generic-value+Output_Impl.gen.cs
// Generated from generic-value+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Output;

public class testGnrcValueOutp
  : ItestGnrcValueOutp
{
  public ItestRefGnrcValueOutp<testEnumGnrcValueOutp> AsRefGnrcValueOutp { get; set; }
  public ItestGnrcValueOutpObject AsGnrcValueOutp { get; set; }
}

public class testRefGnrcValueOutp<TType>
  : ItestRefGnrcValueOutp<TType>
{
  public TType Field { get; set; }
  public ItestRefGnrcValueOutpObject AsRefGnrcValueOutp { get; set; }
}
