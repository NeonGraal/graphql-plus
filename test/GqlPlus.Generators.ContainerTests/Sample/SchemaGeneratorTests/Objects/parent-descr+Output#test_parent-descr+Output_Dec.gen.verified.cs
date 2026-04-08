//HintName: test_parent-descr+Output_Dec.gen.cs
// Generated from {CurrentDirectory}parent-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Output;

public interface ItestPrntDescrOutp
  : ItestRefPrntDescrOutp
{
  ItestPrntDescrOutpObject? As_PrntDescrOutp { get; }
}

public interface ItestPrntDescrOutpObject
  : ItestRefPrntDescrOutpObject
{
}

public interface ItestRefPrntDescrOutp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestRefPrntDescrOutpObject? As_RefPrntDescrOutp { get; }
}

public interface ItestRefPrntDescrOutpObject
  // No Base because it's Class
{
  decimal Parent { get; }
}
