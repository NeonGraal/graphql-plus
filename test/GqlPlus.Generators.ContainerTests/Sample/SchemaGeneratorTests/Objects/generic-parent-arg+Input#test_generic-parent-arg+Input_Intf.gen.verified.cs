//HintName: test_generic-parent-arg+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-arg+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Input;

public interface ItestGnrcPrntArgInp<TType>
  : ItestRefGnrcPrntArgInp<TType>
{
  ItestGnrcPrntArgInpObject<TType>? As_GnrcPrntArgInp { get; }
}

public interface ItestGnrcPrntArgInpObject<TType>
  : ItestRefGnrcPrntArgInpObject<TType>
{
}

public interface ItestRefGnrcPrntArgInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcPrntArgInpObject<TRef>? As_RefGnrcPrntArgInp { get; }
}

public interface ItestRefGnrcPrntArgInpObject<TRef>
  : IGqlpModelImplementationBase
{
}
