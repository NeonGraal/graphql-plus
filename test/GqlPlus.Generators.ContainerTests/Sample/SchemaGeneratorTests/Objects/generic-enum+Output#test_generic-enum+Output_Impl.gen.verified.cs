//HintName: test_generic-enum+Output_Impl.gen.cs
// Generated from generic-enum+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Output;

public class testGnrcEnumOutp
  : ItestGnrcEnumOutp
{
  public ItestRefGnrcEnumOutp<ItestEnumGnrcEnumOutp> AsRefGnrcEnumOutp { get; set; }
}

public class testRefGnrcEnumOutp<Ttype>
  : ItestRefGnrcEnumOutp<Ttype>
{
  public Ttype Field { get; set; }
}
