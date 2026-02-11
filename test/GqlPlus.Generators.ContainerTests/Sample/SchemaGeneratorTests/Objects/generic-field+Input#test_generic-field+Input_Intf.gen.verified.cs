//HintName: test_generic-field+Input_Intf.gen.cs
// Generated from generic-field+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Input;

public interface ItestGnrcFieldInp<Ttype>
{
  ItestGnrcFieldInpObject AsGnrcFieldInp { get; }
}

public interface ItestGnrcFieldInpObject<Ttype>
{
  Ttype Field { get; }
}
