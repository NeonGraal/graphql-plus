//HintName: test_generic-parent-enum-parent+Input_Intf.gen.cs
// Generated from generic-parent-enum-parent+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Input;

public interface ItestGnrcPrntEnumPrntInp
  : ItestFieldGnrcPrntEnumPrntInp
{
  public testGnrcPrntEnumPrntInp GnrcPrntEnumPrntInp { get; set; }
}

public interface ItestGnrcPrntEnumPrntInpField
  : ItestFieldGnrcPrntEnumPrntInpField
{
}

public interface ItestFieldGnrcPrntEnumPrntInp<Tref>
{
  public testFieldGnrcPrntEnumPrntInp FieldGnrcPrntEnumPrntInp { get; set; }
}

public interface ItestFieldGnrcPrntEnumPrntInpField<Tref>
{
  public Tref field { get; set; }
}
