//HintName: test_generic-parent+Input_Intf.gen.cs
// Generated from generic-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Input;

public interface ItestGnrcPrntInp<TType>
{
  TType AsParent { get; }
  ItestGnrcPrntInpObject<TType> AsGnrcPrntInp { get; }
}

public interface ItestGnrcPrntInpObject<TType>
{
}
