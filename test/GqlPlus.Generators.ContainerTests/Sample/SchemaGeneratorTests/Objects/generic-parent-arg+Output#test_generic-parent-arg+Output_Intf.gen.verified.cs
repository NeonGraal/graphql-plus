//HintName: test_generic-parent-arg+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-arg+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Output;

public interface ItestGnrcPrntArgOutp<TType>
  : ItestRefGnrcPrntArgOutp<TType>
{
  ItestGnrcPrntArgOutpObject<TType> AsGnrcPrntArgOutp { get; }
}

public interface ItestGnrcPrntArgOutpObject<TType>
  : ItestRefGnrcPrntArgOutpObject<TType>
{
}

public interface ItestRefGnrcPrntArgOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcPrntArgOutpObject<TRef> AsRefGnrcPrntArgOutp { get; }
}

public interface ItestRefGnrcPrntArgOutpObject<TRef>
{
}
