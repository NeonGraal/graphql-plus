//HintName: test_generic-parent-enum-child+Input_Intf.gen.cs
// Generated from generic-parent-enum-child+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Input;

public interface ItestGnrcPrntEnumChildInp
  : ItestFieldGnrcPrntEnumChildInp
{
}

public interface ItestGnrcPrntEnumChildInpObject
  : ItestFieldGnrcPrntEnumChildInpObject
{
}

public interface ItestFieldGnrcPrntEnumChildInp<Tref>
{
}

public interface ItestFieldGnrcPrntEnumChildInpObject<Tref>
{
  public Tref Field { get; set; }
}
