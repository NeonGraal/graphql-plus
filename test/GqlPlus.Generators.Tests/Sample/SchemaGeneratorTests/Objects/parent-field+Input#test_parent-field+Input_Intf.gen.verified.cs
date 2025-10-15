//HintName: test_parent-field+Input_Intf.gen.cs
// Generated from parent-field+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Input;

public interface ItestPrntFieldInp
  : ItestRefPrntFieldInp
{
  Number field { get; }
}

public interface ItestRefPrntFieldInp
{
  Number parent { get; }
  String AsString { get; }
}
