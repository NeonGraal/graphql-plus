//HintName: test_generic-field-dual+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Dual;

public interface ItestGnrcFieldDualDual
  : IGqlpInterfaceBase
{
  ItestGnrcFieldDualDualObject? As_GnrcFieldDualDual { get; }
}

public interface ItestGnrcFieldDualDualObject
  : IGqlpInterfaceBase
{
  ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> Field { get; }
}

public interface ItestRefGnrcFieldDualDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldDualDualObject<TRef>? As_RefGnrcFieldDualDual { get; }
}

public interface ItestRefGnrcFieldDualDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcFieldDualDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcFieldDualDualObject? As_AltGnrcFieldDualDual { get; }
}

public interface ItestAltGnrcFieldDualDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
