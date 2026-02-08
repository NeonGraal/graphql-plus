//HintName: test_generic-field+Input_Intf.gen.cs
// Generated from generic-field+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Input;

public interface ItestGnrcFieldInp<Ttype>
{
  public ItestGnrcFieldInpObject AsGnrcFieldInp { get; set; }
}

public interface ItestGnrcFieldInpObject<Ttype>
{
  public Ttype Field { get; set; }
}
