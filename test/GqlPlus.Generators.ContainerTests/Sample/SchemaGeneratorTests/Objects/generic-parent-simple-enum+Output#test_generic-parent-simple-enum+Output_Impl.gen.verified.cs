//HintName: test_generic-parent-simple-enum+Output_Impl.gen.cs
// Generated from generic-parent-simple-enum+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Output;

public class testGnrcPrntSmplEnumOutp
  : testFieldGnrcPrntSmplEnumOutp
  , ItestGnrcPrntSmplEnumOutp
{
  public ItestGnrcPrntSmplEnumOutpObject AsGnrcPrntSmplEnumOutp { get; set; }
}

public class testFieldGnrcPrntSmplEnumOutp<Tref>
  : ItestFieldGnrcPrntSmplEnumOutp<Tref>
{
  public Tref Field { get; set; }
  public ItestFieldGnrcPrntSmplEnumOutpObject AsFieldGnrcPrntSmplEnumOutp { get; set; }
}
