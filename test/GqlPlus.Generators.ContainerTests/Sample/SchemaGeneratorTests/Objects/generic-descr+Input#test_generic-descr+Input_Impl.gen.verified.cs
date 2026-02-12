//HintName: test_generic-descr+Input_Impl.gen.cs
// Generated from generic-descr+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Input;

public class testGnrcDescrInp<TType>
  : ItestGnrcDescrInp<TType>
{
  public TType Field { get; set; }
  public ItestGnrcDescrInpObject<TType> AsGnrcDescrInp { get; set; }
}
