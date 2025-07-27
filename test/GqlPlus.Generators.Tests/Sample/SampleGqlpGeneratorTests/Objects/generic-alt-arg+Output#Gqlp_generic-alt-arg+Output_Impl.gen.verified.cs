//HintName: Gqlp_generic-alt-arg+Output_Impl.gen.cs
// Generated from generic-alt-arg+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_arg_Output;

public class OutputGnrcAltArgOutp<Ttype>
  : IGnrcAltArgOutp<Ttype>
{
  public RefGnrcAltArgOutp<Ttype> AsRefGnrcAltArgOutp { get; set; }
}

public class OutputRefGnrcAltArgOutp<Tref>
  : IRefGnrcAltArgOutp<Tref>
{
  public Tref Asref { get; set; }
}
