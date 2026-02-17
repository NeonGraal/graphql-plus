//HintName: test_generic-field-arg+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Dual;

public interface ItestGnrcFieldArgDual<TType>
  : IGqlpModelImplementationBase
{
  ItestGnrcFieldArgDualObject<TType> AsGnrcFieldArgDual { get; }
}

public interface ItestGnrcFieldArgDualObject<TType>
{
  ItestRefGnrcFieldArgDual<TType> Field { get; }
}

public interface ItestRefGnrcFieldArgDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcFieldArgDualObject<TRef> AsRefGnrcFieldArgDual { get; }
}

public interface ItestRefGnrcFieldArgDualObject<TRef>
{
}
