//HintName: test_parent-field+Input_Impl.gen.cs
// Generated from parent-field+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Input;

public class InputtestPrntFieldInp
  : InputtestRefPrntFieldInp
  , ItestPrntFieldInp
{
  public Number field { get; set; }
}

public class InputtestRefPrntFieldInp
  : ItestRefPrntFieldInp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
