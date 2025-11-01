//HintName: test_constraint-enum+Output_Impl.gen.cs
// Generated from constraint-enum+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Output;

public class testCnstEnumOutp
  : ItestCnstEnumOutp
{
  public testRefCnstEnumOutp<testEnumCnstEnumOutp> AsRefCnstEnumOutp { get; set; }
  public testCnstEnumOutp CnstEnumOutp { get; set; }
}

public class testRefCnstEnumOutp<Ttype>
  : ItestRefCnstEnumOutp<Ttype>
{
  public Ttype field { get; set; }
  public testRefCnstEnumOutp RefCnstEnumOutp { get; set; }
}
