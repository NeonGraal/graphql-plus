//HintName: test_generic-parent-simple-enum+Input_Impl.gen.cs
// Generated from generic-parent-simple-enum+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Input;

public class InputtestGnrcPrntSmplEnumInp
  : InputtestFieldGnrcPrntSmplEnumInp
  , ItestGnrcPrntSmplEnumInp
{
}

public class InputtestFieldGnrcPrntSmplEnumInp<Tref>
  : ItestFieldGnrcPrntSmplEnumInp<Tref>
{
  public Tref field { get; set; }
}
