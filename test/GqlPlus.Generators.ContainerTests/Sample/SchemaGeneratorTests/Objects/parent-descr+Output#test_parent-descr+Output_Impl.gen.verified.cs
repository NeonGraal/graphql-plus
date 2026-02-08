//HintName: test_parent-descr+Output_Impl.gen.cs
// Generated from parent-descr+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Output;

public class testPrntDescrOutp
  : testRefPrntDescrOutp
  , ItestPrntDescrOutp
{
  public ItestPrntDescrOutpObject AsPrntDescrOutp { get; set; }
}

public class testRefPrntDescrOutp
  : ItestRefPrntDescrOutp
{
  public ItestNumber Parent { get; set; }
  public ItestString AsString { get; set; }
  public ItestRefPrntDescrOutpObject AsRefPrntDescrOutp { get; set; }
}
