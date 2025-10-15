//HintName: test_parent-descr+Output_Impl.gen.cs
// Generated from parent-descr+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Output;

public class OutputtestPrntDescrOutp
  : OutputtestRefPrntDescrOutp
  , ItestPrntDescrOutp
{
}

public class OutputtestRefPrntDescrOutp
  : ItestRefPrntDescrOutp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
