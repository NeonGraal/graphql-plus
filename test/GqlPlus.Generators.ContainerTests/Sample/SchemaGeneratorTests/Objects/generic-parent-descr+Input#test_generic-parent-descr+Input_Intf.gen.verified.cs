//HintName: test_generic-parent-descr+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-parent-descr+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_descr_Input;

public interface ItestGnrcPrntDescrInp<TType>
  : IGqlpModelImplementationBase
{
  TType? As_Parent { get; }
  ItestGnrcPrntDescrInpObject<TType>? As_GnrcPrntDescrInp { get; }
}

public interface ItestGnrcPrntDescrInpObject<TType>
  : IGqlpModelImplementationBase
{
}
