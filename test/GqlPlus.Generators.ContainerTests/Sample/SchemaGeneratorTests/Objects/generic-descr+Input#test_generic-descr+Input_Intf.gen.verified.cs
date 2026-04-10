//HintName: test_generic-descr+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-descr+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Input;

public interface ItestGnrcDescrInp<TType>
  : IGqlpInterfaceBase
{
  ItestGnrcDescrInpObject<TType>? As_GnrcDescrInp { get; }
}

public interface ItestGnrcDescrInpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}
