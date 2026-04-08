//HintName: test_parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Output;

public interface ItestPrntOutp
  : ItestRefPrntOutp
{
  ItestPrntOutpObject? As_PrntOutp { get; }
}

public interface ItestPrntOutpObject
  : ItestRefPrntOutpObject
{
}

public interface ItestRefPrntOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestRefPrntOutpObject? As_RefPrntOutp { get; }
}

public interface ItestRefPrntOutpObject
  // No Base because it's Class
{
  decimal Parent { get; }
}
