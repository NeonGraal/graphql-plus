//HintName: test_parent-field+Input_Intf.gen.cs
// Generated from {CurrentDirectory}parent-field+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Input;

public interface ItestPrntFieldInp
  : ItestRefPrntFieldInp
{
  ItestPrntFieldInpObject AsPrntFieldInp { get; }
}

public interface ItestPrntFieldInpObject
  : ItestRefPrntFieldInpObject
{
  decimal Field { get; }
}

public interface ItestRefPrntFieldInp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestRefPrntFieldInpObject AsRefPrntFieldInp { get; }
}

public interface ItestRefPrntFieldInpObject
{
  decimal Parent { get; }
}
