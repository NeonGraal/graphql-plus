//HintName: test_constraint-enum+Output_Impl.gen.cs
// Generated from constraint-enum+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Output;

public class testCnstEnumOutp
  : ItestCnstEnumOutp
{
  public ItestRefCnstEnumOutp<testEnumCnstEnumOutp> AsEnumCnstEnumOutpcnstEnumOutp { get; set; }
  public ItestCnstEnumOutpObject AsCnstEnumOutp { get; set; }
}

public class testRefCnstEnumOutp<TType>
  : ItestRefCnstEnumOutp<TType>
{
  public TType Field { get; set; }
  public ItestRefCnstEnumOutpObject<TType> AsRefCnstEnumOutp { get; set; }
}
