//HintName: test_generic-field+Input_Intf.gen.cs
// Generated from generic-field+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Input;

public interface ItestGnrcFieldInp<TType>
{
  ItestGnrcFieldInpObject<TType> AsGnrcFieldInp { get; }
}

public interface ItestGnrcFieldInpObject<TType>
{
  TType Field { get; }
}
