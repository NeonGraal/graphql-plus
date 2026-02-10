//HintName: test_constraint-enum+Output_Intf.gen.cs
// Generated from constraint-enum+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Output;

public interface ItestCnstEnumOutp
{
  public ItestRefCnstEnumOutp<testEnumCnstEnumOutp> AsRefCnstEnumOutp { get; set; }
  public ItestCnstEnumOutpObject AsCnstEnumOutp { get; set; }
}

public interface ItestCnstEnumOutpObject
{
}

public interface ItestRefCnstEnumOutp<Ttype>
{
  public ItestRefCnstEnumOutpObject AsRefCnstEnumOutp { get; set; }
}

public interface ItestRefCnstEnumOutpObject<Ttype>
{
  public Ttype Field { get; set; }
}
