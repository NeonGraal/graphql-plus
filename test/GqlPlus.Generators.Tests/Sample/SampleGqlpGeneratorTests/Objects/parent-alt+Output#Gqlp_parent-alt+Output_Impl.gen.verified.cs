//HintName: Gqlp_parent-alt+Output_Impl.gen.cs
// Generated from parent-alt+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_alt_Output;

public class OutputPrntAltOutp
  : OutputRefPrntAltOutp
  , IPrntAltOutp
{
  public Number AsNumber { get; set; }
}

public class OutputRefPrntAltOutp
  : IRefPrntAltOutp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
