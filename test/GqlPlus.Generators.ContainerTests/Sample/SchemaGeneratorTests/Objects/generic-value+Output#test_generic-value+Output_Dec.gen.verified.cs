//HintName: test_generic-value+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Output;

public interface ItestGnrcValueOutp
  // No Base because it's Class
{
  ItestRefGnrcValueOutp<testEnumGnrcValueOutp>? AsEnumGnrcValueOutpgnrcValueOutp { get; }
  ItestGnrcValueOutpObject? As_GnrcValueOutp { get; }
}

public interface ItestGnrcValueOutpObject
  // No Base because it's Class
{
}

public interface ItestRefGnrcValueOutp<TType>
  // No Base because it's Class
{
  ItestRefGnrcValueOutpObject<TType>? As_RefGnrcValueOutp { get; }
}

public interface ItestRefGnrcValueOutpObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}

public enum testEnumGnrcValueOutp
{
  gnrcValueOutp,
}
