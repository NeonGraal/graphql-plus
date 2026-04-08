//HintName: test_parent-field+Output_Dec.gen.cs
// Generated from {CurrentDirectory}parent-field+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Output;

public interface ItestPrntFieldOutp
  : ItestRefPrntFieldOutp
{
  ItestPrntFieldOutpObject? As_PrntFieldOutp { get; }
}

public interface ItestPrntFieldOutpObject
  : ItestRefPrntFieldOutpObject
{
  decimal Field { get; }
}

public interface ItestRefPrntFieldOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestRefPrntFieldOutpObject? As_RefPrntFieldOutp { get; }
}

public interface ItestRefPrntFieldOutpObject
  // No Base because it's Class
{
  decimal Parent { get; }
}
