//HintName: test_generic-parent-enum-parent+Output_Impl.gen.cs
// Generated from generic-parent-enum-parent+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Output;

public class testGnrcPrntEnumPrntOutp
  : testFieldGnrcPrntEnumPrntOutp
  , ItestGnrcPrntEnumPrntOutp
{
  public testGnrcPrntEnumPrntOutp GnrcPrntEnumPrntOutp { get; set; }
}

public class testFieldGnrcPrntEnumPrntOutp<Tref>
  : ItestFieldGnrcPrntEnumPrntOutp<Tref>
{
  public Tref field { get; set; }
  public testFieldGnrcPrntEnumPrntOutp FieldGnrcPrntEnumPrntOutp { get; set; }
}
