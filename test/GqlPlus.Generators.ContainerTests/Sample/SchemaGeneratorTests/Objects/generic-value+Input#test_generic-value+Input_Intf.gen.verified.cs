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
  ItestRefGnrcValueInp<testEnumGnrcValueInp> AsEnumGnrcValueInpgnrcValueInp { get; }
  ItestGnrcValueInpObject AsGnrcValueInp { get; }
}

public interface ItestGnrcValueInpObject
{
}

public interface ItestRefGnrcValueInp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefGnrcValueInpObject<TType> AsRefGnrcValueInp { get; }
}

public interface ItestRefGnrcValueInpObject<TType>
{
  TType Field { get; }
}
