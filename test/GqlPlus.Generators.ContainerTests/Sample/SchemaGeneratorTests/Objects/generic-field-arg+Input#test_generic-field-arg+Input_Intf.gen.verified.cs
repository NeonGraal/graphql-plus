//HintName: test_generic-field-arg+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field-arg+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Input;

public interface ItestGnrcFieldArgInp<TType>
  : IGqlpInterfaceBase
{
  ItestGnrcFieldArgInpObject<TType>? As_GnrcFieldArgInp { get; }
}

public interface ItestGnrcFieldArgInpObject<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcFieldArgInp<TType> Field { get; }
}

public interface ItestRefGnrcFieldArgInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldArgInpObject<TRef>? As_RefGnrcFieldArgInp { get; }
}

public interface ItestRefGnrcFieldArgInpObject<TRef>
  : IGqlpInterfaceBase
{
}
