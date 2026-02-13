//HintName: test_generic-parent-descr+Input_Impl.gen.cs
// Generated from generic-parent-descr+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_descr_Input;

public class testGnrcPrntDescrInp<TType>
  : ItestGnrcPrntDescrInp<TType>
{
  public TType AsParent { get; set; }
  public ItestGnrcPrntDescrInpObject<TType> AsGnrcPrntDescrInp { get; set; }
}
