//HintName: test_constraint-enum+Output_Impl.gen.cs
// Generated from constraint-enum+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Output;

public class testCnstEnumOutp
  : ItestCnstEnumOutp
{
  public ItestRefCnstEnumOutp<ItestEnumCnstEnumOutp> AsRefCnstEnumOutp { get; set; }
}

public class testRefCnstEnumOutp<Ttype>
  : ItestRefCnstEnumOutp<Ttype>
{
  public Ttype Field { get; set; }
}
