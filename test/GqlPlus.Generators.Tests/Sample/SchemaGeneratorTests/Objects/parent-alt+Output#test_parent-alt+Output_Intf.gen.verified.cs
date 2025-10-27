//HintName: test_parent-alt+Output_Intf.gen.cs
// Generated from parent-alt+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Output;

public interface ItestPrntAltOutp
  : ItestRefPrntAltOutp
{
  Number AsNumber { get; }
}

public interface ItestRefPrntAltOutp
{
  Number parent { get; }
  String AsString { get; }
}
