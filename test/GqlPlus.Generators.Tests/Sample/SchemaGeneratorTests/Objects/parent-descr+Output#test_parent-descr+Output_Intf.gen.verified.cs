//HintName: test_parent-descr+Output_Intf.gen.cs
// Generated from parent-descr+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Output;

public interface ItestPrntDescrOutp
  : ItestRefPrntDescrOutp
{
}

public interface ItestRefPrntDescrOutp
{
  Number parent { get; }
  String AsString { get; }
}
