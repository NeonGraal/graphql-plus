//HintName: test_parent+Input_Intf.gen.cs
// Generated from parent+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_Input;

public interface ItestPrntInp
  : ItestRefPrntInp
{
}

public interface ItestRefPrntInp
{
  Number parent { get; }
  String AsString { get; }
}
