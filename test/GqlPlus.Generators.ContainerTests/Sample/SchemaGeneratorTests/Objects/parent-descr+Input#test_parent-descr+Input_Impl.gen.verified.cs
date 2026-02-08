//HintName: test_parent-descr+Input_Impl.gen.cs
// Generated from parent-descr+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Input;

public class testPrntDescrInp
  : testRefPrntDescrInp
  , ItestPrntDescrInp
{
  public ItestPrntDescrInpObject AsPrntDescrInp { get; set; }
}

public class testRefPrntDescrInp
  : ItestRefPrntDescrInp
{
  public ItestNumber Parent { get; set; }
  public ItestString AsString { get; set; }
  public ItestRefPrntDescrInpObject AsRefPrntDescrInp { get; set; }
}
