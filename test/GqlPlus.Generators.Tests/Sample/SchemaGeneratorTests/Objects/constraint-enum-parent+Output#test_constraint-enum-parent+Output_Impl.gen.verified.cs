//HintName: test_constraint-enum-parent+Output_Impl.gen.cs
// Generated from constraint-enum-parent+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Output;

public class testCnstEnumPrntOutp
  : ItestCnstEnumPrntOutp
{
  public testRefCnstEnumPrntOutp<testEnumCnstEnumPrntOutp> AsRefCnstEnumPrntOutp { get; set; }
  public testCnstEnumPrntOutp CnstEnumPrntOutp { get; set; }
}

public class testRefCnstEnumPrntOutp<Ttype>
  : ItestRefCnstEnumPrntOutp<Ttype>
{
  public Ttype field { get; set; }
  public testRefCnstEnumPrntOutp RefCnstEnumPrntOutp { get; set; }
}
