//HintName: Gqlp_generic-parent-arg+Output_Impl.gen.cs
// Generated from generic-parent-arg+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_parent_arg_Output;

public class OutputGnrcPrntArgOutp<Ttype>
  : OutputRefGnrcPrntArgOutp
  , IGnrcPrntArgOutp<Ttype>
{
}

public class OutputRefGnrcPrntArgOutp<Tref>
  : IRefGnrcPrntArgOutp<Tref>
{
  public Tref Asref { get; set; }
}
