//HintName: test_parent-alt+Output_Dec.gen.cs
// Generated from {CurrentDirectory}parent-alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Output;

public interface ItestPrntAltOutp
  : ItestRefPrntAltOutp
{
  decimal? AsNumber { get; }
  ItestPrntAltOutpObject? As_PrntAltOutp { get; }
}

public interface ItestPrntAltOutpObject
  : ItestRefPrntAltOutpObject
{
}

public interface ItestRefPrntAltOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestRefPrntAltOutpObject? As_RefPrntAltOutp { get; }
}

public interface ItestRefPrntAltOutpObject
  // No Base because it's Class
{
  decimal Parent { get; }
}
