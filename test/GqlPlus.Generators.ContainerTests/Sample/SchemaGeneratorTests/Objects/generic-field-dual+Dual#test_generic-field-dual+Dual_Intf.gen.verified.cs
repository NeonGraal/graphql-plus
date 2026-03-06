//HintName: test_generic-field-dual+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Dual;

public interface ItestGnrcFieldDualDual
  : IGqlpModelImplementationBase
{
  ItestGnrcFieldDualDualObject? As_GnrcFieldDualDual { get; }
}

public interface ItestGnrcFieldDualDualObject
  : IGqlpModelImplementationBase
{
  ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> Field { get; }
}

public interface ItestRefGnrcFieldDualDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldDualDualObject<TRef>? As_RefGnrcFieldDualDual { get; }
}

public interface ItestRefGnrcFieldDualDualObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestAltGnrcFieldDualDual
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltGnrcFieldDualDualObject? As_AltGnrcFieldDualDual { get; }
}

public interface ItestAltGnrcFieldDualDualObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
