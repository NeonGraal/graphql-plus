//HintName: test_generic-alt-simple+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Input;

public interface ItestGnrcAltSmplInp
  : IGqlpModelImplementationBase
{
  ItestRefGnrcAltSmplInp<string>? AsRefGnrcAltSmplInp { get; }
  ItestGnrcAltSmplInpObject? As_GnrcAltSmplInp { get; }
}

public interface ItestGnrcAltSmplInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefGnrcAltSmplInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltSmplInpObject<TRef>? As_RefGnrcAltSmplInp { get; }
}

public interface ItestRefGnrcAltSmplInpObject<TRef>
  : IGqlpModelImplementationBase
{
}
