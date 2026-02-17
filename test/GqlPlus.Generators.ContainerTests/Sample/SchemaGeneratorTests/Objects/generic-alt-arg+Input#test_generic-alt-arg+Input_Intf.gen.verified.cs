//HintName: test_generic-alt-arg+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Input;

public interface ItestGnrcAltArgInp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefGnrcAltArgInp<TType> AsRefGnrcAltArgInp { get; }
  ItestGnrcAltArgInpObject<TType> AsGnrcAltArgInp { get; }
}

public interface ItestGnrcAltArgInpObject<TType>
{
}

public interface ItestRefGnrcAltArgInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcAltArgInpObject<TRef> AsRefGnrcAltArgInp { get; }
}

public interface ItestRefGnrcAltArgInpObject<TRef>
{
}
