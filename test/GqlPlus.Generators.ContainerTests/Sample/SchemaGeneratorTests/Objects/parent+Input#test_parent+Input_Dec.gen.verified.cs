//HintName: test_parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Input;

public interface ItestPrntInp
  : ItestRefPrntInp
{
  ItestPrntInpObject? As_PrntInp { get; }
}

public interface ItestPrntInpObject
  : ItestRefPrntInpObject
{
}

public interface ItestRefPrntInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestRefPrntInpObject? As_RefPrntInp { get; }
}

public interface ItestRefPrntInpObject
  // No Base because it's Class
{
  decimal Parent { get; }
}
