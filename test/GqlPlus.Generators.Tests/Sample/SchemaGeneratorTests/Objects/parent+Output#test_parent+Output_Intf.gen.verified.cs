//HintName: test_parent+Output_Intf.gen.cs
// Generated from parent+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_Output;

public interface ItestPrntOutp
  : ItestRefPrntOutp
{
}

public interface ItestRefPrntOutp
{
  Number parent { get; }
  String AsString { get; }
}
