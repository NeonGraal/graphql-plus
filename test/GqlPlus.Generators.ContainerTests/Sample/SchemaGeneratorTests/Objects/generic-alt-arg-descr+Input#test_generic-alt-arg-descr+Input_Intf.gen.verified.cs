//HintName: test_generic-alt-arg-descr+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Input;

public interface ItestGnrcAltArgDescrInp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefGnrcAltArgDescrInp<TType> AsRefGnrcAltArgDescrInp { get; }
  ItestGnrcAltArgDescrInpObject<TType> AsGnrcAltArgDescrInp { get; }
}

public interface ItestGnrcAltArgDescrInpObject<TType>
{
}

public interface ItestRefGnrcAltArgDescrInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcAltArgDescrInpObject<TRef> AsRefGnrcAltArgDescrInp { get; }
}

public interface ItestRefGnrcAltArgDescrInpObject<TRef>
{
}
