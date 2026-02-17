//HintName: test_generic-alt-arg+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Output;

public interface ItestGnrcAltArgOutp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefGnrcAltArgOutp<TType> AsRefGnrcAltArgOutp { get; }
  ItestGnrcAltArgOutpObject<TType> AsGnrcAltArgOutp { get; }
}

public interface ItestGnrcAltArgOutpObject<TType>
{
}

public interface ItestRefGnrcAltArgOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcAltArgOutpObject<TRef> AsRefGnrcAltArgOutp { get; }
}

public interface ItestRefGnrcAltArgOutpObject<TRef>
{
}
