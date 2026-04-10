//HintName: test_generic-field-dual+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Input;

public interface ItestGnrcFieldDualInp
  : IGqlpInterfaceBase
{
  ItestGnrcFieldDualInpObject? As_GnrcFieldDualInp { get; }
}

public interface ItestGnrcFieldDualInpObject
  : IGqlpInterfaceBase
{
  ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp> Field { get; }
}

public interface ItestRefGnrcFieldDualInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldDualInpObject<TRef>? As_RefGnrcFieldDualInp { get; }
}

public interface ItestRefGnrcFieldDualInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcFieldDualInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcFieldDualInpObject? As_AltGnrcFieldDualInp { get; }
}

public interface ItestAltGnrcFieldDualInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
