//HintName: test_generic-parent-simple-enum+Output_Intf.gen.cs
// Generated from generic-parent-simple-enum+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Output;

public interface ItestGnrcPrntSmplEnumOutp
  : ItestFieldGnrcPrntSmplEnumOutp
{
  ItestGnrcPrntSmplEnumOutpObject AsGnrcPrntSmplEnumOutp { get; }
}

public interface ItestGnrcPrntSmplEnumOutpObject
  : ItestFieldGnrcPrntSmplEnumOutpObject
{
}

public interface ItestFieldGnrcPrntSmplEnumOutp<Tref>
{
  ItestFieldGnrcPrntSmplEnumOutpObject AsFieldGnrcPrntSmplEnumOutp { get; }
}

public interface ItestFieldGnrcPrntSmplEnumOutpObject<Tref>
{
  Tref Field { get; }
}
