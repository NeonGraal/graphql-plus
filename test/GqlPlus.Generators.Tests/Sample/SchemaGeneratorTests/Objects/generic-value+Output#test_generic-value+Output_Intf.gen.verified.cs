//HintName: test_generic-value+Output_Intf.gen.cs
// Generated from generic-value+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Output;

public interface ItestGnrcValueOutp
{
  RefGnrcValueOutp<EnumGnrcValueOutp> AsRefGnrcValueOutp { get; }
}

public interface ItestRefGnrcValueOutp<Ttype>
{
  Ttype field { get; }
}
