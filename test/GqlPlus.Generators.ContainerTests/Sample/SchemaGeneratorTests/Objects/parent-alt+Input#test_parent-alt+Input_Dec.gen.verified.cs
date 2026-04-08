//HintName: test_parent-alt+Input_Dec.gen.cs
// Generated from {CurrentDirectory}parent-alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Input;

public interface ItestPrntAltInp
  : ItestRefPrntAltInp
{
  decimal? AsNumber { get; }
  ItestPrntAltInpObject? As_PrntAltInp { get; }
}

public interface ItestPrntAltInpObject
  : ItestRefPrntAltInpObject
{
}

public interface ItestRefPrntAltInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestRefPrntAltInpObject? As_RefPrntAltInp { get; }
}

public interface ItestRefPrntAltInpObject
  // No Base because it's Class
{
  decimal Parent { get; }
}
