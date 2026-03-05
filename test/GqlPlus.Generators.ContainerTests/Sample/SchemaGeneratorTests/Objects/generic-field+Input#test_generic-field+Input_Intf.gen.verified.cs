//HintName: test_generic-field+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-field+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Input;

public interface ItestGnrcFieldInp<TType>
  : IGqlpModelImplementationBase
{
  ItestGnrcFieldInpObject<TType>? As_GnrcFieldInp { get; }
}

public interface ItestGnrcFieldInpObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
}
