//HintName: Gqlp_generic-field-arg+Output_Impl.gen.cs
// Generated from generic-field-arg+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_field_arg_Output;
public class OutputGnrcFieldArgOutp<Ttype>
  : IGnrcFieldArgOutp<Ttype>
{
  public RefGnrcFieldArgOutp<Ttype> field { get; set; }
}
public class OutputRefGnrcFieldArgOutp<Tref>
  : IRefGnrcFieldArgOutp<Tref>
{
  public Tref Asref { get; set; }
}
