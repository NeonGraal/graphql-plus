//HintName: test_generic-parent-enum-parent+Output_Intf.gen.cs
// Generated from generic-parent-enum-parent+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Output;

public interface ItestGnrcPrntEnumPrntOutp
  : ItestFieldGnrcPrntEnumPrntOutp
{
  public testGnrcPrntEnumPrntOutp GnrcPrntEnumPrntOutp { get; set; }
}

public interface ItestGnrcPrntEnumPrntOutpField
  : ItestFieldGnrcPrntEnumPrntOutpField
{
}

public interface ItestFieldGnrcPrntEnumPrntOutp<Tref>
{
  public testFieldGnrcPrntEnumPrntOutp FieldGnrcPrntEnumPrntOutp { get; set; }
}

public interface ItestFieldGnrcPrntEnumPrntOutpField<Tref>
{
  public Tref field { get; set; }
}
