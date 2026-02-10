//HintName: test_parent-field+Output_Impl.gen.cs
// Generated from parent-field+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Output;

public class testPrntFieldOutp
  : testRefPrntFieldOutp
  , ItestPrntFieldOutp
{
  public decimal Field { get; set; }
  public ItestPrntFieldOutpObject AsPrntFieldOutp { get; set; }
}

public class testRefPrntFieldOutp
  : ItestRefPrntFieldOutp
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntFieldOutpObject AsRefPrntFieldOutp { get; set; }
}
