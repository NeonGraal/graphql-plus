//HintName: test_constraint-parent-enum+Output_Impl.gen.cs
// Generated from constraint-parent-enum+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Output;

public class testCnstPrntEnumOutp
  : ItestCnstPrntEnumOutp
{
  public testRefCnstPrntEnumOutp<testParentCnstPrntEnumOutp> AsRefCnstPrntEnumOutp { get; set; }
  public testCnstPrntEnumOutp CnstPrntEnumOutp { get; set; }
}

public class testRefCnstPrntEnumOutp<Ttype>
  : ItestRefCnstPrntEnumOutp<Ttype>
{
  public Ttype field { get; set; }
  public testRefCnstPrntEnumOutp RefCnstPrntEnumOutp { get; set; }
}
