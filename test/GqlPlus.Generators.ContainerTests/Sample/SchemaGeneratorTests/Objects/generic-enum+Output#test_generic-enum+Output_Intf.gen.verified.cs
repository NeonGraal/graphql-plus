//HintName: test_generic-enum+Output_Intf.gen.cs
// Generated from generic-enum+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Output;

public interface ItestGnrcEnumOutp
{
  ItestRefGnrcEnumOutp<testEnumGnrcEnumOutp> AsEnumGnrcEnumOutpgnrcEnumOutp { get; }
  ItestGnrcEnumOutpObject AsGnrcEnumOutp { get; }
}

public interface ItestGnrcEnumOutpObject
{
}

public interface ItestRefGnrcEnumOutp<TType>
{
  ItestRefGnrcEnumOutpObject AsRefGnrcEnumOutp { get; }
}

public interface ItestRefGnrcEnumOutpObject<TType>
{
  TType Field { get; }
}
