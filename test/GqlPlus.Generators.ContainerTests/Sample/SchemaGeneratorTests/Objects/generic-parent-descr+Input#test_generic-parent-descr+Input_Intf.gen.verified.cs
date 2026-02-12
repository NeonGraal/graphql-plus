//HintName: test_generic-parent-descr+Input_Intf.gen.cs
// Generated from generic-parent-descr+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_descr_Input;

public interface ItestGnrcPrntDescrInp<TType>
{
  TType AsParent { get; }
  ItestGnrcPrntDescrInpObject<TType> AsGnrcPrntDescrInp { get; }
}

public interface ItestGnrcPrntDescrInpObject<TType>
{
}
