//HintName: test_parent-alt+Input_Intf.gen.cs
// Generated from parent-alt+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Input;

public interface ItestPrntAltInp
  : ItestRefPrntAltInp
{
  Number AsNumber { get; }
}

public interface ItestRefPrntAltInp
{
  Number parent { get; }
  String AsString { get; }
}
