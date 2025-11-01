//HintName: test_constraint-enum+Output_Intf.gen.cs
// Generated from constraint-enum+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Output;

public interface ItestCnstEnumOutp
{
  public testRefCnstEnumOutp<testEnumCnstEnumOutp> AsRefCnstEnumOutp { get; set; }
  public testCnstEnumOutp CnstEnumOutp { get; set; }
}

public interface ItestCnstEnumOutpField
{
}

public interface ItestRefCnstEnumOutp<Ttype>
{
  public testRefCnstEnumOutp RefCnstEnumOutp { get; set; }
}

public interface ItestRefCnstEnumOutpField<Ttype>
{
  public Ttype field { get; set; }
}
