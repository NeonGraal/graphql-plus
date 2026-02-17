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
  ItestGnrcFieldDualOutpObject AsGnrcFieldDualOutp { get; }
}

public interface ItestGnrcFieldDualOutpObject
{
  ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp> Field { get; }
}

public interface ItestRefGnrcFieldDualOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcFieldDualOutpObject<TRef> AsRefGnrcFieldDualOutp { get; }
}

public interface ItestRefGnrcFieldDualOutpObject<TRef>
{
}

public interface ItestAltGnrcFieldDualOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcFieldDualOutpObject AsAltGnrcFieldDualOutp { get; }
}

public interface ItestAltGnrcFieldDualOutpObject
{
  decimal Alt { get; }
}
