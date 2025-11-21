//HintName: test_generic-field-arg+Output_Impl.gen.cs
// Generated from generic-field-arg+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Output;

public class testGnrcFieldArgOutp<Ttype>
  : ItestGnrcFieldArgOutp<Ttype>
{
  public testRefGnrcFieldArgOutp<Ttype> field { get; set; }
  public testGnrcFieldArgOutp GnrcFieldArgOutp { get; set; }
}

public class testRefGnrcFieldArgOutp<Tref>
  : ItestRefGnrcFieldArgOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcFieldArgOutp RefGnrcFieldArgOutp { get; set; }
}
