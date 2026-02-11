//HintName: test_generic-parent-enum-parent+Input_Intf.gen.cs
// Generated from generic-parent-enum-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Input;

public interface ItestGnrcPrntEnumPrntInp
  : ItestFieldGnrcPrntEnumPrntInp
{
  ItestGnrcPrntEnumPrntInpObject AsGnrcPrntEnumPrntInp { get; }
}

public interface ItestGnrcPrntEnumPrntInpObject
  : ItestFieldGnrcPrntEnumPrntInpObject
{
}

public interface ItestFieldGnrcPrntEnumPrntInp<Tref>
{
  ItestFieldGnrcPrntEnumPrntInpObject AsFieldGnrcPrntEnumPrntInp { get; }
}

public interface ItestFieldGnrcPrntEnumPrntInpObject<Tref>
{
  Tref Field { get; }
}
