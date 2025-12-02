//HintName: test_generic-parent-enum-child+Input_Impl.gen.cs
// Generated from generic-parent-enum-child+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Input;

public class testGnrcPrntEnumChildInp
  : testFieldGnrcPrntEnumChildInp
  , ItestGnrcPrntEnumChildInp
{
  public testGnrcPrntEnumChildInp GnrcPrntEnumChildInp { get; set; }
}

public class testFieldGnrcPrntEnumChildInp<Tref>
  : ItestFieldGnrcPrntEnumChildInp<Tref>
{
  public Tref field { get; set; }
  public testFieldGnrcPrntEnumChildInp FieldGnrcPrntEnumChildInp { get; set; }
}
