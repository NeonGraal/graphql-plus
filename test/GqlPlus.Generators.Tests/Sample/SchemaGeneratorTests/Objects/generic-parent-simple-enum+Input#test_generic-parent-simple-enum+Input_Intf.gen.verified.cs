//HintName: test_generic-parent-simple-enum+Input_Intf.gen.cs
// Generated from generic-parent-simple-enum+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Input;

public interface ItestGnrcPrntSmplEnumInp
  : ItestFieldGnrcPrntSmplEnumInp
{
  public testGnrcPrntSmplEnumInp GnrcPrntSmplEnumInp { get; set; }
}

public interface ItestGnrcPrntSmplEnumInpField
  : ItestFieldGnrcPrntSmplEnumInpField
{
}

public interface ItestFieldGnrcPrntSmplEnumInp<Tref>
{
  public testFieldGnrcPrntSmplEnumInp FieldGnrcPrntSmplEnumInp { get; set; }
}

public interface ItestFieldGnrcPrntSmplEnumInpField<Tref>
{
  public Tref field { get; set; }
}
