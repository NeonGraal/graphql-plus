//HintName: test_generic-parent-enum-parent+Output_Intf.gen.cs
// Generated from generic-parent-enum-parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Output;

public interface ItestGnrcPrntEnumPrntOutp
  : ItestFieldGnrcPrntEnumPrntOutp
{
  public ItestGnrcPrntEnumPrntOutpObject AsGnrcPrntEnumPrntOutp { get; set; }
}

public interface ItestGnrcPrntEnumPrntOutpObject
  : ItestFieldGnrcPrntEnumPrntOutpObject
{
}

public interface ItestFieldGnrcPrntEnumPrntOutp<Tref>
{
  public ItestFieldGnrcPrntEnumPrntOutpObject AsFieldGnrcPrntEnumPrntOutp { get; set; }
}

public interface ItestFieldGnrcPrntEnumPrntOutpObject<Tref>
{
  public Tref Field { get; set; }
}
