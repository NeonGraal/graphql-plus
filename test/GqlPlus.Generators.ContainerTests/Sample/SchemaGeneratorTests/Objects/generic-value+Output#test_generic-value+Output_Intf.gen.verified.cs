//HintName: test_generic-value+Output_Intf.gen.cs
// Generated from {CurrentDirectory}generic-value+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Output;

public interface ItestGnrcValueOutp
  : IGqlpModelImplementationBase
{
  ItestRefGnrcValueOutp<testEnumGnrcValueOutp> AsEnumGnrcValueOutpgnrcValueOutp { get; }
  ItestGnrcValueOutpObject AsGnrcValueOutp { get; }
}

public interface ItestGnrcValueOutpObject
{
}

public interface ItestRefGnrcValueOutp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefGnrcValueOutpObject<TType> AsRefGnrcValueOutp { get; }
}

public interface ItestRefGnrcValueOutpObject<TType>
{
  TType Field { get; }
}
