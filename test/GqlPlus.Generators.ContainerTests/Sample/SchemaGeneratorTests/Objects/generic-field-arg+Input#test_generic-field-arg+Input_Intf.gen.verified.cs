//HintName: test_generic-field-arg+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field-arg+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Input;

public interface ItestGnrcFieldArgInp<TType>
  : IGqlpModelImplementationBase
{
  ItestGnrcFieldArgInpObject<TType> AsGnrcFieldArgInp { get; }
}

public interface ItestGnrcFieldArgInpObject<TType>
{
  ItestRefGnrcFieldArgInp<TType> Field { get; }
}

public interface ItestRefGnrcFieldArgInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefGnrcFieldArgInpObject<TRef> AsRefGnrcFieldArgInp { get; }
}

public interface ItestRefGnrcFieldArgInpObject<TRef>
{
}
