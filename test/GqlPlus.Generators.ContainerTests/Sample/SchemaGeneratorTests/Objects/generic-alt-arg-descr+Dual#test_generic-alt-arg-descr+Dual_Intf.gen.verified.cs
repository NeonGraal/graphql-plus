//HintName: test_generic-alt-arg-descr+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Dual;

public interface ItestGnrcAltArgDescrDual<TType>
  : IGqlpModelImplementationBase
{
  ItestRefGnrcAltArgDescrDual<TType> AsRefGnrcAltArgDescrDual { get; }
  ItestGnrcAltArgDescrDualObject<TType> AsGnrcAltArgDescrDual { get; }
}

public interface ItestGnrcAltArgDescrDualObject<TType>
{
}

public interface ItestRefGnrcAltArgDescrDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcAltArgDescrDualObject<TRef> AsRefGnrcAltArgDescrDual { get; }
}

public interface ItestRefGnrcAltArgDescrDualObject<TRef>
{
}
