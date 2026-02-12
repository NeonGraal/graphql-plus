//HintName: test_generic-parent-simple-enum+Output_Impl.gen.cs
// Generated from generic-parent-simple-enum+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Output;

public class testGnrcPrntSmplEnumOutp
  : testFieldGnrcPrntSmplEnumOutp<testEnumGnrcPrntSmplEnumOutp>
  , ItestGnrcPrntSmplEnumOutp
{
  public ItestGnrcPrntSmplEnumOutpObject AsGnrcPrntSmplEnumOutp { get; set; }
}

public class testFieldGnrcPrntSmplEnumOutp<TRef>
  : ItestFieldGnrcPrntSmplEnumOutp<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntSmplEnumOutpObject<TRef> AsFieldGnrcPrntSmplEnumOutp { get; set; }
}
