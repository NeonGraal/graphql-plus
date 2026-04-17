//HintName: test_union-parent-dup_Model.gen.cs
// Generated from {CurrentDirectory}union-parent-dup.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_parent_dup;

public class testUnionPrntDup
  : testPrntUnionPrntDup
  , ItestUnionPrntDup
{
}

public class testPrntUnionPrntDup
  : GqlpModelBase
  , ItestPrntUnionPrntDup
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}
