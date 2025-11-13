//HintName: test_generic-parent-enum-child+Input_Intf.gen.cs
// Generated from generic-parent-enum-child+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Input;

public interface ItestGnrcPrntEnumChildInp
  : ItestFieldGnrcPrntEnumChildInp
{
  public testGnrcPrntEnumChildInp GnrcPrntEnumChildInp { get; set; }
}

public interface ItestGnrcPrntEnumChildInpField
  : ItestFieldGnrcPrntEnumChildInpField
{
}

public interface ItestFieldGnrcPrntEnumChildInp<Tref>
{
  public testFieldGnrcPrntEnumChildInp FieldGnrcPrntEnumChildInp { get; set; }
}

public interface ItestFieldGnrcPrntEnumChildInpField<Tref>
{
  public Tref field { get; set; }
}
