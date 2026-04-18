//HintName: test_generic-alt-arg-descr+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Input;

public interface ItestGnrcAltArgDescrInp<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltArgDescrInp<TType>? AsRefGnrcAltArgDescrInp { get; }
  ItestGnrcAltArgDescrInpObject<TType>? As_GnrcAltArgDescrInp { get; }
}

public interface ItestGnrcAltArgDescrInpObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltArgDescrInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltArgDescrInpObject<TRef>? As_RefGnrcAltArgDescrInp { get; }
}

public interface ItestRefGnrcAltArgDescrInpObject<TRef>
  : IGqlpInterfaceBase
{
}
