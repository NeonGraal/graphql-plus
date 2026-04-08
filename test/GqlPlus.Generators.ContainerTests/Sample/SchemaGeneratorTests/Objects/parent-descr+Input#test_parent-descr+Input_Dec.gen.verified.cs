//HintName: test_parent-descr+Input_Dec.gen.cs
// Generated from {CurrentDirectory}parent-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Input;

public interface ItestPrntDescrInp
  : ItestRefPrntDescrInp
{
  ItestPrntDescrInpObject? As_PrntDescrInp { get; }
}

public interface ItestPrntDescrInpObject
  : ItestRefPrntDescrInpObject
{
}

public interface ItestRefPrntDescrInp
  // No Base because it's Class
{
  string? AsString { get; }
  ItestRefPrntDescrInpObject? As_RefPrntDescrInp { get; }
}

public interface ItestRefPrntDescrInpObject
  // No Base because it's Class
{
  decimal Parent { get; }
}
