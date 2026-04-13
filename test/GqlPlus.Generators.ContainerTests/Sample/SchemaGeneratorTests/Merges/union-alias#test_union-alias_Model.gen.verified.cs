//HintName: test_union-alias_Model.gen.cs
// Generated from {CurrentDirectory}union-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_alias;

public class testUnionAlias
  : GqlpModelBase
  , ItestUnionAlias
{
  private object? _value;
  public bool HasA<T>() => _value is T;
  public T AsA<T>() => (T)_value!;
}
