//HintName: test_union-same-parent_Model.gen.cs
// Generated from {CurrentDirectory}union-same-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_same_parent;

public class testUnionSamePrnt
  : testPrntUnionSamePrnt
  , ItestUnionSamePrnt
{
}

public class testPrntUnionSamePrnt
  : GqlpModelBase
  , ItestPrntUnionSamePrnt
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}
