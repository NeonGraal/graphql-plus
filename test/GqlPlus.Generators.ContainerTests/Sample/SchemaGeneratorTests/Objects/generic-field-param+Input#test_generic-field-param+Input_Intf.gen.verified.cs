//HintName: test_generic-field-param+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

public interface ItestGnrcFieldParamInp
  : IGqlpInterfaceBase
{
  ItestGnrcFieldParamInpObject? As_GnrcFieldParamInp { get; }
}

public interface ItestGnrcFieldParamInpObject
  : IGqlpInterfaceBase
{
  ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> Field { get; }
}

public interface ItestRefGnrcFieldParamInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldParamInpObject<TRef>? As_RefGnrcFieldParamInp { get; }
}

public interface ItestRefGnrcFieldParamInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcFieldParamInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcFieldParamInpObject? As_AltGnrcFieldParamInp { get; }
}

public interface ItestAltGnrcFieldParamInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
