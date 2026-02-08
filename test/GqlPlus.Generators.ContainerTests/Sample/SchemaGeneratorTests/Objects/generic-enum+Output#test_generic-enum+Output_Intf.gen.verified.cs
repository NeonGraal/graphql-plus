//HintName: test_generic-enum+Output_Intf.gen.cs
// Generated from generic-enum+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Output;

public interface ItestGnrcEnumOutp
{
  public ItestRefGnrcEnumOutp<ItestEnumGnrcEnumOutp> AsRefGnrcEnumOutp { get; set; }
}

public interface ItestGnrcEnumOutpObject
{
}

public interface ItestRefGnrcEnumOutp<Ttype>
{
}

public interface ItestRefGnrcEnumOutpObject<Ttype>
{
  public Ttype Field { get; set; }
}
