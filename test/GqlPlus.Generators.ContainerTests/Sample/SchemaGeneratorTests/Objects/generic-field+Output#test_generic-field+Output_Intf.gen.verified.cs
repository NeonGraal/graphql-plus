//HintName: test_generic-field+Output_Intf.gen.cs
// Generated from generic-field+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Output;

public interface ItestGnrcFieldOutp<Ttype>
{
  public ItestGnrcFieldOutpObject AsGnrcFieldOutp { get; set; }
}

public interface ItestGnrcFieldOutpObject<Ttype>
{
  public Ttype Field { get; set; }
}
