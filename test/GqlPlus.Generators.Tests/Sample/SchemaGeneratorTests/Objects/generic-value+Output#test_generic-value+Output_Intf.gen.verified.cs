//HintName: test_generic-value+Output_Intf.gen.cs
// Generated from generic-value+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Output;

public interface ItestGnrcValueOutp
{
  public testRefGnrcValueOutp<testEnumGnrcValueOutp> AsRefGnrcValueOutp { get; set; }
  public testGnrcValueOutp GnrcValueOutp { get; set; }
}

public interface ItestGnrcValueOutpField
{
}

public interface ItestRefGnrcValueOutp<Ttype>
{
  public testRefGnrcValueOutp RefGnrcValueOutp { get; set; }
}

public interface ItestRefGnrcValueOutpField<Ttype>
{
  public Ttype field { get; set; }
}
