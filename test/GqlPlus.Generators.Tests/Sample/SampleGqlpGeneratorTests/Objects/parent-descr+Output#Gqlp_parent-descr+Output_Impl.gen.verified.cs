//HintName: Gqlp_parent-descr+Output_Impl.gen.cs
// Generated from parent-descr+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_descr_Output;

public class OutputPrntDescrOutp
  : OutputRefPrntDescrOutp
  , IPrntDescrOutp
{
}

public class OutputRefPrntDescrOutp
  : IRefPrntDescrOutp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
