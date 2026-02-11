//HintName: test_generic-value+Output_Intf.gen.cs
// Generated from generic-value+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Output;

public interface ItestGnrcValueOutp
{
  ItestRefGnrcValueOutp<testEnumGnrcValueOutp> AsRefGnrcValueOutp { get; }
  ItestGnrcValueOutpObject AsGnrcValueOutp { get; }
}

public interface ItestGnrcValueOutpObject
{
}

public interface ItestRefGnrcValueOutp<Ttype>
{
  ItestRefGnrcValueOutpObject AsRefGnrcValueOutp { get; }
}

public interface ItestRefGnrcValueOutpObject<Ttype>
{
  Ttype Field { get; }
}
