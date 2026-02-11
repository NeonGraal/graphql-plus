//HintName: test_generic-parent-arg+Output_Intf.gen.cs
// Generated from generic-parent-arg+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Output;

public interface ItestGnrcPrntArgOutp<TType>
  : ItestRefGnrcPrntArgOutp<TType>
{
  ItestGnrcPrntArgOutpObject AsGnrcPrntArgOutp { get; }
}

public interface ItestGnrcPrntArgOutpObject<TType>
  : ItestRefGnrcPrntArgOutpObject<TType>
{
}

public interface ItestRefGnrcPrntArgOutp<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcPrntArgOutpObject AsRefGnrcPrntArgOutp { get; }
}

public interface ItestRefGnrcPrntArgOutpObject<TRef>
{
}
