//HintName: test_union-same_Model.gen.cs
// Generated from {CurrentDirectory}union-same.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_same;

public class testUnionSame
  : GqlpModelBase
  , ItestUnionSame
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}
