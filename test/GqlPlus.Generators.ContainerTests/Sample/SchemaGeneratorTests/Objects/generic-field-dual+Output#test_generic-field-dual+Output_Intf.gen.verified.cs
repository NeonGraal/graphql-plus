//HintName: test_generic-field-dual+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

public interface ItestGnrcFieldDualOutp
  : IGqlpModelImplementationBase
{
  ItestGnrcFieldDualOutpObject? As_GnrcFieldDualOutp { get; }
}

public interface ItestGnrcFieldDualOutpObject
  : IGqlpModelImplementationBase
{
  ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp> Field { get; }
}

public interface ItestRefGnrcFieldDualOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldDualOutpObject<TRef>? As_RefGnrcFieldDualOutp { get; }
}

public interface ItestRefGnrcFieldDualOutpObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestAltGnrcFieldDualOutp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltGnrcFieldDualOutpObject? As_AltGnrcFieldDualOutp { get; }
}

public interface ItestAltGnrcFieldDualOutpObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
