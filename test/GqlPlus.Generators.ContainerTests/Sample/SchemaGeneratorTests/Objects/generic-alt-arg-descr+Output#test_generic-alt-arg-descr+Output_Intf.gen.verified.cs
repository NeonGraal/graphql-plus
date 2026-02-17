//HintName: test_generic-alt-arg-descr+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Output;

public interface ItestGnrcAltArgDescrOutp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefGnrcAltArgDescrOutp<TType> AsRefGnrcAltArgDescrOutp { get; }
  ItestGnrcAltArgDescrOutpObject<TType> AsGnrcAltArgDescrOutp { get; }
}

public interface ItestGnrcAltArgDescrOutpObject<TType>
{
}

public interface ItestRefGnrcAltArgDescrOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcAltArgDescrOutpObject<TRef> AsRefGnrcAltArgDescrOutp { get; }
}

public interface ItestRefGnrcAltArgDescrOutpObject<TRef>
{
}
