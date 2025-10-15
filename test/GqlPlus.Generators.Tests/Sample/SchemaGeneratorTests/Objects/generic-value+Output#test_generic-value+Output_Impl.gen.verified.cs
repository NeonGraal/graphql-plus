//HintName: test_generic-value+Output_Impl.gen.cs
// Generated from generic-value+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Output;

public class OutputtestGnrcValueOutp
  : ItestGnrcValueOutp
{
  public RefGnrcValueOutp<EnumGnrcValueOutp> AsRefGnrcValueOutp { get; set; }
}

public class OutputtestRefGnrcValueOutp<Ttype>
  : ItestRefGnrcValueOutp<Ttype>
{
  public Ttype field { get; set; }
}
