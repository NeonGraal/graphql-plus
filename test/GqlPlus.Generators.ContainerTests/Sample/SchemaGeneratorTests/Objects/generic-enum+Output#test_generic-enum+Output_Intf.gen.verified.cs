//HintName: test_generic-enum+Output_Intf.gen.cs
// Generated from generic-enum+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Output;

public interface ItestGnrcEnumOutp
{
  ItestRefGnrcEnumOutp<testEnumGnrcEnumOutp> AsRefGnrcEnumOutp { get; }
  ItestGnrcEnumOutpObject AsGnrcEnumOutp { get; }
}

public interface ItestGnrcEnumOutpObject
{
}

public interface ItestRefGnrcEnumOutp<Ttype>
{
  ItestRefGnrcEnumOutpObject AsRefGnrcEnumOutp { get; }
}

public interface ItestRefGnrcEnumOutpObject<Ttype>
{
  Ttype Field { get; }
}
