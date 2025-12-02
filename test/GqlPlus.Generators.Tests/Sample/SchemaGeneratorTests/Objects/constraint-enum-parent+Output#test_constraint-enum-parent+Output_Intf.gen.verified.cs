//HintName: test_constraint-enum-parent+Output_Intf.gen.cs
// Generated from constraint-enum-parent+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Output;

public interface ItestCnstEnumPrntOutp
{
  public testRefCnstEnumPrntOutp<testEnumCnstEnumPrntOutp> AsRefCnstEnumPrntOutp { get; set; }
  public testCnstEnumPrntOutp CnstEnumPrntOutp { get; set; }
}

public interface ItestCnstEnumPrntOutpField
{
}

public interface ItestRefCnstEnumPrntOutp<Ttype>
{
  public testRefCnstEnumPrntOutp RefCnstEnumPrntOutp { get; set; }
}

public interface ItestRefCnstEnumPrntOutpField<Ttype>
{
  public Ttype field { get; set; }
}
