//HintName: test_generic-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Input;

public interface ItestGnrcEnumInp
  // No Base because it's Class
{
  ItestRefGnrcEnumInp<testEnumGnrcEnumInp>? AsEnumGnrcEnumInpgnrcEnumInp { get; }
  ItestGnrcEnumInpObject? As_GnrcEnumInp { get; }
}

public interface ItestGnrcEnumInpObject
  // No Base because it's Class
{
}

public interface ItestRefGnrcEnumInp<TType>
  // No Base because it's Class
{
  ItestRefGnrcEnumInpObject<TType>? As_RefGnrcEnumInp { get; }
}

public interface ItestRefGnrcEnumInpObject<TType>
  // No Base because it's Class
{
  TType Field { get; }
}

public enum testEnumGnrcEnumInp
{
  gnrcEnumInp,
}
