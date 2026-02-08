//HintName: test_generic-value+Output_Intf.gen.cs
// Generated from generic-value+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Output;

public interface ItestGnrcValueOutp
{
  public ItestRefGnrcValueOutp<ItestEnumGnrcValueOutp> AsRefGnrcValueOutp { get; set; }
}

public interface ItestGnrcValueOutpObject
{
}

public interface ItestRefGnrcValueOutp<Ttype>
{
}

public interface ItestRefGnrcValueOutpObject<Ttype>
{
  public Ttype Field { get; set; }
}
