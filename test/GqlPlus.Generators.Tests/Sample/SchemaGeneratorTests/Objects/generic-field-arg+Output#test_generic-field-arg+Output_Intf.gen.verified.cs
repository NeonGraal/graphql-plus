//HintName: test_generic-field-arg+Output_Intf.gen.cs
// Generated from generic-field-arg+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Output;

public interface ItestGnrcFieldArgOutp<Ttype>
{
  public testGnrcFieldArgOutp GnrcFieldArgOutp { get; set; }
}

public interface ItestGnrcFieldArgOutpObject<Ttype>
{
  public testRefGnrcFieldArgOutp<Ttype> field { get; set; }
}

public interface ItestRefGnrcFieldArgOutp<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcFieldArgOutp RefGnrcFieldArgOutp { get; set; }
}

public interface ItestRefGnrcFieldArgOutpObject<Tref>
{
}
