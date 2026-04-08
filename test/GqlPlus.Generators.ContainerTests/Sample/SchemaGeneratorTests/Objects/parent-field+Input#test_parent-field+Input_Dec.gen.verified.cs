//HintName: test_parent-field+Input_Dec.gen.cs
// Generated from {CurrentDirectory}parent-field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Input;

public interface ItestPrntFieldInp
  : ItestRefPrntFieldInp
{
  ItestPrntFieldInpObject? As_PrntFieldInp { get; }
}

public interface ItestPrntFieldInpObject
  : ItestRefPrntFieldInpObject
{
  decimal Field { get; }
}

public interface ItestRefPrntFieldInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestRefPrntFieldInpObject? As_RefPrntFieldInp { get; }
}

public interface ItestRefPrntFieldInpObject
  // No Base because it's Class
{
  decimal Parent { get; }
}
