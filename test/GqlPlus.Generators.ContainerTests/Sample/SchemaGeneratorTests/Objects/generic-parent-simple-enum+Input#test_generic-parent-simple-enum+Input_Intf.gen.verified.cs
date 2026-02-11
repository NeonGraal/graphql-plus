//HintName: test_generic-parent-simple-enum+Input_Intf.gen.cs
// Generated from generic-parent-simple-enum+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Input;

public interface ItestGnrcPrntSmplEnumInp
  : ItestFieldGnrcPrntSmplEnumInp
{
  ItestGnrcPrntSmplEnumInpObject AsGnrcPrntSmplEnumInp { get; }
}

public interface ItestGnrcPrntSmplEnumInpObject
  : ItestFieldGnrcPrntSmplEnumInpObject
{
}

public interface ItestFieldGnrcPrntSmplEnumInp<Tref>
{
  ItestFieldGnrcPrntSmplEnumInpObject AsFieldGnrcPrntSmplEnumInp { get; }
}

public interface ItestFieldGnrcPrntSmplEnumInpObject<Tref>
{
  Tref Field { get; }
}
