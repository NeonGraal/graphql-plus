//HintName: test_parent+Input_Intf.gen.cs
// Generated from parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Input;

public interface ItestPrntInp
  : ItestRefPrntInp
{
}

public interface ItestPrntInpObject
  : ItestRefPrntInpObject
{
}

public interface ItestRefPrntInp
{
  public ItestString AsString { get; set; }
}

public interface ItestRefPrntInpObject
{
  public ItestNumber Parent { get; set; }
}
