//HintName: test_generic-descr+Output_Intf.gen.cs
// Generated from generic-descr+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Output;

public interface ItestGnrcDescrOutp<TType>
{
  ItestGnrcDescrOutpObject AsGnrcDescrOutp { get; }
}

public interface ItestGnrcDescrOutpObject<TType>
{
  TType Field { get; }
}
