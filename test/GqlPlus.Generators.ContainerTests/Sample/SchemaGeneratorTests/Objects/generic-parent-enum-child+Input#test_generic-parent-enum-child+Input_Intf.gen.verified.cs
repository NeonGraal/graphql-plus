//HintName: test_generic-parent-enum-child+Input_Intf.gen.cs
// Generated from generic-parent-enum-child+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Input;

public interface ItestGnrcPrntEnumChildInp
  : ItestFieldGnrcPrntEnumChildInp
{
  ItestGnrcPrntEnumChildInpObject AsGnrcPrntEnumChildInp { get; }
}

public interface ItestGnrcPrntEnumChildInpObject
  : ItestFieldGnrcPrntEnumChildInpObject
{
}

public interface ItestFieldGnrcPrntEnumChildInp<Tref>
{
  ItestFieldGnrcPrntEnumChildInpObject AsFieldGnrcPrntEnumChildInp { get; }
}

public interface ItestFieldGnrcPrntEnumChildInpObject<Tref>
{
  Tref Field { get; }
}
