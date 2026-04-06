//HintName: test_generic-value+Input_Intf.gen.cs
// Generated from {CurrentDirectory}generic-value+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Input;

public interface ItestGnrcValueInp
  : IGqlpModelImplementationBase
{
  ItestRefGnrcValueInp<testEnumGnrcValueInp>? AsEnumGnrcValueInpgnrcValueInp { get; }
  ItestGnrcValueInpObject? As_GnrcValueInp { get; }
}

public interface ItestGnrcValueInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefGnrcValueInp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefGnrcValueInpObject<TType>? As_RefGnrcValueInp { get; }
}

public interface ItestRefGnrcValueInpObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
}

public enum testEnumGnrcValueInp
{
  gnrcValueInp,
}
