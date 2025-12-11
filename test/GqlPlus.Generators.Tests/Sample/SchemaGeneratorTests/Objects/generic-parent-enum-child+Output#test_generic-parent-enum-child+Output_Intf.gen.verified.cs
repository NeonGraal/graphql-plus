//HintName: test_generic-parent-enum-child+Output_Intf.gen.cs
// Generated from generic-parent-enum-child+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Output;

public interface ItestGnrcPrntEnumChildOutp
  : ItestFieldGnrcPrntEnumChildOutp
{
  public testGnrcPrntEnumChildOutp GnrcPrntEnumChildOutp { get; set; }
}

public interface ItestGnrcPrntEnumChildOutpField
  : ItestFieldGnrcPrntEnumChildOutpField
{
}

public interface ItestFieldGnrcPrntEnumChildOutp<Tref>
{
  public testFieldGnrcPrntEnumChildOutp FieldGnrcPrntEnumChildOutp { get; set; }
}

public interface ItestFieldGnrcPrntEnumChildOutpField<Tref>
{
  public Tref field { get; set; }
}
