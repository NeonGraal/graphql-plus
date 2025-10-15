//HintName: test_constraint-enum-parent+Output_Impl.gen.cs
// Generated from constraint-enum-parent+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Output;

public class OutputtestCnstEnumPrntOutp
  : ItestCnstEnumPrntOutp
{
  public RefCnstEnumPrntOutp<EnumCnstEnumPrntOutp> AsRefCnstEnumPrntOutp { get; set; }
}

public class OutputtestRefCnstEnumPrntOutp<Ttype>
  : ItestRefCnstEnumPrntOutp<Ttype>
{
  public Ttype field { get; set; }
}
