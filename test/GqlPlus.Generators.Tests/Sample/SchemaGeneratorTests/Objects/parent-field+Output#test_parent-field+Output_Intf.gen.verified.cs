//HintName: test_parent-field+Output_Intf.gen.cs
// Generated from parent-field+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Output;

public interface ItestPrntFieldOutp
  : ItestRefPrntFieldOutp
{
  Number field { get; }
}

public interface ItestRefPrntFieldOutp
{
  Number parent { get; }
  String AsString { get; }
}
