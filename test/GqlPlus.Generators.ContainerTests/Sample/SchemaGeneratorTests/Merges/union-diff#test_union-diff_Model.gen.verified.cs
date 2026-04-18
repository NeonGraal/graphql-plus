//HintName: test_union-diff_Model.gen.cs
// Generated from {CurrentDirectory}union-diff.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_diff;

public class testUnionDiff
  : GqlpModelBase
  , ItestUnionDiff
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}
