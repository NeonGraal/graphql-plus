//HintName: test_union-parent_Model.gen.cs
// Generated from {CurrentDirectory}union-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_parent;

public class testUnionPrnt
  : testPrntUnionPrnt
  , ItestUnionPrnt
{
}

public class testPrntUnionPrnt
  : GqlpModelBase
  , ItestPrntUnionPrnt
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}
