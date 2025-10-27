//HintName: test_generic-field-arg+Output_Impl.gen.cs
// Generated from generic-field-arg+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Output;

public class testGnrcFieldArgOutp<Ttype>
  : ItestGnrcFieldArgOutp<Ttype>
{
  public RefGnrcFieldArgOutp<Ttype> field { get; set; }
}

public class testRefGnrcFieldArgOutp<Tref>
  : ItestRefGnrcFieldArgOutp<Tref>
{
  public Tref Asref { get; set; }
}
