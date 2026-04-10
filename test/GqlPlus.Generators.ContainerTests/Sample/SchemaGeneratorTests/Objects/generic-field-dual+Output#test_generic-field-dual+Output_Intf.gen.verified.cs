//HintName: test_generic-field-dual+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

public interface ItestGnrcFieldDualOutp
  : IGqlpInterfaceBase
{
  ItestGnrcFieldDualOutpObject? As_GnrcFieldDualOutp { get; }
}

public interface ItestGnrcFieldDualOutpObject
  : IGqlpInterfaceBase
{
  ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp> Field { get; }
}

public interface ItestRefGnrcFieldDualOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldDualOutpObject<TRef>? As_RefGnrcFieldDualOutp { get; }
}

public interface ItestRefGnrcFieldDualOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcFieldDualOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcFieldDualOutpObject? As_AltGnrcFieldDualOutp { get; }
}

public interface ItestAltGnrcFieldDualOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}
