//HintName: test_parent+Input_Impl.gen.cs
// Generated from parent+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_Input;

public class InputtestPrntInp
  : InputtestRefPrntInp
  , ItestPrntInp
{
}

public class InputtestRefPrntInp
  : ItestRefPrntInp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
