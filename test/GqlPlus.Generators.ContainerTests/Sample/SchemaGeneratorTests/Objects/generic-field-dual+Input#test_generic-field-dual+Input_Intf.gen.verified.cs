//HintName: test_generic-field-dual+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Input;

public interface ItestGnrcFieldDualInp
  : IGqlpModelImplementationBase
{
  ItestGnrcFieldDualInpObject? As_GnrcFieldDualInp { get; }
}

public interface ItestGnrcFieldDualInpObject
  : IGqlpModelImplementationBase
{
  ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp> Field { get; }
}

public interface ItestRefGnrcFieldDualInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldDualInpObject<TRef>? As_RefGnrcFieldDualInp { get; }
}

public interface ItestRefGnrcFieldDualInpObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestAltGnrcFieldDualInp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestAltGnrcFieldDualInpObject? As_AltGnrcFieldDualInp { get; }
}

public interface ItestAltGnrcFieldDualInpObject
  : IGqlpModelImplementationBase
{
  decimal Alt { get; }
}
