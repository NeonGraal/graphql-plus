//HintName: test_generic-field+Input_Impl.gen.cs
// Generated from generic-field+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Input;

public class testGnrcFieldInp<TType>
  : ItestGnrcFieldInp<TType>
{
  public TType Field { get; set; }
  public ItestGnrcFieldInpObject<TType> AsGnrcFieldInp { get; set; }
}
