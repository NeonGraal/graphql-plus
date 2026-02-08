//HintName: test_parent-field+Output_Impl.gen.cs
// Generated from parent-field+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Output;

public class testPrntFieldOutp
  : testRefPrntFieldOutp
  , ItestPrntFieldOutp
{
  public ItestNumber Field { get; set; }
}

public class testRefPrntFieldOutp
  : ItestRefPrntFieldOutp
{
  public ItestNumber Parent { get; set; }
  public ItestString AsString { get; set; }
}
