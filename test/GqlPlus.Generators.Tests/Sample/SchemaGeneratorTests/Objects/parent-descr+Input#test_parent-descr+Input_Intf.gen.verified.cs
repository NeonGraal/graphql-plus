//HintName: test_parent-descr+Input_Intf.gen.cs
// Generated from parent-descr+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Input;

public interface ItestPrntDescrInp
  : ItestRefPrntDescrInp
{
}

public interface ItestRefPrntDescrInp
{
  Number parent { get; }
  String AsString { get; }
}
