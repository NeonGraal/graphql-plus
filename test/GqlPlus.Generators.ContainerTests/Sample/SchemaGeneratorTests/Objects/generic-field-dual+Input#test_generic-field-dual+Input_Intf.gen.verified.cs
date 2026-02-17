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
  ItestGnrcFieldDualInpObject AsGnrcFieldDualInp { get; }
}

public interface ItestGnrcFieldDualInpObject
{
  ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp> Field { get; }
}

public interface ItestRefGnrcFieldDualInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcFieldDualInpObject<TRef> AsRefGnrcFieldDualInp { get; }
}

public interface ItestRefGnrcFieldDualInpObject<TRef>
{
}

public interface ItestAltGnrcFieldDualInp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestAltGnrcFieldDualInpObject AsAltGnrcFieldDualInp { get; }
}

public interface ItestAltGnrcFieldDualInpObject
{
  decimal Alt { get; }
}
