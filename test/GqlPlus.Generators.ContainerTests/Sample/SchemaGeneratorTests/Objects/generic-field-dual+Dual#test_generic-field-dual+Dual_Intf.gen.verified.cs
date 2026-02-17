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
  ItestGnrcFieldDualDualObject AsGnrcFieldDualDual { get; }
}

public interface ItestGnrcFieldDualDualObject
{
  ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> Field { get; }
}

public interface ItestRefGnrcFieldDualDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcFieldDualDualObject<TRef> AsRefGnrcFieldDualDual { get; }
}

public interface ItestRefGnrcFieldDualDualObject<TRef>
{
}

public interface ItestAltGnrcFieldDualDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcFieldDualDualObject AsAltGnrcFieldDualDual { get; }
}

public interface ItestAltGnrcFieldDualDualObject
{
  decimal Alt { get; }
}
