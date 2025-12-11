//HintName: test_generic-parent-simple-enum+Output_Intf.gen.cs
// Generated from generic-parent-simple-enum+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Output;

public interface ItestGnrcPrntSmplEnumOutp
  : ItestFieldGnrcPrntSmplEnumOutp
{
  public testGnrcPrntSmplEnumOutp GnrcPrntSmplEnumOutp { get; set; }
}

public interface ItestGnrcPrntSmplEnumOutpField
  : ItestFieldGnrcPrntSmplEnumOutpField
{
}

public interface ItestFieldGnrcPrntSmplEnumOutp<Tref>
{
  public testFieldGnrcPrntSmplEnumOutp FieldGnrcPrntSmplEnumOutp { get; set; }
}

public interface ItestFieldGnrcPrntSmplEnumOutpField<Tref>
{
  public Tref field { get; set; }
}
