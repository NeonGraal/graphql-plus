//HintName: test_generic-parent-simple-enum+Output_Intf.gen.cs
// Generated from generic-parent-simple-enum+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Output;

public interface ItestGnrcPrntSmplEnumOutp
  : ItestFieldGnrcPrntSmplEnumOutp
{
  public ItestGnrcPrntSmplEnumOutpObject AsGnrcPrntSmplEnumOutp { get; set; }
}

public interface ItestGnrcPrntSmplEnumOutpObject
  : ItestFieldGnrcPrntSmplEnumOutpObject
{
}

public interface ItestFieldGnrcPrntSmplEnumOutp<Tref>
{
  public ItestFieldGnrcPrntSmplEnumOutpObject AsFieldGnrcPrntSmplEnumOutp { get; set; }
}

public interface ItestFieldGnrcPrntSmplEnumOutpObject<Tref>
{
  public Tref Field { get; set; }
}
