//HintName: test_generic-alt-simple+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Input;

public interface ItestGnrcAltSmplInp
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltSmplInp<string>? AsRefGnrcAltSmplInp { get; }
  ItestGnrcAltSmplInpObject? As_GnrcAltSmplInp { get; }
}

public interface ItestGnrcAltSmplInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltSmplInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltSmplInpObject<TRef>? As_RefGnrcAltSmplInp { get; }
}

public interface ItestRefGnrcAltSmplInpObject<TRef>
  : IGqlpInterfaceBase
{
}
