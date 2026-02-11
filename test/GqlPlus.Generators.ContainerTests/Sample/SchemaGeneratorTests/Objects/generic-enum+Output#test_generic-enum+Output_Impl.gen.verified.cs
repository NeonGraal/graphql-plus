//HintName: test_generic-enum+Output_Impl.gen.cs
// Generated from generic-enum+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Output;

public class testGnrcEnumOutp
  : ItestGnrcEnumOutp
{
  public ItestRefGnrcEnumOutp<testEnumGnrcEnumOutp> AsEnumGnrcEnumOutpgnrcEnumOutp { get; set; }
  public ItestGnrcEnumOutpObject AsGnrcEnumOutp { get; set; }
}

public class testRefGnrcEnumOutp<TType>
  : ItestRefGnrcEnumOutp<TType>
{
  public TType Field { get; set; }
  public ItestRefGnrcEnumOutpObject AsRefGnrcEnumOutp { get; set; }
}
