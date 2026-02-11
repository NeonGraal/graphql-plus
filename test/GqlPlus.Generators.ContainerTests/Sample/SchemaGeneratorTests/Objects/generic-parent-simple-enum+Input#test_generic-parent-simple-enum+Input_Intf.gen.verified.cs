//HintName: test_generic-parent-simple-enum+Input_Intf.gen.cs
// Generated from generic-parent-simple-enum+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Input;

public interface ItestGnrcPrntSmplEnumInp
  : ItestFieldGnrcPrntSmplEnumInp<testEnumGnrcPrntSmplEnumInp>
{
  ItestGnrcPrntSmplEnumInpObject AsGnrcPrntSmplEnumInp { get; }
}

public interface ItestGnrcPrntSmplEnumInpObject
  : ItestFieldGnrcPrntSmplEnumInpObject<testEnumGnrcPrntSmplEnumInp>
{
}

public interface ItestFieldGnrcPrntSmplEnumInp<TRef>
{
  ItestFieldGnrcPrntSmplEnumInpObject AsFieldGnrcPrntSmplEnumInp { get; }
}

public interface ItestFieldGnrcPrntSmplEnumInpObject<TRef>
{
  TRef Field { get; }
}
