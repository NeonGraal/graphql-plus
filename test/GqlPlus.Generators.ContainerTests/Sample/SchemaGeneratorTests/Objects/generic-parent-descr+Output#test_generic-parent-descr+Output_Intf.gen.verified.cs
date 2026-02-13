//HintName: test_generic-parent-descr+Output_Intf.gen.cs
// Generated from generic-parent-descr+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_descr_Output;

public interface ItestGnrcPrntDescrOutp<TType>
{
  TType AsParent { get; }
  ItestGnrcPrntDescrOutpObject<TType> AsGnrcPrntDescrOutp { get; }
}

public interface ItestGnrcPrntDescrOutpObject<TType>
{
}
