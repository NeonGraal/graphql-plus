//HintName: test_parent+Input_Impl.gen.cs
// Generated from parent+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Input;

public class testPrntInp
  : testRefPrntInp
  , ItestPrntInp
{
}

public class testRefPrntInp
  : ItestRefPrntInp
{
  public ItestNumber Parent { get; set; }
  public ItestString AsString { get; set; }
}
