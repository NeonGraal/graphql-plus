//HintName: test_constraint-parent-enum+Output_Impl.gen.cs
// Generated from constraint-parent-enum+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Output;

public class OutputtestCnstPrntEnumOutp
  : ItestCnstPrntEnumOutp
{
  public RefCnstPrntEnumOutp<ParentCnstPrntEnumOutp> AsRefCnstPrntEnumOutp { get; set; }
}

public class OutputtestRefCnstPrntEnumOutp<Ttype>
  : ItestRefCnstPrntEnumOutp<Ttype>
{
  public Ttype field { get; set; }
}
