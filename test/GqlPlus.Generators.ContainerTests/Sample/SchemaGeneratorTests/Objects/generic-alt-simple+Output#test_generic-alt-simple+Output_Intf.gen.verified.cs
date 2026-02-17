//HintName: test_generic-alt-simple+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Output;

public interface ItestGnrcAltSmplOutp
  : IGqlpModelImplementationBase
{
  ItestRefGnrcAltSmplOutp<string> AsRefGnrcAltSmplOutp { get; }
  ItestGnrcAltSmplOutpObject AsGnrcAltSmplOutp { get; }
}

public interface ItestGnrcAltSmplOutpObject
{
}

public interface ItestRefGnrcAltSmplOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcAltSmplOutpObject<TRef> AsRefGnrcAltSmplOutp { get; }
}

public interface ItestRefGnrcAltSmplOutpObject<TRef>
{
}
