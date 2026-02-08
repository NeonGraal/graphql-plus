//HintName: test_parent-descr+Input_Intf.gen.cs
// Generated from parent-descr+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Input;

public interface ItestPrntDescrInp
  : ItestRefPrntDescrInp
{
}

public interface ItestPrntDescrInpObject
  : ItestRefPrntDescrInpObject
{
}

public interface ItestRefPrntDescrInp
{
  public ItestString AsString { get; set; }
}

public interface ItestRefPrntDescrInpObject
{
  public ItestNumber Parent { get; set; }
}
