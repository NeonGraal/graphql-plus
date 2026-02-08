//HintName: test_generic-parent-enum-child+Output_Intf.gen.cs
// Generated from generic-parent-enum-child+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Output;

public interface ItestGnrcPrntEnumChildOutp
  : ItestFieldGnrcPrntEnumChildOutp
{
  public ItestGnrcPrntEnumChildOutpObject AsGnrcPrntEnumChildOutp { get; set; }
}

public interface ItestGnrcPrntEnumChildOutpObject
  : ItestFieldGnrcPrntEnumChildOutpObject
{
}

public interface ItestFieldGnrcPrntEnumChildOutp<Tref>
{
  public ItestFieldGnrcPrntEnumChildOutpObject AsFieldGnrcPrntEnumChildOutp { get; set; }
}

public interface ItestFieldGnrcPrntEnumChildOutpObject<Tref>
{
  public Tref Field { get; set; }
}
