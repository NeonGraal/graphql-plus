//HintName: test_constraint-enum+Output_Impl.gen.cs
// Generated from constraint-enum+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Output;

public class OutputtestCnstEnumOutp
  : ItestCnstEnumOutp
{
  public RefCnstEnumOutp<EnumCnstEnumOutp> AsRefCnstEnumOutp { get; set; }
}

public class OutputtestRefCnstEnumOutp<Ttype>
  : ItestRefCnstEnumOutp<Ttype>
{
  public Ttype field { get; set; }
}
