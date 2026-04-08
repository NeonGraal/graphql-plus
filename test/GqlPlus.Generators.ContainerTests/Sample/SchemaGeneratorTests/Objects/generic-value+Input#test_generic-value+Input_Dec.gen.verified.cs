//HintName: test_generic-value+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Input;

public interface ItestGnrcValueInp
  // No Base because it's Class
{
  ItestRefGnrcValueInp<testEnumGnrcValueInp>? AsEnumGnrcValueInpgnrcValueInp { get; }
  ItestGnrcValueInpObject? As_GnrcValueInp { get; }
}

public interface ItestGnrcValueInpObject
  // No Base because it's Class
{
}

public interface ItestRefGnrcValueInp<TType>
  // No Base because it's Class
{
  ItestRefGnrcValueInpObject<TType>? As_RefGnrcValueInp { get; }
}

public interface ItestRefGnrcValueInpObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}

public enum testEnumGnrcValueInp
{
  gnrcValueInp,
}
