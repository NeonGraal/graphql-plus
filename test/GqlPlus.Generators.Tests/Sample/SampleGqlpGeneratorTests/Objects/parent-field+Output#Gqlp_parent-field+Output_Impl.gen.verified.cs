//HintName: Gqlp_parent-field+Output_Impl.gen.cs
// Generated from parent-field+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_field_Output;
public class OutputPrntFieldOutp
  : OutputRefPrntFieldOutp
  , IPrntFieldOutp
{
  public Number field { get; set; }
}
public class OutputRefPrntFieldOutp
  : IRefPrntFieldOutp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
