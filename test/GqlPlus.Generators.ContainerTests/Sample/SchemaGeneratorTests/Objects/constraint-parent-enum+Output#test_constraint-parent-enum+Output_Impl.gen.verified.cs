//HintName: test_constraint-parent-enum+Output_Impl.gen.cs
// Generated from constraint-parent-enum+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_enum_Output;

public class testCnstPrntEnumOutp
  : ItestCnstPrntEnumOutp
{
  public ItestRefCnstPrntEnumOutp<testParentCnstPrntEnumOutp> AsRefCnstPrntEnumOutp { get; set; }
  public ItestCnstPrntEnumOutpObject AsCnstPrntEnumOutp { get; set; }
}

public class testRefCnstPrntEnumOutp<TType>
  : ItestRefCnstPrntEnumOutp<TType>
{
  public TType Field { get; set; }
  public ItestRefCnstPrntEnumOutpObject AsRefCnstPrntEnumOutp { get; set; }
}
