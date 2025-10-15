//HintName: test_generic-parent-enum-child+Output_Impl.gen.cs
// Generated from generic-parent-enum-child+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Output;

public class OutputtestGnrcPrntEnumChildOutp
  : OutputtestFieldGnrcPrntEnumChildOutp
  , ItestGnrcPrntEnumChildOutp
{
}

public class OutputtestFieldGnrcPrntEnumChildOutp<Tref>
  : ItestFieldGnrcPrntEnumChildOutp<Tref>
{
  public Tref field { get; set; }
}
