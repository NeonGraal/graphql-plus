//HintName: test_constraint-parent-enum+Output_Intf.gen.cs
// Generated from constraint-parent-enum+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Output;

public interface ItestCnstPrntEnumOutp
{
  public testRefCnstPrntEnumOutp<testParentCnstPrntEnumOutp> AsRefCnstPrntEnumOutp { get; set; }
  public testCnstPrntEnumOutp CnstPrntEnumOutp { get; set; }
}

public interface ItestCnstPrntEnumOutpField
{
}

public interface ItestRefCnstPrntEnumOutp<Ttype>
{
  public testRefCnstPrntEnumOutp RefCnstPrntEnumOutp { get; set; }
}

public interface ItestRefCnstPrntEnumOutpField<Ttype>
{
  public Ttype field { get; set; }
}
