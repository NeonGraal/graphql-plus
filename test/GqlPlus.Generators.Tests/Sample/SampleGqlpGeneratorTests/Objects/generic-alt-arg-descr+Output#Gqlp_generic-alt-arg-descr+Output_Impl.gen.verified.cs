//HintName: Gqlp_generic-alt-arg-descr+Output_Impl.gen.cs
// Generated from generic-alt-arg-descr+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_arg_descr_Output;
public class OutputGnrcAltArgDescrOutp<Ttype>
  : IGnrcAltArgDescrOutp<Ttype>
{
  public RefGnrcAltArgDescrOutp<Ttype> AsRefGnrcAltArgDescrOutp { get; set; }
}
public class OutputRefGnrcAltArgDescrOutp<Tref>
  : IRefGnrcAltArgDescrOutp<Tref>
{
  public Tref Asref { get; set; }
}
