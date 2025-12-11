//HintName: test_generic-enum+Output_Impl.gen.cs
// Generated from generic-enum+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Output;

public class testGnrcEnumOutp
  : ItestGnrcEnumOutp
{
  public testRefGnrcEnumOutp<testEnumGnrcEnumOutp> AsRefGnrcEnumOutp { get; set; }
  public testGnrcEnumOutp GnrcEnumOutp { get; set; }
}

public class testRefGnrcEnumOutp<Ttype>
  : ItestRefGnrcEnumOutp<Ttype>
{
  public Ttype field { get; set; }
  public testRefGnrcEnumOutp RefGnrcEnumOutp { get; set; }
}
