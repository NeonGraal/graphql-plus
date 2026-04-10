//HintName: test_generic-alt-arg+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Input;

public interface ItestGnrcAltArgInp<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltArgInp<TType>? AsRefGnrcAltArgInp { get; }
  ItestGnrcAltArgInpObject<TType>? As_GnrcAltArgInp { get; }
}

public interface ItestGnrcAltArgInpObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltArgInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltArgInpObject<TRef>? As_RefGnrcAltArgInp { get; }
}

public interface ItestRefGnrcAltArgInpObject<TRef>
  : IGqlpInterfaceBase
{
}
