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
  ItestGnrcFieldArgInpObject<TType>? As_GnrcFieldArgInp { get; }
}

public interface ItestGnrcFieldArgInpObject<TType>
  : IGqlpModelImplementationBase
{
  ItestRefGnrcFieldArgInp<TType> Field { get; }
}

public interface ItestRefGnrcFieldArgInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldArgInpObject<TRef>? As_RefGnrcFieldArgInp { get; }
}

public interface ItestRefGnrcFieldArgInpObject<TRef>
  : IGqlpModelImplementationBase
{
}
