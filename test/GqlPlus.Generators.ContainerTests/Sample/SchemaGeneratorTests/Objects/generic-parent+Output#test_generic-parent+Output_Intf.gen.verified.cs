//HintName: test_generic-parent+Output_Intf.gen.cs
// Generated from generic-parent+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_Output;

public interface ItestGnrcPrntOutp<TType>
  : Itesttype
{
  ItestGnrcPrntOutpObject<TType> AsGnrcPrntOutp { get; }
}

public interface ItestGnrcPrntOutpObject<TType>
  : ItesttypeObject
{
}
